<template>
  <section class="section">
    <el-form
      :model="ApiSecretModel"
      ref="ApiSecretForm"
      :rules="ApiSecretModelRules"
      label-width="120px"
    >
      <el-form-item label="Type：" prop="Type">
        <span slot="label">
          <label>密钥类型：</label>
          <el-tooltip slot="append">
            <span slot="content">密钥类型。</span>
            <i class="el-icon-info"></i>
          </el-tooltip>
        </span>
        <el-select v-model="ApiSecretModel.Type">
          <el-option
            v-for="item in ApiSecretModel.TypeList"
            :key="item.value"
            :value="item.value"
            :label="item.label"
          >{{item.label}}</el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="Value：" prop="Value">
        <span slot="label">
          <label>密钥值：</label>
          <el-tooltip slot="append">
            <span slot="content">密钥值。</span>
            <i class="el-icon-info"></i>
          </el-tooltip>
        </span>
        <el-input v-model="ApiSecretModel.Value" placeholder="请输入密钥值">
          <el-button icon="el-icon-edit" slot="append" @click="onUUIDValue()"></el-button>
        </el-input>
      </el-form-item>
      <el-form-item label="哈希类型:" prop="HashType">
        <el-select v-model="ApiSecretModel.HashType">
          <el-option
            v-for="item in ApiSecretModel.HashTypes"
            :key="item.value"
            :value="item.value"
            :label="item.label"
          >{{item.label}}</el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="Description：" prop="Description">
        <span slot="label">
          <label>描述：</label>
          <el-tooltip slot="append">
            <span slot="content">描述。</span>
            <i class="el-icon-info"></i>
          </el-tooltip>
        </span>
        <el-input v-model="ApiSecretModel.Description" placeholder="请输入Description"></el-input>
      </el-form-item>
      <el-form-item label="Expiration：" prop="Expiration">
        <span slot="label">
          <label>过期时间：</label>
          <el-tooltip slot="append">
            <span slot="content">过期时间,默认永不过期。</span>
            <i class="el-icon-info"></i>
          </el-tooltip>
        </span>
        <el-date-picker value-format="yyyy-MM-dd" v-model="ApiSecretModel.Expiration"></el-date-picker>
      </el-form-item>

      <el-form-item>
        <el-button type="primary" @click="onSubmit">确定</el-button>
      </el-form-item>
    </el-form>
  </section>
</template>

<script>
import util from "../../../common/util";
import {
  AddApiSecret,
  GetOneForEdit,
  UpdateApiSecret
} from "../../../api/identity_server/api_secret";
export default {
  name: "ApiSecret",
  props: {
    ApiSecretId: null,
    ApiResourceId: null
  },
  watch: {
    ApiSecretId: function() {
      this.Id = this.ApiSecretId;
      this.getApiSecretById();
    },
    ApiResourceId: function() {
      this.ApiSecretModel.ApiResourceId = this.ApiResourceId;
    }
  },
  data() {
    return {
      Id: null, //主键
      ApiSecretModelRules: {
        Description: [
          { max: 1000, message: "描述最长1000个字。", trigger: "change" }
        ],
        Value: [
          { required: true, message: "请填写密钥值。", trigger: "change" },
          { max: 4000, message: "密钥值最长4000个字。", trigger: "change" }
        ],
        Type: [
          { required: true, message: "请选择密钥类型。", trigger: "change" }
        ],
        HashType: [
          { required: true, message: "请选择哈希类型", trigger: "change" }
        ]
      },
      ApiSecretModel: {
        Description: "",
        Value: "",
        Expiration: null,
        Type: "SharedSecret",
        ApiResourceId: 0,
        HashType: 0,
        HashTypes: [],
        TypeList: []
      }
    };
  },
  methods: {
    onUUIDValue: function() {
      this.ApiSecretModel.Value = util.uuid();
    },
    onSubmit: function() {
      let that = this;
      that.$refs.ApiSecretForm.validate(function(valid) {
        if (!valid) {
          return;
        }
        let params = Object.assign({}, that.ApiSecretModel);

        if (that.Id) {
          UpdateApiSecret(that.Id, params).then(function(result) {
            if (result.success) {
              that.$notify.success("操作成功。");

              that.$emit("onApiSecretOk");
            }
          });
        } else {
          AddApiSecret(params).then(function(result) {
            if (result.success) {
              that.$notify.success("操作成功。");
              that.$refs.ApiSecretForm.resetFields();
              that.$emit("onApiSecretOk");
            }
          });
        }
      });
    },
    getApiSecretById: function() {
      let that = this;
      that.$refs.ApiSecretForm.resetFields();
      GetOneForEdit(that.Id).then(function(result) {
        if (result.success) {
          if (result.data.Expiration) {
            result.data.Expiration = util.formatDateTime(
              result.data.Expiration
            );
          }
          result.data.ApiResourceId=that.ApiResourceId;
          that.ApiSecretModel = Object.assign(that.ApiSecretModel, result.data);
        }
      });
    }
  },
  mounted: function() {
    this.Id = this.ApiSecretId;
    this.ApiSecretModel.ApiResourceId = this.ApiResourceId;
    this.getApiSecretById();
  }
};
</script>

<style scoped>
</style>

