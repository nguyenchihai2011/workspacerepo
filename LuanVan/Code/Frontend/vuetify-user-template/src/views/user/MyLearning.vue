<template>
  <v-row no-gutters>
    <v-container>
      <v-row>
        <v-col cols="12" class="d-flex align-center justify-space-between mt-6">
          <div class="text-h4">My learning</div>
        </v-col>
        <v-col v-if="student.orders && student.orders.length === 0" cols="12">
          <div class="text-h6 font-weight-regular">
            No courses have been created yet
          </div>
        </v-col>
        <v-col v-else cols="12">
          <v-row no-gutters v-for="order in student.orders" :key="order.id">
            <v-col
              cols="9"
              v-for="orderDetail in order.orderDetails"
              :key="orderDetail.id"
            >
              <course-details
                :courseId="orderDetail.course.id"
                :courseImage="orderDetail.course.imageUrl"
                :courseName="orderDetail.course.name"
                :courseTitle="orderDetail.course.title"
                :coursePrice="orderDetail.price"
                :lectureName="lectureFullName(orderDetail.course.lecture)"
                :showPrice="false"
                :courseRatingAvg="orderDetail.course.ratingAvg"
                :totalRatings="orderDetail.course.totalRatings"
              ></course-details>
            </v-col>
          </v-row>
        </v-col>
      </v-row>
    </v-container>
  </v-row>
</template>

<script>
import CourseDetails from "@/components/course/CourseDetails.vue";
import { getCourseYourselfStudent } from "@/api/student";
import { mapGetters, mapActions } from "vuex";
export default {
  components: { CourseDetails },
  data() {
    return {
      student: {}
    };
  },

  computed: {
    ...mapGetters("auth", ["studentId"]),
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
    ...mapActions("yourself", ["setCoursesOfStudent"]),
    ...mapActions("snackbar", ["addSnackbar"]),
    fetchCourseYourself() {
      getCourseYourselfStudent(this.studentId).then(res => {
        this.student = res.data;
        let coursesOfStudent = [];
        res.data.orders.forEach(element => {
          element.orderDetails.forEach(item => {
            coursesOfStudent.push(item);
          });
        });
        this.setCoursesOfStudent(coursesOfStudent);
      });
    },

    lectureFullName(lecture) {
      return `${lecture?.firstName} ${lecture?.lastName}`;
    }
  },

  created() {
    this.fetchCourseYourself();
  }
};
</script>
