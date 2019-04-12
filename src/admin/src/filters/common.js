import Vue from 'vue'
import moment from 'moment';

Vue.filter('datetime', function (value,pattern='YYYY-MM-DD HH:mm') {
  if (!value) return '-';
  return new moment(value).format(pattern);
});

Vue.filter('date', function (value,pattern='YYYY-MM-DD') {
  if (!value) return '-';
  return new moment(value).format(pattern);
});

Vue.filter('month', function (value, pattern = 'YYYY年M月') {
  if (!value) return '-';
  return new moment(value).format(pattern);
});