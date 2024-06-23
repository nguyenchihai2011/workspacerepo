<template>
  <v-navigation-drawer
    :key="navigationKey"
    :rail="isCollapseNav"
    rail-width="64"
    width="250"
    permanent
    class="core-left-navigation font-weight-bold"
  >
    <div class="pa-3">
      <slot></slot>
    </div>
    <div class="custom-icon">
      <v-icon
        class="icon-clock"
        size="20"
        @click="toggleNavigation()"
        :icon="isCollapseNav ? 'mdi-chevron-right' : 'mdi-chevron-left'"
        color="#898989"
      />
    </div>
  </v-navigation-drawer>
</template>

<script>
import { mapActions, mapGetters } from "vuex";
export default {
  data() {
    return {
      navigationKey: 0,
    };
  },
  computed: {
    ...mapGetters("layout", ["isCollapseNav"]),
  },
  methods: {
    ...mapActions("layout", ["setCollapseNav"]),
    toggleNavigation() {
      this.setCollapseNav(!this.isCollapseNav);
    },
  },
  watch: {
    isCollapseNav() {
      this.navigationKey++;
    },
  },
};
</script>

<style lang="scss">
@import "@/styles/variables.scss";
.core-left-navigation {
  background-color: $gfit-light;
  color: $gfit-dark;
  position: relative;
  .custom-icon {
    position: absolute;
    display: flex;
    align-items: center;
    justify-content: center;
    right: -12.5px;
    top: 85px;
    border-radius: 50px;
    width: 25px;
    height: 25px;
    background: #ffffff;
    border: 1px solid #d9d9d9;
    box-shadow: 0 4px 4px rgba(0, 0, 0, 0.25);
  }
}
</style>
