<template>
  <div>
    <v-fade-transition mode="out-in">
      <router-view />
    </v-fade-transition>
    <core-snackbar></core-snackbar>
  </div>
</template>

<script>
import CoreSnackbar from "@/components/core/CoreSnackbar.vue";
import alanBtn from "@alan-ai/alan-sdk-web";
import { mapGetters, mapActions } from "vuex";

import "@/styles/overrides.sass";
export default {
  components: { CoreSnackbar },
  computed: {
    ...mapGetters("auth", ["role"])
  },
  methods: {
    ...mapActions("alanAI", ["setCommand", "setValue"]),
    ...mapActions("snackbar", ["addSnackbar"])
  },
  created() {
    alanBtn({
      key:
        "dcf6ffded2e0e10e9a01b45609aacfdd2e956eca572e1d8b807a3e2338fdd0dc/stage",
      onCommand: commandData => {
        if (commandData.command.COMMAND === "navigateDashboard") {
          this.setCommand("navigateDashboard");
        } else if (commandData.command.COMMAND === "navigateMyLearning") {
          this.setCommand("navigateMyLearning");
        } else if (commandData.command.COMMAND === "navigateMyTeaching") {
          this.setCommand("navigateMyTeaching");
        } else if (commandData.command.COMMAND === "navigateCart") {
          this.setCommand("navigateCart");
        } else if (commandData.command.COMMAND === "search") {
          this.setCommand("search");
          this.setValue(commandData.command.value);
        } else if (commandData.command.COMMAND === "buy") {
          this.setCommand("buy");
        } else if (commandData.command.COMMAND === "top1purchasescourse") {
          this.setCommand("top1purchasescourse");
          this.setValue(commandData.command.value);
        } else if (commandData.command.COMMAND === "top1ratingcourse") {
          this.setCommand("top1ratingcourse");
          this.setValue(commandData.command.value);
        } else if (commandData.command.COMMAND === "freecourse") {
          this.setCommand("freecourse");
        } else if (commandData.command.COMMAND === "courseforbeginner") {
          this.setCommand("courseforbeginner");
        } else if (commandData.command.COMMAND === "notunderstand") {
          this.setCommand("notunderstand");
        }
      }
    });
  }
};
</script>
