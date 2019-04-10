<template>
  <el-form
    :model="ClientProperty"
    :rules="ClientPropertyRules"
    ref="ClientPropertyForm"
    label-width="120px"
  >
    <el-form-item label="属性名:" prop="Key">
      <el-input v-model="ClientProperty.Key"></el-input>
    </el-form-item>
    <el-form-item label="属性值:" prop="Value">
      <el-input v-model="ClientProperty.Value"></el-input>
    </el-form-item>
    <el-form-item>
      <el-button type="primary" @click="onOk">添加属性</el-button>
    </el-form-item>
  </el-form>
</template>

<script>
import util from "../../../common/util";
import { CreateClientProperty } from "../../../api/identity_server/client_property";
export default {
  name: "ClientProperty",
  props: {
    ClientId: {
      type: Number,
      default: 0
    }
  },
  watch: {
    ClientId: function() {
      this.ClientProperty.ClientId = this.ClientId;
    }
  },
  data() {
    return {
      ClientProperty: {
        Key: "",
        Value: "",
        ClientId: 0
      },
      ClientPropertyRules: {
        Key: [
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
    onOk: function() {
      var that = this;
      that.$refs.ClientPropertyForm.validate(function(valid) {
        if (!valid) {
          return;
        }
        var param = Object.assign({}, that.ClientProperty);
        CreateClientProperty(param).then(result => {
          if (result.success) {
            that.$refs.ClientPropertyForm.resetFields();
            that.$notify.success("操作成功。");
            that.$emit("onPropertyOk");
          }
        });
      });
    }
  },
  mounted() {
    this.ClientProperty.ClientId = this.ClientId;
  }
};
</script>

<style>
</style>
