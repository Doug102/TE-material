<template>
  <div class="products">
    <h1>Products for just us</h1>
    <products-list />
  </div>
</template>

<script>
  import ProductsList from '@/components/ProductsList';

  export default {
    components: {
      ProductsList
    }
  };
</script>