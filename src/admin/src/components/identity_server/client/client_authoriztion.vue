<template>
  <el-form
    :model="ClientModel"
    ref="ClientAuthoriztionForm"
    :rules="ClientModelRules"
    label-width="200px"
  >
    <el-form-item prop="FrontChannelLogoutUri">
      <span slot="label">
        <label>前端通道注销 Uri ：</label>
        <el-tooltip slot="append">
          <span slot="content">指定客户端的注销 URI，以用于基于 HTTP 的前端通道注销。 有关详细信息，请参阅 OIDC Front-Channel 规范。</span>
          <i class="el-icon-info"></i>
        </el-tooltip>
      </span>
      <el-input v-model="ClientModel.FrontChannelLogoutUri"></el-input>
    </el-form-item>
    <el-form-item prop="FrontChannelLogoutSessionRequired">
      <span slot="label">
        <label>需要前端通道注销会话 ：</label>
        <el-tooltip slot="append">
          <span slot="content">指定是否应将用户的会话标识发送到 FrontChannelLogoutUri。 默认为 true。</span>
          <i class="el-icon-info"></i>
        </el-tooltip>
      </span>
      <el-checkbox v-model="ClientModel.FrontChannelLogoutSessionRequired"></el-checkbox>
    </el-form-item>
    <el-form-item prop="BackChannelLogoutUri">
      <span slot="label">
        <label>后端通道退出 Uri ：</label>
        <el-tooltip slot="append">
          <span slot="content">指定客户端的注销 URI，以用于基于 HTTP 的后端通道注销。 有关详细信息，请参阅 OIDC Back-Channel 规范。</span>
          <i class="el-icon-info"></i>
        </el-tooltip>
      </span>
      <el-input v-model="ClientModel.BackChannelLogoutUri"></el-input>
    </el-form-item>
    <el-form-item prop="BackChannelLogoutSessionRequired">
      <span slot="label">
        <label>需要后端通道注销会话 ：</label>
        <el-tooltip slot="append">
          <span slot="content">指定是否应在请求中将用户的会话 ID 发送到 BackChannelLogoutUri。</span>
          <i class="el-icon-info"></i>
        </el-tooltip>
      </span>
      <el-checkbox v-model="ClientModel.BackChannelLogoutSessionRequired"></el-checkbox>
    </el-form-item>
    <el-form-item prop="EnableLocalLogin">
      <span slot="label">
        <label>启用本地登录 ：</label>
        <el-tooltip slot="append">
          <span slot="content">指定此客户端是否可以使用本地帐户或仅外部 IdPs。 默认为 true。</span>
          <i class="el-icon-info"></i>
        </el-tooltip>
      </span>
      <el-checkbox v-model="ClientModel.EnableLocalLogin"></el-checkbox>
    </el-form-item>
    <el-form-item prop="RedirectUris">
      <span slot="label">
        <label>注销重定向 Uri：</label>
        <el-tooltip slot="append">
          <span slot="content">指定在注销后重定向到允许的 URI。</span>
          <i class="el-icon-info"></i>
        </el-tooltip>
      </span>
      <el-input v-model="formModel.PostLogoutRedirectUri">
        <el-button slot="append" icon="el-icon-plus" @click="onPostLogoutRedirectUriPlus()"></el-button>
      </el-input>
      <el-tag
        style="margin-left:5px;"
        :key="redirectUri"
        v-for="(redirectUri,index) in ClientModel.PostLogoutRedirectUris"
        closable
        @close="onPostLogoutRedirectUriClose(redirectUri,index)"
        :disable-transitions="false"
      >{{redirectUri}}</el-tag>
    </el-form-item>
    <el-form-item prop="IdentityProviderRestrictions">
      <span slot="label">
        <label>身份提供程序限制：</label>
        <el-tooltip slot="append">
          <span slot="content">指定可以与此客户端一起使用的外部 IdPs（如果列表为空，则允许所有 IdPs）。 默认为空。</span>
          <i class="el-icon-info"></i>
        </el-tooltip>
      </span>
      <el-input v-model="formModel.IdentityProviderRestriction">
        <el-button slot="append" icon="el-icon-plus" @click="onIdentityProviderRestrictionPlus()"></el-button>
      </el-input>
      <el-tag
        style="margin-left:5px;"
        :key="identityProviderRestriction"
        v-for="(identityProviderRestriction,index) in ClientModel.IdentityProviderRestrictions"
        closable
        @close="onIdentityProviderRestrictionClose(identityProviderRestriction,index)"
        :disable-transitions="false"
      >{{identityProviderRestriction}}</el-tag>
    </el-form-item>
    <el-form-item prop="UserSsoLifetime">
      <span slot="label">
        <label>用户 SSO 生命周期 ：</label>
        <el-tooltip slot="append">
          <span slot="content">自上次用户进行身份验证以来的最长持续时间（以秒为单位）。 默认为 null。</span>
          <i class="el-icon-info"></i>
        </el-tooltip>
      </span>
      <el-input v-model="ClientModel.UserSsoLifetime"></el-input>
    </el-form-item>
    <el-form-item>
      <el-button type="primary" @click="onPrevSetup()">上一步</el-button>
      <el-button type="primary" @click="onNextOk()">下一步</el-button>
    </el-form-item>
  </el-form>
