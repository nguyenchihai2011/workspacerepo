export default {
  addSnackbar(state, snackbar) {
    state.isShow = snackbar.isShow;
    state.text = snackbar.text;
    state.priority = snackbar.priority;
    state.timeout = snackbar.timeout;
  },

  removeSnackbar(state) {
    state.isShow = false;
    // state.text = "";
    // state.priority = "";
    // state.timeout = 0;
  }
};
