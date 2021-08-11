import Vue from 'vue'
import App from './App.vue'
import axios from 'axios'
import store from './store/index'
import router from './router'

window.axios = axios
Vue.prototype.$http = axios
Vue.config.productionTip = false

new Vue({
  store,
  router,
  render: h => h(App)
}).$mount('#app')
