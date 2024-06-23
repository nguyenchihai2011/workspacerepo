<template>
  <v-container
    fluid
    class="align-center pa-0"
    style="
        border-bottom: 1px solid #d1d7dc;
        position: fixed;
        z-index: 3;
        background-color: white;
      "
  >
    <v-row no-gutters class="px-3">
      <v-col cols="3" class="d-flex align-center">
        <router-link to="/"
          ><v-img
            alt="Education Logo"
            class="mr-2"
            contain
            src="@/assets/education-logo.svg"
            min-width="100"
            width="150"
        /></router-link>
        <v-menu
          open-on-hover
          bottom
          offset-y
          nudge-bottom="35"
          close-delay="300"
          v-if="!isLecture"
        >
          <template v-slot:activator="{ on, attrs }">
            <v-hover v-slot="{ hover }">
              <div
                v-bind="attrs"
                v-on="on"
                :class="[
                  hover ? 'primary--text' : '',
                  'ml-6 text-h6 font-weight-medium'
                ]"
              >
                Categories
              </div>
            </v-hover>
          </template>

          <v-list>
            <v-hover
              v-for="item in categories"
              :key="item.id"
              v-slot:default="{ hover }"
            >
              <v-list-item
                style="min-width: 200px;"
                @click="navigateTo(item.id)"
              >
                <template v-slot:default>
                  <v-expand-transition>
                    <v-overlay absolute :opacity="0.2" :value="hover">
                    </v-overlay>
                  </v-expand-transition>
                  <v-list-item-content>
                    <v-list-item-title v-text="item.name"></v-list-item-title>
                  </v-list-item-content>
                </template>
              </v-list-item>
            </v-hover>
          </v-list>
        </v-menu>
      </v-col>
      <v-col cols="5" class="d-flex align-center" style="position: relative;">
        <v-text-field
          v-if="!isLecture"
          v-model="search"
          outlined
          prepend-inner-icon="mdi-magnify"
          placeholder="Search for anything"
          color="#000"
          dense
          hide-details
          class="rounded-xxl"
          @blur="resetSearch()"
        ></v-text-field>
        <v-card
          class="mx-auto"
          width="100%"
          tile
          style="position: absolute; z-index: 999; max-height: 400px; overflow: auto;"
          :style="{ bottom: -cardBottom + 'px' }"
          v-show="course.result && course.result.length > 0"
          ref="cardRef"
          id="header-card"
        >
          <v-list dense>
            <v-list-item-group color="primary">
              <v-list-item
                v-for="item in course.result"
                :key="item.id"
                @click="$router.push(`/course/${item.id}`)"
              >
                <v-row class="mb-1">
                  <v-col cols="2" class="d-flex align-center">
                    <v-img :src="item.imageUrl" max-width="100px"></v-img
                  ></v-col>
                  <v-col cols="9" class="d-flex align-center ml-2">
                    <v-list-item-title v-text="item.name"></v-list-item-title
                  ></v-col>
                </v-row>
              </v-list-item>
            </v-list-item-group>
          </v-list>
        </v-card>
      </v-col>
      <v-divider></v-divider>
      <v-col cols="2" class="d-flex justify-end align-center">
        <div v-if="isLogged" class="d-flex align-center">
          <v-badge bordered overlap class="mr-2" v-if="isStudent">
            <template v-slot:badge>
              <div>{{ cartQuantity }}</div>
            </template>
            <v-btn
              v-if="isStudent"
              link
              to="/cart"
              text
              style="background-color: transparent !important;"
              ><v-icon>mdi-cart</v-icon></v-btn
            ></v-badge
          >

          <v-menu
            :key="userKey"
            open-on-hover
            bottom
            offset-y
            nudge-bottom="5"
            close-delay="300"
          >
            <template v-slot:activator="{ on, attrs }">
              <v-hover>
                <div v-bind="attrs" v-on="on">
                  <v-avatar v-if="avatarUrl !== 'null'" size="48" class="ma-4">
                    <img :src="avatarUrl" />
                  </v-avatar>
                  <v-avatar v-else color="teal" size="48" class="ma-4">
                    <v-icon dark>
                      mdi-account-circle
                    </v-icon>
                  </v-avatar>
                </div>
              </v-hover>
            </template>

            <v-list class="pa-2" style="min-width: 300px;">
              <!-- <v-hover v-slot:default>
                <v-list-item>
                  <v-avatar color="teal" size="48" class="mr-4">
                    <img :src="avatarUrl" alt="John" />
                  </v-avatar> -->
              <!-- <div :class="[hover ? 'primary--text' : '']">
                    <div>Hải Nguyễn</div>
                    <div>nguyenchihai2011it@gmail.com</div>
                  </div> -->
              <!-- </v-list-item>
              </v-hover>
              <v-divider class="mx-4 my-2 mt-4"></v-divider> -->
              <v-hover v-if="isStudent" v-slot:default>
                <v-list-item link to="/user/my-learning">
                  <div>My learning</div>
                </v-list-item>
              </v-hover>
              <v-hover v-else v-slot:default>
                <v-list-item link to="/user/my-teaching">
                  <div>My teaching</div>
                </v-list-item>
              </v-hover>
              <v-hover v-if="!isStudent" v-slot:default>
                <v-list-item link to="/user/revenue">
                  <div>Revenue</div>
                </v-list-item>
              </v-hover>
              <v-hover v-if="!isStudent" v-slot:default>
                <v-list-item link to="">
                  <div>Notify</div>
                </v-list-item>
              </v-hover>
              <v-hover v-slot:default>
                <v-list-item link to="/user/profile">
                  <div>Profile</div>
                </v-list-item>
              </v-hover>
              <v-hover v-slot:default>
                <v-list-item link to="">
                  <div>Change password</div>
                </v-list-item>
              </v-hover>
              <v-divider class="mx-4 my-2"></v-divider>
              <v-hover v-slot:default>
                <v-list-item link @click="signOut()">
                  <div>Log out</div>
                </v-list-item>
              </v-hover>
            </v-list>
          </v-menu>
        </div>
        <div v-else class="d-flex align-center">
          <core-button outlined link class="ml-2" to="/authentication/sign-in">
            Sign in
          </core-button>
          <core-button outlined link class="ml-2" to="/authentication/sign-up">
            Sign up
          </core-button>
        </div>
      </v-col>
    </v-row>
  </v-container>
