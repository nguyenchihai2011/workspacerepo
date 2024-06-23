<template>
  <core-dialog v-model="model" :width="600" persistent :title="title">
    <template v-slot:title>
      <div style="width: 100%;">{{ title }}</div>
      <v-divider class="my-1" color="#ccc"></v-divider>
    </template>
    <template v-slot:body>
      <div>
        <v-row no-gutters class="">
          <v-col cols="3" class="d-flex flex-column">
            <div
              class="text-subtitle-1 font-weight-bold"
              style="line-height: 24px !important;"
            >
              Quest
            </div>
            <div v-if="!isDetails" class="text-caption red--text">
              required
            </div>
          </v-col>
          <v-col v-if="!isDetails" cols="9" class="d-flex">
            <v-text-field
              v-model="practice.quest"
              outlined
              class="pt-0 rounded-lg"
              dense
            ></v-text-field>
          </v-col>
          <!-- <v-col v-else cols="10">
            <div class="text-subtitle-1 font-weight-bold">
              {{ quiz.question }}
            </div>
          </v-col> -->
          <v-col cols="3" class="d-flex flex-column">
            <div
              class="text-subtitle-1 font-weight-bold"
              style="line-height: 24px !important;"
            >
              Function Name:
            </div>
            <div v-if="!isDetails" class="text-caption red--text">
              required
            </div>
          </v-col>
          <v-col v-if="!isDetails" cols="9" class="d-flex">
            <v-text-field
              v-model="practice.functionName"
              outlined
              class="pt-0 rounded-lg"
              dense
            ></v-text-field>
          </v-col>
          <!-- <v-col v-else cols="10">
            <div class="text-subtitle-1 font-weight-bold">
              {{ quiz.lessonId }}
            </div>
          </v-col> -->
          <v-col cols="3" class="d-flex flex-column">
            <div
              class="text-subtitle-1 font-weight-bold"
              style="line-height: 24px !important;"
            >
              Input
            </div>
            <div v-if="!isDetails" class="text-caption red--text">
              required
            </div>
          </v-col>
          <v-col v-if="!isDetails" cols="3" class="d-flex">
            <v-text-field
              v-model="testcase.input"
              outlined
              class="pt-0 rounded-lg"
              dense
            ></v-text-field>
          </v-col>
          <v-col cols="3" class="d-flex flex-column pr-4">
            <div
              class="text-subtitle-1 font-weight-bold text-end"
              style="line-height: 24px !important;"
            >
              Expected
            </div>
            <div v-if="!isDetails" class="text-caption red--text text-end">
              required
            </div>
          </v-col>
          <v-col v-if="!isDetails" cols="3" class="d-flex">
            <v-text-field
              v-model="testcase.expected"
              outlined
              class="pt-0 rounded-lg"
              dense
            ></v-text-field>
          </v-col>
          <v-col cols="9"> </v-col>
          <v-col v-if="!isDetails" cols="3" class="d-flex flex-column mt-1">
            <v-btn @click="addTestCase()" class="text-none"
              >Add test case</v-btn
            >
          </v-col>
          <v-col cols="12">
            <div v-for="(item, index) in practice.testCasesDTO" :key="index">
              <div class="text-subtitle-1 font-weight-bold">
                Testcase {{ index + 1 }}:
              </div>
              <div class="ml-4">Input: {{ item.input }}</div>
              <div class="ml-4">Expected: {{ item.expected }}</div>
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
import { getCourseById } from "@/api/course";
import { createPractice } from "@/api/practice";

export default {
  components: { CoreDialog, CoreButton },
  data() {
    return {
      practice: {
        quest: "",
        functionName: "",
        testCasesDTO: []
      },
      testcase: {
        input: "",
        expected: ""
      }
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
        ? "Create Practice"
        : this.isEdit
        ? "Edit Practice"
        : "Practice Details";
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

    addTestCase() {
      if (this.testcase.input && this.testcase.expected) {
        this.practice.testCasesDTO.push({
          input: this.testcase.input,
          expected: this.testcase.expected,
          createAt: new Date().toISOString(),
          updateAt: new Date().toISOString()
        });
        this.testcase = {
          input: "",
          expected: ""
        };
      }
    },
    submit() {
      const payload = {
        ...this.practice,
        createAt: new Date().toISOString(),
        updateAt: new Date().toISOString(),
        lessonId: this.lessonId
      };
      createPractice(payload).then(() => {
        this.closeDialog();
      });
    }
  },

  created() {},

  props: {
    value: {
      type: Boolean
    },
    action: {
      type: String,
      default: "create"
    },
    lessonId: {
      type: Number
    }
  }
};
</script>

<style lang="scss" scoped></style>
