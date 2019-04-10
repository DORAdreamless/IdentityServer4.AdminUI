<template>
  <el-form
    :model="ClientModel"
    ref="ClientForm"
    :rules="ClientModelRules"
    label-width="200px"
    class="margin-top-20"
  >
    <el-form-item prop="RequireConsent">
      <span slot="label">
        <label>需要同意 ：</label>
        <el-tooltip slot="append">
          <span slot="content">指定是否需要同意屏幕。 默认为 true。</span>
          <i class="el-icon-info"></i>
        </el-tooltip>
      </span>
      <el-checkbox v-model="ClientModel.RequireConsent"></el-checkbox>
    </el-form-item>
    <el-form-item prop="AllowRememberConsent">
      <span slot="label">
        <label>允许记住同意 ：</label>
        <el-tooltip slot="append">
          <span slot="content">指定用户是否可以选择存储同意决策。 默认为 true。</span>
          <i class="el-icon-info"></i>
        </el-tooltip>
      </span>
      <el-checkbox v-model="ClientModel.AllowRememberConsent"></el-checkbox>
    </el-form-item>
    <el-form-item prop="ClientUri">
      <span slot="label">
        <label>客户端 Uri ：</label>
        <el-tooltip slot="append">
          <span slot="content">有关客户端的更多信息的URI（在同意屏幕上使用）。</span>
          <i class="el-icon-info"></i>
        </el-tooltip>
      </span>
      <el-input v-model="ClientModel.ClientUri"></el-input>
    </el-form-item>
    <el-form-item prop="LogoUri">
      <span slot="label">
        <label>徽标 Uri ：</label>
        <el-tooltip slot="append">
          <span slot="content">客户端徽标 URI（在同意屏幕上使用）。</span>
          <i class="el-icon-info"></i>
        </el-tooltip>
      </span>
      <el-input v-model="ClientModel.LogoUri"></el-input>
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
  UpdateConsentClient,
  GetOneForEdit
} from "../../../api/identity_server/client";
export default {
  name: "ClientConsent",
  data() {
    return {
      Id: null,
      ClientModel: {
        RequireConsent: true,
        AllowRememberConsent: true,
        ClientUri: "",
        LogoUri: ""
      },
      ClientModelRules: {}
    };
  },
  methods: {
    onPrevSetup: function() {
      this.$emit("onSetup", 3);
    },
    onNextOk: function() {
      var that = this;
      var param = Object.assign({}, that.ClientModel);
      UpdateConsentClient(that.Id, param).then(result => {
        if (result.success) {
          this.$notify.success("操作成功。");
          this.$emit("onSetup", 5);
        }
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
