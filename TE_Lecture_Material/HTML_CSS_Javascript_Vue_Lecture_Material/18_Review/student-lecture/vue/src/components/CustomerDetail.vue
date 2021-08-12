<template>
  <table class="table table-bordered table-hover">
    <tbody>
      <tr>
        <td>Name</td>
        <td>{{ customer.name }}</td>
      </tr>

      <tr>
        <td>Phone</td>
        <td>{{ customer.phone }}</td>
      </tr>

      <tr>
        <td>Email</td>
        <td>{{ customer.email }}</td>
      </tr>
    </tbody>
  </table>
</template>

<script>
export default {
  name: "CustomerDetail",

  data: function () {
    return {
      customer: {},
    };
  },

  props: ["id"],

  created() {
    let customers = this.$store.state.customers;
    this.customer = customers.find((item) => {
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