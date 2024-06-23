<template>
  <v-container>
    <v-row class="justify-center">
      <v-col cols="5">
        <div class="text-h6 font-weight-bold d-flex justify-center">
          Sign up and start learning
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
import { signUp, signUpStudent } from "@/api/auth";

export default {
  components: {},
  data() {
    return {
      username: "",
      email: "",
      password: "",
    };
  },

  methods: {
    signUp() {
      const payload = {
        username: this.username,
        email: this.email,
        password: this.password,
      };
      const params = {
        role: "Student",
      };
      signUp(params, payload)
        .then((res) => {
          localStorage.setItem("userId", res.data);
          signUpStudent({
            address: "185, Tân Sơn, Phường 15, Tân Bình, Hồ Chí Minh",
            avatarUrl: "",
            firstName: "Student",
            lastName: "1",
            userId: res.data,
          }).then((res) => {
            console.log(res);
          });
        })
        .catch((err) => console.log(err));
    },
  },
};
</script>
