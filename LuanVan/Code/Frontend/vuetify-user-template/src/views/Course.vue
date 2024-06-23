<template>
  <div>
    <div class="black white--text" v-if="isShow">
      <v-container style="position: relative">
        <v-row>
          <v-col cols="8" class="pa-0">
            <div class="text-h4 my-2">{{ course.name }}</div>
            <div class="text-subtitle-1">{{ course.title }}</div>
            <v-btn text class="text-none pa-0" @click="openRatingDialog()">
              <div class="d-flex mx-0 my-2">
                <v-rating
                  :value="4.5"
                  color="amber"
                  dense
                  half-increments
                  readonly
                  size="12"
                ></v-rating>
                <div class="purple--text text--lighten-4 ml-1">
                  {{ ratingCourse.averageRating }} ({{
                    ratingCourse.totalRatings
                  }}
                  ratings)
                </div>
              </div>
            </v-btn>
            <div>
              Created by
              <span class="purple--text text--lighten-4"
                >{{ course.lecture.firstName }}
                {{ course.lecture.lastName }}</span
              >
            </div>
            <div class="d-flex mt-2 my-8">
              <v-icon color="white">mdi-alert-octagram</v-icon>
              <div class="ml-2 text-subtitle-2">
                Last updated {{ formatDate(course.updateAt) }}
              </div>
              <v-icon color="white" class="ml-4">mdi-web</v-icon>
              <div class="ml-2 text-subtitle-2">{{ course.language }}</div>
            </div>
          </v-col>
          <v-col
            cols="4"
            style="position: absolute; right: 0; top: 0"
            class="pa-0"
          >
            <v-card class="rounded-0">
              <video controls width="100%">
                <source src="@/assets/videos/Demo.mp4" />
              </video>
              <v-card-title class="text-h5 font-weight-bold"
                >{{ course.price }} USD</v-card-title
              >
              <div v-if="!isLogged || (isStudent && !hasCourse)">
                <v-card-title class="py-0">
                  <v-btn
                    class="text-none purple white--text"
                    text
                    width="100%"
                    @click="addToCart(course)"
                    >Add to card</v-btn
                  >
                </v-card-title>
                <v-card-title class="pt-2 pb-8">
                  <v-btn
                    class="text-none"
                    outlined
                    width="100%"
                    @click="buyNow()"
                    >Buy now</v-btn
                  >
                </v-card-title>
              </div>
              <div v-else>
                <v-card-title class="py-4">
                  <v-btn
                    @click="
                      $router.push(
                        `/course/${course.id}/lesson/${course.sections[0].lessons[0].id}`
                      )
                    "
                    class="text-none purple white--text"
                    text
                    width="100%"
                    >Go to course</v-btn
                  >
                </v-card-title>
              </div>
            </v-card>
          </v-col>
        </v-row>
      </v-container>
    </div>
    <v-container>
      <v-row>
        <v-col cols="8" class="pl-0 mt-4">
          <v-card>
            <v-card-title class="text-h5 font-weight-bold">
              What you'll learn
            </v-card-title>
            <v-row class="mx-4">
              <v-col cols="6" class="d-flex">
                <v-icon class="mr-2">mdi-check</v-icon>
                <div>Only practical demostations of javascript concepts</div>
              </v-col>
              <v-col cols="6" class="d-flex">
                <v-icon class="mr-2">mdi-check</v-icon>
                <div>Only practical demostations of javascript concepts</div>
              </v-col>
              <v-col cols="6" class="d-flex">
                <v-icon class="mr-2">mdi-check</v-icon>
                <div>Only practical demostations of javascript concepts</div>
              </v-col>
              <v-col cols="6" class="d-flex">
                <v-icon class="mr-2">mdi-check</v-icon>
                <div>Only practical demostations of javascript concepts</div>
              </v-col>
              <v-col cols="6" class="d-flex">
                <v-icon class="mr-2">mdi-check</v-icon>
                <div>Only practical demostations of javascript concepts</div>
              </v-col>
            </v-row>
          </v-card>
          <div class="mt-15">
            <v-card-title
              class="text-h5 font-weight-bold justify-space-between"
            >
              <div>Course content</div>
              <core-button
                v-if="isLecture"
                class="text-none"
                outlined
                @click.native="openSectionDialog({}, 'create')"
              >
                <v-icon>mdi-plus</v-icon>
                Create new section
              </core-button>
            </v-card-title>
            <!-- <v-card-subtitle>
              1 section <v-icon>mdi-circle-small</v-icon> 7 lectures
              <v-icon>mdi-circle-small</v-icon> 37m total
              lenght</v-card-subtitle
            > -->
            <v-row class="mx-4">
              <v-col cols="12">
                <v-expansion-panels>
                  <v-expansion-panel
                    v-for="item in course.sections"
                    :key="item.id"
                  >
                    <v-expansion-panel-header class="font-weight-bold text-h6">
                      <div style="min-width: 540px">{{ item.name }}</div>
                      <v-menu v-if="isLecture" offset-y class="d-inline-block">
                        <template v-slot:activator="{ on, attrs }">
                          <v-btn text v-bind="attrs" v-on="on">
                            <v-icon>mdi-dots-vertical</v-icon>
                          </v-btn>
                        </template>
                        <v-list>
                          <v-list-item @click="openSectionDialog(item, 'edit')">
                            <v-list-item-title class="d-flex justify-center">
                              <v-icon>mdi-pencil</v-icon>
                            </v-list-item-title>
                          </v-list-item>
                          <v-list-item @click="deleteSection(item)">
                            <v-list-item-title class="d-flex justify-center">
                              <v-icon>mdi-delete</v-icon>
                            </v-list-item-title>
                          </v-list-item>
                        </v-list>
                      </v-menu>
                    </v-expansion-panel-header>
                    <v-expansion-panel-content
                      v-for="lesson in item.lessons"
                      :key="lesson.id"
                    >
                      <v-card flat>
                        <v-row>
                          <v-col cols="1"
                            ><v-icon>mdi-presentation-play</v-icon></v-col
                          >
                          <v-col cols="7">
                            <div>{{ lesson.name }}</div>
                            <div class="d-flex">
                              <div
                                v-for="(quiz, index) in lesson.quizzes"
                                :key="index"
                              >
                                <v-btn class="mr-1" outlined rounded small>{{
                                  index + 1
                                }}</v-btn>
                              </div>
                            </div>
                          </v-col>
                          <v-col cols="2">
                            <v-btn
                              text
                              class="d-flex justify-end text-none blue--text text-decoration-underline"
                              @click="openVideoDialog(lesson)"
                              v-if="lesson.isReview"
                            >
                              Preview
                            </v-btn>
                          </v-col>
                          <v-col cols="2"
                            ><div class="d-flex justify-end">
                              <v-menu
                                v-if="isLecture"
                                offset-y
                                class="d-inline-block"
                              >
                                <template v-slot:activator="{ on, attrs }">
                                  <v-btn text v-bind="attrs" v-on="on">
                                    <v-icon>mdi-dots-vertical</v-icon>
                                  </v-btn>
                                </template>
                                <v-list>
                                  <v-list-item
                                    @click="
                                      openQuizDialog(lesson, {}, 'create')
                                    "
                                  >
                                    <v-list-item-title
                                      class="d-flex justify-center"
                                    >
                                      <v-icon>mdi-help-box-multiple</v-icon>
                                    </v-list-item-title>
                                  </v-list-item>
                                  <v-list-item
                                    @click="
                                      openPracticeDialog(lesson, {}, 'create')
                                    "
                                  >
                                    <v-list-item-title
                                      class="d-flex justify-center"
                                    >
                                      <v-icon>mdi-book-play</v-icon>
                                    </v-list-item-title>
                                  </v-list-item>
                                  <v-list-item
                                    @click="
                                      openLessonDialog(item, lesson, 'edit')
                                    "
                                  >
                                    <v-list-item-title
                                      class="d-flex justify-center"
                                    >
                                      <v-icon>mdi-pencil</v-icon>
                                    </v-list-item-title>
                                  </v-list-item>
                                  <v-list-item @click="deleteLesson(lesson)">
                                    <v-list-item-title
                                      class="d-flex justify-center"
                                    >
                                      <v-icon>mdi-delete</v-icon>
                                    </v-list-item-title>
                                  </v-list-item>
                                </v-list>
                              </v-menu>
                            </div></v-col
                          >
                        </v-row>
                      </v-card>
                    </v-expansion-panel-content>
                    <v-expansion-panel-content>
                      <div class="d-flex justify-end">
                        <core-button
                          v-if="isLecture"
                          class="text-none"
                          outlined
                          @click.native="openLessonDialog(item, {}, 'create')"
                        >
                          <v-icon>mdi-plus</v-icon>
                          Create new lesson
                        </core-button>
                      </div>
                    </v-expansion-panel-content>
                  </v-expansion-panel>
                </v-expansion-panels>
              </v-col>
            </v-row>
          </div>
          <div class="mt-15">
            <v-card-title class="text-h5 font-weight-bold">
              Description
            </v-card-title>
            <v-card-subtitle class="font-weight-bold font-italic pt-1">
              Learn javascript programming language
            </v-card-subtitle>
            <div class="px-4">
              <p>
                Take this Javascript training course and start learning
                Javascript today. "As a business person, I have no place in
                programming." Ten years ago you could have gotten away with that
                statement.
              </p>
              <p>
                Take this Javascript training course and start learning
                Javascript today. "As a business person, I have no place in
                programming." Ten years ago you could have gotten away with that
                statement.
              </p>
              <p>
                Take this Javascript training course and start learning
                Javascript today. "As a business person, I have no place in
                programming." Ten years ago you could have gotten away with that
                statement.
              </p>
            </div>
          </div>
          <div class="mt-15">
            <v-card-title class="text-h5 font-weight-bold">
              <div class="d-flex" v-if="ratingCourse.averageRating > 0">
                <v-icon color="amber">mdi-star</v-icon>
                <div class="text-h6 font-weight-bold">
                  {{ ratingCourse.averageRating }} course rating
                </div>
              </div>
            </v-card-title>
            <v-row class="px-4">
              <v-col
                cols="6"
                v-for="item in ratingCourse.ratingsWithAverage"
                :key="item.id"
              >
                <v-card>
                  <div class="d-flex align-center">
                    <v-avatar size="48" class="mr-4">
                      <img :src="item.avatarUrl" alt="John" />
                    </v-avatar>
                    <div>
                      <div class="font-weight-bold">{{ item.name }}</div>
                      <v-rating
                        :value="item.start"
                        color="amber"
                        dense
                        half-increments
                        readonly
                        size="12"
                      ></v-rating>
                    </div>
                    <v-spacer></v-spacer>
                    <v-btn text small>
                      <v-icon size="20">mdi-dots-vertical</v-icon>
                    </v-btn>
                  </div>
                  <div class="pa-4 pb-6">{{ item.content }}</div>
                </v-card>
              </v-col>
            </v-row>
          </div>
          <v-btn
            v-if="
              ratingCourse.ratingsWithAverage &&
                ratingCourse.ratingsWithAverage.length > 0
            "
            class="text-none ml-4 mt-4"
            outlined
            >Show all review</v-btn
          >
        </v-col>
      </v-row>
    </v-container>
    <section-dialog
      v-if="isSectionDialog"
      v-model="isSectionDialog"
      :idInit="sectionId"
      :courseId="course.id"
      :action="sectionAction"
      @closeDialog="closeDialog()"
      @createSuccess="createSectionSuccess()"
    ></section-dialog>
    <lesson-dialog
      v-if="isLessonDialog"
      v-model="isLessonDialog"
      :sectionId="sectionId"
      :action="lessonAction"
      :idInit="lessonId"
      @closeDialog="closeDialog()"
      @createSuccess="createLessonSuccess()"
    ></lesson-dialog>
    <quiz-dialog
      v-if="isQuizDialog"
      v-model="isQuizDialog"
      :action="'create'"
      :courseId="course.id"
      @closeDialog="closeDialog()"
      @createSuccess="createLessonSuccess()"
    ></quiz-dialog>
    <practice-dialog
      v-if="isPracticeDialog"
      v-model="isPracticeDialog"
      :action="'create'"
      :lessonId="lessonId"
      @closeDialog="closeDialog()"
      @createSuccess="createLessonSuccess()"
    ></practice-dialog>
    <video-dialog
      v-if="isVideoDialog"
      v-model="isVideoDialog"
      :title="title"
      :videoUrl="videoUrl"
      @closeDialog="closeDialog()"
    >
    </video-dialog>
    <core-dialog v-model="ratingDialog" width="500">
      <template v-slot:title>
        <div style="width: 100%;">{{ "How would you rate this course?" }}</div>
        <v-divider class="my-1" color="#ccc"></v-divider>
      </template>
      <template v-slot:body>
        <div class="d-flex justify-center">
          <v-rating
            v-model="ratingCount"
            background-color="yellow darken-3"
            color="yellow darken-2"
            size="80"
            hover
          ></v-rating>
        </div>
        <div class="d-flex justify-center">
          <v-textarea
            v-model="ratingText"
            outlined
            placeholder="Enter the text for rating"
            color="#000"
            hide-details
            height="80"
            class="rounded-l"
          ></v-textarea>
        </div>
      </template>
      <template v-slot:actions>
        <div class="d-flex justify-center">
          <core-button
            @click.native="ratingDialog = false"
            outlined
            color="primary"
            class="rounded-lg"
          >
            Close
          </core-button>
          <core-button
            @click.native="submitRating()"
            tonal
            class="primary white--text ml-6"
          >
            Submit
          </core-button>
        </div>
      </template></core-dialog
    >
  </div>
