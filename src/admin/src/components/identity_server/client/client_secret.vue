<template>
  <el-form
    :model="ClientSecret"
    :rules="ClientSecretRules"
    ref="ClientSecretForm"
    label-width="120px"
  >
    <el-form-item label="密钥类型:" prop="Type">
      <el-select v-model="ClientSecret.Type">
        <el-option value="SharedSecret">SharedSecret</el-option>
        <el-option value="X509Thumbprint">X509Thumbprint</el-option>
        <el-option value="X509Name">X509Name</el-option>
        <el-option value="X509CertificateBase64">X509CertificateBase64</el-option>
      </el-select>
    </el-form-item>
    <el-form-item label="密钥值:" prop="Value">
      <el-input v-model="ClientSecret.Value">
        <el-button icon="el-icon-edit" @click="onCreateUUID()" slot="append"></el-button>
      </el-input>
    </el-form-item>
    <el-form-item label="哈希类型:" prop="HashType">
      <el-select v-model="ClientSecret.HashType">
        <el-option
          v-for="item in ClientSecret.HashTypeList"
          :key="item.value"
          :value="item.value"
          :label="item.label"
        >{{item.label}}</el-option>
      </el-select>
    </el-form-item>
    <el-form-item label="描述:" prop="Description">
      <el-input v-model="ClientSecret.Description"></el-input>
    </el-form-item>
    <el-form-item label="过期时间:" prop="Expiration">
      <el-date-picker v-model="ClientSecret.Expiration"></el-date-picker>
    </el-form-item>
    <el-form-item>
      <el-button type="primary" @click="onOk">添加客户端密钥</el-button>
    </el-form-item>
  </el-form>
</template>

<script>
import util from "../../../common/util";
import { AddClientSecret } from "../../../api/identity_server/client_secret";
export default {
  name: "ClientSecret",
  props: {
    ClientId: {
      type: Number,
      default: 0
    }
  },
  watch: {
    ClientId: function() {
      this.ClientSecret.ClientId = this.ClientId;
    }
  },
  data() {
    return {
      ClientSecret: {
        Type: "SharedSecret",
        Value: "",
        HashType: [],
        Description: "",
        Expiration: null,
        ClientId: 0
      },
      ClientSecretRules: {
        Type: [
          { required: true, message: "请选择密钥类型", trigger: "change" }
        ],
        Value: [
          { required: true, message: "密钥值不能为空。", trigger: "change" },
          { maxlength: 50, message: "密钥值最长50字。", trigger: "change" }
        ],
        HashType: [
          { required: true, message: "请选择哈希类型", trigger: "change" }
        ]
      }
    };
  },
  methods: {
    onCreateUUID: function() {
      this.ClientSecret.Value = util.uuid();
    },
    onOk: function() {
      var that = this;
      that.$refs.ClientSecretForm.validate(function(valid) {
        if (!valid) {
          return;
        }
        var param = Object.assign({}, that.ClientSecret);
        AddClientSecret(param).then(result => {
          if (result.success) {
            that.$notify.success("操作成功。");
            that.$refs.ClientSecretForm.resetFields();
            that.$emit("onSecretOk");
          }
        });
      });
    }
  },
  mounted() {
    this.ClientSecret.ClientId = this.ClientId;
     that.$refs.ClientSecretForm.resetFields();
  }
};
</script>

<style>
</style>
