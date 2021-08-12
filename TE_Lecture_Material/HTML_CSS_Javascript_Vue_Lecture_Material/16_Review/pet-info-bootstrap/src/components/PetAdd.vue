<template>
  <div class="container">
    <a
      v-on:click="isFormShown = true"
      v-if="!isFormShown"
      class="btn btn-success"
      >Add Pet</a
    >

    <form v-on:submit.prevent="onSubmit" v-if="isFormShown">
      <div class="form-group">
        <label for="name">Name: </label>
        <input
          required
          type="text"
          id="name"
          name="name"
          class="form-control"
          v-model="newPet.name"
        />
      </div>

      <div class="form-group">
        <label for="age">Age: </label>
        <input
          type="number"
          id="age"
          name="age"
          class="form-control"
          v-model="newPet.age"
        />
      </div>
      <div class="form-group">
        <label for="type">Type: </label>
        <input
          type="text"
          id="type"
          name="type"
          class="form-control"
          v-model="newPet.type"
        />
      </div>
      <div class="form-group">
        <label for="breed">Breed: </label>
        <input
          type="text"
          id="breed"
          name="breed"
          class="form-control"
          v-model="newPet.breed"
        />
      </div>

      <div class="form-group">
        <label for="image">Image URL: </label>
        <input
          type="text"
          id="image"
          name="image"
          class="form-control"
          v-model="newPet.image"
        />
      </div>

      <input type="submit" class="btn btn-success" />
      <input
        type="button"
        v-on:click.prevent="resetForm"
        class="btn btn-success"
        value="Cancel"
      />
    </form>
  </div>
</template>

<script>
export default {
  name: "PetAdd",
  data() {
    return {
      newPet: {},

      isFormShown: false,
    };
  },

  methods: {
    onSubmit() {
      this.$store.commit("ADD_PET", this.newPet);
      this.resetForm();
    },

    resetForm() {
      this.newPet = {};
      this.isFormShown = false;
    },
  },
};
</script>

<style>
form {
  width: 50%;
  margin: 20px;
}

label {
  text-align: left;
  display: block;
}

.btn {
  margin: 0 5px;
}
</style>