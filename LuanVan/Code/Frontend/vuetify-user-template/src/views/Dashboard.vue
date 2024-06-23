<template>
  <v-container fluid>
    <v-row>
      <v-col cols="12" class="pa-0">
        <v-carousel hide-delimiters>
          <v-carousel-item
            v-for="(item, i) in items"
            :key="i"
            :src="item.src"
          ></v-carousel-item>
        </v-carousel>
      </v-col>
      <v-col cols="12" class="pb-0" v-if="!isLecture">
        <div class="text-h5 font-weight-bold mt-3">Top Best Sellers</div>
      </v-col>
      <v-col cols="12" class="d-flex" v-if="!isLecture">
        <v-row>
          <v-col cols="2" v-for="item in bestSellers" :key="item.id">
            <course-intro
              :courseId="item.course.id"
              :courseImage="item.course.imageUrl"
              :courseName="item.course.name"
              :courseTitle="item.course.title"
              :coursePrice="item.course.price"
              :courseRatingAvg="item.ratingAvg"
              :totalRatings="item.totalRatings"
            />
          </v-col>
        </v-row>
      </v-col>
      <v-col cols="12" class="pb-0" v-if="!isLecture">
        <div class="text-h5 font-weight-bold mt-3">For newbies</div>
      </v-col>
      <v-col cols="12" class="d-flex" v-if="!isLecture">
        <v-row>
          <v-col cols="2" v-for="course in courseNewbies" :key="course.id">
            <course-intro
              :courseId="course.id"
              :courseImage="course.imageUrl"
              :courseName="course.name"
              :courseTitle="course.title"
              :coursePrice="course.price"
              :courseRatingAvg="course.ratingAvg"
              :totalRatings="course.totalRatings"
            />
          </v-col>
        </v-row>
      </v-col>
      <v-col cols="12" class="pb-0" v-if="!isLecture">
        <div class="text-h5 font-weight-bold mt-3">Recommended for you</div>
      </v-col>
      <v-col cols="12" class="d-flex" v-if="!isLecture">
        <v-row>
          <v-col cols="2" v-for="course in recommend" :key="course.id">
            <course-intro
              :courseId="course.id"
              :courseImage="course.imageUrl"
              :courseName="course.name"
              :courseTitle="course.title"
              :coursePrice="course.price"
              :courseRatingAvg="course.ratingAvg"
              :totalRatings="course.totalRatings"
            />
          </v-col>
        </v-row>
      </v-col>
      <v-col v-if="isLecture">
        <v-img src="@/assets/dashboard_lecture_1.webp"></v-img>
      </v-col>
      <v-col v-if="isLecture">
        <v-img src="@/assets/dashboard_lecture_2.webp"></v-img>
      </v-col>
      <v-col cols="12">
        <v-row class="justify-center">
          <v-col cols="3" class="d-flex flex-column justify-center">
            <div class="text-h4 font-weight-bold mb-4">
              Upskill your team with Open Education
            </div>
            <ul class="text-h6 font-weight-regular">
              <li>
                Unlimited access to 22,000+ top Open Education courses, anytime,
                anywhere
              </li>
              <li>
                International course collection in 14 languages
              </li>
              <li>
                Top certifications in tech and business
              </li>
            </ul>
          </v-col>
          <v-col cols="3">
            <v-img src="@/assets/dashboard_intro_education.jpg"></v-img>
          </v-col>
        </v-row>
      </v-col>
      <v-col cols="12">
        <v-row class="justify-center">
          <v-col cols="3">
            <v-img src="@/assets/dashboard_become_lecture.jpg"></v-img>
          </v-col>
          <v-col cols="3" class="d-flex flex-column justify-center">
            <div class="text-h4 font-weight-bold mb-4">
              Become an instructor
            </div>
            <div class="text-h6 font-weight-regular mb-4">
              Instructors from around the world teach millions of learners on
              Open Education. We provide the tools and skills to teach what you
              love.
            </div>
            <core-button
              class="black white--text py-6"
              link
              to="/authentication/sign-up/lecture"
              >Start teaching today</core-button
            >
          </v-col>
        </v-row>
      </v-col>
    </v-row>
  </v-container>
</template>
<script>
import { mapGetters, mapActions } from "vuex";
import CourseIntro from "@/components/course/CourseIntro.vue";
import CoreButton from "@/components/core/CoreButton.vue";
import { getCategory } from "@/api/category";
import { getTopCourses } from "@/api/statistical";
import { getCourse } from "@/api/course";
export default {
  components: { CourseIntro, CoreButton },
  data: () => ({
    category: {},
    items: [
      {
        src:
          "https://img-c.udemycdn.com/notices/featured_carousel_slide/image/4349ebec-262b-42c9-83fe-b1605a3ed5b1.jpg"
      },
      {
        src:
          "https://img-c.udemycdn.com/notices/featured_carousel_slide/image/9ea59bc2-bd61-463e-9ce9-7e71e8e586ae.jpg"
      },
      {
        src:
          "https://img-c.udemycdn.com/notices/featured_carousel_slide/image/34c63aef-8d1f-483e-b0ea-0ead94879e56.jpg"
      }
    ],
    bestSellers: [],
    recommend: [],
    courseNewbies: []
  }),
  computed: {
    ...mapGetters("auth", ["role"]),
    ...mapGetters("alanAI", ["command", "value"]),
    isStudent() {
      return this.role === "Student";
    },
    isLecture() {
      return this.role === "Lecture";
    }
  },

  watch: {
    command(val) {
      if (val === "navigateMyLearning") {
        if (this.role === "Student") {
          this.$router.push("/user/my-learning");
        } else {
          this.addSnackbar({
            isShow: true,
            text: "You not have permission!",
            priority: "error",
            timeout: 3000
          });
        }
      } else if (val === "navigateMyTeaching") {
        if (this.role === "Lecture") {
          this.$router.push("/user/my-teaching");
        } else {
          this.addSnackbar({
            isShow: true,
            text: "You not have permission!",
            priority: "error",
            timeout: 3000
          });
        }
      } else if (val === "navigateCart") {
        if (this.role === "Student") {
          this.$router.push("/cart");
        } else {
          this.addSnackbar({
            isShow: true,
            text: "You not have permission!",
            priority: "error",
            timeout: 3000
          });
        }
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
    getCategoryInfo() {
      getCategory(1).then(res => {
        this.category = res.data;
      });
    }
  },

  created() {
    this.getCategoryInfo();
    getTopCourses().then(res => {
      this.bestSellers = res.data;
    });
    const paramsRecommend = {
      rating: 4,
      page: 1,
      size: 12
    };
    getCourse(paramsRecommend).then(res => {
      this.recommend = res.data.result;
    });
    const paramsCourseNewbies = {
      level: "Beginner",
      page: 1,
      size: 10
    };
    getCourse(paramsCourseNewbies).then(res => {
      this.courseNewbies = res.data.result;
    });
  }
};
</script>
<style lang=""></style>
