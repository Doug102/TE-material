import Vue from 'vue'
import VueRouter from 'vue-router'

import About from '@/views/About';
import ProductDetail from '@/views/ProductDetail';
import Products from '@/views/Products';

Vue.use(VueRouter)

const routes = [
  {
    path: '/',
    name: 'products',
    component: Products
  },
  {
    path: '/products',
    name: 'products',
    component: Products
  },
  {
    path: '/products/:id',
    name: 'product-detail',
    component: ProductDetail
  },
  {
    path: '/about',
    name: 'about',
    component: About
  }
]

const router = new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes
})

export default router
