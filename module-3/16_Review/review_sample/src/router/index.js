import Vue from 'vue'
import VueRouter from 'vue-router'


import About from '../views/About.vue'
import Home from '../views/Home.vue'
import NotFound from '../views/NotFound.vue'
import Owners from '../views/Owners.vue'
import Pets from '../views/Pets.vue'


Vue.use(VueRouter)

const routes = [
  {
    path: '/about',
    name: 'About',
    component: About
  },
  {
    path: '/',
    name: 'Home',
    component: Home
  },
  {
    path: '*',
    name: 'Not Found',
    component: NotFound
  },
  {
    path: '/owners',
    name: 'Owners',
    component: Owners
  },
  {
    path: '/pets',
    name: 'Pets',
    component: Pets
  },
]

const router = new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes
})

export default router
