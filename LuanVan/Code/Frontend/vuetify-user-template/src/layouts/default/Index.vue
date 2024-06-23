<template>
  <v-app>
    <core-header></core-header>
    <default-view />
    <core-footer v-if="$route.name !== 'Lesson'"></core-footer>
  </v-app>
</template>
<script>
import CoreHeader from "@/components/core/CoreHeader.vue";
import CoreFooter from "@/components/core/CoreFooter.vue";
import DefaultView from "@/layouts/default/View.vue";
export default {
  name: "DefaultLayout",
  components: {
    DefaultView,
    CoreHeader,
    CoreFooter
  }
};
</script>
<style lang=""></style>
