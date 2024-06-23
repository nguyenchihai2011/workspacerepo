export default {
  setCoursesOfStudent(state, coursesOfStudent) {
    state.coursesOfStudent = coursesOfStudent;
    localStorage.setItem("coursesOfStudent", JSON.stringify(coursesOfStudent));
  }
};
