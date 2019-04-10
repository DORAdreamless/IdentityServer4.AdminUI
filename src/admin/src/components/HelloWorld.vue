<template>
  <div class="hello">
    <el-button @click="onTest()">test</el-button>
    <pre>{{ msg }}</pre>
  </div>
</template>

<script>
import axios from 'axios'
export default {
  name: "HelloWorld",
  data() {
    return {
      msg: {}
    };
  },
  methods: {
    onTest: function() {
      axios({
        url: `/api/Configuration/client/create`,
        method: "POST",
        data: { ClientId: "abc", ClientName: "abc" }
      }).then(result => {
        this.msg = result.data;
      });
    }
  }
};
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
</style>
