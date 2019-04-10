/**
 * http配置
 */
// 引入axios以及element ui中的loading和message组件
import axios from 'axios'
import { Loading, Message } from 'element-ui'
import util from './util'
import Router from "vue-router";
import config from './config'
import { UserManager } from "oidc-client";


var loading = undefined;

var mgr = new UserManager(config);
// 超时时间
axios.defaults.timeout = 50000
// http请求拦截器
axios.interceptors.request.use(config => {

  let token = util.getToken();
  if (token.length > 20) {
    config.headers['Authorization'] = token;
  }
  loading = Loading.service({ fullscreen: true });

  // element ui Loading方法
  return config
}, error => {
  //关闭loading
  loading.close();
  Message.error({
    message: '加载超时'
  })
  return Promise.reject(error)
})
// http响应拦截器
axios.interceptors.response.use(resp => {// 响应成功关闭loading
  //关闭loading
  loading.close();
  var result = resp.data || {};
  if (result.success == false) {
    Message.error({
      message: result.message
    })
  }
  return result
}, error => {
  if (loading) {
    loading.close()
  }
  if (error.response) {
    if (error.response.status == 401) {
      sessionStorage.clear();
      mgr.signinRedirect();
    }
  }
  let message = undefined;
  if (error.response) {
    if (error.response.data) {
      message = error.response.data.error_description;
    }
  }
  message = message || '加载失败';
  Message.error({
    message: message
  })
  return Promise.reject(error)
})

export default axios
