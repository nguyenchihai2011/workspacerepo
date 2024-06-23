<template>
  <v-card>
    <v-card-title>
      {{ title }}
    </v-card-title>
    <v-data-table v-model="model" v-bind="$attrs" v-on="$listeners">
      <template v-for="(slot, name) in $scopedSlots" v-slot:[name]="item">
        <slot :name="name" v-bind="item" />
      </template>
    </v-data-table>
  </v-card>
</template>
<script>
export default {
  name: "AppDataTable",
  inheritAttrs: false,

  computed: {
    model: {
      get() {
        return this.value;
      },
      set(newValue) {
        this.$emit("input", newValue);
      }
    }
  },
  props: {
    value: {
      type: Array
    },
    title: {
      type: String,
      default: null
    }
  }
};
</script>
<style lang=""></style>
