<template>
  <section class="section">
    <!--面包屑导航-->
    <el-breadcrumb separator-class="el-icon-arrow-right" style="padding: 15px 0;">
      <el-breadcrumb-item>api资源</el-breadcrumb-item>
    </el-breadcrumb>
    <hr>
    <el-row>
      <el-col :span="12">
        <el-form label-width="120px" inline>
          <el-form-item label="关键词：">
            <el-input v-model="pager.keywords"></el-input>
          </el-form-item>
          <el-form-item>
            <el-button @click="onSearch" type="default" icon="el-icon-search"></el-button>
            <el-button type="primary" icon="el-icon-plus" @click="onAdd"></el-button>
          </el-form-item>
        </el-form>
      </el-col>
      <el-col :span="12"></el-col>
    </el-row>
    <el-table
      ref="singleTable"
      :data="results.list"
      highlight-current-row
      border
      style="width: 100%"
    >
      <el-table-column type="index" width="50"></el-table-column>
      <el-table-column property="Enabled" label="启用">
        <template slot-scope="scope">
          <el-tag v-if="scope.row.Enabled">是</el-tag>
          <el-tag v-if="!scope.row.Enabled">否</el-tag>
        </template>
      </el-table-column>
      <el-table-column property="Name" label="名称"></el-table-column>
      <el-table-column property="DisplayName" label="显示名称"></el-table-column>
      <el-table-column property="Description" label="描述"></el-table-column>
      <el-table-column property="Created" label="创建时间">
        <template slot-scope="scope">{{scope.row.Created|date}}</template>
      </el-table-column>
      <el-table-column property="Updated" label="修改时间">
        <template slot-scope="scope">{{scope.row.Updated|date}}</template>
      </el-table-column>
      <el-table-column property="LastAccessed" label="最后授权时间">
        <template slot-scope="scope">{{scope.row.LastAccessed|date}}</template>
      </el-table-column>
      <el-table-column label="操作">
        <template slot-scope="scope">
          <el-button-group>
            <el-button type="primary" size="mini" icon="el-icon-edit" @click="onEdit(scope.row)"></el-button>
            <el-button type="danger" size="mini" icon="el-icon-delete" @click="onDelete(scope.row)"></el-button>
          </el-button-group>
        </template>
      </el-table-column>
    </el-table>
    <el-pagination
      @size-change="handleSizeChange"
      @current-change="handleCurrentChange"
      :current-page="pager.page"
      :page-sizes="pager.pageSizes"
      :page-size="pager.rows"
      layout="total, sizes, prev, pager, next, jumper"
      :total="results.total"
    ></el-pagination>
  </section>
</template>

<script>
import {
  GetApiResourceByPage,
  DeleteApiResource
} from "../../../api/identity_server/api_resource";

export default {
  components: {},
  data() {
    return {
      pager: {
        page: 1,
        rows: 10,
        pageSizes: [10, 15],
        keywords: ""
      },
      results: {
        list: [],
        total: 0
      }
    };
  },
  methods: {
    getApiResourceByPage: function() {
      let that = this;
      let params = Object.assign({}, that.pager);
      GetApiResourceByPage(params).then(function(result) {
        if (result.success) {
          that.results = Object.assign(that.results, result.data);
        }
      });
    },
    handleSizeChange(val) {
      this.pager = Object.assign(this.pager, {
        page: 1,
        rows: val
      });
      this.getApiResourceByPage();
    },
    handleCurrentChange(val) {
      this.pager = Object.assign(this.pager, {
        page: val
      });
      this.getApiResourceByPage();
    },
    onSearch: function() {
      this.pager = Object.assign(this.pager, {
        page: 1
      });
      this.getApiResourceByPage();
    },
    onAdd: function() {
      this.$router.push({
        name: "IdentityServerApiResourceAdd"
      });
    },
    onEdit: function(ApiResource) {
      this.$router.push({
        name: "IdentityServerApiResourceEdit",
        params: {
          Id: ApiResource.Id
        }
      });
    },
    onDelete: function(ApiResource) {
      let that = this;
      that
        .$confirm(`此操作将永久删除${ApiResource.Created}, 是否继续?`, "提示", {
          confirmButtonText: "确定",
          cancelButtonText: "取消",
          type: "warning"
        })
        .then(() => {
          DeleteApiResource(ApiResource.Id).then(function(result) {
            if (result.success) {
              that.$message({
                type: "success",
                message: "操作成功"
              });
              that.getApiResourceByPage();
            }
          });
        })
        .catch(() => {});
    }
  },
  mounted: function() {
    this.getApiResourceByPage();
  }
};
</script>

<style scoped>
.section {
  background: #fff;
  padding: 10px 30px 5px;
}
.el-main {
  margin-left: 220px;
  /* min-height: 400px; */
  position: initial;
}
</style>

