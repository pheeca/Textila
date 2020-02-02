<template> 
  <v-content>
    <img alt="Vue logo" src="../assets/logo.png">
    <li  v-for="(item, index) in count" v-bind:key="index">
    {{ item.message }}
  </li>
  </v-content>
</template>

<script>
import backendService from './../services/backendService';
export default {
  name: 'home',
  components: {
  },
  data: function () {
    return {
      count: backendService.getPosts()
    }
  },
}
</script>
