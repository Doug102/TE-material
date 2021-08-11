<template>
  <div>
    <p id="message">{{ message }}</p>
    <h3>Pet number: {{ petNumber }}</h3>
    <h4>You are about to delete a pet. Are you sure?</h4>
    <a href="#" v-on:click="deletePet" class="btn btn-danger">Delete</a>
    <router-link class="btn btn-success" v-bind:to="{ name: 'Home' }"
      >Cancel</router-link
    >
  </div>
</template>

<script>
import petService from "@/services/PetService.js";
export default {
  name: "PetDelete",
  data() {
    return {
      petNumber: 0,
      message: "",
    };
  },
  created() {
    this.petNumber = this.$route.params.id;
  },
  methods: {
    deletePet() {
      console.log("Entered delete pet");
      petService
        .deletePet(this.petNumber)
        .then(() => {
          this.$router.push("/pets");
        })
        .catch((error) => {
          if (error.response) {
            this.message =
              "Error: HTTP Response Code: " + error.response.status;
            this.message += "    Description: " + error.response.statusText;
          } else {
            this.message = "Network Error";
          }
        });
    },
  },
};
</script>

<style scoped>
#message {
  background-color: coral;
  margin: 5px;
}

</style>