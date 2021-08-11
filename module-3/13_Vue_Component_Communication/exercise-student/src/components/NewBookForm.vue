<template>
  <form class="new-book-form" v-on:submit.prevent="addNewBook">
    <label for="title">Title:</label>
    <input class="title-input" id="title" type="text" v-model="newBook.title" />
    <label for="author">Author:</label>
    <input
      class="author-input"
      id="author"
      type="text"
      v-model="newBook.author"
    />
    <label for="isbn">ISBN:</label>
    <input class="isbn-input" id="isbn" type="text" v-model="newBook.isbn" />
    <input type="submit" value="Save" />
    <input type="button" value="Cancel" v-on:click.prevent="resetForm" />
  </form>
</template>

<script>
export default {
  name: "new-book-form",
  data() {
    return {
      newBook: {
        title: "",
        author: "",
        read: false,
        isbn: "",
      },
    };
  },
  methods: {
    addNewBook() {
      this.$store.commit("ADD_NEW_BOOK", this.newBook);
      this.resetForm();
    },
    resetForm() {
      this.newBook = {};
    },
  },
};
</script>

<style>
div.form-element {
  margin-top: 10px;
}
div.form-element > label {
  display: block;
}
div.form-element > input,
div.form-element > select {
  height: 30px;
  width: 300px;
}
div.form-element > textarea {
  height: 60px;
  width: 300px;
}
form > input[type="button"] {
  width: 100px;
}
form > input[type="submit"] {
  width: 100px;
  margin-right: 10px;
}
</style>