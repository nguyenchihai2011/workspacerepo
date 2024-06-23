<template>
  <core-dialog v-model="model" :width="450" persistent :title="title">
    <template v-slot:title>
      <div style="width: 100%;">{{ title }}</div>
      <v-divider class="my-1" color="#ccc"></v-divider>
    </template>
    <template v-slot:body>
      <div>
        <v-row no-gutters class="">
          <v-col cols="2" class="d-flex flex-column">
            <div
              class="text-subtitle-1 font-weight-bold"
              style="line-height: 24px !important;"
            >
              Name:
            </div>
            <div v-if="!isDetails" class="text-caption red--text">
              required
            </div>
          </v-col>
          <v-col v-if="!isDetails" cols="10" class="d-flex">
            <v-text-field
              v-model="sectionName"
              outlined
              class="pt-0 rounded-lg"
              dense
            ></v-text-field>
          </v-col>
          <v-col v-else cols="10">
            <div class="text-subtitle-1 font-weight-bold">
              {{ sectionName }}
            </div>
          </v-col>
        </v-row>
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
          Cancel
        </core-button>
        <core-button
          @click.native="submit()"
          tonal
          class="primary white--text ml-6"
        >
          Save
        </core-button>
      </div>
    </template>
  </core-dialog>
</template>

<script>
import { mapGetters } from "vuex";
import CoreDialog from "@/components/core/CoreDialog.vue";
import CoreButton from "@/components/core/CoreButton.vue";
import { addSection, getSectionById, updateSection } from "@/api/section";

export default {
  components: { CoreDialog, CoreButton },
  data() {
    return {
      sectionName: ""
    };
  },
  computed: {
    ...mapGetters("auth", ["lectureId"]),
    model: {
      get() {
        return this.value;
      },
      set(newValue) {
        this.$emit("input", newValue);
      }
    },

    title() {
      return this.isCreate
        ? "Create Course"
        : this.isEdit
        ? "Edit Course"
        : "Course Details";
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
    },

    createSection() {
      const payload = {
        name: this.sectionName,
        createAt: new Date().toISOString(),
        updateAt: new Date().toISOString(),
        courseId: this.courseId
      };
      addSection(payload).then(() => {
        this.$emit("createSuccess");
      });
    },

    updateSection() {
      const payload = {
        id: this.idInit,
        name: this.sectionName,
        createAt: new Date().toISOString(),
        updateAt: new Date().toISOString(),
        courseId: this.courseId
      };
      updateSection(this.idInit, payload).then(() => {
        this.$emit("createSuccess");
      });
    },

    submit() {
      if (this.action === "create") this.createSection();
      else {
        this.updateSection();
      }
    },

    fetchData() {
      getSectionById(this.idInit).then(res => {
        this.sectionName = res.data[0].name;
      });
    }
  },

  created() {
    if (!this.isCreate) this.fetchData();
  },

  props: {
    value: {
      type: Boolean
    },
    action: {
      type: String,
      default: "create"
    },
    idInit: {
      type: Number
    },
    courseId: {
      type: Number
    }
  }
};
</script>

<style lang="scss" scoped></style>
