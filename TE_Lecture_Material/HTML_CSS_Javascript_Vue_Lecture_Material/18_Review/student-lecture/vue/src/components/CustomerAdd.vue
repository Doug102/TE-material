<template>
  <div class="container">
    <a
      v-on:click="isFormShown = true"
      v-if="!isFormShown"
      class="btn btn-success"
      >Add Customer</a
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
          v-model="newCustomer.name"
        />
      </div>

      <div class="form-group">
        <label for="phone">Phone: </label>
        <input
          type="text"
          id="phone"
          name="phone"
          class="form-control"
          v-model="newCustomer.phone"
        />
      </div>

      <div class="form-group">
        <label for="email">Email: </label>
        <input
          type="text"
          id="email"
          name="email"
          class="form-control"
          v-model="newCustomer.email"
        />
      </div>

      <input type="submit" class="btn btn-success" />
      <input type="button" v-on:click.prevent="resetForm" class="btn btn-success" value="Cancel">
    </form>
  </div>
</template>

<script>
export default {
  name: 'CustomerAdd',
  data() {
    return {
      newCustomer: {},

      isFormShown: false,
    };
  },

  methods: {
    onSubmit() {
      this.$store.commit("ADD_CUSTOMER", this.newCustomer);
      this.resetForm();
    },

    resetForm() {
      this.newCustomer = {};
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

.btn{
  margin: 0 5px;
}
</style>