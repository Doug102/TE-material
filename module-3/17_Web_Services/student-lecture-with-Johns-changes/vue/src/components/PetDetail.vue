<template>
  <table class="table table-bordered table-hover">
    <tbody>
      <tr>
        <th>Name</th>
        <td>{{ pet.name }}</td>
      </tr>

      <tr>
        <th>Age</th>
        <td>{{ pet.age }}</td>
      </tr>

      <tr>
        <td>Type</td>
        <td>{{ pet.type }}</td>
      </tr>

      <tr>
        <td>Breed</td>
        <td>{{ pet.breed }}</td>
      </tr>

      <tr>
        <td>Image</td>
        <td>
          <a v-bind:href="pet.image" target="_blank">{{ pet.name }} </a>
        </td>
      </tr>
    </tbody>
  </table>
</template>

<script>
export default {
  name: "PetDetail",

  data: function () {
    return {
      pet: {},
    };
  },

  props: ["id"],

  created() {
    let pets = this.$store.state.pets;
    this.pet = pets.find((item) => {
      return item.id == this.id;
    });
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