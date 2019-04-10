import Vue from 'vue'
import Router from 'vue-router'
import HelloWorld from '@/components/HelloWorld'

Vue.use(Router)

export default new Router({
  routes: [
    {
      path: '/',
      name: 'HelloWorld',
      component: HelloWorld
    },
    {
      path: '/identity_server/client',
      name: 'IdentityServerClient',
      component: resolve =>
        require(["../components/identity_server/client/index.vue"], resolve)
    },
    {
      path: '/identity_server/client/add',
      name: 'IdentityServerClientAdd',
      component: resolve =>
        require(["../components/identity_server/client/manager.vue"], resolve)
    }, {
      path: '/identity_server/client/edit/:Id',
      name: 'IdentityServerClientEdit',
      component: resolve =>
        require(["../components/identity_server/client/manager.vue"], resolve)
    },
    {
      path: '/identity_server/api_resource',
      name: 'IdentityServerApiResource',
      component: resolve =>
        require(["../components/identity_server/api_resource/index.vue"], resolve)
    },
    {
      path: '/identity_server/api_resource/add',
      name: 'IdentityServerApiResourceAdd',
      component: resolve =>
        require(["../components/identity_server/api_resource/manager.vue"], resolve)
    }, {
      path: '/identity_server/api_resource/edit/:Id',
      name: 'IdentityServerApiResourceEdit',
      component: resolve =>
        require(["../components/identity_server/api_resource/manager.vue"], resolve)
    },
    {
      path: '/identity_server/identity_resource',
      name: 'IdentityServerIdentityResource',
      component: resolve =>
        require(["../components/identity_server/identity_resource/index.vue"], resolve)
    },
    {
      path: '/identity_server/identity_resource/add',
      name: 'IdentityServerIdentityResourceAdd',
      component: resolve =>
        require(["../components/identity_server/identity_resource/manager.vue"], resolve)
    }, {
      path: '/identity_server/identity_resource/edit/:Id',
      name: 'IdentityServerIdentityResourceEdit',
      component: resolve =>
        require(["../components/identity_server/identity_resource/manager.vue"], resolve)
    }
  ]
})
