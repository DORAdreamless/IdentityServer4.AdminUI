<template>
  <section class="section">
    <!--面包屑导航-->
    <el-breadcrumb separator-class="el-icon-arrow-right" style="padding: 15px 0;">
      <el-breadcrumb-item :to="{ name: 'IdentityServerClient' }" style="cursor: pointer">返回</el-breadcrumb-item>
      <el-breadcrumb-item>{{ClientModel.ClientName}}</el-breadcrumb-item>
    </el-breadcrumb>
    <hr>
    <el-steps :active="active" finish-status="success">
      <el-step title="名称"></el-step>
      <el-step title="基本"></el-step>
      <el-step title="认证/注销"></el-step>
      <el-step title="令牌"></el-step>
      <el-step title="同意屏幕"></el-step>
      <el-step title="设备流程"></el-step>
      <el-step title="预览"></el-step>
    </el-steps>

    <el-form
      v-if="active==0"
      :model="ClientModel"
      ref="MainClientForm"
      :rules="ClientModelRules"
      label-width="180px"
    >
      
      <el-form-item label="应用类型" prop="ClientType">
        <el-select clearable v-model="ClientModel.ClientType" placeholder="请选择">
          <el-option
            v-for="item in ClientModel.ClientTypeList"
            :key="item.value"
            :label="item.label"
            :value="item.value"
          ></el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="应用ID：" prop="ClientId">
        <el-input v-model="ClientModel.ClientId" placeholder="请输入应用ID">
          <el-button slot="append" icon="el-icon-edit-outline" @click="onRandomClientId()"></el-button>
        </el-input>
      </el-form-item>
      <el-form-item label="应用名称：" prop="ClientName">
        <el-input v-model="ClientModel.ClientName" placeholder="请输入应用名称"></el-input>
      </el-form-item>
      <el-form-item label="应用描述：" prop="Description">
        <el-input v-model="ClientModel.Description" placeholder="请输入应用描述"></el-input>
      </el-form-item>
      <el-form-item label="应用地址：" prop="ClientUri">
        <el-input v-model="ClientModel.ClientUri" placeholder="https://"></el-input>
      </el-form-item>
      <el-form-item label="应用徽标：" prop="LogoUri">
        <!-- <el-input v-model="ClientModel.LogoUri" placeholder="https://"></el-input> -->
        <el-upload
          class="avatar-uploader"
          action="/api/common/upload"
          :show-file-list="false"
          :on-success="onAvatarSuccess"
          :before-upload="onBeforeAvatarUpload"
          with-credentials
          :headers="headers"
        >
          <img v-if="ClientModel.LogoUri" :src="ClientModel.LogoUri" class="avatar">
          <i v-else class="el-icon-plus avatar-uploader-icon"></i>
        </el-upload>
      </el-form-item>
    
      <el-form-item>
        <el-button type="primary" @click="onMainClientFormOk(false)">下一步</el-button>
        <el-button v-if="Id>0" type="success" icon="el-icon-check" @click="onMainClientFormOk(true)">完成</el-button>
      </el-form-item>
    </el-form>

    <!--基本-->
    <div v-if="active==1">
      <client-basic :client-model="ClientModel" :id="Id" @onSetup="onSetup"></client-basic>
    </div>

    <!--认证/注销-->
    <div v-if="active==2">
      <client-authoriztion :client-model="ClientModel" :id="Id" @onSetup="onSetup"></client-authoriztion>
    </div>
    <!--令牌-->
    <div v-if="active==3">
      <client-token :client-model="ClientModel" :id="Id" @onSetup="onSetup"></client-token>
    </div>
    <!--同意屏幕-->
    <div v-if="active==4">
      <client-consent :client-model="ClientModel" :id="Id" @onSetup="onSetup"></client-consent>
    </div>
    <!--设备流程-->
    <div v-if="active==5">
      <client-device-flow :client-model="ClientModel" :id="Id" @onSetup="onSetup"></client-device-flow>
    </div>
    <!--最终预览-->
    <div v-if="active==6"></div>
  </section>
</template>

