export const base='http://localhost:5003';


export const APP_NAME='';

export const APP_TITLE='';

//export const AUTHSERVER='http://medical.weixiaobang.cn';


const config = {
  authority: "http://localhost:5000",
  client_id: "js",
  redirect_uri: "http://localhost:8080/static/callback.html",
  response_type: "id_token token",
  scope: "openid profile role api1",
  post_logout_redirect_uri: "http://localhost:5000"
};

export default config;