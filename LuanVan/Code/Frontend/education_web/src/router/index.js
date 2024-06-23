import Vue from "vue";
import VueRouter from "vue-router";

Vue.use(VueRouter);

const routes = [
  {
    path: "/",
    name: "home",
    component: () => import("@/views/HomeView.vue"),
  },
  {
    path: "/user",
    component: () => import("@/views/user/MainView.vue"),
    children: [
      {
        path: "my-learning",
        name: "my-learning",
        component: () => import("@/views/user/LearningView.vue"),
      },
      {
        path: "profile",
        name: "profile",
        component: () => import("@/views/user/ProfileView.vue"),
      },
    ],
  },
  {
    path: "/category/:id",
    name: "category",
    component: () => import("@/views/CategoryView.vue"),
  },
  {
    path: "/category/:id/course/:id",
    name: "course",
    component: () => import("@/views/CourseView.vue"),
  },
  {
    path: "/category/:id/course/:id/lecture",
    name: "lecture",
    component: () => import("@/views/LectureView.vue"),
  },
  {
    path: "/cart",
    name: "cart",
    component: () => import("@/views/CartView.vue"),
  },
  {
    path: "/checkout",
    name: "checkout",
    component: () => import("@/views/CheckoutView.vue"),
  },
  {
    path: "/authentication/sign-in",
    name: "Signin",
    component: () => import("@/views/LoginView.vue"),
  },
  {
    path: "/authentication/sign-up",
    name: "Signup",
    component: () => import("@/views/SignupView.vue"),
  },
];

const router = new VueRouter({
  routes,
  mode: "history",
});

export default router;
