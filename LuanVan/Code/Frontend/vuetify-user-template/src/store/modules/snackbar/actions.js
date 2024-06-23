export default {
  addSnackbar({ commit }, snackbar) {
    commit("addSnackbar", snackbar);
  },

  removeSnackbar({ commit }) {
    commit("removeSnackbar");
  }
};
