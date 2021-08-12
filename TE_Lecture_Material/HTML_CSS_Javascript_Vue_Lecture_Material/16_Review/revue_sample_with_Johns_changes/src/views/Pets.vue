<template>
  <div>
    <h3>Pets view</h3>
    <table class="table table-bordered table-hover">
      <thead>
        <tr>
          <th>Name</th>
          <th>Age</th>
          <th>Type</th>
          <th>Breed</th>
          <th></th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="pet in pets" v-bind:key="pet.id">
          <td>{{ pet.name }}</td>
          <td>{{ pet.age }}</td>
          <td>{{ pet.type }}</td>
          <td>{{ pet.breed }}</td>
          <td>
            <button class="btn btn-danger" v-on:click="deletePet(pet.id)">
              Delete
            </button>
          </td>
        </tr>
      </tbody>
    </table>
    <pet-add />
  </div>
</template>

<script>
import PetAdd from "../components/PetAdd.vue";

export default {
  methods: {
    deletePet(petId) {
      console.log(petId);
      this.$store.commit("DELETE_PET", petId);
    },
  },
  components: {
    PetAdd,
  },
  computed: {
    pets() {
      return this.$store.state.pets;
    },
  },
};
</script>

<style>
</style>