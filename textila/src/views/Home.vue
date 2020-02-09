<template> 
  <v-content>
    <img alt="Vue logo" src="../assets/logo.png">
    <li  v-for="(item, index) in count" v-bind:key="index">
    {{ item }}
  </li>
  </v-content>
</template>

<script>
export default {
  name: 'home',
  components: {
  },
  data: function () {
    return {
      count: ['Under Construction']
    }
  },
}
</script>
