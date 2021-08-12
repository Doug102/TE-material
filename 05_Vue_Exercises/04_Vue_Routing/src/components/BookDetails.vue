<template>
  <div>
    <h1 v-for="book in books" v-bind:key="book.isbn">{{ book.title }}</h1>
    <h2 v-for="book in books" v-bind:key="book.isbn">{{ book.author }}</h2>
    <img
      v-for="book in books"
      v-bind:key="book.isbn"
      v-bind:src="
        'http://covers.openlibrary.org/b/isbn/' + book.isbn + '-M.jpg'
      "
    />

    <div v-for="book in books" v-bind:key="book.isbn">
      <h3 v-if="book.read">I Have Read This Book</h3>
      <h3 v-else>I Have Not Read This Book</h3>
    </div>
  </div>
</template>

<script>
export default {
  name: "book-details",
  props: ["isbn"],
  data() {
    return {
      book: {
        title: "",
        author: "",
        read: false,
        isbn: "",
      },
    };
  },
  computed: {
    books() {
      return this.$store.state.books.filter((book) => {
        return book.isbn === this.isbn;
      });
    },
  },
};
</script>

<style>
</style>