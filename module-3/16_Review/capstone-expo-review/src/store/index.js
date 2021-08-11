import Vue from "vue";
import Vuex from "vuex";

Vue.use(Vuex);

export default new Vuex.Store({
  state: {
    version: "",
    topTitleLine: "",
    secondTitleLine: "",
    mainVideo: "",
    randomMessage: "",
    schedule: [],
    instructions: [],
    tipsHeading: "",
    tips: [],
    teams: [],
  },

  mutations: {
    SET_JSON_DATA(state, payload) {
      state.version = payload.version;
      state.topTitleLine = payload.topTitleLine;
      state.secondTitleLine = payload.secondTitleLine;
      state.mainVideo = payload.mainVideo;
      state.randomMessage = payload.randomMessage;

      state.instructions = payload.instructions;
      state.tipsHeading = payload.tipsHeading;
      state.tips = payload.tips;
      state.teams = payload.teams;
    },

    RANDOMIZE_TEAMS(state) {
      if (state.teams) {
        for (let x = 0; x < state.teams.length; x++) {
          let random = Math.floor(Math.random() * Math.floor(state.teams.length));
          // ES6 allows us to assign two variables at once
          [state.teams[x], state.teams[random]] = [
            state.teams[random],
            state.teams[x],
          ];
        }
      }
    },
  },
  actions: {},
  getters: {},
});
