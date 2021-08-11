<template>
  <div id="nav">
    <router-link v-bind:to="{ name: 'Home' }">Home</router-link> |
    <router-link v-bind:to="{ name: 'About' }">About</router-link> |
    <router-link v-bind:to="{ name: 'Customers' }">Customers</router-link> |
    <router-link v-bind:to="{ name: 'Pets' }">Pets</router-link>

    <span v-if="$store.state.user.username">
      <router-link v-bind:to="{ name: 'Logout' }"> | Logout</router-link></span
    >
    <span v-else
      ><router-link v-bind:to="{ name: 'Login' }"> | Login</router-link></span
    >

    <p v-if="$store.state.user.username">
      User: {{ $store.state.user.username }}
    </p>
    <p v-else>Not logged in</p>
  </div>
</template>
