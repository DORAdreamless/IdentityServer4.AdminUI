<template>
  <el-form
    :model="ResourceProperty"
    :rules="ResourcePropertyRules"
    ref="ResourcePropertyForm"
    label-width="80px"
  >
    <el-form-item label="键:" prop="Key">
      <el-input v-model="ResourceProperty.Key"></el-input>
    </el-form-item>
    <el-form-item label="值:" prop="Value">
      <el-input v-model="ResourceProperty.Value"></el-input>
    </el-form-item>
    <el-form-item>
      <el-button type="primary" @click="onPropertyOk">立即创建</el-button>
    </el-form-item>
  </el-form>
</template>

<script>
import util from "../../../common/util";
import { CreateIdentityProperty } from "../../../api/identity_server/identity_resource_property";
export default {
  name: "IdentityResourceProperty",
  props: {
    IdentityResourceId: null
  },
  watch: {
    IdentityResourceId: function(v1, v2) {
      this.ResourceProperty.IdentityResourceId = this.IdentityResourceId;
    }
  },
  data() {
    return {
      ResourceProperty: {
        Key: "",
        Value: "",
        IdentityResourceId: 0
      },
      ResourcePropertyRules: {
        Key: [
          { required: true, message: "Key不能为空。", trigger: "change" },
          { maxlength: 50, message: "Key最长50字。", trigger: "change" }
        ],
        Value: [
          { required: true, message: "Value不能为空。", trigger: "change" },
          { maxlength: 50, message: "Value最长50字。", trigger: "change" }
        ]
      }
    };
  },
  methods: {
    onPropertyOk: function() {
      var that = this;
      that.$refs.ResourcePropertyForm.validate(function(valid) {
        if (!valid) {
          return;
        }
        var param = Object.assign({}, that.ResourceProperty);
        CreateIdentityProperty(param).then(result => {
          if (result.success) {
            that.$refs.ResourcePropertyForm.resetFields();
            that.$notify.success("操作成功。");
            that.$emit("onPropertyOk");
          }
        });
      });
    }
  },
  mounted() {
    this.ResourceProperty.IdentityResourceId = this.IdentityResourceId;
  }
};
</script>

<style>
</style>
