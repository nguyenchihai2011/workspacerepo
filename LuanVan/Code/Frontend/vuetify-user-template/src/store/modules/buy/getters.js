import _ from "lodash";

export default {
  isBuyNow: state =>
    state.isBuyNow || localStorage.getItem("isBuyNow") === "true",
  courseBuyNow: state => {
    return _.isEmpty(state.courseBuyNow)
      ? JSON.parse(localStorage.getItem("courseBuyNow"))
      : state.courseBuyNow;
  },
  cartQuantity: state => {
    return state.cartQuantity || Number(localStorage.getItem("cartQuantity"));
  },
  listCourseSelectToBuy: state => {
    return _.isEmpty(state.listCourseSelectToBuy)
      ? JSON.parse(localStorage.getItem("listCourseSelectToBuy"))
      : state.listCourseSelectToBuy;
  }
};
