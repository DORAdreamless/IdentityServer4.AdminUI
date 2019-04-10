<template>
  <section class="section">
    <!--面包屑导航-->
    <el-breadcrumb separator-class="el-icon-arrow-right" style="padding: 15px 0;">
      <el-breadcrumb-item :to="{ name: 'IdentityServerApiResource' }" style="cursor: pointer">返回</el-breadcrumb-item>
      <el-breadcrumb-item>{{ApiResourceModel.Name}}</el-breadcrumb-item>
    </el-breadcrumb>
    <hr>
    <el-form
      :model="ApiResourceModel"
      ref="ApiResourceForm"
      :rules="ApiResourceModelRules"
      label-width="120px"
    >
      <el-form-item label="Name：" prop="Name">
        <span slot="label">
          <label>名称：</label>
          <el-tooltip slot="append">
            <span slot="content">API 的唯一名称。 此值用于内省身份验证，并将添加到传出访问令牌的受众。</span>
            <i class="el-icon-info"></i>
          </el-tooltip>
        </span>
        <el-input v-model="ApiResourceModel.Name" placeholder="请输入名称"></el-input>
      </el-form-item>

      <el-form-item label="DisplayName：" prop="DisplayName">
        <span slot="label">
          <label>显示名称：</label>
          <el-tooltip slot="append">
            <span slot="content">该值可以用于例如 在同意屏幕上。</span>
            <i class="el-icon-info"></i>
          </el-tooltip>
        </span>
        <el-input v-model="ApiResourceModel.DisplayName" placeholder="请输入显示名称"></el-input>
      </el-form-item>

      <el-form-item label="Description：" prop="Description">
        <span slot="label">
          <label>描述：</label>
          <el-tooltip slot="append">
            <span slot="content">该值可以用于例如 在同意屏幕上。</span>
            <i class="el-icon-info"></i>
          </el-tooltip>
        </span>
        <el-input v-model="ApiResourceModel.Description" placeholder="请输入描述"></el-input>
      </el-form-item>
      <el-form-item label="Enabled：" prop="Enabled">
        <span slot="label">
          <label>启用：</label>
          <el-tooltip slot="append">
            <span slot="content">指示此资源是否已启用且可以请求。 默认为 true。</span>
            <i class="el-icon-info"></i>
          </el-tooltip>
        </span>
        <el-checkbox v-model="ApiResourceModel.Enabled"></el-checkbox>
      </el-form-item>
      <el-form-item>
        <span slot="label">
          <label>用户声明：</label>
          <el-tooltip slot="append">
            <span slot="content">应包含在访问令牌中的关联用户声明类型的列表。</span>
            <i class="el-icon-info"></i>
          </el-tooltip>
        </span>
        <el-input v-model="formModel.Type" placeholder="请输入声明">
          <el-button slot="append" icon="el-icon-plus" @click="onClaimOk()"></el-button>
        </el-input>
        <div>
          <el-tag
            closable
            style="margin-left:10px;"
            @close="onClaimDelete(claim,index)"
            v-for="(claim,index) in ApiResourceModel.UserClaims"
            :key="claim.Id"
          >{{claim.Type}}</el-tag>
        </div>
      </el-form-item>
      <el-form-item v-if="Id>0">
        <span slot="label">
          <label>作用域：</label>
          <el-tooltip slot="append">
            <span slot="content">API 必须至少有一个作用域。 每个作用域可以有不同的设置。</span>
            <i class="el-icon-info"></i>
          </el-tooltip>
        </span>
        <el-card>
          <div slot="header" class="clearfix text-right">
            <el-button icon="el-icon-plus" circle @click="onNewApiScope()"></el-button>
          </div>
          <el-table size="mini" stripe border :data="ApiScopes">
            <el-table-column prop="Name" label="名称"></el-table-column>
            <el-table-column prop="DisplayName" label="显示名称"></el-table-column>
            <el-table-column prop="Description" label="描述"></el-table-column>
            <el-table-column prop="Required" label="必须">
              <template slot-scope="scope">
                <el-tag v-if="scope.row.Required">是</el-tag>
                <el-tag v-if="!scope.row.Required">否</el-tag>
              </template>
            </el-table-column>
            <el-table-column prop="Emphasize" label="强调">
              <template slot-scope="scope">
                <el-tag v-if="scope.row.Emphasize">是</el-tag>
                <el-tag v-if="!scope.row.Emphasize">否</el-tag>
              </template>
            </el-table-column>
            <el-table-column prop="ShowInDiscoveryDocument" label="在文档中显示">
              <template slot-scope="scope">
                <el-tag v-if="scope.row.ShowInDiscoveryDocument">是</el-tag>
                <el-tag v-if="!scope.row.ShowInDiscoveryDocument">否</el-tag>
              </template>
            </el-table-column>
            <el-table-column label="操作">
              <template slot-scope="scope">
                <el-button
                  icon="el-icon-edit"
                  circle
                  size="sm"
                  @click="onEditApiScope(scope.row,scope.$index)"
                ></el-button>
                <el-button
                  icon="el-icon-delete"
                  circle
                  size="sm"
                  @click="onDeleteApiScope(scope.row,scope.$index)"
                ></el-button>
              </template>
            </el-table-column>
          </el-table>
        </el-card>
      </el-form-item>
      <el-form-item v-if="Id>0">
        <span slot="label">
          <label>密钥：</label>
          <el-tooltip slot="append">
            <span slot="content">API 密钥用于内省端点。 API 可以使用 API 名称和密钥进行内省验证。</span>
            <i class="el-icon-info"></i>
          </el-tooltip>
        </span>
        <el-card>
          <div slot="header" class="clearfix text-right">
            <el-button icon="el-icon-plus" circle @click="onNewApiSecret()"></el-button>
          </div>
          <el-table size="mini" stripe border :data="ApiSecrets">
            <el-table-column prop="Type" label="密钥类型"></el-table-column>
            <el-table-column prop="Value" label="密钥值"></el-table-column>
            <el-table-column prop="Description" label="描述"></el-table-column>
            <el-table-column prop="Expiration" label="过期时间">
              <template slot-scope="scope">{{scope.row.Expiration|datetime}}</template>
            </el-table-column>
            <el-table-column prop="Created" label="创建时间">
              <template slot-scope="scope">{{scope.row.Created|datetime}}</template>
            </el-table-column>
            <el-table-column label="操作">
              <template slot-scope="scope">
                <el-button
                  icon="el-icon-edit"
                  circle
                  size="sm"
                  @click="onEditApiSecret(scope.row,scope.$index)"
                ></el-button>
                <el-button
                  icon="el-icon-delete"
                  circle
                  size="sm"
                  @click="onDeleteApiSecret(scope.row,scope.$index)"
                ></el-button>
              </template>
            </el-table-column>
          </el-table>
        </el-card>
      </el-form-item>
      <el-form-item v-if="Id>0">
        <span slot="label">
          <label>属性：</label>
          <el-tooltip slot="append">
            <span slot="content">需要保留任何自定义 Api 资源特定值的字典。</span>
            <i class="el-icon-info"></i>
          </el-tooltip>
        </span>
        <el-card>
          <div slot="header" class="clearfix text-right">
            <el-button icon="el-icon-plus" circle @click="onNewApiProperty()"></el-button>
          </div>
          <el-table size="mini" stripe border :data="ApiProperties">
            <el-table-column prop="Key" label="键"></el-table-column>
            <el-table-column prop="Value" label="值"></el-table-column>
            <el-table-column label="操作">
              <template slot-scope="scope">
                <el-button
                  icon="el-icon-edit"
                  circle
                  size="sm"
                  @click="onEditApiProperty(scope.row,scope.$index)"
                ></el-button>
                <el-button
                  icon="el-icon-delete"
                  circle
                  size="sm"
                  @click="onDeleteApiProperty(scope.row,scope.$index)"
                ></el-button>
              </template>
            </el-table-column>
          </el-table>
        </el-card>
      </el-form-item>
      <el-form-item>
        <el-button type="primary" @click="onSubmit">确定</el-button>
      </el-form-item>
    </el-form>

    <!--api scope dialog-->
    <el-dialog title="Api作用域" :visible.sync="dialogApiScopeVisible">
      <ApiScope :ApiResourceId="Id" :ApiScopeId="ApiScopeId" @onApiScopeOk="onApiScopeOk()"></ApiScope>
    </el-dialog>
    <!--api secret dialog-->
    <el-dialog title="Api密钥" :visible.sync="dialogApiSecretVisible">
      <ApiSecret :ApiResourceId="Id" :ApiSecretId="ApiSecretId" @onApiSecretOk="onApiSecretOk()"></ApiSecret>
    </el-dialog>
    <!--api property dialog-->
    <el-dialog title="Api属性" :visible.sync="dialogApiPropertyVisible">
      <ApiProperty
        :ApiResourceId="Id"
        :ApiPropertyId="ApiPropertyId"
        @onApiPropertyOk="onApiPropertyOk()"
      ></ApiProperty>
    </el-dialog>
  </section>
