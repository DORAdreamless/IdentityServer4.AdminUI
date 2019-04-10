<template>
  <el-form
    :model="ClientModel"
    ref="ClientForm"
    :rules="ClientModelRules"
    label-width="200px"
    class="margin-top-20"
  >
    <el-form-item prop="UserCodeType">
      <span slot="label">
        <label>用户代码类型 ：</label>
        <el-tooltip slot="append">
          <span slot="content">指定用于客户端的用户代码的类型。 否则回落到默认值。</span>
          <i class="el-icon-info"></i>
        </el-tooltip>
      </span>
      <el-input v-model="ClientModel.UserCodeType"></el-input>
    </el-form-item>
    <el-form-item prop="DeviceCodeLifetime">
      <span slot="label">
        <label>设备代码生命周期 ：</label>
        <el-tooltip slot="append">
          <span slot="content">设备代码的生命周期（以秒为单位）（默认为 300 秒/5 分钟）。</span>
          <i class="el-icon-info"></i>
        </el-tooltip>
      </span>
      <el-input type="number" v-model="ClientModel.DeviceCodeLifetime"></el-input>
    </el-form-item>
    <el-form-item>
      <el-button type="primary" @click="onPrevSetup()">上一步</el-button>
      <el-button type="primary" @click="onNextOk()">完成</el-button>
    </el-form-item>
  </el-form>
</template>

<script>
import util from "../../../common/util";
import {
  UpdateDeviceFlowClient,
  GetOneForEdit
} from "../../../api/identity_server/client";
export default {
  name: "ClientDeviceFlow",
  data() {
    return {
      Id: null,
      ClientModel: {
        UserCodeType: "",
        DeviceCodeLifetime: 300
      },
      ClientModelRules: {}
    };
  },
  methods: {
    onPrevSetup: function() {
      this.$emit("onSetup", 4);
    },
    onNextOk: function() {
      var that = this;
      var param = Object.assign({}, that.ClientModel);
      UpdateDeviceFlowClient(that.Id, param).then(result => {
        if (result.success) {
          this.$notify.success("操作成功。");
          // this.$emit("onSetup", 5);
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