</template>

<script>
import { logout } from "@/api/auth";
import { mapGetters, mapActions } from "vuex";
import { getListCategory } from "@/api/category";
import CoreButton from "@/components/core/CoreButton.vue";
import { getCourse } from "@/api/course";
import _ from "lodash";
import { getCartId } from "@/api/cart";
export default {
  components: { CoreButton },
  data() {
    return {
      userKey: 0,
      abortController: new AbortController(),
      categories: [],
      search: "",
      course: {},
      debounceSearch: () => {},
      cardBottom: "0px" // Thiết lập giá trị mặc định ban đầu,
    };
  },

  computed: {
    ...mapGetters("auth", ["token", "role", "avatarUrl", "cartId"]),
    ...mapGetters("buy", ["cartQuantity"]),
    ...mapGetters("alanAI", ["command", "value"]),
    isLogged() {
      return !!this.token;
    },
    isStudent() {
      return this.role === "Student";
    },
    isLecture() {
      return this.role === "Lecture";
    }
  },

  watch: {
    search(val) {
      this.debounceSearch();
    },

    command(val) {
      if (val === "search") {
        this.search = this.value;
      }
    },

    value(val) {
      if (this.command === "search") {
        this.search = val;
      }
    }
  },

  methods: {
    ...mapActions("auth", ["unsetAuth"]),
    ...mapActions("buy", ["setCartQuantity"]),
    fetchCategories(params = {}) {
      this.abortController.abort();
      this.abortController = new AbortController();
      getListCategory(params, this.abortController.signal).then(res => {
        this.categories = res.data;
      });
    },

    signOut() {
      logout().then(() => {
        localStorage.clear();
        this.unsetAuth();
        this.userKey++;
        if (this.$route.name !== "Home") {
          this.$router.push("/");
        }
      });
    },

    resetSearch() {
      this.search = "";
    },

    fetchCourse() {
      getCourse({ search: this.search })
        .then(res => {
          if (this.search) {
            this.course = res.data;
          } else {
            this.course = {};
          }
        })
        .finally(() => {
          this.cardBottom =
            document.getElementById("header-card").clientHeight * 1;
        });
    },

    navigateTo(id) {
      this.$router.push(`/category/${id}`);
    }
  },

  created() {
    this.fetchCategories();
    getCartId(this.cartId).then(res => {
      this.setCartQuantity(res.data.cartDetails.length);
    });
    this.debounceSearch = _.debounce(this.fetchCourse, 1000);
  }
};
</script>

<style></style>
