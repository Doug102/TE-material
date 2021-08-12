<template>
  <div id="app">
    <top-header />
    <router-view />
    <bottom-footer />
  </div>
</template>

<script>
import TopHeader from "@/components/TopHeader.vue";
import BottomFooter from "@/components/BottomFooter.vue";

export default {
  name: "App",

  components: {
    TopHeader,
    BottomFooter,
  },
};
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
