<template>
  <div>
    <header>
    <router-link v-bind:to="{name: 'about'}">About</router-link> |
    <router-link v-bind:to="{name: 'products'}">Products</router-link>
    </header>
    <router-view />
  </div>
</template>

<script>
export default {};
</script>

<style>
#app {
  font-family: "Avenir", Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  max-width: 800px;
  margin: 60px auto 0 auto;
}
</style>
