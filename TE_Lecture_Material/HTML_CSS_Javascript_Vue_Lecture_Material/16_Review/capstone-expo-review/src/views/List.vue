<template>
  <div id="home">
    <top />
    <list />
  </div>
</template>

<script>
import List from "@/components/List.vue";
import Top from "@/components/Top.vue";

export default {
  name: "Home",
  components: {
    List,
    Top
  },
};
</script>

