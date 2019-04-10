<template>
  <section class="section">
    <!--面包屑导航-->
    <el-breadcrumb separator-class="el-icon-arrow-right" style="padding: 15px 0;">
      <el-breadcrumb-item
        :to="{ name: 'IdentityServerIdentityResource' }"
        style="cursor: pointer"
      >返回</el-breadcrumb-item>
      <el-breadcrumb-item>{{IdentityResourceModel.Name}}</el-breadcrumb-item>
    </el-breadcrumb>

    <hr>
    <el-form
      :model="IdentityResourceModel"
      ref="IdentityResourceForm"
      :rules="IdentityResourceModelRules"
      label-width="180px"
    >
      <el-form-item label="Name：" prop="Name">
        <span slot="label">
          <label>名称：</label>
          <el-tooltip slot="append">
            <span slot="content">身份资源的唯一名称。 这是客户端将用于授权请求中的作用域参数的值。</span>
            <i class="el-icon-info"></i>
          </el-tooltip>
        </span>
        <el-input v-model="IdentityResourceModel.Name" placeholder="请输入名称"></el-input>
      </el-form-item>

      <el-form-item label="DisplayName：" prop="DisplayName">
        <span slot="label">
          <label>显示名称：</label>
          <el-tooltip slot="append">
            <span slot="content">该值将用于例如 在同意屏幕上。</span>
            <i class="el-icon-info"></i>
          </el-tooltip>
        </span>
        <el-input v-model="IdentityResourceModel.DisplayName" placeholder="请输入显示名称"></el-input>
      </el-form-item>

      <el-form-item label="Description：" prop="Description">
        <span slot="label">
          <label>描述：</label>
          <el-tooltip slot="append">
            <span slot="content">该值将用于例如 在同意屏幕上。</span>
            <i class="el-icon-info"></i>
          </el-tooltip>
        </span>

        <el-input v-model="IdentityResourceModel.Description" placeholder="请输入描述"></el-input>
      </el-form-item>

      <el-form-item prop="Enabled">
        <span slot="label">
          <label>启用：</label>
          <el-tooltip slot="append">
            <span slot="content">指示此资源是否已启用且可以请求。 默认为 true。</span>
            <i class="el-icon-info"></i>
          </el-tooltip>
        </span>
        <el-checkbox v-model="IdentityResourceModel.Enabled"></el-checkbox>
      </el-form-item>

      <el-form-item label="Required：" prop="Required">
        <span slot="label">
          <label>必须：</label>
          <el-tooltip slot="append">
            <span slot="content">指定用户是否可以在同意屏幕上取消选择作用域（如果同意屏幕要实现此类功能）。 默认为 false。</span>
            <i class="el-icon-info"></i>
          </el-tooltip>
        </span>
        <el-checkbox v-model="IdentityResourceModel.Required"></el-checkbox>
      </el-form-item>

      <el-form-item label="Emphasize：" prop="Emphasize">
        <span slot="label">
          <label>强调：</label>
          <el-tooltip slot="append">
            <span slot="content">指定同意屏幕是否会强调此作用域（如果同意屏幕要实现此类功能）。 将此设置用于敏感或重要作用域。 默认为 false。</span>
            <i class="el-icon-info"></i>
          </el-tooltip>
        </span>

        <el-checkbox v-model="IdentityResourceModel.Emphasize"></el-checkbox>
      </el-form-item>

      <el-form-item label="ShowInDiscoveryDocument：" prop="ShowInDiscoveryDocument">
        <span slot="label">
          <label>在发现文档中显示：</label>
          <el-tooltip slot="append">
            <span slot="content">指定此作用域是否显示在发现文档中。 默认为 true。</span>
            <i class="el-icon-info"></i>
          </el-tooltip>
        </span>
        <el-checkbox v-model="IdentityResourceModel.ShowInDiscoveryDocument"></el-checkbox>
      </el-form-item>

      <!---->
      <el-form-item>
        <span slot="label">
          <label>声明：</label>
          <el-tooltip slot="append">
            <span slot="content">应包含在身份令牌中的关联用户声明类型的列表。</span>
            <i class="el-icon-info"></i>
          </el-tooltip>
        </span>
        <el-input v-model="CommonFormModel.Type">
          <el-button icon="el-icon-plus" slot="append" @click="onNewClaim()"></el-button>
        </el-input>

        <div>
          <el-tag
            closable
            style="margin-right:10px;"
            @close="onDeleteClaim(claim,index)"
            v-for="(claim,index) in IdentityResourceModel.IdentityClaims"
            :key="claim"
          >{{claim}}</el-tag>
        </div>
      </el-form-item>
      <el-form-item v-if="Id>0">
        <span slot="label">
          <label>属性：</label>
          <el-tooltip slot="append">
            <span slot="content">需要保留任何自定义身份资源特定值的字典。</span>
            <i class="el-icon-info"></i>
          </el-tooltip>
        </span>
        <el-card>
          <div slot="header" class="clearfix text-right">
            <el-button icon="el-icon-plus" circle @click="onNewProperty()"></el-button>
          </div>
          <el-table size="mini" stripe border :data="IdentityProperties">
            <el-table-column prop="Key" label="键"></el-table-column>
            <el-table-column prop="Value" label="值"></el-table-column>
            <el-table-column label="操作">
              <template slot-scope="scope">
                <el-button
                  icon="el-icon-delete"
                  circle
                  size="sm"
                  @click="onDeleteProperty(scope.row,scope.$index)"
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
    <!-- <el-dialog title="身份证资源声明" :visible.sync="dialogClaimVisible">
      <identity-resource-claim :IdentityResourceId="Id" @onClaimOk="onClaimOk"></identity-resource-claim>
    </el-dialog>-->
    <el-dialog title="身份资源属性" :visible.sync="dialogPropertyVisible">
      <IdentityResourceProperty :IdentityResourceId="Id" @onPropertyOk="onPropertyOk"></IdentityResourceProperty>
    </el-dialog>
  </section>
