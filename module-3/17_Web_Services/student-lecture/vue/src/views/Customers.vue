<template>
  <div>
    <customer-add />
    <customer-view />
  </div>
</template>

<script>
import CustomerAdd from "../components/CustomerAdd.vue";
import CustomerView from "../components/CustomerView.vue";

export default {
  name: 'Customers',

  components: {
    CustomerAdd,
    CustomerView,
  },
};
</script>

<style>
</style>