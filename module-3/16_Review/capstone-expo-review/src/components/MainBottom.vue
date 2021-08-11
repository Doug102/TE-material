<template>
  <div>
    <div>
      <h3>{{ randomMessage }}</h3>
    </div>
    <div class="bottom grid-container">
      <div v-for="team in teams" v-bind:key="team.id" class="team grid-item">
        <p class="team-name">{{ team.name }}</p>
        <p class="project-name">{{ team.project }}</p>
        <p class="technologies">{{ team.technologies }}</p>
        <ul class="members">
          <li v-for="member in team.members" v-bind:key="member.member">
            {{ member.member }}
            <span v-if="member.linkedIn">
              -
              <a
                class="fa fa-linkedin-square fa_custom fa-2x"
                v-bind:href="member.linkedIn"
                target="_blank"
              ></a>
            </span>
          </li>
        </ul>

        <a class="quick-link" v-if="team.quickLink" :href="team.quickLink" target="_blank">
          <p>Visit {{ team.quickLink }}</p>
        </a>
        <a class="quick-link" v-else :href="team.link" target="_blank">
          <p>Visit {{ team.link }}</p>
        </a>

        <a class="link" v-if="team.link && team.quickLink" :href="team.link" target="_blank">
          <p>or {{ team.link }}</p>
        </a>
      </div>
    </div>
    <p>{{version}}</p>
  </div>
</template>

<script>
import axios from "axios";

export default {
  name: "MainBottom",

  data: function () {
    return {
      a: true,
    };
  },

  computed: {
    randomMessage() {
      return this.$store.state.randomMessage;
    },

    teams() {
      return this.$store.state.teams;
    },
    version() {
      return this.$store.state.version;
    },
  },

  mounted() {
    this.loadData();
  },

  methods: {
    loadData: function () {
      axios.get("data.json").then((response) => {
        this.$store.commit("SET_JSON_DATA", response.data);
        this.$store.commit("RANDOMIZE_TEAMS");
      });
    },
  },
};
</script>

<style scoped>
.bottom {
  display: grid;
  grid-template-columns: 1fr 1fr 1fr;
  background-color: #2196f3;
  padding: 5px;
}

.grid-item {
  background-color: rgba(255, 255, 255, 0.8);
  border: 1px solid rgba(0, 0, 0, 0.8);
  padding: 20px;
  text-align: center;
}

.team-name {
  color: #2196f3;
}

ol,
ul,
.schedule {
  text-align: left;
}

.project-name {
  font-weight: bold;
}

.link {
  font-size: 0.7em;
}

.fa_custom {
  color: #0099cc;
}

@media only screen and (max-width: 1000px) {
  .bottom {
    display: grid;
    grid-template-columns: 1fr;
  }
}
</style>
