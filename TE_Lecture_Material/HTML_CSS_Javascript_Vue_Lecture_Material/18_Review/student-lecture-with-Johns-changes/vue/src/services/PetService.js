import axios from 'axios';

const path =  '/pet';

export default {

  getPets() {
    return axios.get(path)
  },

  getPet(petId) {
    return axios.get(path +'/' + petId)
  },

  addPet(pet) {
    return axios.post(path, pet)
  },

  deletePet(petId) {
    console.log("Reached deletePet in PetService ", petId);
    return axios.delete(path +"/" + petId)
  }

}
