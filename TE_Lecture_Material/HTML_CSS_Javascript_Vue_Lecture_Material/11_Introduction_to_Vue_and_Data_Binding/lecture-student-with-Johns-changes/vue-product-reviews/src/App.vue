<template>
  <div id="app">
   <!-- <HelloWorld msg="Welcome to Your Vue.js App"/> -->
     <product-review> </product-review>
     <img alt="Vue logo" src="./assets/logo.png"> 
  </div>
</template>

<script>
//import HelloWorld from './components/HelloWorld.vue'
import ProductReview from './components/ProductReview.vue'

export default {
  name: 'App',
  components: {
    //HelloWorld,
    ProductReview
  }
}
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
