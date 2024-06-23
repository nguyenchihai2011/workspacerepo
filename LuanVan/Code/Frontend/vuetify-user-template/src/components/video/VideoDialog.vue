<template>
  <core-dialog
    v-model="model"
    :width="650"
    :height="700"
    persistent
    :title="title"
  >
    <template v-slot:title>
      <div style="width: 100%;">{{ title }}</div>
      <v-divider class="my-1" color="#ccc"></v-divider>
    </template>
    <template v-slot:body>
      <div>
        <video controls width="100%">
          <source :src="videoUrl" />
        </video>
      </div>
    </template>
    <template v-slot:actions>
      <div class="d-flex justify-center">
        <core-button
          @click.native="closeDialog()"
          outlined
          color="primary"
          class="rounded-lg"
        >
          Close
        </core-button>
        <!-- <core-button
          @click.native="submit()"
          tonal
          class="primary white--text ml-6"
        >
          Save
        </core-button> -->
      </div>
    </template>
  </core-dialog>
</template>

<script>
import CoreDialog from "@/components/core/CoreDialog.vue";
import CoreButton from "@/components/core/CoreButton.vue";

export default {
  components: { CoreDialog, CoreButton },
  data() {
    return {};
  },
  computed: {
    model: {
      get() {
        return this.value;
      },
      set(newValue) {
        this.$emit("input", newValue);
      }
    },

    isCreate() {
      return this.action === "create";
    },

    isEdit() {
      return this.action === "edit";
    },

    isDetails() {
      return this.action === "details";
    }
  },

  methods: {
    closeDialog() {
      this.$emit("closeDialog");
    }
  },

  created() {},

  props: {
    value: {
      type: Boolean
    },
    title: {
      type: String
    },
    videoUrl: {
      type: String
    }
  }
};
</script>

<style lang="scss" scoped></style>
