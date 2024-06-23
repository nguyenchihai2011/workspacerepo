<template>
  <v-row no-gutters>
    <v-container>
      <v-row>
        <v-col cols="12" class="d-flex align-center justify-space-between mt-6">
          <div class="text-h4">My teaching</div>
          <core-button class="text-none" @click.native="openCourseDialog()">
            <v-icon>mdi-plus</v-icon>
            Create new course
          </core-button>
        </v-col>
        <v-col v-if="courses.length === 0" cols="12">
          <div class="text-h6 font-weight-regular">
            No courses have been created yet
          </div>
        </v-col>
        <v-col v-else cols="12">
          <v-row no-gutters>
            <v-col cols="9" v-for="course in courses" :key="course.id">
              <course-details
                :courseId="course.id"
                :courseImage="course.imageUrl"
                :courseName="course.name"
                :courseTitle="course.title"
                :coursePrice="course.price"
                :lectureName="lectureFullName(course.lecture)"
                :showPrice="false"
                :courseRatingAvg="course.ratingAvg"
                :totalRatings="course.totalRatings"
                @deleteSuccess="deleteSuccess()"
                @changeSuccess="changeSuccess()"
              ></course-details>
            </v-col>
          </v-row>
        </v-col>
      </v-row>
    </v-container>
    <course-dialog
      v-if="isCourseDialog"
      v-model="isCourseDialog"
      @closeDialog="closeCourseDialog()"
      @changeSuccess="changeSuccess()"
    ></course-dialog>
  </v-row>
</template>

<script>
import { mapGetters, mapActions } from "vuex";
import CourseDetails from "@/components/course/CourseDetails.vue";
import { getCourseYourselfLecture } from "@/api/lecture";
import CoreButton from "@/components/core/CoreButton.vue";
import CourseDialog from "@/components/course/CourseDialog.vue";
export default {
  components: { CoreButton, CourseDialog, CourseDetails },
  data() {
    return {
      isCourseDialog: false,
      courses: []
    };
  },

  computed: {
    ...mapGetters("auth", ["lectureId"]),
    ...mapGetters("alanAI", ["command", "value"])
  },

  watch: {
    command(val) {
      if (val === "navigateDashboard") {
        this.$router.push("/");
      } else if (val === "notunderstand") {
        this.addSnackbar({
          isShow: true,
          text: "Sorry! I dont have understand your request.",
          priority: "error",
          timeout: 3000
        });
      }
    }
  },

  methods: {
    ...mapActions("snackbar", ["addSnackbar"]),
    fetchCourseYourself() {
      getCourseYourselfLecture({ lectureId: this.lectureId }).then(res => {
        this.courses = res.data.result;
      });
    },

    openCourseDialog() {
      this.isCourseDialog = true;
    },
    closeCourseDialog() {
      this.isCourseDialog = false;
    },

    lectureFullName(lecture) {
      return `${lecture?.firstName} ${lecture?.lastName}`;
    },

    deleteSuccess() {
      this.fetchCourseYourself();
    },

    changeSuccess() {
      this.closeCourseDialog();
      this.fetchCourseYourself();
    }
  },

  created() {
    this.fetchCourseYourself();
  }
};
</script>
