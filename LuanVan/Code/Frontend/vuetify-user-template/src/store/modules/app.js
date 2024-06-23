const state = {
  drawer: true,
  gradient: "rgba(0, 0, 0, .7), rgba(0, 0, 0, .7)",
  items: [
    { title: "Dashboard", icon: "mdi-view-dashboard", to: "/" },
    {
      title: "Catalog",
      icon: "mdi-menu",
      items: [
        {
          title: "Category",
          icon: "mdi-view-list",
          to: "/category"
        },
        {
          title: "Course",
          icon: "mdi-book-education",
          to: "/course"
        }
      ]
    },
    { title: "Grid System", icon: "mdi-grid", to: "/grid-system" },
    { title: "Breakpoints", icon: "mdi-responsive", to: "/breakpoints" },
    {
      title: "Grid List Page",
      icon: "mdi-view-list-outline",
      to: "/grid-list-page"
    },
    {
      title: "Typography",
      icon: "mdi-format-text-variant-outline",
      to: "/typography"
    },
    {
      title: "Tables",
      icon: "mdi-table-settings",
      items: [
        { title: "Basic Table", to: "/tables/basic-table" },
        { title: "App Table", to: "/tables/app-table" }
      ]
    },
    {
      title: "Forms",
      icon: "mdi-form-select",
      items: [
        { title: "Validation Form", to: "/forms/validation-form" },
        { title: "App Form", to: "/forms/app-form" }
      ]
    },
    { title: "Buttons", icon: "mdi-gesture-tap-button", to: "/buttons" },
    { title: "Icons", icon: "mdi-emoticon-excited-outline", to: "/icons" },
    { title: "Logout", icon: "mdi-logout", to: "/authentication/sign-in" }
  ]
};

const getters = {
  getDrawer: state => state.drawer
};

const mutations = {
  setDrawer(state, data) {
    state.drawer = data;
  }
};

const actions = {
  toggleDrawer({ commit }, value) {
    commit("setDrawer", value);
  }
};

export default {
  namespaced: true,
  state,
  getters,
  mutations,
  actions
};
