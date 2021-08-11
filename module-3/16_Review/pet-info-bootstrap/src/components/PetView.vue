<template>
  <table class="table table-bordered table-hover">
    <thead>
      <tr>
        <th scope="col">Name</th>
        <th scope="col">age</th>
        <th scope="col">Type</th>
        <th scope="col">Breed</th>
        <th scope="col">Image</th>
      </tr>
    </thead>
    <tbody>
      <tr v-for="pet in pets" v-bind:key="pet.id">
        <td>{{ pet.name }}</td>
        <td>{{ pet.age }}</td>
        <td>{{ pet.type }}</td>
        <td>{{ pet.breed }}</td>
        <td>
          <a v-bind:href="pet.image" target="blank">{{ pet.image }} </a>
        </td>
      </tr>
    </tbody>
  </table>
</template>

<script>
export default {
  name: "PetView",
  computed: {
    pets() {
      return this.$store.state.pets;
    },
  },
};
</script>

<style scoped>
table,
th,
td {
  border: 1px solid black;
}

table {
  width: 50%;
  margin: 20px;
}
</style>