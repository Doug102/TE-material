<template>
  <div>
    <br />
    <br />
    <div
      class="p-5 text-center bg-image img-fluid img-responsive"
      style="
        background-image: url('https://i.ibb.co/3kCCM7B/leaderboard.jpg');
        background-size: cover;
        object-fit: contain;
        height: 350px;
        max-width: 100%;
        margin-top: 58px;
      "
    >
      <div class="d-flex justify-content-center align-items-center h-100">
        <div class="text-black">
          <h1 class="mb-3">Leaderboard</h1>
        </div>
      </div>
    </div>
    <br />
    <h1>Your Event Progress</h1>
    <table class="table table-hover">
      <thead>
        <tr>
          <th scope="col">Event</th>
          <th scope="col">UserName</th>
          <th scope="col">Progress</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="progress in userProgress" v-bind:key="progress.name">
          <td>{{ progress.eventName }}</td>
          <td>{{ progress.userName }}</td>
          <td>{{ progress.distanceProgress }} miles</td>

          <td></td>
        </tr>
      </tbody>
    </table>
    <br />
    <br />
    <h1>Event Leaderboard</h1>
    <table class="table table-hover">
      <thead>
        <tr>
          <th scope="col">Event</th>
          <th scope="col">UserName</th>
          <th scope="col">Progress</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="leader in leaderboard" v-bind:key="leader.name">
          <td>{{ leader.eventName }}</td>
          <td>{{ leader.userName }}</td>
          <td>{{ leader.distanceProgress }} miles</td>

          <td></td>
        </tr>
      </tbody>
    </table>
<br>
<br>
 <footer>        
      <p>Photos courtesy of Unsplash.com. Florian Schmetz</p>
      <p> &copy; 2021 Summit Fitness</p>
      </footer>
  </div>
</template>

<script>
import leaderboardService from "../services/LeaderboardService";
export default {
  name: "leaderboard",
  data() {
    return {
      userProgress: [],
      progress: {
        eventName: "",
        username: "",
        distanceProgress: "",
      },
      leaderboard: [],
      leader: {
        eventName: "",
        username: "",
        distanceProgress: "",
      },
    };
  },
  created() {
    const eventId = this.$route.params.eventId;
    leaderboardService.getLeaders(eventId).then((response) => {
      this.leaderboard = response.data;
    });
    leaderboardService.getUserProgress(eventId).then((response) => {
      this.userProgress = response.data;
    });
  },
};
</script>

<style>
</style>