import Vue from 'vue'
import VueRouter from 'vue-router'
import Home from '../views/Home.vue'
import List from '../views/List.vue'
import Print from '../views/Print.vue'

Vue.use(VueRouter)

const routes = [
  {
    path: '/',
    name: 'Home',
    component: Home
  },

  {
    path: '/home',
    alias: '/',
    component: Home
  },

  {
    path: '/list',
    name: 'List',
    component: List
  },
  
  {
    path: '/print',
    name: 'Print',
    component: Print
  },

  {
    path: "*",
    redirect: "/",
  },

]

const router = new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes
})

export default router
