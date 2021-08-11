<template>
  <div id="navbar">
    <div id="menu">
      <router-link to="/">Home</router-link> |
      <router-link to="/list">List</router-link> |
       <router-link to="/print">Print</router-link>
    </div>
    <img src="../assets/Long_Logo_All_white.png" />
  </div>
</template>

<script>
export default {
  name: "Top",
  data: function () {
    return {};
  },

  computed: {},
};
</script>

<style scoped>
#navbar {
  padding: 10px;
  display: grid;
  grid-template-columns: 1fr 1fr 3fr 1fr;
  grid-template-areas: "menu . img .";
}

#menu{
  grid-area: menu;
}

img{
  grid-area: img;
}

#navbar a {
  color: #3b3e42;
}

#navbar a.router-link-exact-active {
  font-weight: bold;
}

img {
  padding-left: 50px;
  height: 50px;
}

@media only screen and (max-width: 1000px) {
  img {
    display: none;
  }
}
</style>
