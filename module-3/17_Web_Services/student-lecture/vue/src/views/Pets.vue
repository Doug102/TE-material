<template>
  <div>
    <pet-add />
    <pet-view />
  </div>
</template>

<script>
import PetAdd from "../components/PetAdd.vue";
import PetView from "../components/PetView.vue";

export default {
  components: {
    PetView,
    PetAdd,
  },
};
</script>

<style>
</style>