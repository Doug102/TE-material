<template>
  <div>
    <div >
      <div v-for="team in teams" v-bind:key="team.id" >
        <p class="team-name">{{ team.name }}</p>
        <p class="project-name">{{ team.project }}</p>
        <p class="technologies">{{ team.technologies }}</p>
        <ul class="members">
          <li v-for="member in team.members" v-bind:key="member.member">
            {{ member.member }}
          </li>
        </ul>

        <a class="quick-link" v-if="team.link" :href="team.link" target="_blank"
          ><p>Visit {{ team.link }}</p></a>
        <a class="quick-link" v-else :href="team.quickLink" target="_blank"
          ><p>Visit {{ team.quickLink }}</p></a>

        <hr><hr>
      </div>
    </div>
  </div>
</template>

<script>
import axios from 'axios'

export default {
  name: "List",

  data: function() {
    return {
    };
  },

  computed: {

    teams() {
      return this.$store.state.teams;
    }
  },

  mounted() {
    this.loadData();
  },

  methods: {

    loadData: function() {
      axios.get("data.json")
      .then(response => {
        this.$store.commit('SET_JSON_DATA', response.data);
      })}
  }
}

</script>

<style>

</style>
