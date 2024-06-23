<template>
  <v-container :key="categoryKey">
    <v-row>
      <v-col cols="12">
        <div class="text-h4">{{ category.name }} Courses</div>
      </v-col>

      <v-col cols="12" class="d-flex py-0">
        <v-icon>mdi-account-supervisor</v-icon>
        <div>15 000 learners</div>
      </v-col>

      <v-col cols="12" class="pb-0">
        <div class="text-h5">Courses to get you started</div>
      </v-col>
      <v-col cols="12" class="d-flex">
        <v-row>
          <v-col cols="2" v-for="course in courseBeginners" :key="course.id">
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

      <v-col cols="12" class="pb-0">
        <div class="text-h5">Top courses in {{ category.name }}</div>
      </v-col>
      <v-col cols="12" class="d-flex">
        <v-row>
          <v-col cols="2" v-for="course in topCourses" :key="course.id">
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

      <v-col cols="12" class="pb-0 d-flex justify-space-between align-center">
        <div class="text-h5">All {{ category.name }} courses</div>
        <div>
          <v-btn class="text-none" outlined @click="clearFilter()">
            Clear filter</v-btn
          >
        </div>
      </v-col>
      <v-col cols="12">
        <v-row>
          <v-col cols="3">
            <div class="font-weight-bold">Ratings</div>
            <v-radio-group
              v-model="radioGroup"
              hide-details
              @change="changeRating()"
            >
              <v-radio
                v-for="item in radioItems"
                :key="item.value"
                :value="item.value"
              >
                <template v-slot:label>
                  <div class="d-flex mx-0">
                    <v-rating
                      :value="item.label"
                      color="amber"
                      dense
                      half-increments
                      readonly
                      size="12"
                    ></v-rating>
                    <div class="grey--text ml-1">{{ item.label }} & up</div>
                  </div>
                </template>
              </v-radio>
            </v-radio-group>
            <v-divider class="my-4"></v-divider>
            <div class="font-weight-bold">Level</div>
            <v-radio-group
              v-model="radioGroupLevel"
              hide-details
              @change="changeLevel()"
            >
              <v-radio
                v-for="item in radioItemsLevel"
                :key="item.value"
                :value="item.value"
              >
                <template v-slot:label>
                  <div class="d-flex mx-0">
                    <div class="grey--text ml-1">{{ item.label }}</div>
                  </div>
                </template>
              </v-radio>
            </v-radio-group>
            <v-divider class="my-4"></v-divider>
            <div class="font-weight-bold">Price</div>
            <v-radio-group
              v-model="radioGroupPrice"
              hide-details
              @change="changePrice()"
            >
              <v-radio
                v-for="item in radioItemsPrice"
                :key="item.value"
                :value="item.value"
              >
                <template v-slot:label>
                  <div class="d-flex mx-0">
                    <div class="grey--text ml-1">{{ item.label }}</div>
                  </div>
                </template>
              </v-radio>
            </v-radio-group>
            <v-divider class="my-4"></v-divider>
          </v-col>
          <v-col cols="9">
            <div v-for="course in course.result" :key="course.id">
              <course-details
                :courseId="course.id"
                :courseImage="course.imageUrl"
                :courseName="course.name"
                :courseTitle="course.title"
                :coursePrice="course.price"
                :lectureName="
                  `${course.lecture.firstName} ${course.lecture.lastName}`
                "
                :courseRatingAvg="course.ratingAvg"
                :totalRatings="course.totalRatings"
              >
              </course-details>
            </div>
          </v-col>
          <v-col cols="12">
            <v-pagination
              v-model="page"
              :length="course.totalPage"
              :total-visible="10"
            ></v-pagination>
          </v-col>
        </v-row>
      </v-col>
    </v-row>
  </v-container>
