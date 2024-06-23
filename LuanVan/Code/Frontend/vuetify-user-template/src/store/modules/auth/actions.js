export default {
  setToken({ commit }, token) {
    commit("setToken", token);
  },

  setUserId({ commit }, userId) {
    commit("setUserId", userId);
  },

  setRole({ commit }, role) {
    commit("setRole", role);
  },

  setAvatarUrl({ commit }, avatarUrl) {
    commit("setAvatarUrl", avatarUrl);
  },

  setStudentId({ commit }, studentId) {
    commit("setStudentId", studentId);
  },

  setCartId({ commit }, cartId) {
    commit("setCartId", cartId);
  },

  setLectureId({ commit }, lectureId) {
    commit("setLectureId", lectureId);
  },

  setAuth({ commit }, auth) {
    commit("setAuth", auth);
  },

  unsetAuth({ commit }) {
    commit("unsetAuth");
  }
};