</template>

<script>
import util from "../../../common/util";
import {
  CreateIdentityResource,
  GetOneForEdit,
  UpdateIdentityResource
} from "../../../api/identity_server/identity_resource";
// import IdentityResourceClaim from "./resource_claim";
// import {
//   GetIdentityClaims,
//   DeleteIdentityClaim
// } from "../../../../api/identity_server/identity_resource_claim";
import IdentityResourceProperty from "./resource_property";
import {
  GetIdentityProperties,
  DeleteIdentityProperty
} from "../../../api/identity_server/identity_resource_property";
export default {
  name: "IdentityResourceManager",
  components: { IdentityResourceProperty },
  data() {
    return {
      Id: null, //主键
      IdentityResourceModelRules: {
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
      IdentityResourceModel: {
        Enabled: true,
        Name: "",
        DisplayName: "",
        Description: "",
        Required: false,
        Emphasize: false,
        ShowInDiscoveryDocument: true,
        IdentityClaims: []
      },

      //Property
      IdentityProperties: [],
      dialogPropertyVisible: false,

      CommonFormModel: {
        Type: ""
      }
    };
  },
  methods: {
    onSubmit: function() {
      let that = this;
      that.$refs.IdentityResourceForm.validate(function(valid) {
        if (!valid) {
          return;
        }
        let params = Object.assign({}, that.IdentityResourceModel);

        if (that.Id) {
          UpdateIdentityResource(that.Id, params).then(function(result) {
            if (result.success) {
              that.$router.push({
                name: "IdentityServerIdentityResource"
              });
            }
          });
        } else {
          CreateIdentityResource(params).then(function(result) {
            if (result.success) {
              that.$router.push({
                name: "IdentityServerIdentityResource"
              });
            }
          });
        }
      });
    },
    getIdentityResourceById: function() {
      let that = this;
      if (!that.Id) {
        return;
      }
      GetOneForEdit(that.Id).then(function(result) {
        if (result.success) {
          that.IdentityResourceModel = Object.assign(
            that.IdentityResourceModel,
            result.data
          );
        }
      });
    },
    //claims
    onNewClaim: function() {
      if (util.isNullOrEmpty(this.CommonFormModel.Type)) {
        return;
      }
      if (
        util.getFromArray(
          this.CommonFormModel.Type.toLowerCase(),
          this.IdentityResourceModel.IdentityClaims
        )
      ) {
        this.$notify.warning(`已经存在${this.CommonFormModel.Type}了。`);
        return;
      }
      this.IdentityResourceModel.IdentityClaims.push(
        this.CommonFormModel.Type.toLowerCase()
      );
      this.CommonFormModel.Type = "";
    },
    onDeleteClaim: function(claim, index) {
      this.$confirm(`此操作将永久删除${claim}, 是否继续?`, "提示", {
        confirmButtonText: "确定",
        cancelButtonText: "取消",
        type: "warning"
      }).then(() => {
        this.IdentityResourceModel.IdentityClaims.splice(index, 1);
        this.$notify.success("操作成功。");
      });
    },
    //property
    onNewProperty: function() {
      this.dialogPropertyVisible = true;
    },
    onDeleteProperty: function(property, index) {
      this.$confirm(`此操作将永久删除${property.Key}, 是否继续?`, "提示", {
        confirmButtonText: "确定",
        cancelButtonText: "取消",
        type: "warning"
      }).then(() => {
        DeleteIdentityProperty(property.Id).then(result => {
          if (result.success) {
            this.$notify.success("操作成功。");
            this.getIdentityProperties();
          }
        });
      });
    },
    onPropertyOk: function() {
      this.dialogPropertyVisible = false;
      this.getIdentityProperties();
    },
    getIdentityProperties: function() {
      if (this.Id > 0) {
        GetIdentityProperties(this.Id).then(result => {
          if (result.success) {
            this.IdentityProperties = result.data || [];
          }
        });
      }
    }
  },
  mounted: function() {
    this.Id = this.$router.history.current.params["Id"];
    this.getIdentityResourceById();
    this.getIdentityProperties();
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

