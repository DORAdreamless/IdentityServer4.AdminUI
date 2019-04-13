<template>
  <section>
    <el-form
      :model="ClientModel"
      ref="ClientTokenForm"
      :rules="ClientModelRules"
      label-width="200px"
      class="margin-top-20"
    >
      <el-form-item prop="IdentityTokenLifetime">
        <span slot="label">
          <label>身份令牌生命周期 ：</label>
          <el-tooltip slot="append">
            <span slot="content">标识令牌的生命周期（以秒为单位）（默认为 300 秒/5 分钟）。</span>
            <i class="el-icon-info"></i>
          </el-tooltip>
        </span>
        <el-input type="number" v-model="ClientModel.IdentityTokenLifetime"></el-input>
      </el-form-item>
      <el-form-item prop="AccessTokenLifetime">
        <span slot="label">
          <label>访问令牌生命周期 ：</label>
          <el-tooltip slot="append">
            <span slot="content">问令牌的生命周期（以秒为单位）（默认为 3600 秒/1 小时）。</span>
            <i class="el-icon-info"></i>
          </el-tooltip>
        </span>
        <el-input type="number" v-model="ClientModel.AccessTokenLifetime"></el-input>
      </el-form-item>
      <el-form-item prop="AccessTokenType">
        <span slot="label">
          <label>访问令牌类型 ：</label>
          <el-tooltip slot="append">
            <span slot="content">指定访问令牌是引用令牌还是自包含 JWT 令牌（默认为 Jwt）。</span>
            <i class="el-icon-info"></i>
          </el-tooltip>
        </span>
        <el-select v-model="ClientModel.AccessTokenType">
          <el-option
            :value="item.value"
            :label="item.label"
            :key="item.value"
            v-for="item in ClientModel.AccessTokenTypes"
          >{{item.label}}</el-option>
        </el-select>
      </el-form-item>
      <el-form-item prop="AuthorizationCodeLifetime">
        <span slot="label">
          <label>授权码生命周期 ：</label>
          <el-tooltip slot="append">
            <span slot="content">授权码的生命周期（以秒为单位）（默认为 300 秒/5 分钟）。</span>
            <i class="el-icon-info"></i>
          </el-tooltip>
        </span>
        <el-input type="number" v-model="ClientModel.AuthorizationCodeLifetime"></el-input>
      </el-form-item>
      <el-form-item prop="AbsoluteRefreshTokenLifetime">
        <span slot="label">
          <label>绝对刷新令牌生命周期 ：</label>
          <el-tooltip slot="append">
            <span slot="content">刷新令牌的最长生命周期，以秒为单位。 默认为 2592000 秒/30 天。</span>
            <i class="el-icon-info"></i>
          </el-tooltip>
        </span>
        <el-input type="number" v-model="ClientModel.AbsoluteRefreshTokenLifetime"></el-input>
      </el-form-item>
      <el-form-item prop="SlidingRefreshTokenLifetime">
        <span slot="label">
          <label>滚动刷新令牌生命周期 ：</label>
          <el-tooltip slot="append">
            <span slot="content">滚动刷新生命周期是多少秒钟刷新令牌。 默认为 1296000 秒/15 天。</span>
            <i class="el-icon-info"></i>
          </el-tooltip>
        </span>
        <el-input type="number" v-model="ClientModel.SlidingRefreshTokenLifetime"></el-input>
      </el-form-item>
      <el-form-item prop="RefreshTokenUsage">
        <span slot="label">
          <label>刷新令牌使用情况 ：</label>
          <el-tooltip slot="append">
            <span slot="content">ReUse 刷新令牌时，令牌句柄将保持不变 OneTime 刷新令牌时将更新令牌句柄。</span>
            <i class="el-icon-info"></i>
          </el-tooltip>
        </span>
        <el-select v-model="ClientModel.RefreshTokenUsage">
          <el-option
            :value="item.value"
            :label="item.label"
            :key="item.value"
            v-for="item in ClientModel.RefreshTokenUsages"
          >{{item.label}}</el-option>
        </el-select>
      </el-form-item>
      <el-form-item prop="RefreshTokenExpiration">
        <span slot="label">
          <label>刷新令牌过期 ：</label>
          <el-tooltip slot="append">
            <span slot="content">
              bsolute 刷新令牌将在固定时间点到期（由 AbsoluteRefreshTokenLifetime 指定）
              Sliding 滚动刷新令牌，刷新令牌时生命周期将被更新（按 SlidingRefreshTokenLifetime 中指定的量）。 生命周期不会超过 AbsoluteRefreshTokenLifetime。
            </span>
            <i class="el-icon-info"></i>
          </el-tooltip>
        </span>
        <el-select v-model="ClientModel.RefreshTokenExpiration">
          <el-option
            :value="item.value"
            :label="item.label"
            :key="item.value"
            v-for="item in ClientModel.RefreshTokenExpirations"
          >{{item.label}}</el-option>
        </el-select>
      </el-form-item>
      <el-form-item prop="AllowedCorsOrigins">
        <span slot="label">
          <label>允许跨域来源 ：</label>
          <el-tooltip slot="append">
            <span slot="content">如果指定，将由默认 CORS 策略服务实现（In-Memory 和 EF）用于为 JavaScript 客户端构建 CORS 策略。</span>
            <i class="el-icon-info"></i>
          </el-tooltip>
        </span>
        <el-input v-model="formModel.AllowedCorsOrigin">
          <el-button slot="append" icon="el-icon-plus" @click="onAllowedCorsOriginPlus()"></el-button>
        </el-input>
        <el-tag
          style="margin-left:5px;"
          :key="item"
          v-for="(item,index) in ClientModel.AllowedCorsOrigins"
          closable
          @close="onAllowedCorsOriginClose(item,index)"
          :disable-transitions="false"
        >{{item}}</el-tag>
      </el-form-item>
      <el-form-item prop="UpdateAccessTokenClaimsOnRefresh">
        <span slot="label">
          <label>刷新时更新访问令牌声明 ：</label>
          <el-tooltip slot="append">
            <span slot="content">获取或设置一个值，该值指示是否应在刷新令牌请求上更新访问令牌（及其声明）。</span>
            <i class="el-icon-info"></i>
          </el-tooltip>
        </span>
        <el-checkbox v-model="ClientModel.UpdateAccessTokenClaimsOnRefresh"></el-checkbox>
      </el-form-item>
      <el-form-item prop="IncludeJwtId">
        <span slot="label">
          <label>包括 Jwt 标识 ：</label>
          <el-tooltip slot="append">
            <span slot="content">指定 JWT 访问令牌是否应具有嵌入的唯一标识（通过 jti 声明）。</span>
            <i class="el-icon-info"></i>
          </el-tooltip>
        </span>
        <el-checkbox v-model="ClientModel.IncludeJwtId"></el-checkbox>
      </el-form-item>
      <el-form-item prop="AlwaysSendClientClaims">
        <span slot="label">
          <label>始终发送客户端声明 ：</label>
          <el-tooltip slot="append">
            <span slot="content">如果设置，将为每个流发送客户端声明。 如果不是，仅用于客户端凭证流（默认为 false）。</span>
            <i class="el-icon-info"></i>
          </el-tooltip>
        </span>
        <el-checkbox v-model="ClientModel.AlwaysSendClientClaims"></el-checkbox>
      </el-form-item>
      <el-form-item prop="AlwaysIncludeUserClaimsInIdToken">
        <span slot="label">
          <label>始终在标识令牌中包含用户声明 ：</label>
          <el-tooltip slot="append">
            <span slot="content">始终在标识令牌中包含用户声明。</span>
            <i class="el-icon-info"></i>
          </el-tooltip>
        </span>
        <el-checkbox v-model="ClientModel.AlwaysIncludeUserClaimsInIdToken"></el-checkbox>
      </el-form-item>
      <el-form-item prop="ClientClaimsPrefix">
        <span slot="label">
          <label>客户端声明前缀 ：</label>
          <el-tooltip slot="append">
            <span slot="content">如果设置，客户端声明类型将以此为前缀。 默认为 client_。 目的是确保它们不会意外地与用户声明冲突。。</span>
            <i class="el-icon-info"></i>
          </el-tooltip>
        </span>
        <el-input type="text" v-model="ClientModel.ClientClaimsPrefix"></el-input>
      </el-form-item>
      <el-form-item prop="PairWiseSubjectSalt">
        <span slot="label">
          <label>配对主体盐 ：</label>
          <el-tooltip slot="append">
            <span slot="content">对于此客户端的用户，在配对主体标识生成中使用的盐值。</span>
            <i class="el-icon-info"></i>
          </el-tooltip>
        </span>
        <el-input  v-model="ClientModel.PairWiseSubjectSalt"></el-input>
      </el-form-item>
      <el-form-item prop="AccessTokenLifetime">
        <span slot="label">
          <label>访问令牌生命周期 ：</label>
          <el-tooltip slot="append">
            <span slot="content">问令牌的生命周期（以秒为单位）（默认为 3600 秒/1 小时）。</span>
            <i class="el-icon-info"></i>
          </el-tooltip>
        </span>
        <el-input type="number" v-model="ClientModel.AccessTokenLifetime"></el-input>
      </el-form-item>
      <el-form-item label="声明：">
        <el-card>
          <div slot="header" class="clearfix text-right">
            <el-button icon="el-icon-plus" circle @click="onNewClaim()"></el-button>
          </div>
          <el-table size="mini" stripe border :data="ClientClaims">
            <el-table-column prop="Type" label="Type"></el-table-column>
            <el-table-column prop="Value" label="Value"></el-table-column>
            <el-table-column label="操作">
              <template slot-scope="scope">
                <el-button
                  icon="el-icon-delete"
                  circle
                  size="sm"
                  @click="onClaimRemove(scope.row,scope.$index)"
                ></el-button>
              </template>
            </el-table-column>
          </el-table>
        </el-card>
      </el-form-item>
      <el-form-item>
        <el-button type="primary" @click="onPrevSetup()">上一步</el-button>
        <el-button type="primary" @click="onTokenOk()">下一步</el-button>
      </el-form-item>
    </el-form>
    <el-dialog title="客户端声明" :visible.sync="dialogClaimVisible">
      <client-claim :client-id="Id" @onClaimOk="onClaimOk"></client-claim>
    </el-dialog>
  </section>
