<template>
  <div>
    <h1>Home Page</h1>

    <h5>Pets</h5>
    <pet-view />
    <pet-add />

    <h5>Customers</h5>
    <customer-view />
    <customer-add />
  </div>
</template>

<script>
import PetView from "./PetView";
import PetAdd from "./PetAdd";
import CustomerView from "./CustomerView";
import CustomerAdd from "./CustomerAdd";

export default {
  name: "Home",
  components: {
    PetView,
    PetAdd,
    CustomerView,
    CustomerAdd,
  },
};
</script>

<style>
</style>