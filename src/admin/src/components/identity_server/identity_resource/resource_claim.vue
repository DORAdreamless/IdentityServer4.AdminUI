<template>
  <el-form
    :model="ResourceClaim"
    :rules="ResourceClaimRules"
    ref="ResourceClaimForm"
    label-width="80px"
  >
    <el-form-item label="Type:" prop="Type">
      <el-input v-model="ResourceClaim.Type"></el-input>
    </el-form-item>
    <!-- <el-form-item label="Value:" prop="Value">
      <el-input v-model="ResourceClaim.Value"></el-input>
    </el-form-item> -->
    <el-form-item>
      <el-button type="primary" @click="onClaimOk">立即创建</el-button>
    </el-form-item>
  </el-form>
</template>

<script>
import util from "../../../common/util";
import { CreateIdentityClaim } from "../../../api/identity_server/identity_resource_claim";
export default {
  name: "IdentityResourceClaim",
  props: {
    IdentityResourceId: null
  },
  watch: {
    IdentityResourceId: function(v1, v2) {
      this.ResourceClaim.IdentityResourceId = this.IdentityResourceId;
    }
  },
  data() {
    return {
      ResourceClaim: {
        Type: "",
        Value: "",
        IdentityResourceId: 0
      },
      ResourceClaimRules: {
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
      that.$refs.ResourceClaimForm.validate(function(valid) {
        if (!valid) {
          return;
        }
        var param = Object.assign({}, that.ResourceClaim);
        CreateIdentityClaim(param).then(result => {
          if (result.success) {
            that.$refs.ResourceClaimForm.resetFields();
            that.$notify.success("操作成功。");
            that.$emit("onClaimOk");
          }
        });
      });
    }
  },
  mounted() {
    this.ResourceClaim.IdentityResourceId = this.IdentityResourceId;
  }
};
</script>

<style>
</style>
