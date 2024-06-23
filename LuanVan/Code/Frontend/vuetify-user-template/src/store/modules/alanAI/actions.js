export default {
  setCommand({ commit }, command) {
    commit("setCommand", command);
  },

  setValue({ commit }, value) {
    commit("setValue", value);
  }
};
