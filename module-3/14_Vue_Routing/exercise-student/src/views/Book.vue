<template>
  <div>
     
      <book-details v-bind:isbn="isbn" />
  </div>
</template>

<script>
import BookDetails from "@/components/BookDetails.vue";
export default {
components: {
    BookDetails,
},
data() {
    return {
        isbn: 0,
    }
},
created() {
    this.isbn = this.$route.params.isbn;
   
},
}
</script>

<style>

</style>