</template>
<script>
import CourseIntro from "@/components/course/CourseIntro.vue";
import CourseDetails from "@/components/course/CourseDetails.vue";
import { getCategory } from "@/api/category";
import { getCourse } from "@/api/course";
import { mostPurchaseCourse, topRatingCourse } from "@/api/alanAI";
import { mapGetters, mapActions } from "vuex";
export default {
  components: { CourseIntro, CourseDetails },
  data() {
    return {
      category: {},
      radioGroup: -1,
      radioItems: [
        { label: 4.5, value: 0 },
        { label: 4.0, value: 1 },
        { label: 3.5, value: 2 },
        { label: 3.0, value: 3 }
      ],
      radioGroupLevel: -1,
      radioItemsLevel: [
        { label: "Beginner", value: 0 },
        { label: "Intermediate", value: 1 },
        { label: "Expert", value: 2 }
      ],
      radioGroupPrice: -1,
      radioItemsPrice: [
        { label: "Paid", value: 0 },
        { label: "Free", value: 1 }
      ],
      checkbox: false,
      page: 1,
      course: {},
      courseBeginners: [],
      topCourses: [],
      categoryKey: 0
    };
  },

  computed: {
    ...mapGetters("alanAI", ["command", "value"])
  },

  watch: {
    "$route.params.id"() {
      this.getCategoryInfo();
      this.getCourses();
      const paramsBeginner = {
        categoryId: this.$route.params.id,
        level: "Beginner",
        page: 1,
        size: 12
      };
      getCourse(paramsBeginner).then(res => {
        this.courseBeginners = res.data.result;
      });

      const paramsTopCourse = {
        categoryId: this.$route.params.id,
        rating: 4,
        page: 1,
        size: 12
      };
      getCourse(paramsTopCourse).then(res => {
        this.topCourses = res.data.result;
      });
    },

    page() {
      this.getCourses();
    },

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
      } else if (val === "navigateDashboard") {
        this.$router.push("/");
      } else if (val === "top1purchasescourse") {
        const params = {
          categoryName: this.value
        };
        mostPurchaseCourse(params).then(res => {
          this.$router.push(`/course/${res.data.courseId}`);
        });
      } else if (val === "top1ratingcourse") {
        const params = {
          categoryName: this.value
        };
        topRatingCourse(params).then(res => {
          this.$router.push(`/course/${res.data.id}`);
        });
      } else if (val === "freecourse") {
        this.radioGroupPrice = 1;
        this.getCourses();
      } else if (val === "courseforbeginner") {
        this.radioGroupLevel = 0;
        this.getCourses();
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
      getCategory(this.$route.params.id).then(res => {
        this.category = res.data;
      });
    },

    getCourses() {
      const params = {
        categoryId: this.$route.params.id,
        rating:
          this.radioGroup !== -1
            ? this.radioItems[this.radioGroup].label
            : undefined,
        level:
          this.radioGroupLevel !== -1
            ? this.radioItemsLevel[this.radioGroupLevel].label
            : undefined,
        page: this.page,
        size: 10,
        from: this.radioGroupPrice === 0 ? 0.1 : undefined,
        to: this.radioGroupPrice === 1 ? 0 : undefined
      };
      getCourse(params).then(res => {
        this.course = res.data;
      });
    },

    changeRating() {
      this.page = 1;
      this.getCourses();
    },

    changeLevel() {
      this.page = 1;
      this.getCourses();
    },

    changePrice() {
      this.page = 1;
      this.getCourses();
    },

    clearFilter() {
      this.radioGroup = -1;
      this.radioGroupLevel = -1;
      this.radioGroupPrice = -1;
      this.page = 1;
      this.getCourses();
    }
  },

  created() {
    this.getCategoryInfo();
    this.getCourses();
    const paramsBeginner = {
      categoryId: this.$route.params.id,
      level: "Beginner",
      page: 1,
      size: 12
    };
    getCourse(paramsBeginner).then(res => {
      this.courseBeginners = res.data.result;
    });

    const paramsTopCourse = {
      categoryId: this.$route.params.id,
      rating: 4,
      page: 1,
      size: 12
    };
    getCourse(paramsTopCourse).then(res => {
      this.topCourses = res.data.result;
    });
  }
};
</script>
