<template>
  <div>
    <h4>{{ activeProductID }}</h4>
  </div>
</template>

<script>
export default {
  data() {
    return {
      activeProductID: 0,
    };
  },
  created() {
    this.activeProductID = this.$route.params.id;
    console.log(this.activeProductID);
  },
};
</script>

<style>
</style>