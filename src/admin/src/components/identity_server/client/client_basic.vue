<template>
  <section>
    <el-form :model="ClientModel" ref="ClientForm" :rules="ClientModelRules" label-width="200px">
      <el-form-item label="启用：" prop="Enabled">
        <el-checkbox v-model="ClientModel.Enabled"></el-checkbox>
      </el-form-item>
      <el-form-item label="描述：" prop="Description">
        <el-input v-model="ClientModel.Description" placeholder="请输入描述"></el-input>
      </el-form-item>

      <el-form-item label="协议类型：" prop="ProtocolType">
        <el-select v-model="ClientModel.ProtocolType">
          <el-option
            v-for="item in ClientModel.ProtocolTypes"
            :key="item.value"
            :value="item.value"
            :label="item.label"
          >{{item.label}}</el-option>
        </el-select>
      </el-form-item>

      <el-form-item label="需要客户端密钥：" prop="RequireClientSecret">
        <el-checkbox v-model="ClientModel.RequireClientSecret"></el-checkbox>
      </el-form-item>

      <el-form-item label="需要Pkce：" prop="RequirePkce">
        <el-checkbox v-model="ClientModel.RequirePkce"></el-checkbox>
      </el-form-item>
      <el-form-item label="允许纯文本Pkce：" prop="AllowPlainTextPkce">
        <el-checkbox v-model="ClientModel.AllowPlainTextPkce"></el-checkbox>
      </el-form-item>
      <el-form-item label="允许离线访问：" prop="AllowOfflineAccess">
        <el-checkbox v-model="ClientModel.AllowOfflineAccess"></el-checkbox>
      </el-form-item>
      <el-form-item label="允许通过浏览器访问令牌：" prop="AllowAccessTokensViaBrowser">
        <el-checkbox v-model="ClientModel.AllowAccessTokensViaBrowser"></el-checkbox>
      </el-form-item>
      <el-form-item label="允许的作用域：" prop>
        <el-input v-model="formModel.Scope">
          <el-button @click="onAllowedScopePlus()" slot="append" icon="el-icon-plus"></el-button>
        </el-input>
        <el-tag
          style="margin-left:5px;"
          :key="scope"
          v-for="(scope,index) in ClientModel.AllowedScopes"
          closable
          @close="onAllowedScopeClose(scope,index)"
          :disable-transitions="false"
        >{{scope}}</el-tag>
        <!-- <hr>
        <el-tag
          style="margin-left:5px;"
          :key="tag+'aa'"
          v-for="tag in ['openid','profile','email','phone','roles']"
        >{{tag}}</el-tag>-->
      </el-form-item>
      <el-form-item label="重定向Uri：" prop="RedirectUris">
        <el-input v-model="formModel.RedirectUri">
          <el-button slot="append" icon="el-icon-plus" @click="onRedirectUriPlus()"></el-button>
        </el-input>
        <el-tag
          style="margin-left:5px;"
          :key="redirectUri"
          v-for="(redirectUri,index) in ClientModel.RedirectUris"
          closable
          @close="onRedirectUriClose(redirectUri,index)"
          :disable-transitions="false"
        >{{redirectUri}}</el-tag>
      </el-form-item>
      <el-form-item label="允许的授权类型：">
        <el-select v-model="ClientModel.AllowedGrantTypes" multiple style="width:100%;">
          <el-option
            v-for="item in ClientModel.AllowedGrantTypesItems"
            :key="item.value"
            :value="item.value"
            :label="item.label"
          >{{item.label}}</el-option>
        </el-select>
      </el-form-item>

      <el-form-item label="客户端密钥：">
        <el-card size="mini">
          <div slot="header" class="clearfix text-right">
            <el-button icon="el-icon-plus" circle @click="onNewSecret()"></el-button>
          </div>
          <el-table stripe size="mini " border :data="ClientSecrets">
            <el-table-column prop="Type" label="密钥类型"></el-table-column>
            <el-table-column prop="Value" label="密钥值"></el-table-column>
            <el-table-column prop="Description" label="描述"></el-table-column>
            <el-table-column prop="Expiration" label="过期时间">
              <template slot-scope="scope">{{scope.row.Expiration|datetime}}</template>
            </el-table-column>
            <el-table-column prop="Created" label="创建时间">
              <template slot-scope="scope">{{scope.row.Created|datetime}}</template>
            </el-table-column>
            <el-table-column prop="Id" label="操作">
              <template slot-scope="scope">
                <el-button
                  icon="el-icon-delete"
                  circle
                  @click="onDeleteSecret(scope.row,scope.$index)"
                ></el-button>
              </template>
            </el-table-column>
          </el-table>
        </el-card>
      </el-form-item>
      <el-form-item label="客户端属性：">
        <el-card size="mini">
          <div slot="header" class="clearfix text-right">
            <el-button icon="el-icon-plus" circle @click="onNewProperty()"></el-button>
          </div>
          <el-table stripe size="mini " border :data="ClientProperties">
            <el-table-column prop="Key" label="属性名"></el-table-column>
            <el-table-column prop="Value" label="属性值"></el-table-column>

            <el-table-column prop="Id" label="操作">
              <template slot-scope="scope">
                <el-button
                  icon="el-icon-delete"
                  circle
                  @click="onDeleteProperty(scope.row,scope.$index)"
                ></el-button>
              </template>
            </el-table-column>
          </el-table>
        </el-card>
      </el-form-item>
      <el-form-item>
        <el-button type="primary" @click="onPrevSetup()">上一步</el-button>
        <el-button type="primary" @click="onNextSetup()">下一步</el-button>
      </el-form-item>
    </el-form>

    <el-dialog title="创建客户端密钥" :visible.sync="dialogSecretVisible">
      <client-secret :client-id="Id" @onSecretOk="onSecretOk()"></client-secret>
    </el-dialog>

    <el-dialog title="创建客户端密钥" :visible.sync="dialogPropertyVisible">
      <client-property :client-id="Id" @onPropertyOk="onPropertyOk()"></client-property>
    </el-dialog>
  </section>
