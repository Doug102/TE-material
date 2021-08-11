<template>
  <div>
    <div class="top">
      <div class="top-left">
        <div
          class="iframe-container"
          style="overflow: hidden; padding-top: 56.25%; position: relative"
        >
          <iframe
            id="mainVideo"
            allow="microphone; camera"
            v-bind:src="mainVideo"
            frameborder="0"
          ></iframe>
        </div>
      </div>

      <div class="top-right">
        <span id="title-text">
          <h1 id="topTitle">{{ topTitleLine }}</h1>
          <p id="secondTitle">{{ secondTitleLine }}</p>

          <hr />

          <ol>
            <li v-for="item in this.instructions" v-bind:key="item.line">
              {{ item.line }}
            </li>
          </ol>

          <hr />
          <p id="tipsHeading">{{ tipsHeading }}</p>
          <ul>
            <li v-for="item in this.tips" v-bind:key="item.line">
              {{ item.line }}
            </li>
          </ul>
        </span>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "MainTop",
  data: function () {
    return {};
  },

  computed: {
    topTitleLine() {
      return this.$store.state.topTitleLine;
    },

    secondTitleLine() {
      return this.$store.state.secondTitleLine;
    },

    mainVideo() {
      return this.$store.state.mainVideo;
    },

    tipsHeading() {
      return this.$store.state.tipsHeading;
    },

    tips() {
      return this.$store.state.tips;
    },

    instructions() {
      return this.$store.state.instructions;
    },
  },
};
</script>

<style scoped>
iframe {
  border: 0;
  height: 100%;
  left: 0;
  position: absolute;
  top: 0;
  width: 100%;
}
body {
  font-family: Tahoma, Calibri, "Sans Serif";
  background-color: #2196f3;
}

.top {
  display: grid;
  grid-template-columns: 1fr 1fr;
  grid-template-areas: "left right";
  background-color: rgba(255, 255, 255, 0.8);
}

.top-left {
  grid-area: left;
}

.top-right {
  grid-area: right;
  margin: 15px;
  display: flex;
}

#topTitle,
#secondTitle,
#tipsHeading {
  text-align: center;
  font-weight: bold;
}

ol,
ul,
.schedule {
  text-align: left;
}

ol li {
  padding-top: 15px;
}

@media only screen and (max-width: 1000px) {
  .top {
    display: grid;
    grid-template-columns: 1fr;
    grid-template-areas:
      "left"
      "right";
  }

  img {
    display: none;
  }
}
</style>
