import Vue from 'vue'
import Router from 'vue-router'
import store from '@/store/index'

import Login from '@/views/Login.vue'
import Logout from '@/views/Logout.vue'
import Register from '@/views/Register.vue'

import About from '@/views/About.vue'
import Customer from '@/views/Customer.vue'
import Customers from '@/views/Customers.vue'
import Home from '@/views/Home.vue'
import NotFound from '@/views/NotFound.vue'
import Pet from '@/views/Pet.vue'
import PetDelete from '@/views/PetDelete.vue'
import Pets from '@/views/Pets.vue'
import PetUpdate from '@/views/NotFound.vue'


Vue.use(Router)

/**
 * The Vue Router is used to "direct" the browser to render a specific view component
 * inside of App.vue depending on the URL.
 *
 * It also is used to detect whether or not a route requires the user to have first authenticated.
 * If the user has not yet authenticated (and needs to) they are redirected to /login
 * If they have (or don't need to) they're allowed to go about their way.
 */

const router = new Router({
  mode: 'history',
  base: process.env.BASE_URL,
  routes: [
    {
      path: '/',
      name: 'Home',
      component: Home,
      meta: {
        requiresAuth: false
      }
    },

    {
      path: '/about',
      name: 'About',
      component: About,
      meta: {
        requiresAuth: false
      }
    },

    {
      path: '/customer/:id',
      name: 'Customer',
      component: Customer,
      meta: {
        requiresAuth: false
      }
    },

    {
      path: '/customers',
      name: 'Customers',
      component: Customers,
      meta: {
        requiresAuth: false
      }
    },

    {
      path: "/login",
      name: "Login",
      component: Login,
      meta: {
        requiresAuth: false
      }
    },

    {
      path: "/logout",
      name: "Logout",
      component: Logout,
      meta: {
        requiresAuth: false
      }
    },

    {
      path: '/pet/:id',
      name: 'PetDetails',
      component: Pet,
      meta: {
        requiresAuth: false
      }
    },

    {
      path: '/petdelete/:id',
      name: 'PetDelete',
      component: PetDelete,
      meta: {
        requiresAuth: true
      }
    },

    {
      path: '/pets',
      name: 'Pets',
      component: Pets,
      meta: {
        requiresAuth: false
      }
    },

    {
      path: '/petupdate/:id',
      name: 'PetUpdate',
      component: PetUpdate,
      meta: {
        requiresAuth: false
      }
    },


    {
      path: "/register",
      name: "Register",
      component: Register,
      meta: {
        requiresAuth: false
      }
    },

    {
      path: '*',
      name: "NotFound",
      component: NotFound,
      meta: {
        requiresAuth: false
      }
    },

  ]
})

router.beforeEach((to, from, next) => {
  // Determine if the route requires Authentication
  const requiresAuth = to.matched.some(x => x.meta.requiresAuth);

  // If it does and they are not logged in, send the user to "/login"
  if (requiresAuth && store.state.token === '') {
    next("/login");
  } else {
    // Else let them go to their next destination
    next();
  }
});

export default router;
