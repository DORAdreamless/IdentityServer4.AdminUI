<template>
  <el-form :model="ClientClaim" :rules="ClientClaimRules" ref="ClientClaimForm" label-width="80px">
    <el-form-item label="Type:" prop="Type">
      <el-input v-model="ClientClaim.Type"></el-input>
    </el-form-item>
    <el-form-item label="Value:" prop="Value">
      <el-input v-model="ClientClaim.Value"></el-input>
    </el-form-item>
    <el-form-item>
      <el-button type="primary" @click="onClaimOk">立即创建</el-button>
    </el-form-item>
  </el-form>
</template>

<script>
import util from "../../../common/util";
import { CreateClientClaim } from "../../../api/identity_server/client_claim";
export default {
  name: "ClientClaim",
  props: {
    ClientId: {
      type: Number,
      default: 0
    }
  },
  watch: {
    ClientId: function() {
      this.ClientClaim.ClientId = this.ClientId;
    }
  },
  data() {
    return {
      ClientClaim: {
        Type: "",
        Value: "",
        ClientId: 0
      },
      ClientClaimRules: {
        Type: [
          { required: true, message: "Type不能为空。", trigger: "change" },
          { maxlength: 50, message: "Type最长50字。", trigger: "change" }
        ],
        Value: [
          { required: true, message: "Value不能为空。", trigger: "change" },
          { maxlength: 50, message: "Value最长50字。", trigger: "change" }
        ]
      }
    };
  },
  methods: {
    onClaimOk: function() {
      var that = this;
      that.$refs.ClientClaimForm.validate(function(valid) {
        if (!valid) {
          return;
        }
        var param = Object.assign({}, that.ClientClaim);
        CreateClientClaim(param).then(result => {
          if (result.success) {
            that.$refs.ClientClaimForm.resetFields();
            that.$notify.success('操作成功。');
            that.$emit("onClaimOk");
          }
        });
      });
    }
  },
  mounted() {
    this.ClientClaim.ClientId = this.ClientId;
  }
};
</script>

<style>
</style>
