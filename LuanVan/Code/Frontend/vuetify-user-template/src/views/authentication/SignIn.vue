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
          type="password"
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
import { getCartId } from "@/api/cart";
import { mapGetters, mapActions } from "vuex";

export default {
  data() {
    return {
      username: "",
      password: "",
      isHasProfileLecture: false
    };
  },
  computed: {
    ...mapGetters("auth", ["token", "userId", "role"])
  },
  methods: {
    ...mapActions("auth", [
      "setToken",
      "setUserId",
      "setCartId",
      "setRole",
      "setAvatarUrl",
      "setLectureId",
      "setStudentId",
      "setAuth"
    ]),

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
              if (res.data.id) {
                this.$router.push("/");
              } else {
                this.$router.push("/user/profile");
              }
            } else {
              this.setStudentId(res.data.id);
              getCartId(res.data.id).then(res => {
                this.setCartId(res.data.id);
              });
              this.$router.push("/");
            }
          });
        })
        .catch(err => console.log(err));
    }
  }
};
</script>