</template>
<script>
import _ from "lodash";
import SectionDialog from "@/components/section/SectionDialog.vue";
import LessonDialog from "@/components/lesson/LessonDialog.vue";
import QuizDialog from "@/components/quiz/QuizDialog.vue";
import CoreButton from "@/components/core/CoreButton.vue";
import CoreDialog from "@/components/core/CoreDialog.vue";
import PracticeDialog from "@/components/practice/PracticeDialog.vue";
import VideoDialog from "@/components/video/VideoDialog.vue";
import { addOrder } from "@/api/order";
import { getCourseById } from "@/api/course";
import { deleteCartDetails } from "@/api/cartDetails";
import { getRatingsCourse, postRating } from "@/api/ratings";
import { deleteSection } from "@/api/section";
import { topRatingCourse } from "@/api/alanAI";
import { deleteLesson } from "@/api/lesson";
import { createCartDetails } from "@/api/cartDetails";
import { mapActions, mapGetters } from "vuex";
export default {
  components: {
    SectionDialog,
    LessonDialog,
    CoreButton,
    VideoDialog,
    QuizDialog,
    CoreDialog,
    PracticeDialog
  },
  data() {
    return {
      course: {},
      isShow: false,
      isSectionDialog: false,
      isLessonDialog: false,
      isQuizDialog: false,
      isPracticeDialog: false,
      lessonId: undefined,
      sectionId: undefined,
      lessons: [],
      isVideoDialog: false,
      title: "",
      videoUrl: "",
      ratingCourse: {},
      sectionAction: "",
      lessonAction: "",
      ratingDialog: false,
      ratingCount: 0,
      ratingText: ""
    };
  },

  computed: {
    ...mapGetters("auth", ["role", "token", "cartId", "studentId"]),
    ...mapGetters("buy", ["listCourseSelectToBuy", "cartQuantity"]),
    ...mapGetters("yourself", ["coursesOfStudent"]),
    ...mapGetters("alanAI", ["command", "value"]),

    isLogged() {
      return !!this.token;
    },

    isStudent() {
      return this.role === "Student";
    },

    isLecture() {
      return this.role === "Lecture";
    },

    hasCourse() {
      return _.some(this.coursesOfStudent, { courseId: this.course.id });
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
      } else if (val === "navigateDashboard") {
        this.$router.push("/");
      } else if (val === "top1ratingcourse") {
        const params = {
          categoryName: this.value
        };
        topRatingCourse(params).then(res => {
          this.$router.push(`/course/${res.data.id}`);
        });
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
    ...mapActions("buy", [
      "setIsBuyNow",
      "setCourseBuyNow",
      "setCartQuantity",
      "setListCourseSelectToBuy"
    ]),
    ...mapActions("snackbar", ["addSnackbar"]),
    formatDate(date) {
      const result = new Date(date);
      return result.toLocaleDateString("en-GB");
    },
    openSectionDialog(item, action) {
      this.isSectionDialog = true;
      this.sectionAction = action;
      if (!_.isEmpty(item)) {
        this.sectionId = item.id;
      } else {
        this.sectionId = "";
      }
    },

    openQuizDialog(item, action) {
      this.isQuizDialog = true;
      this.sectionAction = action;
      if (!_.isEmpty(item)) {
        this.sectionId = item.id;
      } else {
        this.sectionId = "";
      }
    },

    openPracticeDialog(item, action) {
      this.isPracticeDialog = true;
      this.sectionAction = action;
      this.lessonId = item.id;
    },

    openRatingDialog() {
      this.ratingDialog = true;
    },

    submitRating() {
      const payload = {
        start: this.ratingCount,
        content: this.ratingText,
        createAt: new Date().toISOString(),
        updateAt: new Date().toISOString(),
        studentId: Number(this.studentId),
        courseId: Number(this.course.id)
      };
      postRating(payload).then(() => {
        this.ratingDialog = false;
        getCourseById(this.course.id).then(res => {
          this.course = res.data;
          this.isShow = true;
        });
      });
    },

    openLessonDialog(section, item, action) {
      this.sectionId = section.id;
      this.isLessonDialog = true;
      this.lessonAction = action;
      if (!_.isEmpty(item)) {
        this.lessonId = item.id;
      } else {
        this.lessonId = "";
      }
    },

    deleteLesson(item) {
      deleteLesson(item.id).then(() => {
        getCourseById(this.$route.params.id).then(res => {
          this.course = res.data;
          this.isShow = true;
        });
        this.closeDialog();
      });
    },

    deleteSection(item) {
      deleteSection(item.id).then(() => {
        getCourseById(this.$route.params.id).then(res => {
          this.course = res.data;
          this.isShow = true;
        });
        this.closeDialog();
      });
    },

    closeDialog() {
      this.isSectionDialog = false;
      this.isLessonDialog = false;
      this.isVideoDialog = false;
      this.isQuizDialog = false;
      this.isPracticeDialog = false;
    },

    buyNow() {
      if (this.course.price == 0) {
        const payload = {
          payment: "Free",
          totalPrice: 0,
          createAt: new Date().toISOString(),
          studentId: this.studentId,
          orderDetailsDTO: [{ courseId: this.course.id, price: 0 }]
        };
        addOrder(payload).then(() => {
          const cartDetails = [];
          payload.orderDetailsDTO.forEach(element => {
            cartDetails.push({
              cartId: this.cartId,
              courseId: element.courseId
            });
          });
          deleteCartDetails(cartDetails).then(() => {
            this.setCartQuantity(
              this.cartQuantity - payload.orderDetailsDTO.length
            );
          });
          this.$router.push("/");
        });
      } else {
        this.setIsBuyNow(true);
        this.setCourseBuyNow(this.course);
        this.$router.push("/checkout");
      }
    },

    createSectionSuccess() {
      this.closeDialog();
      getCourseById(this.$route.params.id).then(res => {
        this.course = res.data;
        this.isShow = true;
      });
    },

    createLessonSuccess() {
      this.closeDialog();
      getCourseById(this.$route.params.id).then(res => {
        this.course = res.data;
        this.isShow = true;
      });
    },

    openVideoDialog(lesson) {
      this.isVideoDialog = true;
      this.title = lesson.name;
      this.videoUrl = lesson.videoUrl;
    },

    addToCart(item) {
      if (!this.listCourseSelectToBuy?.includes(item.id)) {
        createCartDetails({ cartId: this.cartId, courseId: item.id }).then(
          () => {
            this.setCartQuantity(this.cartQuantity + 1);
            this.listCourseSelectToBuy = this.listCourseSelectToBuy.push(
              item.id
            );
            this.setListCourseSelectToBuy(this.listCourseSelectToBuy);
          }
        );
      }
    }
  },

  created() {
    getCourseById(this.$route.params.id).then(res => {
      this.course = res.data;
      this.isShow = true;
    });

    getRatingsCourse(this.$route.params.id).then(res => {
      this.ratingCourse = res.data;
    });
  }
};
</script>
