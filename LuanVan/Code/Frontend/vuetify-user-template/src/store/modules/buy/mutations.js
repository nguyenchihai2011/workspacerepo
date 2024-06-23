export default {
  setIsBuyNow(state, isBuyNow) {
    state.isBuyNow = isBuyNow;
    localStorage.setItem("isBuyNow", isBuyNow);
  },
  setCourseBuyNow(state, courseBuyNow) {
    state.courseBuyNow = courseBuyNow;
    localStorage.setItem("courseBuyNow", JSON.stringify(courseBuyNow));
  },
  setCartQuantity(state, cartQuantity) {
    state.cartQuantity = cartQuantity;
    localStorage.setItem("cartQuantity", cartQuantity);
  },
  setListCourseSelectToBuy(state, listCourseSelectToBuy) {
    state.listCourseSelectToBuy = listCourseSelectToBuy;
    localStorage.setItem(
      "listCourseSelectToBuy",
      JSON.stringify(listCourseSelectToBuy)
    );
  }
};
