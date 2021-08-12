<template>
  <div>
    <router-link class="btn btn-success" v-bind:to="{ name: 'Pets' }"
      >List</router-link
    >
    <router-link
      class="btn btn-danger"
      v-bind:to="{ name: 'PetUpdate', params: { id: pet.id } }"
      >Update</router-link
    >
    <router-link
      class="btn btn-danger"
      v-bind:to="{ name: 'PetDelete', params: { id: pet.id } }"
      >Delete</router-link
    >

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
          <th>Type</th>
          <td>{{ pet.type }}</td>
        </tr>

        <tr>
          <th>Breed</th>
          <td>{{ pet.breed }}</td>
        </tr>

        <tr>
          <th>Image</th>
          <td>
            <a v-bind:href="pet.image" target="_blank">{{ pet.name }} </a>
          </td>
        </tr>
      </tbody>
    </table>
  </div>
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