<template>
  <core-dialog v-model="model" :width="600" persistent :title="title">
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
              Question
            </div>
            <div v-if="!isDetails" class="text-caption red--text">
              required
            </div>
          </v-col>
          <v-col v-if="!isDetails" cols="10" class="d-flex">
            <v-text-field
              v-model="quiz.question"
              outlined
              class="pt-0 rounded-lg"
              dense
            ></v-text-field>
          </v-col>
          <v-col v-else cols="10">
            <div class="text-subtitle-1 font-weight-bold">
              {{ quiz.question }}
            </div>
          </v-col>
          <v-col cols="2" class="d-flex flex-column">
            <div
              class="text-subtitle-1 font-weight-bold"
              style="line-height: 24px !important;"
            >
              Lesson:
            </div>
            <div v-if="!isDetails" class="text-caption red--text">
              required
            </div>
          </v-col>
          <v-col v-if="!isDetails" cols="10" class="d-flex">
            <v-select
              v-model="quiz.lessonId"
              :items="lessons"
              class="pt-0 rounded-lg"
              item-text="name"
              item-value="id"
              dense
              outlined
            ></v-select>
          </v-col>
          <v-col v-else cols="10">
            <div class="text-subtitle-1 font-weight-bold">
              {{ quiz.lessonId }}
            </div>
          </v-col>
          <v-col cols="2" class="d-flex flex-column">
            <div
              class="text-subtitle-1 font-weight-bold"
              style="line-height: 24px !important;"
            >
              Answer
            </div>
            <div v-if="!isDetails" class="text-caption red--text">
              required
            </div>
          </v-col>
          <v-col v-if="!isDetails" cols="8" class="d-flex">
            <v-text-field
              v-model="answer"
              outlined
              class="pt-0 rounded-lg"
              dense
            ></v-text-field>
          </v-col>
          <v-col v-if="!isDetails" cols="2" class="d-flex flex-column mt-1">
            <v-btn @click="addAnswer()" class="text-none">Add answer</v-btn>
          </v-col>
          <v-col
            v-if="answerList.length > 0"
            cols="12"
            class="d-flex flex-column"
          >
            <div
              class="text-subtitle-1 font-weight-bold"
              style="line-height: 24px !important;"
            >
              Select true answer
            </div>
          </v-col>
          <v-col cols="12" class="d-flex">
            <v-radio-group v-model="radioGroup">
              <v-radio
                v-for="item in answerList"
                :key="item"
                :label="item"
                :value="item"
              ></v-radio>
            </v-radio-group>
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
import { getCourseById } from "@/api/course";

export default {
  components: { CoreDialog, CoreButton },
  data() {
    return {
      quiz: {
        question: "",
        lessonId: ""
      },
      answer: "",
      answerList: [],
      lessons: [],
      radioGroup: ""
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
        ? "Create Quiz"
        : this.isEdit
        ? "Edit Quiz"
        : "Quiz Details";
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

    addAnswer() {
      if (this.answer) {
        this.answerList.push(this.answer);
        this.answer = "";
      }
    },

    fetchData() {
      getCourseById(this.courseId).then(res => {
        res.data.sections.forEach(element => {
          element.lessons.forEach(item => {
            this.lessons.push(item);
          });
        });
      });
    }
  },

  created() {
    this.fetchData();
  },

  props: {
    value: {
      type: Boolean
    },
    action: {
      type: String,
      default: "create"
    },
    courseId: {
      type: Number
    }
  }
};
</script>

<style lang="scss" scoped></style>
