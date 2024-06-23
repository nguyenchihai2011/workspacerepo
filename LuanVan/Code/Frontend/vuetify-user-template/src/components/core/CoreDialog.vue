<template>
  <v-dialog
    v-bind="{ ...$attrs }"
    :width="width"
    :height="height"
    :persistent="persistent"
  >
    <v-card class="rounded-lg pb-2">
      <v-card-title class="d-block">
        <slot name="title">
          <div>{{ title }}</div>
        </slot>
      </v-card-title>
      <v-card-text class="pb-0 pt-2 pb-4">
        <slot name="body"></slot>
      </v-card-text>
      <v-card-actions class="d-block">
        <slot name="actions"></slot>
      </v-card-actions>
    </v-card>
  </v-dialog>
</template>

<script lang="ts">
export default {
  data() {
    return {};
  },
  created() {},
  props: {
    width: {
      type: Number,
      default: 300
    },
    height: {
      type: Number,
      default: 300
    },
    title: {
      type: String,
      default: ""
    },
    persistent: {
      type: Boolean,
      default: true
    }
  }
};
</script>

<style lang="scss" scoped></style>
