<template>
  <div id="app">
    <div id="nav">
      <router-link v-bind:to="{ name: 'Home' }">Home</router-link> |
      <router-link v-bind:to="{ name: 'About' }">About</router-link> |
      <router-link v-bind:to="{ name: 'Customers' }">Customers</router-link> |
      <router-link v-bind:to="{ name: 'Pets' }">Pets</router-link>
    </div>

    <router-view />
    <h5 class="footer">Copyright &copy; 2021, NoSuchCompany</h5>
  </div>
</template>

<script>

export default {
  name: "App",
}


</script>


<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
}

#nav {
  padding: 30px;
}

#nav a {
  font-weight: bold;
  color: #2c3e50;
}

#nav a.router-link-exact-active {
  color: #42b983;
}

.footer {
  font-size: 0.9rem;
}
</style>
