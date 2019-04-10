<template>
  <el-container class="layout">
    <el-header
      style="background-color: #1c6da9;color: white;line-height: 60px;height: 75px;text-align: left;font-size:16px;padding-top: 8px;"
    >
      <span class="logotitle">
        <img src="./assets/logo.png" class="logo">

        <span class="headertitle">IdentityServer4 Admin UI</span>
      </span>
      <ul class="nav">
        <li class="nav-item nav-theme-switch" style>
          <el-dropdown split-button type="primary" trigger="click" @command="userDropdownCommand">
            {{UserData.name}}
            <el-dropdown-menu slot="dropdown">
              <el-dropdown-item command="return">返回平台</el-dropdown-item>
              <el-dropdown-item command="logout">退出系统</el-dropdown-item>
            </el-dropdown-menu>
          </el-dropdown>
        </li>
      </ul>
    </el-header>
    <el-container class="layout-center">
      <el-aside>
        <el-menu :default-openeds="defaultOpeneds" :router="true" :unique-opened="true">
          <el-submenu :key="menu.id" :index="menu.id" v-for="menu in menuData">
            <template slot="title">
              <i class="el-icon-menu"></i>
              {{menu.text}}
            </template>
            <el-menu-item
              :key="submenu.id"
              :index="submenu.id"
              :route="{path:submenu.target}"
              v-for="submenu in menu.children"
            >{{submenu.text}}</el-menu-item>
          </el-submenu>
        </el-menu>
      </el-aside>
      <el-main>
        <div class="main-content">
          <router-view></router-view>
        </div>
      </el-main>
    </el-container>
  </el-container>
</template>

<style lang="scss" scoped>
.logo {
  height: 40px;
  float: left;
  position: relative;
  top: 15px;
}
.headertitle {
  line-height: 72px;
  font-size: 22px;
  color: #ffffff;
}
.section {
  background: #fff;
  padding: 10px 30px 60px;
}

.el-main {
  margin-left: 240px;
  position: initial;
  padding-top: 0px !important;
}

.el-aside {
  color: #333;
  height: calc(100% - 95px);
  position: absolute;
  margin-top: 20px;
  top: 75px;
  width: 220px !important;
  border-right: solid 20px #ebf0f5;
  overflow-y: auto;
}
hr {
  height: 1px;
  border: none;
  border-top: 1px solid #ebf0f5;
}
.layout {
  height: 100%;
}

.layout-center {
  top: 60px;
  width: 100%;
  text-align: left;
  overflow: auto;
  border-top: solid 20px #ebf0f5;
  background: white;
}

.el-main {
  margin-left: 220px;
  height: calc(100vh - 95px);
  overflow-y: auto;
}

.el-menu {
  height: 100%;
  /*background-color: #f0f2f5;*/
}

.nav {
  float: right;
  margin: 0;
  padding: 0;
}

.nav-item {
  list-style: none;
  float: left;
}

.logotitle {
  font-size: 22px;
  cursor: pointer;
}

.main-content {
  padding: 15px;
}
</style>
<script>
// import { refreshToken } from "../../../api/UserAuthorize";
// import { GetAdminPermissionAdminMenu } from "../../../api/Privilege/Permission";
// import { GetCurrentAdmin } from "../../../api/Privilege/Admin";
import util from "./common/util";
import config from "./common/config";
import { UserManager } from "oidc-client";
export default {
  name: "Home",
  data() {
    return {
      // tableData: Array(20).fill(item),
      menuData: [
        {
          id: "2",
          text: "客户端",
          children: [
            {
              id: "2-1",
              text: "api资源",
              target: "/identity_server/api_resource"
            },
            {
              id: "2-2",
              text: "身份资源",
              target: "/identity_server/identity_resource"
            },
            {
              id: "2-3",
              text: "客户端",
              target: "/identity_server/client"
            }
          ]
        },
        {
          id: "1",
          text: "系统管理",
          children: [
            {
              id: "1-1",
              text: "菜单管理",
              target: "/admin/privilege/adminmenu"
            },
            {
              id: "1-2",
              text: "角色管理",
              target: "/admin/privilege/adminrole"
            },
            {
              id: "1-3",
              text: "用户管理",
              target: "/admin/privilege/application_user"
            }
          ]
        }
      ],
      defaultOpeneds: [],
      UserData: {
        name: "admin"
      },
      MyNewNoticeCount: 0
    };
  },
  methods: {
    userDropdownCommand: function(command) {
      var mgr = new UserManager(config);
      switch (command) {
        case "logout":
          sessionStorage.clear();
          mgr.signoutRedirect();
          this.$router.push({ name: "Home" });

          break;
        case "modifypassword":
          this.$router.push({ name: "ModifyPassword" });
          break;
        case "profile":
          this.$router.push({ name: "UserProfile" });
          break;
        case "register":
          this.$router.push({ name: "SchoolProfile" });
          break;
        case "suggest":
          this.$router.push({ path: "/app/suggest" });
          break;
        case "return":
          sessionStorage.clear();
          window.location.href = config.authority;
          break;
      }
    },
    linkIndex: function() {
      this.$router.push({ name: "Welcome" });
    },
    getAdminPermission: function() {
      var that = this;
      GetAdminPermissionAdminMenu().then(function(result) {
        if (result.success && result.data.length > 0) {
          that.menuData = result.data || [];
          if (that.menuData.length > 0) {
            that.defaultOpeneds = [
              that.menuData[0].target,
              that.menuData[0].children[0].target
            ];
          }
        }
      });
    },
    initUser: function() {
      let that = this;
      that.UserData = util.getUser();
    },
    initNewNoticeCount: function() {
      let that = this;
      getMyNewNoticeCount().then(function(result) {
        if (result.success) {
          that.MyNewNoticeCount = result.data || 0;
        }
      });
    }
  },
  created: function() {
    // this.initNewNoticeCount();
  },
  mounted: function() {
    let that = this;

    this.getAdminPermission();
    this.initUser();
  }
};
</script>