</template>

<script>
import util from "../../../common/util";
import {
  CreateApiResource,
  GetOneForEdit,
  UpdateApiResource
} from "../../../api/identity_server/api_resource";
import ApiScope from "./api_scope";
import {
  GetApiScopes,
  DeleteApiScope
} from "../../../api/identity_server/api_scope";
import ApiSecret from "./api_secret";
import {
  GetApiSecrets,
  DeleteApiSecret
} from "../../../api/identity_server/api_secret";
import ApiProperty from "./api_property";
import {
  GetApiProperties,
  DeleteApiProperty
} from "../../../api/identity_server/api_property";
export default {
  name: "ApiResourceManager",
  components: { ApiScope, ApiSecret, ApiProperty },
  data() {
    return {
      Id: null, //主键
      ApiResourceModelRules: {
        Name: [
          { required: true, message: "请填写名称。", trigger: "change" },
          { max: 200, message: "名称最长200个字。", trigger: "change" }
        ],
        DisplayName: [
          { max: 200, message: "显示名称最长200个字。", trigger: "change" }
        ],
        Description: [
          { max: 1000, message: "描述最长1000个字。", trigger: "change" }
        ]
      },
      ApiResourceModel: {
        Enabled: true,
        Name: "",
        DisplayName: "",
        Description: "",
        UserClaims: []
      },
      formModel: {
        Type: ""
      },

      //api scopes
      dialogApiScopeVisible: false,
      ApiScopes: [],
      ApiScopeId: null,

      //api secrets
      dialogApiSecretVisible: false,
      ApiSecrets: [],
      ApiSecretId: null,

      //api property
      ApiProperties: [],
      dialogApiPropertyVisible: false,
      ApiPropertyId: null
    };
  },
  methods: {
    //claim
    onClaimOk: function() {
      if (util.isNullOrEmpty(this.formModel.Type)) {
        return;
      }
      this.ApiResourceModel.UserClaims.push({
        Id: Math.random(),
        Type: this.formModel.Type
      });
      this.formModel.Type = "";
    },
    onClaimDelete: function(claim, index) {
      this.ApiResourceModel.UserClaims.splice(index, 1);
    },
    //api scope
    onNewApiScope: function() {
      this.dialogApiScopeVisible = true;
    },
    onEditApiScope: function(scope, index) {
      this.ApiScopeId = scope.Id;
      this.dialogApiScopeVisible = true;
    },
    onDeleteApiScope: function(scope, index) {
      this.$confirm(`此操作将永久删除${scope.Name}, 是否继续?`, "提示", {
        confirmButtonText: "确定",
        cancelButtonText: "取消",
        type: "warning"
      }).then(() => {
        DeleteApiScope(scope.Id).then(result => {
          if (result.success) {
            this.$notify.success("操作成功。");
            this.getApiScopes();
          }
        });
      });
    },
    onApiScopeOk: function() {
      this.dialogApiScopeVisible = false;
      this.getApiScopes();
    },
    getApiScopes: function() {
      if (this.Id > 0) {
        GetApiScopes(this.Id).then(result => {
          if (result.success) {
            this.ApiScopes = result.data || [];
          }
        });
      }
    },
    //api secrets
    onNewApiSecret: function() {
      this.dialogApiSecretVisible = true;
    },
    onEditApiSecret: function(secret, index) {
      this.ApiSecretId = secret.Id;
      this.dialogApiSecretVisible = true;
    },
    onDeleteApiSecret: function(secret, index) {
      this.$confirm(`此操作将永久删除${secret.Value}, 是否继续?`, "提示", {
        confirmButtonText: "确定",
        cancelButtonText: "取消",
        type: "warning"
      }).then(() => {
        DeleteApiSecret(secret.Id).then(result => {
          if (result.success) {
            this.$notify.success("操作成功。");
            this.getApiSecrets();
          }
        });
      });
    },
    onApiSecretOk: function() {
      this.dialogApiSecretVisible = false;
      this.getApiSecrets();
    },
    getApiSecrets: function() {
      if (this.Id > 0) {
        GetApiSecrets(this.Id).then(result => {
          if (result.success) {
            this.ApiSecrets = result.data || [];
          }
        });
      }
    },
    //api property
    onNewApiProperty: function() {
      this.dialogApiPropertyVisible = true;
    },
    onEditApiProperty: function(property, index) {
      this.ApiPropertyId = property.Id;
      this.dialogApiPropertyVisible = true;
    },
    onDeleteApiProperty: function(property, index) {
      this.$confirm(`此操作将永久删除${property.Key}, 是否继续?`, "提示", {
        confirmButtonText: "确定",
        cancelButtonText: "取消",
        type: "warning"
      }).then(() => {
        DeleteApiProperty(property.Id).then(result => {
          if (result.success) {
            this.$notify.success("操作成功。");
            this.getApiProperties();
          }
        });
      });
    },
    onApiPropertyOk: function() {
      this.dialogApiPropertyVisible = false;
      this.getApiProperties();
    },
    getApiProperties: function() {
      if (this.Id > 0) {
        GetApiProperties(this.Id).then(result => {
          if (result.success) {
            this.ApiProperties = result.data || [];
          }
        });
      }
    },
    onSubmit: function() {
      let that = this;
      that.$refs.ApiResourceForm.validate(function(valid) {
        if (!valid) {
          return;
        }
        let params = Object.assign({}, that.ApiResourceModel);

        if (that.Id) {
          UpdateApiResource(that.Id, params).then(function(result) {
            if (result.success) {
              that.$router.push({
                name: "IdentityServerApiResource"
              });
            }
          });
        } else {
          CreateApiResource(params).then(function(result) {
            if (result.success) {
              that.$router.push({
                name: "IdentityServerApiResource"
              });
            }
          });
        }
      });
    },
    getApiResourceById: function() {
      let that = this;
      if (!that.Id) {
        return;
      }
      GetOneForEdit(that.Id).then(function(result) {
        if (result.success) {
          that.ApiResourceModel = Object.assign(
            that.ApiResourceModel,
            result.data
          );
        }
      });
    }
  },
  mounted: function() {
    this.Id = this.$router.history.current.params["Id"];
    this.getApiResourceById();
    this.getApiScopes();
    this.getApiSecrets();
    this.getApiProperties();
  }
};
</script>

<style scoped>
.section {
  background: #fff;
  padding: 10px 30px 5px;
}
.el-main {
  margin-left: 220px;
  /* min-height: 400px; */
  position: initial;
}
</style>

