<template>
  <v-container>
    <v-row class="justify-center">
      <v-col cols="5">
        <div class="text-h6 font-weight-bold d-flex justify-center">
          Log in to your Open Education account
        </div>
        <v-text-field
          v-model="username"
          outlined
          placeholder="Username"
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
          @click="signIn()"
        >
          Log in
        </v-btn>
      </v-col>
    </v-row>
  </v-container>
</template>

<script>
import { signIn, getUserInfo } from "@/api/auth";

export default {
  components: {},
  data() {
    return {
      username: "",
      password: "",
    };
  },
  methods: {
    signIn() {
      const payload = {
        username: this.username,
        password: this.password,
      };
      signIn(payload)
        .then((res) => {
          localStorage.setItem("token", res.data.token);
          getUserInfo(res.data.token).then((res) => {
            console.log(res);
          });
          this.$router.push("/");
        })
        .catch((err) => console.log(err));
    },
  },
};
</script>
