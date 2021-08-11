<template>
  <div id="nav">
    <router-link to="/">Home</router-link> |
    <router-link to="/about">About</router-link> |
    <router-link v-bind:to="{name:'Pets'}">Pets</router-link> |
    <router-link v-bind:to="{name:'Owners'}">Owners</router-link> 
  </div>
</template>

