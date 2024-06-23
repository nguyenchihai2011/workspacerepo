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
        >
          <template v-slot:activator="{ on, attrs }">
            <v-hover v-slot="{ hover }">
              <div
                v-bind="attrs"
                v-on="on"
                :class="[
                  hover ? 'purple--text' : '',
                  'ml-6 font-weight-medium',
                ]"
              >
                Categories
              </div>
            </v-hover>
          </template>

          <v-list>
            <v-hover
              v-for="(item, index) in items"
              :key="index"
              v-slot:default="{ hover }"
            >
              <v-list-item :key="item.title">
                <template v-slot:default>
                  <v-expand-transition>
                    <v-overlay absolute :opacity="0.2" :value="hover">
                    </v-overlay>
                  </v-expand-transition>
                  <v-list-item-content>
                    <v-list-item-title v-text="item.title"></v-list-item-title>
                    <v-list-item-subtitle
                      class="text--primary"
                      v-text="item.headline"
                    ></v-list-item-subtitle>
                    <v-list-item-subtitle
                      v-text="item.subtitle"
                    ></v-list-item-subtitle>
                  </v-list-item-content>
                  <v-list-item-action>
                    <v-list-item-action-text
                      v-text="item.action"
                    ></v-list-item-action-text>
                  </v-list-item-action>
                </template>
              </v-list-item>
            </v-hover>
            <v-divider v-if="index + 1 < items.length" :key="index"></v-divider>
          </v-list>
        </v-menu>
      </v-col>
      <!-- <v-col cols="1" class="d-flex justify-center align-center"> -->

      <!-- </v-col> -->
      <v-col cols="5" class="d-flex align-center">
        <v-text-field
          outlined
          prepend-inner-icon="mdi-magnify"
          placeholder="Search for anything"
          color="#000"
          dense
          hide-details
          class="rounded-xxl"
        ></v-text-field>
      </v-col>
      <v-divider></v-divider>
      <v-col cols="2" class="d-flex justify-end align-center">
        <div class="d-flex align-center">
          <v-btn text><v-icon>mdi-cart</v-icon></v-btn>
          <v-menu
            open-on-hover
            bottom
            offset-y
            nudge-bottom="5"
            close-delay="300"
          >
            <template v-slot:activator="{ on, attrs }">
              <v-hover>
                <div v-bind="attrs" v-on="on">
                  <v-avatar color="teal" size="48" class="ma-4">
                    <span class="white--text text-h5">48</span>
                  </v-avatar>
                </div>
              </v-hover>
            </template>

            <v-list class="pa-2">
              <v-hover v-slot:default="{ hover }">
                <v-list-item>
                  <v-avatar color="teal" size="48" class="mr-4">
                    <span class="white--text text-h5">48</span>
                  </v-avatar>
                  <div :class="[hover ? 'primary--text' : '']">
                    <div>Hải Nguyễn</div>
                    <div>nguyenchihai2011it@gmail.com</div>
                  </div>
                </v-list-item>
              </v-hover>
              <v-divider class="mx-4 my-2 mt-4"></v-divider>
              <v-hover v-slot:default="{ hover }">
                <v-list-item
                  :class="[hover ? 'primary--text' : '']"
                  link
                  to="/user/my-learning"
                >
                  <div>My learning</div>
                </v-list-item>
              </v-hover>
              <v-hover v-slot:default="{ hover }">
                <v-list-item :class="[hover ? 'primary--text' : '']">
                  <div>My cart</div>
                </v-list-item>
              </v-hover>
              <v-hover v-slot:default="{ hover }">
                <v-list-item
                  :class="[hover ? 'primary--text' : '']"
                  link
                  to="/user/profile"
                >
                  <div>Profile</div>
                </v-list-item>
              </v-hover>
              <v-divider class="mx-4 my-2"></v-divider>
              <v-hover v-slot:default="{ hover }">
                <v-list-item :class="[hover ? 'primary--text' : '']">
                  <div>Log out</div>
                </v-list-item>
              </v-hover>
            </v-list>
          </v-menu>
        </div>
        <div class="d-flex align-center">
          <v-btn
            size="large"
            flat
            outlined
            class="ml-2"
            to="/authentication/sign-in"
          >
            Login
          </v-btn>
          <v-btn
            size="large"
            variant="flat"
            outlined
            class="ml-2"
            to="/authentication/sign-up"
          >
            Signup
          </v-btn>
        </div>
      </v-col>
    </v-row>
  </v-container>
</template>

<script>
export default {
  data() {
    return {
      items: [
        {
          action: "15 min",
          headline: "Brunch this weekend?",
          title: "Ali Connors",
          subtitle:
            "I'll be in your neighborhood doing errands this weekend. Do you want to hang out?",
        },
        {
          action: "2 hr",
          headline: "Summer BBQ",
          title: "me, Scrott, Jennifer",
          subtitle: "Wish I could come, but I'm out of town this weekend.",
        },
        {
          action: "6 hr",
          headline: "Oui oui",
          title: "Sandra Adams",
          subtitle: "Do you have Paris recommendations? Have you ever been?",
        },
        {
          action: "12 hr",
          headline: "Birthday gift",
          title: "Trevor Hansen",
          subtitle:
            "Have any ideas about what we should get Heidi for her birthday?",
        },
        {
          action: "18hr",
          headline: "Recipe to try",
          title: "Britta Holt",
          subtitle:
            "We should eat this: Grate, Squash, Corn, and tomatillo Tacos.",
        },
      ],
    };
  },

  methods: {},
};
</script>

<style></style>
