export default {
  setIsBuyNow({ commit }, isBuyNow) {
    commit("setIsBuyNow", isBuyNow);
  },

  setCourseBuyNow({ commit }, courseBuyNow) {
    commit("setCourseBuyNow", courseBuyNow);
  },

  setCartQuantity({ commit }, cartQuantity) {
    commit("setCartQuantity", cartQuantity);
  },

  setListCourseSelectToBuy({ commit }, listCourseSelectToBuy) {
    commit("setListCourseSelectToBuy", listCourseSelectToBuy);
  }
};
