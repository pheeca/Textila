import Vue from 'vue';
import App from './App.vue';
import vuetify from './plugins/vuetify';
import router from './router';

import Centered from './layout/Centered.vue';
import Main from './layout/Main.vue';

import 'material-design-icons-iconfont/dist/material-design-icons.css';


Vue.config.productionTip = false;

Vue.component('centered-layout',Centered);
Vue.component('main-layout',Main);


new Vue({
  vuetify,
  router,
  render: h => h(App)
}).$mount('#app');
