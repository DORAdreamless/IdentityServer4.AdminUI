import config from './config'
import moment  from 'moment';
var SIGN_REGEXP = /([yMdhsm])(\1*)/g;
var DEFAULT_PATTERN = 'yyyy-MM-dd';



function padding(s, len) {
  var len = len - (s + '').length;
  for (var i = 0; i < len; i++) {
    s = '0' + s;
  }
  return s;
};
export default {
  getQueryStringByName: function (name) {
    var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)", "i");
    var r = window.location.search.substr(1).match(reg);
    var context = "";
    if (r != null)
      context = r[2];
    reg = null;
    r = null;
    return context == null || context == "" || context == "undefined" ? "" : context;
  },
  formatDateTime: function (value, pattern = "YYYY-MM-DD") {
    if (!value)
      return "";
    return new moment(value).format(pattern);
  },
  formatDate: {
    format: function (date, pattern) {
      pattern = pattern || DEFAULT_PATTERN;
      return pattern.replace(SIGN_REGEXP, function ($0) {
        switch ($0.charAt(0)) {
          case 'y':
            return padding(date.getFullYear(), $0.length);
          case 'M':
            return padding(date.getMonth() + 1, $0.length);
          case 'd':
            return padding(date.getDate(), $0.length);
          case 'w':
            return date.getDay() + 1;
          case 'h':
            return padding(date.getHours(), $0.length);
          case 'm':
            return padding(date.getMinutes(), $0.length);
          case 's':
            return padding(date.getSeconds(), $0.length);
        }
      });
    },
    parse: function (dateString, pattern) {
      var matchs1 = pattern.match(SIGN_REGEXP);
      var matchs2 = dateString.match(/(\d)+/g);
      if (matchs1.length == matchs2.length) {
        var _date = new Date(1970, 0, 1);
        for (var i = 0; i < matchs1.length; i++) {
          var _int = parseInt(matchs2[i]);
          var sign = matchs1[i];
          switch (sign.charAt(0)) {
            case 'y':
              _date.setFullYear(_int);
              break;
            case 'M':
              _date.setMonth(_int - 1);
              break;
            case 'd':
              _date.setDate(_int);
              break;
            case 'h':
              _date.setHours(_int);
              break;
            case 'm':
              _date.setMinutes(_int);
              break;
            case 's':
              _date.setSeconds(_int);
              break;
          }
        }
        return _date;
      }
      return null;
    }
  }
  ,
  isNullOrEmpty: function (value) {
    if (value == null)
      return true;
    return this.trim(value).length == 0;
  },

  download: function (url) {
    let sements = '?';
    if (url.indexOf('?') > 0) {
      sements = '&';
    }
    window.location.href = url + sements + 'token=' + getToken();
  },

  getUser: function () {
    var key = `oidc.user:${config.authority}:${config.client_id}`;
    var user = JSON.parse(sessionStorage.getItem(key) || '{}');
    return user.profile;
  },

  getToken: function () {
    var key = `oidc.user:${config.authority}:${config.client_id}`;
    var user = JSON.parse(sessionStorage.getItem(key) || '{}');
    return user.token_type + " " + user.access_token;
  },

  setToken: function (token) {
    sessionStorage.setItem(SESSION_KEY, JSON.stringify(token));
  }
  ,
  getRefreshToken: function () {
    var user = JSON.parse(sessionStorage.getItem(SESSION_KEY) || '{}');
    return user['refresh_token'] || '';
  },

  trim: function (value) {
    let text = value || '';
    return text.replace(/\s/g, '');
  },

  getString: function (value) {
    if (value == null)
      return '';
    return value.toString();
  },
  uuid: function () {
    return 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, function (c) {
      var r = Math.random() * 16 | 0, v = c == 'x' ? r : (r & 0x3 | 0x8);
      return v.toString(16);
    });

  },
  getFromArray: function (value, arr, property) {
    arr = arr || [];
    var result = undefined;
    for (var i = 0; i < arr.length; i++) {
      if (property) {
        if (arr[i][property] == value) {
          result = arr[i];
          break;
        }
      } else {
        if (arr[i] == value) {
          result = arr[i];
          break;
        }
      }
    }
    return result;
  }
};

export const SESSION_KEY = 'SESSION_USER';
