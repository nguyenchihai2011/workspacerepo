<template>
  <div class="text-center ma-2 rounded-xl">
    <v-snackbar
      v-model="isSnackbar"
      transition="v-scroll-y-transition"
      max-width="550"
      :timeout="timeout"
      :color="color"
      top
      absolute
      style="z-index: 10"
      rounded
    >
      {{ text }}
    </v-snackbar>
  </div>
</template>

<script>
import _ from "lodash";
import { mapActions, mapGetters } from "vuex";

export default {
  data() {
    return {
      isSnackbar: false,
      debounceSnackbar: () => {}
    };
  },
  watch: {
    isShow(val) {
      this.isSnackbar = val;
      this.debounceSnackbar();
    }
  },
  computed: {
    ...mapGetters("snackbar", ["isShow", "text", "priority", "timeout"]),
    color() {
      switch (this.priority) {
        case "error":
          return "#FF1744";
        case "success":
          return "#4caf50";
        default:
          return "";
      }
    }
  },
  methods: {
    ...mapActions("snackbar", ["removeSnackbar"])
  },

  created() {
    this.debounceSnackbar = _.debounce(this.removeSnackbar, 3000);
  }
};
</script>

<style scoped lang="scss"></style>
