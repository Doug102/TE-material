<template>
  <pet-detail v-bind:id="petNumber" />
</template>

<script>
import PetDetail from "@/components/PetDetail.vue";
export default {
  name: "Pet",

  components: {
    PetDetail,
  },

  data() {
    return {
      petNumber: 0,
    };
  },

  created() {
    this.petNumber = this.$route.params.id;
  },
};
</script>

<style>
</style>