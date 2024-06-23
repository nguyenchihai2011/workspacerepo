<template>
  <v-container>
    <v-row>
      <v-col cols="4">
        <router-link :to="`/course/${courseId}`" class="d-block">
          <!-- <v-img cover :src="courseImage"></v-img> -->
          <v-img class="mr-2 d-block" contain :src="courseImage" />
        </router-link>
      </v-col>
      <v-col cols="6">
        <div class="font-weight-bold">{{ courseName }}</div>
        <div class="text-subtitle-1 course-title">{{ courseTitle }}</div>
        <div class="text-caption">{{ lectureName }}</div>
        <div class="d-flex mx-0">
          <v-rating
            :value="courseRatingAvg"
            color="amber"
            dense
            half-increments
            readonly
            size="12"
          ></v-rating>
          <div class="grey--text ml-1">
            {{ courseRatingAvg }} ({{ totalRatings }})
          </div>
        </div>
        <!-- <div class="text-caption">
          38 total mins <v-icon>mdi-circle-small</v-icon>7
          letures<v-icon>mdi-circle-small</v-icon>All Levels
        </div> -->
      </v-col>
      <v-col cols="2" v-if="isLecture">
        <v-menu offset-y>
          <template v-slot:activator="{ on, attrs }">
            <v-btn text v-bind="attrs" v-on="on">
              <v-icon>mdi-dots-vertical</v-icon>
            </v-btn>
          </template>
          <v-list>
            <v-list-item @click="openEditCourse()">
              <v-list-item-title>
                <v-icon>mdi-pencil</v-icon>
              </v-list-item-title>
            </v-list-item>
            <v-list-item @click="deleteCourse()">
              <v-list-item-title>
                <v-icon>mdi-delete</v-icon>
              </v-list-item-title>
            </v-list-item>
          </v-list>
        </v-menu>
      </v-col>
      <v-col cols="2" v-if="showPrice">
        <div class="py-0 px-4 font-weight-bold">{{ coursePrice }} USD</div>
        <!-- <core-button
          class="mt-2 py-5 deep-purple lighten-2 white--text text-none"
        >
          <v-icon>mdi-cart-plus</v-icon>
          <div class="ml-2">Add to cart</div>
        </core-button> -->
      </v-col>
    </v-row>
    <course-dialog
      v-if="isCourseDialog"
      v-model="isCourseDialog"
      :idInit="courseId"
      action="edit"
      @closeDialog="closeCourseDialog()"
      @changeSuccess="changeSuccess()"
    ></course-dialog>
  </v-container>
</template>

<script>
import CourseDialog from "@/components/course/CourseDialog.vue";
import { deleteCourse } from "@/api/course";
import { mapGetters } from "vuex";
export default {
  components: {
    CourseDialog
  },

  data() {
    return {
      isCourseDialog: false
    };
  },

  computed: {
    ...mapGetters("auth", ["role"]),
    isLecture() {
      return this.role === "lecture";
    }
  },

  methods: {
    navigateToCourse() {
      this.$router.push("/course");
    },
    closeCourseDialog() {
      this.isCourseDialog = false;
    },
    openEditCourse() {
      this.isCourseDialog = true;
    },
    deleteCourse() {
      deleteCourse([this.courseId]).then(res => {
        this.$emit("deleteSuccess");
      });
    },
    changeSuccess() {
      this.closeCourseDialog();
      this.$emit("changeSuccess");
    }
  },
  props: {
    courseId: {
      type: Number
    },
    courseImage: {
      type: String
    },
    courseName: {
      type: String
    },
    courseTitle: {
      type: String
    },
    coursePrice: {
      type: Number
    },
    lectureName: {
      type: String
    },
    showPrice: {
      type: Boolean,
      default: true
    },
    courseRatingAvg: {
      type: Number
    },
    totalRatings: {
      type: Number
    }
  }
};
</script>

<style lang="scss" scoped>
.course-title {
  overflow: hidden;
  text-overflow: ellipsis;
  display: -webkit-box;
  -webkit-line-clamp: 3;
  -webkit-box-orient: vertical;
}
</style>
