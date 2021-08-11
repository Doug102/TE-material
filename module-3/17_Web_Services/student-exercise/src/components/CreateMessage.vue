<template>
  <form v-on:submit.prevent>
    <div class="field">
      <label for="title">Title</label>
      <input type="text" name="title" v-model="message.title" />
    </div>
    <div class="field">
      <label for="messageText">Message</label>
      <input type="text" name="messageText" v-model="message.messageText" />
    </div>
    <div class="actions">
      <button type="submit" v-on:click="saveMessage()">Save Message</button>
    </div>
  </form>
</template>

<script>
import messageService from "../services/MessageService";

export default {
  name: "create-message",
  props: ["topicId"],
  data() {
    return {
      message: {
        id: Math.floor(Math.random() * (1000 - 100) + 100),
        topicId: this.topicId,
        title: "",
        messageText: "",
      },
    };
  },
  methods: {
    saveMessage() {
       const newMessage = {
        id: this.message.id,
        topicId: this.message.topicId,
        title: this.message.title,
        messageText: this.message.messageText
      };
      messageService
        .addMessage(newMessage)
        .then((response) => {
          if (response.status === 201) {
            this.$router.push(`/${newMessage.topicId}`);
          }
        })
        .catch((error) => {
          if (error.response) {
            console.log("HTTP Response Code: ", error.response.data.status);
            console.log("Description: ", error.response.data.title);
          } else {
            console.log("Network Error");
          }
        });
    },
  },
};
</script>

<style>
</style>
