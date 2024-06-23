<template>
  <core-dialog
    v-model="model"
    :width="650"
    :height="800"
    persistent
    :title="title"
  >
    <template v-slot:title>
      <div style="width: 100%;">{{ title }}</div>
      <v-divider class="my-1" color="#ccc"></v-divider>
    </template>
    <template v-slot:body>
      <div>
        <v-row no-gutters class="">
          <v-col cols="2"> </v-col>
          <v-col cols="10">
            <v-checkbox
              v-model="lesson.isReview"
              :label="`Video preview`"
            ></v-checkbox>
          </v-col>
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
              v-model="lesson.name"
              outlined
              class="pt-0 rounded-lg"
              dense
            ></v-text-field>
          </v-col>
          <v-col v-else cols="10">
            <div class="text-subtitle-1 font-weight-bold">
              {{ categoryName }}
            </div>
          </v-col>
          <v-col cols="2" class="d-flex flex-column">
            <div
              class="text-subtitle-1 font-weight-bold"
              style="line-height: 24px !important;"
            >
              Video:
            </div>
            <div v-if="!isDetails" class="text-caption red--text">
              required
            </div>
          </v-col>
          <v-col v-if="!isDetails" cols="10" class="d-flex">
            <v-file-input
              v-model="fileVideo"
              outlined
              dense
              :prepend-icon="null"
              small-chips
            ></v-file-input>
          </v-col>
          <v-col v-else cols="10">
            <div class="text-subtitle-1 font-weight-bold">
              {{ categoryName }}
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
import axios from "axios";
import { mapGetters } from "vuex";
import CoreDialog from "@/components/core/CoreDialog.vue";
import CoreButton from "@/components/core/CoreButton.vue";
import { addLesson, getLessonById, updateLesson } from "@/api/lesson";
const cloudName = "drampapfw";
const uploadPreset = "education";

export default {
  components: { CoreDialog, CoreButton },
  data() {
    return {
      lesson: {
        name: "",
        isReview: false,
        videoUrl: "",
        isReview: false
      },
      fileVideo: null
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
        ? "Create Lesson"
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

    createLesson() {
      const payload = {
        ...this.lesson,
        index: 1,
        time: new Date().toISOString(),
        createAt: new Date().toISOString(),
        updateAt: new Date().toISOString(),
        sectionId: this.sectionId
      };
      addLesson(payload).then(() => {
        this.$emit("createSuccess");
      });
    },

    updateLesson() {
      updateLesson(this.idInit, this.lesson).then(res => {
        this.$emit("createSuccess");
      });
    },

    async submit() {
      const file = this.fileVideo;
      const formData = new FormData();
      formData.append("file", file);
      formData.append("upload_preset", uploadPreset);

      try {
        const response = await axios.post(
          `https://api.cloudinary.com/v1_1/${cloudName}/upload`,
          formData,
          {
            headers: {
              "Content-Type": "multipart/form-data"
            }
          }
        );
        this.lesson.videoUrl = response.data.secure_url;
        if (this.isCreate) this.createLesson();
        else {
          this.updateLesson();
        }
      } catch (error) {
        console.error("Error uploading file:", error);
      }
    },

    fetchData() {
      getLessonById(this.idInit).then(res => {
        this.lesson = res.data;
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
    sectionId: {
      type: Number
    }
  }
};
</script>

<style lang="scss" scoped></style>
