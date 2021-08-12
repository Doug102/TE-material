<template>
  <div>
    <p id="message">{{ message }}</p>
    
    <h3>Pet number {{ petNumber }}</h3>
    <h4>You are about to delete a pet. Are you sure?</h4>

    <a href="#" class="btn btn-danger" v-on:click="deletePet">Delete </a>

    <router-link class="btn btn-success" v-bind:to="{ name: 'Home' }">
      Cancel</router-link
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
          console.log("Reached then in deletePet");
          this.$router.push("/pets");
        })
        .catch((error) => {
          console.log("Reached catch in deletePet");
          if (error.response) {
            this.message =
              "Error: HTTP Response Code: " + error.response.status;
            this.message += "    Description: " + error.response.statustext;
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