</template>

<script>
import util from "../../../common/util";
import {
  GetOneForEdit,
  UpdateClientAuthorization
} from "../../../api/identity_server/client";
export default {
  name: "ClientAuthoriztion",
  data() {
    return {
      Id: null,
      ClientModel: {
        FrontChannelLogoutUri: "",
        FrontChannelLogoutSessionRequired: true,
        BackChannelLogoutUri: "",
        BackChannelLogoutSessionRequired: true,
        EnableLocalLogin: true,
        PostLogoutRedirectUris: [],
        IdentityProviderRestrictions: [],
        UserSsoLifetime: null
      },
     
      ClientModelRules: {},
      formModel: {
        PostLogoutRedirectUri: "",
        IdentityProviderRestriction: ""
      }
    };
  },
  methods: {
    onPostLogoutRedirectUriPlus: function() {
      if (util.isNullOrEmpty(this.formModel.PostLogoutRedirectUri)) {
        return;
      }
      if (
        util.getFromArray(
          this.formModel.PostLogoutRedirectUri.toLowerCase(),
          this.ClientModel.PostLogoutRedirectUris
        )
      ) {
        this.$notify.warn("重定向URI已经存在！");
        return;
      }
      this.ClientModel.PostLogoutRedirectUris.push(
        this.formModel.PostLogoutRedirectUri.toLowerCase()
      );
      this.formModel.PostLogoutRedirectUri = "";
    },
    onPostLogoutRedirectUriClose: function(item, index) {
      this.ClientModel.PostLogoutRedirectUris.splice(index, 1);
    },
    onIdentityProviderRestrictionPlus: function() {
      if (util.isNullOrEmpty(this.formModel.IdentityProviderRestriction)) {
        return;
      }
      if (
        util.getFromArray(
          this.formModel.IdentityProviderRestriction.toLowerCase(),
          this.ClientModel.IdentityProviderRestrictions
        )
      ) {
        this.$notify.warn("重定向URI已经存在！");
        return;
      }
      this.ClientModel.IdentityProviderRestrictions.push(
        this.formModel.IdentityProviderRestriction.toLowerCase()
      );
      this.formModel.IdentityProviderRestriction = "";
    },
    onIdentityProviderRestrictionClose: function(item, index) {
      this.ClientModel.IdentityProviderRestrictions.splice(index, 1);
    },
    onPrevSetup: function() {
      this.$emit("onSetup", 1);
    },
    onNextOk: function() {
      var that = this;
      that.$refs.ClientAuthoriztionForm.validate(function(valid) {
        if (!valid) {
          return;
        }
        let params = Object.assign({}, that.ClientModel);

        UpdateClientAuthorization(that.Id, params).then(function(result) {
          if (result.success) {
            that.$emit("onSetup", 3);
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
    }
  },
  mounted() {
    this.Id = parseInt(this.$router.history.current.params["Id"]);
    this.getClientById();
  }
};
</script>

<style>
</style>
