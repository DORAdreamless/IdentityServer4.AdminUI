<template>
  <section class="section">
    <el-form
      :model="ApiPropertyModel"
      ref="ApiPropertyForm"
      :rules="ApiPropertyModelRules"
      label-width="120px"
    >
      <el-form-item label="键：" prop="Key">
        <el-input v-model="ApiPropertyModel.Key" placeholder="请输入键"></el-input>
      </el-form-item>

      <el-form-item label="值：" prop="Value">
        <el-input v-model="ApiPropertyModel.Value" placeholder="请输入值"></el-input>
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
  CreateApiProperty,
  GetOneForEdit,
  UpdateApiProperty
} from "../../../api/identity_server/api_property";
export default {
  name: "ApiProperty",
  props: {
    ApiResourceId: null,
    ApiPropertyId: null
  },
  watch: {
    ApiResourceId: function() {
      this.ApiPropertyModel.ApiResourceId = this.ApiResourceId;
    },
    ApiPropertyId: function() {
      this.Id = this.ApiPropertyId;
      this.getApiPropertyById();
    }
  },
  data() {
    return {
      Id: null, //主键
      ApiPropertyModelRules: {
        Key: [
          { required: true, message: "请填写键。", trigger: "change" },
          { max: 250, message: "键最长250个字。", trigger: "change" }
        ],
        Value: [
          { required: true, message: "请填写值。", trigger: "change" },
          { max: 2000, message: "值最长2000个字。", trigger: "change" }
        ]
      },
      ApiPropertyModel: {
        Key: "",
        Value: "",
        ApiResourceId: 0
      }
    };
  },
  methods: {
    onSubmit: function() {
      let that = this;
      that.$refs.ApiPropertyForm.validate(function(valid) {
        if (!valid) {
          return;
        }
        let params = Object.assign({}, that.ApiPropertyModel);

        if (that.Id) {
          UpdateApiProperty(that.Id, params).then(function(result) {
            if (result.success) {
              that.$notify.success("操作成功。");
              //that.$refs.ApiPropertyForm.resetFields();
              that.$emit("onApiPropertyOk");
            }
          });
        } else {
          CreateApiProperty(params).then(function(result) {
            if (result.success) {
              that.$notify.success("操作成功。");
              that.$refs.ApiPropertyForm.resetFields();
              that.$emit("onApiPropertyOk");
            }
          });
        }
      });
    },
    getApiPropertyById: function() {
      let that = this;
      that.$refs.ApiPropertyForm.resetFields();
      if (!that.Id) {
        return;
      }
      GetOneForEdit(that.Id).then(function(result) {
        if (result.success) {
          that.ApiPropertyModel = Object.assign(
            that.ApiPropertyModel,
            result.data
          );
        }
      });
    }
  },
  mounted: function() {
    this.ApiPropertyModel.ApiResourceId = this.ApiResourceId;
    this.Id = this.ApiPropertyId;
    this.getApiPropertyById();
  }
};
</script>

<style scoped>
</style>

