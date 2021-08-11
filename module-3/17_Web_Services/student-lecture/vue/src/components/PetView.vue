<template>
  <div>
    <p id="message">{{ message }}</p>
    <table class="table table-bordered table-hover">
      <thead>
        <tr>
          <th scope="col">Name</th>
          <th scope="col">age</th>
          <th scope="col">Type</th>
          <th scope="col">Breed</th>
          <th scope="col">Image</th>
          <th></th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="(pet, index) in pets" v-bind:key="index">
          <td>{{ pet.name }}</td>
          <td>{{ pet.age }}</td>
          <td>{{ pet.type }}</td>
          <td>{{ pet.breed }}</td>
          <td>
            <a v-bind:href="pet.image" target="blank">{{ pet.image }} </a>
          </td>
          <td>
            <router-link v-bind:to="{ name: 'Pet', params: { id: pet.id } }"
              >Details</router-link
            >
          </td>
        </tr>
      </tbody>
    </table>
  </div>
</template>

<script>
import petService from "../services/PetService.js";

export default {
  name: "PetView",

  data() {
    return {
      message: "",
    };
  },

  computed: {
    pets() {
      return this.$store.state.pets;
    },
  },

  created() {
    this.message = "";

    petService
      .getPets()
      .then((response) => {
        this.$store.commit("REPLACE_PETS", response.data);
      })
      .catch((error) => {
        if (error.response) {
          this.message =
            "Error: HTTP Response Code: " + error.response.data.status;
          this.message += "    Description: " + error.response.data.title;
        } else {
          this.message = "Network Error";
        }
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

#message{
  background-color:coral;
  margin: 5px;
}
</style>