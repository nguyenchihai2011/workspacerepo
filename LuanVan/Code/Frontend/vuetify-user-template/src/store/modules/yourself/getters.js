import _ from "lodash";

export default {
  coursesOfStudent: state => {
    return _.isEmpty(state.coursesOfStudent)
      ? JSON.parse(localStorage.getItem("coursesOfStudent"))
      : state.coursesOfStudent;
  }
};
