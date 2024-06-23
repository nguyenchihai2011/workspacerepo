<template>
  <v-container>
    <v-row class="justify-center">
      <v-col cols="5">
        <div class="text-h6 font-weight-bold d-flex justify-center">
          Sign up and start {{ isSignUpStudent ? "learning" : "teaching" }}
        </div>
        <v-text-field
          v-model="username"
          outlined
          placeholder="Full name"
          color="#000"
          height="38"
          hide-details
          class="mt-4"
        ></v-text-field>
        <v-text-field
          v-model="email"
          outlined
          placeholder="Email"
          color="#000"
          height="38"
          hide-details
          class="mt-4"
        ></v-text-field>
        <v-text-field
          v-model="password"
          outlined
          type="password"
          placeholder="Password"
          color="#000"
          height="38"
          hide-details
          class="mt-4"
        ></v-text-field>
        <v-btn
          class="purple lighten-2 white--text text-none mt-4"
          height="48"
          width="100%"
          @click="signUp()"
        >
          Sign up
        </v-btn>
        <v-divider class="mt-6"></v-divider>
        <div class="d-flex justify-center mt-4">
          Already have an account?
          <div class="purple--text text--lighten-2 ml-2">Log in</div>
        </div>
      </v-col>
    </v-row>
  </v-container>
</template>

<script>
import { mapGetters, mapActions } from "vuex";
import {
  signUp,
  signUpStudent,
  signUpLecture,
  signIn,
  getUserInfo
} from "@/api/auth";

import { createCart } from "@/api/cart";

export default {
  components: {},
  data() {
    return {
      username: "",
      email: "",
      password: ""
    };
  },

  computed: {
    ...mapGetters("auth", ["userId", "role"]),
    isSignUpStudent() {
      return this.$route.name === "SignUp";
    }
  },

  methods: {
    ...mapActions("auth", [
      "setUserId",
      "setRole",
      "setToken",
      "setAvatarUrl",
      "setLectureId",
      "setStudentId"
    ]),
    createInitProfile() {
      const payload = {
        userId: this.userId
      };

      if (this.isSignUpStudent) {
        signUpStudent(payload).then(res => {
          createCart({ studentId: res.data.userId }).then(res =>
            console.log(res)
          );
        });
      } else {
        signUpLecture(payload).then(() => {});
      }
    },

    signIn() {
      const payload = {
        username: this.username,
        password: this.password
      };
      signIn(payload)
        .then(res => {
          this.setToken(res.data.token);
          this.setUserId(res.data.userId);
          this.setRole(res.data.role);

          getUserInfo({ userId: this.userId, role: this.role }).then(res => {
            this.setAvatarUrl(res.data.avatarUrl);
            if (this.role === "Lecture") {
              this.setLectureId(res.data.id);
              this.$router.push("/user/profile");
            } else {
              this.setStudentId(res.data.id);
              this.$router.push("/");
            }
          });
        })
        .catch(err => console.log(err));
    },

    signUp() {
      const payload = {
        username: this.username,
        email: this.email,
        password: this.password
      };
      const params = {
        role: this.isSignUpStudent ? "Student" : "Lecture"
      };
      signUp(params, payload)
        .then(res => {
          this.setUserId(res.data.id);
          this.setRole(res.data.userType);

          this.createInitProfile();
          this.signIn();
        })
        .catch(err => console.log(err));
    }
  }
};
</script>
