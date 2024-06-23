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
              v-model="course.name"
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
              Title:
            </div>
            <div v-if="!isDetails" class="text-caption red--text">
              required
            </div>
          </v-col>
          <v-col v-if="!isDetails" cols="10" class="d-flex">
            <v-text-field
              v-model="course.title"
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
              Image:
            </div>
            <div v-if="!isDetails" class="text-caption red--text">
              required
            </div>
          </v-col>
          <v-col v-if="!isDetails" cols="10" class="d-flex">
            <v-file-input
              v-model="fileImage"
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
          <v-col cols="2" class="d-flex flex-column">
            <div
              class="text-subtitle-1 font-weight-bold"
              style="line-height: 24px !important;"
            >
              Description:
            </div>
          </v-col>
          <v-col v-if="!isDetails" cols="10" class="d-flex">
            <v-text-field
              v-model="course.description"
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
              Price:
            </div>
            <div v-if="!isDetails" class="text-caption red--text">
              required
            </div>
          </v-col>
          <v-col v-if="!isDetails" cols="10" class="d-flex">
            <v-text-field
              v-model="course.price"
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
              Level:
            </div>
            <div v-if="!isDetails" class="text-caption red--text">
              required
            </div>
          </v-col>
          <v-col v-if="!isDetails" cols="10" class="d-flex">
            <v-select
              v-model="course.level"
              :items="['Beginner', 'Intermediate', 'Expert']"
              class="pt-0 rounded-lg"
              dense
              outlined
            ></v-select>
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
              Language:
            </div>
            <div v-if="!isDetails" class="text-caption red--text">
              required
            </div>
          </v-col>
          <v-col v-if="!isDetails" cols="10" class="d-flex">
            <v-text-field
              v-model="course.language"
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
              Category:
            </div>
            <div v-if="!isDetails" class="text-caption red--text">
              required
            </div>
          </v-col>
          <v-col v-if="!isDetails" cols="10" class="d-flex">
            <v-select
              v-model="course.categoryId"
              :items="categories"
              class="pt-0 rounded-lg"
              item-text="name"
              item-value="id"
              dense
              outlined
            ></v-select>
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
import { getListCategory } from "@/api/category";
import { addCourse, getCourseById, updateCourse } from "@/api/course";

const cloudName = "drampapfw";
const uploadPreset = "education";

export default {
  components: { CoreDialog, CoreButton },
  data() {
    return {
      categories: [],
      course: {
        name: "",
        title: "",
        imageUrl: "",
        description: "",
        price: 0,
        level: "",
        language: "",
        categoryId: ""
      },
      fileImage: null
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

    fetchCategories(params = {}) {
      getListCategory(params).then(res => {
        this.categories = res.data;
      });
    },

    createCourse() {
      const payload = {
        ...this.course,
        price: Number(this.course.price),
        createBy: String(this.lectureId),
        createAt: new Date().toISOString(),
        updateBy: String(this.lectureId),
        updateAt: new Date().toISOString(),
        lectureId: this.lectureId
      };
      addCourse(payload).then(() => {
        this.$emit("changeSuccess");
      });
    },

    updateCourse() {
      const payload = {
        id: this.idInit,
        name: this.course.name,
        title: this.course.title,
        imageUrl: this.course.imageUrl,
        description: this.course.description,
        level: this.course.level,
        language: this.course.language,
        categoryId: this.course.categoryId,
        price: Number(this.course.price),
        createBy: String(this.lectureId),
        createAt: new Date().toISOString(),
        updateBy: String(this.lectureId),
        updateAt: new Date().toISOString(),
        lectureId: this.lectureId
      };
      updateCourse(this.idInit, payload).then(() => {
        this.$emit("changeSuccess");
      });
    },

    async submit() {
      const file = this.fileImage;
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
        this.course.imageUrl = response.data.secure_url;
        if (this.isCreate) this.createCourse();
        if (this.isEdit) this.updateCourse();
      } catch (error) {
        console.error("Error uploading file:", error);
      }
    }
  },

  created() {
    if (!this.isCreate)
      getCourseById(this.idInit).then(res => {
        this.course = res.data;
      });
    this.fetchCategories();
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
    }
  }
};
</script>

<style lang="scss" scoped></style>