</template>

<script>
import util from "../../../common/util";
import {
  GetOneForEdit,
  UpdateClientBasic
} from "../../../api/identity_server/client";
import ClientSecret from "./client_secret";
import {
  GetClientSecrets,
  DeleteClientSecret
} from "../../../api/identity_server/client_secret";
import ClientProperty from "./client_property";
import {
  GetClientProperties,
  DeleteClientProperty
} from "../../../api/identity_server/client_property";
export default {
  name: "ClientBasic",
  components: { ClientSecret, ClientProperty },
  data() {
    return {
      Id: null,
      ClientModel: {
        RedirectUris: [],
        AllowedScopes: [],
        AllowedGrantTypes: [],
        Description: "",
        ProtocolType: "oidc",
        RequireClientSecret: false,
        RequirePkce: false,
        AllowPlainTextPkce: false,
        AllowOfflineAccess: false,
        AllowAccessTokensViaBrowser: false
      },
      ClientModelRules: {},
      formModel: {
        RedirectUri: "",
        Scope: ""
      },
      dialogSecretVisible: false,
      ClientSecrets: [],
      dialogPropertyVisible: false,
      ClientProperties: []
    };
  },
  methods: {
    // redirecturi add
    onRedirectUriPlus: function() {
      if (util.isNullOrEmpty(this.formModel.RedirectUri)) {
        return;
      }
      if (
        util.getFromArray(
          this.formModel.RedirectUri.toLowerCase(),
          this.ClientModel.RedirectUris
        )
      ) {
        this.$notify.warn("重定向URI已经存在！");
        return;
      }
      this.ClientModel.RedirectUris.push(
        this.formModel.RedirectUri.toLowerCase()
      );
      this.formModel.RedirectUri = "";
    },
    // redirecturi delete
    onRedirectUriClose: function(redirectUri, index) {
      this.ClientModel.RedirectUris.splice(index, 1);
    },
    //scope add
    onAllowedScopePlus: function() {
      if (util.isNullOrEmpty(this.formModel.Scope)) {
        return;
      }
      if (
        util.getFromArray(
          this.formModel.Scope.toLowerCase(),
          this.ClientModel.AllowedScopes
        )
      ) {
        this.$notify.warn("重定向URI已经存在！");
        return;
      }
      this.ClientModel.AllowedScopes.push(this.formModel.Scope.toLowerCase());
      this.formModel.Scope = "";
    },
    //scope delete
    onAllowedScopeClose: function(scope, index) {
      this.ClientModel.AllowedScopes.splice(index, 1);
    },
    //
    onPrevSetup: function() {
      this.$emit("onSetup", 0);
    },
    onNextSetup: function() {
      let that = this;

      that.$refs.ClientForm.validate(function(valid) {
        if (!valid) {
          return;
        }
        let params = Object.assign({}, that.ClientModel);

        UpdateClientBasic(that.Id, params).then(function(result) {
          if (result.success) {
            that.$emit("onSetup", 2);
          }
        });
      });
    },
    getClientById: function() {
      let that = this;
      if (!that.Id) {
        return;
      }
      GetOneForEdit(that.Id).then(function(result) {
        if (result.success) {
          that.ClientModel = Object.assign(that.ClientModel, result.data);
        }
      });
    },
    //Secret
    onNewSecret: function() {
      this.dialogSecretVisible = true;
    },
    onSecretOk: function() {
      this.dialogSecretVisible = false;
      this.getClientSecrets();
    },
    onDeleteSecret: function(secret, index) {
      this.$confirm(`此操作将永久删除${secret.Value}, 是否继续?`, "提示", {
        confirmButtonText: "确定",
        cancelButtonText: "取消",
        type: "warning"
      }).then(() => {
        DeleteClientSecret(secret.Id).then(result => {
          if (result.success) {
            this.$notify.success("操作成功。");
            this.getClientSecrets();
          }
        });
      });
    },
    getClientSecrets: function() {
      GetClientSecrets(this.Id).then(result => {
        if (result.success) {
          this.ClientSecrets = result.data || [];
        }
      });
    },
    //Property
    onNewProperty: function() {
      this.dialogPropertyVisible = true;
    },
    onDeleteProperty: function(property, index) {
      this.$confirm(`此操作将永久删除${property.Key}, 是否继续?`, "提示", {
        confirmButtonText: "确定",
        cancelButtonText: "取消",
        type: "warning"
      }).then(() => {
        DeleteClientProperty(property.Id).then(result => {
          if (result.success) {
            this.$notify.success("操作成功。");
            this.getClientProperties();
          }
        });
      });
    },
    onPropertyOk: function() {
      this.dialogPropertyVisible = false;
      this.getClientProperties();
    },
    getClientProperties: function() {
      GetClientProperties(this.Id).then(result => {
        if (result.success) {
          this.ClientProperties = result.data || [];
        }
      });
    }
  },
  mounted() {
    this.Id = parseInt(this.$router.history.current.params["Id"]);
    this.getClientById();
    this.getClientSecrets();
    this.getClientProperties();
  }
};
</script>

<style>
</style>
