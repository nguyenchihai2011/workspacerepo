export default {
  token: state => state.token || localStorage.getItem("token"),
  userId: state => state.userId || localStorage.getItem("userId"),
  cartId: state => state.cartId || localStorage.getItem("cartId"),
  lectureId: state => state.lectureId || localStorage.getItem("lectureId"),
  avatarUrl: state => state.avatarUrl || localStorage.getItem("avatarUrl"),
  studentId: state => state.studentId || localStorage.getItem("studentId"),
  role: state => state.role || localStorage.getItem("role")
};
