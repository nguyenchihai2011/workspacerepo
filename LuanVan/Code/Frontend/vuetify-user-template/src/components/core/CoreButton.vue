<template>
  <v-btn
    v-model="model"
    class="core-button pa-4"
    :class="disabled ? 'disabled-button' : ''"
    v-bind="{ ...$attrs, ...$props }"
  >
    <slot>
      {{ label }}
    </slot>
  </v-btn>
</template>

<script>
export default {
  props: {
    value: {
      type: Boolean,
      default: false
    },
    label: {
      type: String,
      default: ""
    },
    disabled: {
      type: Boolean,
      default: false
    }
  },
  computed: {
    model: {
      get: function() {
        return this.value;
      },
      set: function(newValue) {
        this.$emit("input", newValue);
      }
    }
  }
};
</script>

<style lang="scss">
.core-button {
  .v-btn__content {
    padding: 0 16px;
    font-style: normal !important;
    font-weight: 700 !important;
    font-size: 14px !important;
    line-height: 20px !important;
    letter-spacing: 0.0025em !important;
  }
  .v-btn__loader {
    .v-progress-circular {
      background-color: transparent;
    }
  }
  .v-btn {
    border-radius: 8px !important;
  }
  .v-btn__overlay {
    visibility: hidden !important;
  }
  .v-btn__underlay {
    visibility: hidden !important;
  }
}
.disabled-button {
  .v-btn__overlay {
    visibility: visible !important;
    opacity: 0.5 !important;
  }
  .v-btn__underlay {
    visibility: visible !important;
    opacity: 0.5 !important;
  }
}
</style>