</template>

<script>
import util from "../../../common/util";
import {
  UpdateClientToken,
  GetOneForEdit
} from "../../../api/identity_server/client";
import {
  GetClientClaims,
  DeleteClientClaim
} from "../../../api/identity_server/client_claim";
import ClientClaim from "./client_claim";
export default {
  name: "ClientToken",
  components: { ClientClaim },
  data() {
    return {
      Id: null,
      ClientModel: {
        //token
        IdentityTokenLifetime: 300,
        AccessTokenLifetime: 3600,
        AccessTokenType: 0, // default jwt
        AuthorizationCodeLifetime: 300,
        AbsoluteRefreshTokenLifetime: 2592000,
        SlidingRefreshTokenLifetime: 1296000,
        RefreshTokenUsage: 1, //one time only
        RefreshTokenExpiration: 0,
        AllowedCorsOrigins: [],
        UpdateAccessTokenClaimsOnRefresh: true,
        IncludeJwtId: true,
        AlwaysSendClientClaims: true,
        AlwaysIncludeUserClaimsInIdToken: true,
        ClientClaimsPrefix: "client_",
        PairWiseSubjectSalt: ""
        //Claims: []
      },
      dialogClaimVisible: false,
      ClientClaims: [],
      formModel: {
        AllowedCorsOrigin: ""
      },
      ClientModelRules: {}
    };
  },
  methods: {
    onAllowedCorsOriginPlus: function() {
      if (util.isNullOrEmpty(this.formModel.AllowedCorsOrigin)) {
        return;
      }
      if (
        util.getFromArray(
          this.formModel.AllowedCorsOrigin.toLowerCase(),
          this.ClientModel.AllowedCorsOrigins
        )
      ) {
        this.$notify.warn("重定向URI已经存在！");
        return;
      }
      this.ClientModel.AllowedCorsOrigins.push(
        this.formModel.AllowedCorsOrigin.toLowerCase()
      );
      this.formModel.AllowedCorsOrigin = "";
    },
    onAllowedCorsOriginClose: function(item, index) {
      this.ClientModel.AllowedCorsOrigins.splice(index, 1);
    },
    onNewClaim: function() {
      this.dialogClaimVisible = true;
    },
    onClaimOk: function() {
      this.dialogClaimVisible = false;
      this.getClientClaims();
    },
    onClaimRemove: function(claim, index) {
      this.$confirm(`此操作将永久删除${claim.Value}, 是否继续?`, "提示", {
        confirmButtonText: "确定",
        cancelButtonText: "取消",
        type: "warning"
      }).then(() => {
        DeleteClientClaim(claim.Id).then(result => {
          if (result.success) {
            this.$notify.success("操作成功。");
            this.getClientClaims();
          }
        });
      });
    },
    getClientClaims: function() {
      GetClientClaims(this.Id).then(result => {
        if (result.success) {
          this.ClientClaims = result.data || [];
        }
      });
    },
    onPrevSetup: function() {
      let that = this;
      that.$emit("onSetup", 2);
    },
    onTokenOk: function() {
      let that = this;

      that.$refs.ClientTokenForm.validate(function(valid) {
        if (!valid) {
          return;
        }
        let params = Object.assign({}, that.ClientModel);

        UpdateClientToken(that.Id, params).then(function(result) {
          if (result.success) {
            that.$emit("onSetup", 4);
          }
        });
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
    this.getClientClaims();
  }
};
</script>

<style>
</style>
