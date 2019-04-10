<template>
  <section class="section">
    <el-form
      :model="ApiScopeModel"
      ref="ApiScopeForm"
      :rules="ApiScopeModelRules"
      label-width="120px"
    >
      <el-form-item label="Name：" prop="Name">
        <span slot="label">
          <label>名称：</label>
          <el-tooltip slot="append">
            <span slot="content">API 的唯一名称。 此值用于内省身份验证，并将添加到传出访问令牌的受众。</span>
            <i class="el-icon-info"></i>
          </el-tooltip>
        </span>
        <el-input v-model="ApiScopeModel.Name" placeholder="请输入名称"></el-input>
      </el-form-item>

      <el-form-item label="DisplayName：" prop="DisplayName">
        <span slot="label">
          <label>显示名称：</label>
          <el-tooltip slot="append">
            <span slot="content">该值可以用于例如 在同意屏幕上。</span>
            <i class="el-icon-info"></i>
          </el-tooltip>
        </span>
        <el-input v-model="ApiScopeModel.DisplayName" placeholder="请输入显示名称"></el-input>
      </el-form-item>

      <el-form-item label="Description：" prop="Description">
        <span slot="label">
          <label>描述：</label>
          <el-tooltip slot="append">
            <span slot="content">该值可以用于例如 在同意屏幕上。</span>
            <i class="el-icon-info"></i>
          </el-tooltip>
        </span>
        <el-input v-model="ApiScopeModel.Description" placeholder="请输入描述"></el-input>
      </el-form-item>

      <el-form-item label="Required：" prop="Required">
        <span slot="label">
          <label>必须：</label>
          <el-tooltip slot="append">
            <span slot="content">指定用户是否可以在同意屏幕上取消选择作用域（如果同意屏幕要实现此类功能）。 默认为 false。</span>
            <i class="el-icon-info"></i>
          </el-tooltip>
        </span>
        <el-checkbox v-model="ApiScopeModel.Required"></el-checkbox>
      </el-form-item>

      <el-form-item label="Emphasize：" prop="Emphasize">
        <span slot="label">
          <label>强调：</label>
          <el-tooltip slot="append">
            <span slot="content">指定同意屏幕是否会强调此作用域（如果同意屏幕要实现此类功能）。 将此设置用于敏感或重要作用域。 默认为 false。</span>
            <i class="el-icon-info"></i>
          </el-tooltip>
        </span>
        <el-checkbox v-model="ApiScopeModel.Emphasize"></el-checkbox>
      </el-form-item>
      <el-form-item>
        <span slot="label">
          <label>用户声明：</label>
          <el-tooltip slot="append">
            <span slot="content">应包含在访问令牌中的关联用户声明类型的列表。</span>
            <i class="el-icon-info"></i>
          </el-tooltip>
        </span>
        <el-input v-model="CommonFormModel.Claim">
          <el-button icon="el-icon-plus" slot="append" @click="onNewClaim()"></el-button>
        </el-input>
        <div>
          <el-tag
            style="margin-right:10px;"
            closable
            @close="onDeleteClaim(claim,index)"
            v-for="(claim,index) in ApiScopeModel.Claims"
            :key="claim"
          >{{claim}}</el-tag>
        </div>
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
  CreateApiScope,
  GetOneForEdit,
  UpdateApiScope
} from "../../../api/identity_server/api_scope";
export default {
  name: "ApiScope",
  props: {
    ApiResourceId: null,
    ApiScopeId: null
  },
  watch: {
    ApiScopeId: function() {
      this.Id = this.ApiScopeId;
      this.getApiScopeById();
    },
    ApiResourceId: function() {
      this.ApiScopeModel.ApiResourceId = this.ApiResourceId;
    }
  },
  data() {
    return {
      Id: null, //主键
      ApiScopeModelRules: {
        Name: [
          { required: true, message: "请填写名称。", trigger: "change" },
          { max: 200, message: "名称最长200个字。", trigger: "change" }
        ],
        DisplayName: [
          { max: 200, message: "显示名称最长200个字。", trigger: "change" }
        ],
        Description: [
          { max: 1000, message: "描述最长1000个字。", trigger: "change" }
        ]
      },
      ApiScopeModel: {
        Name: "",
        DisplayName: "",
        Description: "",
        Required: false,
        Emphasize: false,
        ShowInDiscoveryDocument: true,
        ApiResourceId: 0,
        Claims: []
      },
      CommonFormModel: {
        Claim: ""
      }
    };
  },
  methods: {
    onSubmit: function() {
      let that = this;
      that.$refs.ApiScopeForm.validate(function(valid) {
        if (!valid) {
          return;
        }
        let params = Object.assign({}, that.ApiScopeModel);

        if (that.Id) {
          UpdateApiScope(that.Id, params).then(function(result) {
            if (result.success) {
              that.$notify.success("操作成功。");

              that.$emit("onApiScopeOk");
            }
          });
        } else {
          CreateApiScope(params).then(function(result) {
            if (result.success) {
              that.$notify.success("操作成功。");
              that.$refs.ApiScopeForm.resetFields();
              that.$emit("onApiScopeOk");
            }
          });
        }
      });
    },
    getApiScopeById: function() {
      let that = this;
      that.$refs.ApiScopeForm.resetFields();
      if (!that.Id) {
        return;
      }
      GetOneForEdit(that.Id).then(function(result) {
        if (result.success) {
          that.ApiScopeModel = Object.assign(that.ApiScopeModel, result.data);
        }
      });
    },
    //claim
    onNewClaim: function() {
      if (util.isNullOrEmpty(this.CommonFormModel.Claim)) {
        return;
      }
      if (
        util.getFromArray(
          this.CommonFormModel.Claim.toLowerCase(),
          this.ApiScopeModel.Claims
        )
      ) {
        this.$notify.warning(`声明${this.CommonFormModel.Claim}已经存在了。`);
        return;
      }
      this.ApiScopeModel.Claims.push(this.CommonFormModel.Claim.toLowerCase());
      this.CommonFormModel.Claim = "";
    },
    onDeleteClaim: function(claim, index) {
      this.ApiScopeModel.Claims.splice(index, 1);
    }
  },
  mounted: function() {
    // this.Id = this.$router.history.current.params["Id"];
    this.Id = this.ApiScopeId;
    this.ApiScopeModel.ApiResourceId = this.ApiResourceId;
    this.getApiScopeById();
  }
};
</script>

<style scoped>
</style>

