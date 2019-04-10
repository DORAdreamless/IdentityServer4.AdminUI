export const base='http://localhost:5002';


export const APP_NAME='';

export const APP_TITLE='';

//export const AUTHSERVER='http://medical.weixiaobang.cn';


const config = {
  authority: "http://localhost:5000",
  client_id: "jyj.zhxy.weixiaobang.cn",
  redirect_uri: "http://localhost:8080/login/notify",
  response_type: "id_token token",
  scope: "openid profile role jyj",
  post_logout_redirect_uri: "http://localhost:8080/index.html"
};

export default config;