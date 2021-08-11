<template>
  <div id="home">
    <top />
    <main-top />
    <main-bottom />
  </div>
</template>

<script>
import MainTop from "@/components/MainTop.vue";
import MainBottom from "@/components/MainBottom.vue";
import Top from "@/components/Top.vue";

export default {
  name: "Home",
  components: {
    MainTop,
    MainBottom,
    Top,
  },
};
</script>
