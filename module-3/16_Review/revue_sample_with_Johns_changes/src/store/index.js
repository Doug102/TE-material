import Vue from 'vue'
import Vuex from 'vuex'

Vue.use(Vuex)

export default new Vuex.Store({
  state: {
    pets: [
      {
        id: 1,
        name: "Bella",
        age: 4,
        type: "dog",
        breed: "GSD",
        owner: 1,
        image: "https://photos.app.goo.gl/cGfChNdaT8bdCmi69"
      },
      {
        id: 2,
        name: "Primrose",
        age: 7,
        type: "cat",
        breed: "DSH",
        owner: 1,
        image: "https://www.flickr.com/photos/192624577@N03/shares/8MKE8X"
      },
      {
        id: 3,
        name: "Gabriel",
        age: 7,
        type: "cat",
        breed: "DSH",
        owner: 1,
        image: "https://photos.app.goo.gl/mApSEdJqNiMwnfLGA"
      },
      {
        id: 4,
        name: "Penelope",
        age: 7,
        type: "cat",
        breed: "DSH",
        owner: 1,
        image: "https://photos.app.goo.gl/6YpuvDqFM8zA4Swo7"
      }
    ],
  },
  mutations: {
    ADD_PET (state, payload) {
      
      state.pets.push(payload);
    },

    DELETE_PET (state, petId){
      console.log("Reached mutator", petId)
      state.pets = state.pets.filter( pet => {
        return petId != pet.id;
      })
    }
  }
})