<script>
import util from "../../../common/util";
import {
  CreateClient,
  UpdateNameClient,
  GetOneForEdit,
  UpdateBasicClient,
  UpdateAuthoriztionClient,
  UpdateTokenClient
} from "../../../api/identity_server/client";
import ClientToken from "./client_token";
import ClientConsent from "./client_consent";
import ClientDeviceFlow from "./client_device_flow";
import ClientAuthoriztion from "./client_authoriztion";
import ClientBasic from "./client_basic";
export default {
  name: "ClientManager",
  components: {
    ClientToken,
    ClientConsent,
    ClientDeviceFlow,
    ClientBasic,
    ClientAuthoriztion
  },
  data() {
    return {
      Id: 0, //主键
      active: 0,
      ClientModelRules: {
        ClientCategoryId: [
          { required: true, message: "请选择应用分类", trigger: "change" }
        ],
        ClientType: [
          { required: true, message: "请选择应用类型", trigger: "change" }
        ],
        ClientId: [
          { required: true, message: "请填写应用ID。", trigger: "change" },
          { max: 200, message: "ClientId最长200个字。", trigger: "change" }
        ],
        ProtocolType: [
          {
            required: true,
            message: "请填写ProtocolType。",
            trigger: "change"
          },
          { max: 200, message: "ProtocolType最长200个字。", trigger: "change" }
        ],
        ClientName: [
          { required: true, message: "请填写应用名称。", trigger: "change" },
          { max: 200, message: "应用名称最长200个字。", trigger: "change" }
        ],
        ClientUri: [
          { required: true, message: "请填写应用地址", trigger: "change" }
        ],
        LogoUri: [
          { required: true, message: "请上传应用图标", trigger: "change" }
        ]
      },
      ClientModel: {
        //name
        ClientCategoryId: "",
        ClientId: "",
        ClientName: "",
        Description: "",
        ClientType: 0,
        WantAuthentication: true,
        WantRealNameAuthentication: true,
        ClientUri: "",
        LogoUri: "",
        //basic
        RedirectUris: [],
        AllowedScopes: [],
        AllowedGrantTypes: [],
        Description: "",
        ProtocolType: "oidc",
        RequireClientSecret: false,
        RequirePkce: false,
        AllowPlainTextPkce: false,
        AllowOfflineAccess: false,
        AllowAccessTokensViaBrowser: false,
        //auth
        FrontChannelLogoutUri: "",
        FrontChannelLogoutSessionRequired: true,
        BackChannelLogoutUri: "",
        BackChannelLogoutSessionRequired: true,
        EnableLocalLogin: true,
        PostLogoutRedirectUris: [],
        IdentityProviderRestrictions: [],
        UserSsoLifetime: null
      },
      formModel: {
        RedirectUri: "",
        Scope: "",
        PostLogoutRedirectUri: "",
        IdentityProviderRestriction: ""
      },
      headers: {
        Authorization: util.getToken()
      }
    };
  },
  methods: {
    onAvatarSuccess: function(result, file, fileList) {
      if (result.success) {
        this.ClientModel.LogoUri = result.data;
      }
    },
    onBeforeAvatarUpload: function() {},
    onRandomClientId: function() {
      this.ClientModel.ClientId = util.uuid();
    },

    onMainClientFormOk: function(complete) {
      let that = this;

      that.$refs.MainClientForm.validate(function(valid) {
        if (!valid) {
          return;
        }
        let params = Object.assign({}, that.ClientModel);

        if (that.Id > 0) {
          UpdateNameClient(that.Id, params).then(function(result) {
            if (result.success) {
              if (!complete) {
                that.getClientById();
                that.active = 1;
              } else {
                that.$router.push({
                  name: "IdentityServerClient"
                });
              }
            }
          });
        } else {
          CreateClient(params).then(function(result) {
            if (result.success) {
              that.Id = result.data;
              that.$router.push({
                name: "IdentityServerClient"
              });
            }
          });
        }
      });
    },
    onSetup: function(active) {
      this.active = active;
    },
    getClientById: function() {
      let that = this;
      GetOneForEdit(that.Id).then(function(result) {
        if (result.success) {
          that.ClientModel = Object.assign(that.ClientModel, result.data);
        }
      });
    }
  },
  mounted: function() {
    this.Id = this.$router.history.current.params["Id"];
    this.getClientById();
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
.margin-top-20 {
  margin-top: 30px;
}
.avatar-uploader {
  width: 72px;
  height: 72px;
}

.avatar-uploader .el-upload {
  border: 1px dashed #d9d9d9 !important;
  border-radius: 6px;
  cursor: pointer;
  position: relative;
  overflow: hidden;
}
.avatar-uploader .el-upload:hover {
  border-color: #409eff;
}
.avatar-uploader-icon {
  font-size: 28px;
  color: #8c939d;
  width: 72px;
  height: 72px;
  line-height: 72px;
  text-align: center;
}
.avatar {
  width: 72px;
  height: 72px;
  display: block;
}
</style>

