export default {
  setToken(state, token) {
    state.token = token;
    localStorage.setItem("token", token);
  },

  setUserId(state, userId) {
    state.userId = userId;
    localStorage.setItem("userId", userId);
  },

  setRole(state, role) {
    state.role = role;
    localStorage.setItem("role", role);
  },

  setAvatarUrl(state, avatarUrl) {
    state.avatarUrl = avatarUrl;
    localStorage.setItem("avatarUrl", avatarUrl);
  },

  setLectureId(state, lectureId) {
    state.lectureId = lectureId;
    localStorage.setItem("lectureId", lectureId);
  },

  setCartId(state, cartId) {
    state.cartId = cartId;
    localStorage.setItem("cartId", cartId);
  },

  setStudentId(state, studentId) {
    state.studentId = studentId;
    localStorage.setItem("studentId", studentId);
  },

  setAuth(state, auth) {
    state.userId = auth.userId;
    localStorage.setItem("token", auth.userId);
    state.lectureId = auth.lectureId;
    localStorage.setItem("token", auth.lectureId);
    state.studentId = auth.studentId;
    localStorage.setItem("token", auth.studentId);
    state.role = auth.role;
    localStorage.setItem("token", auth.role);
  },

  unsetAuth(state) {
    state.token = "";
    localStorage.setItem("token", "");
    state.userId = "";
    localStorage.setItem("token", "");
    state.lectureId = "";
    localStorage.setItem("token", "");
    state.studentId = "";
    localStorage.setItem("token", "");
    state.role = "";
    localStorage.setItem("token", "");
  }
};
