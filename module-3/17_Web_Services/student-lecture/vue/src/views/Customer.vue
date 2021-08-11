<template>
  <customer-detail v-bind:id="customerNumber" />
</template>

<script>
import CustomerDetail from "../components/CustomerDetail.vue";
export default {
  components: {
    CustomerDetail,
  },

    data() {
    return {
      customerNumber: 0,
    }
  },

  created() {
      this.customerNumber = this.$route.params.id;
  },
};
</script>

<style>
</style>