<template>
  <div class="home">
    <img alt="Vue logo" src="https://previews.123rf.com/images/vastard/vastard1906/vastard190600055/124538305-dog-cat-pet-logo-vector-icon-illustration-negative-space-style.jpg">
    <HelloWorld msg="Welcome to the PetInfo Application"/>
  </div>
</template>

<script>
// @ is an alias to /src
import HelloWorld from '@/components/HelloWorld.vue'

export default {
  name: 'Home',
  components: {
    HelloWorld
  }
}
</script>

<style scoped>

img {
  height:300px;
}
</style>
