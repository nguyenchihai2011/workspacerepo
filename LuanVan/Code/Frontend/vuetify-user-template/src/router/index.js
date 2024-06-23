import Vue from "vue";
import VueRouter from "vue-router";

Vue.use(VueRouter);

const routes = [
  {
    path: "/",
    component: () => import("@/layouts/default/Index"),
    children: [
      {
        path: "/",
        name: "Home",
        component: () => import("@/views/Dashboard")
      },
      {
        path: "/category/:id",
        name: "Category",
        component: () => import("@/views/Category")
      },
      {
        path: "/course/:id",
        name: "Course",
        component: () => import("@/views/Course")
      },
      {
        path: "/course/:courseId/lesson/:id",
        name: "Lesson",
        component: () => import("@/views/Lesson")
      },
      {
        path: "/cart",
        name: "Cart",
        component: () => import("@/views/Cart")
      },
      {
        path: "/checkout",
        name: "Checkout",
        component: () => import("@/views/Checkout")
      },
      {
        path: "/user",
        component: () => import("@/views/user/ViewMain"),
        children: [
          {
            path: "my-learning",
            name: "MyLearning",
            component: () => import("@/views/user/MyLearning")
          },
          {
            path: "my-teaching",
            name: "MyTeaching",
            component: () => import("@/views/lecture/MyTeaching")
          },
          {
            path: "notify",
            name: "Notify",
            component: () => import("@/views/user/Notify")
          },
          {
            path: "revenue",
            name: "Revenue",
            component: () => import("@/views/lecture/Revenue")
          },
          {
            path: "my-cart",
            name: "MyCart",
            component: () => import("@/views/user/MyLearning")
          },
          {
            path: "profile",
            name: "Profile",
            component: () => import("@/views/user/Profile")
          }
        ]
      },
      {
        path: "/authentication",
        component: () => import("@/views/authentication/ViewMain"),
        children: [
          {
            path: "sign-in",
            name: "SignIn",
            component: () => import("@/views/authentication/SignIn")
          },
          {
            path: "sign-up",
            name: "SignUp",
            component: () => import("@/views/authentication/SignUp")
          },
          {
            path: "sign-up/lecture",
            name: "SignUpLecture",
            component: () => import("@/views/authentication/SignUp")
          }
        ]
      }
    ]
  }
];
const router = new VueRouter({
  mode: process.env.NODE_ENV === "production" ? "hash" : "history",
  base: process.env.BASE_URL,
  routes
});

// router.beforeEach((to, from, next) => {
//   if (!checkUserLoggedIn() && to.name !== "SignIn") {
//     next({ name: "SignIn" });
//   } else {
//     next();
//   }
// });

// function checkUserLoggedIn() {
//   return !!localStorage.getItem("token");
// }

export default router;
