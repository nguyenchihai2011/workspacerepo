<template>
  <v-container fluid class="pa-0" v-if="isShow">
    <v-row no-gutters>
      <v-col>
        <v-card style="position: relative" :key="videoCard">
          <video v-if="showVideo" controls width="100%" height="500">
            <source :src="lesson.videoUrl" />
          </video>
          <div v-else-if="showCodeArea">
            <div class="text-h4 pt-6 pl-4 ml-4">
              Quest: {{ practice.quest }}
            </div>
            <div class="text-h5 pt-6 pl-4 ml-4">
              Funtion name: {{ practice.functionName }}
            </div>
            <AreaCodeMirror :practice="practice" />
          </div>
          <div v-else>
            <div class="text-h3 pt-6 pl-4">{{ this.question.question }}</div>
            <div class="text-h6 pt-4 pl-4 pb-6">Select correct answer:</div>
            <div v-for="answer in question.answers" :key="answer.id">
              <v-btn
                class="text-none ml-4 mb-2"
                style="min-width: 600px;"
                @click="checkAnswer(answer)"
                >{{ answer.value }}</v-btn
              >
            </div>
          </div>
          <v-btn
            class="rounded-circle"
            absolute
            style="right: -18px; top: 200px; z-index: 2"
            width="30"
            height="30"
            min-width="30"
            @click="isNavigation = !isNavigation"
          >
            <v-icon color="#898989">{{
              isNavigation ? "mdi-chevron-right" : "mdi-chevron-left"
            }}</v-icon>
          </v-btn>
        </v-card>
        <v-tabs v-model="tab">
          <v-tabs-slider color="black"></v-tabs-slider>

          <v-tab class="ml-0 text-none black--text"> Overview </v-tab>
          <v-tab class="ml-0 text-none black--text"> Comment </v-tab>
        </v-tabs>
        <v-tabs-items v-model="tab">
          <v-tab-item>
            <v-card flat>
              <v-card-text>
                <div class="d-flex align-center">
                  <v-icon color="success" large>mdi-check</v-icon>
                  <div class="text-h6 ml-2">
                    Build 16 web development projects for your portfolio, ready
                    to apply for junior developer jobs.
                  </div>
                </div>
                <div class="d-flex align-center">
                  <v-icon color="success" large>mdi-check</v-icon>
                  <div class="text-h6 ml-2">
                    After the course you will be able to build ANY website you
                    want.
                  </div>
                </div>
                <div class="d-flex align-center">
                  <v-icon color="success" large>mdi-check</v-icon>
                  <div class="text-h6 ml-2">
                    Learn the latest technologies, including Javascript, React,
                    Node and even Web3 development.
                  </div>
                </div>
                <div class="d-flex align-center">
                  <v-icon color="success" large>mdi-check</v-icon>
                  <div class="text-h6 ml-2">
                    Build fully-fledged websites and web apps for your startup
                    or business.
                  </div>
                </div>
                <div class="d-flex align-center">
                  <v-icon color="success" large>mdi-check</v-icon>
                  <div class="text-h6 ml-2">
                    Work as a freelance web developer.
                  </div>
                </div>
              </v-card-text>
            </v-card>
          </v-tab-item>
          <v-tab-item>
            <v-card flat class="ma-4">
              <div class="d-flex align-start mb-16">
                <v-avatar color="teal" size="48" class="ma-4">
                  <img :src="avatarUrl" alt="John" />
                </v-avatar>
                <v-textarea
                  v-model="commentText"
                  outlined
                  placeholder="Enter the text comment"
                  color="#000"
                  hide-details
                  height="80"
                  class="rounded-l lecture-comment"
                ></v-textarea>
                <v-btn text @click="sendComment()"
                  ><v-icon>mdi-send</v-icon></v-btn
                >
              </div>
              <div style="max-height: 600px; overflow-y: auto;">
                <div
                  class="d-flex mb-6"
                  v-for="comment in comments"
                  :key="comment.id"
                >
                  <v-avatar size="48" class="mr-4">
                    <img :src="comment.avatarUrl" alt="John" />
                  </v-avatar>
                  <div>
                    <div class="font-weight-bold">{{ comment.name }}</div>
                    <div v-html="formatCommentContent(comment.content)"></div>
                  </div>
                </div>
              </div>
            </v-card>
          </v-tab-item>
        </v-tabs-items>
        <core-footer />
      </v-col>
      <v-col v-if="isNavigation" cols="3">
        <v-card
          class="overflow-y-auto"
          style="position: fixed; height: calc(100vh - 80px); width: 380px;"
          flat
        >
          <div class="d-flex justify-space-between align-center py-2">
            <div class="ml-4 text-h5 font-ưeight-bold">Course Content</div>
            <div class="d-flex justify-end align-center">
              <progress-chart
                v-if="isStudent"
                :data="dataProgress"
                :width="80"
                :height="80"
              />
              <v-btn @click="isNavigation = false" text>
                <v-icon>mdi-close</v-icon>
              </v-btn>
            </div>
          </div>
          <v-expansion-panels multiple flat>
            <v-expansion-panel
              v-for="item in course.sections"
              :key="item.id"
              class="mt-0"
            >
              <v-expansion-panel-header class="font-weight-bold text-h6">
                {{ item.name }}
              </v-expansion-panel-header>
              <v-expansion-panel-content
                v-for="lesson in item.lessons"
                :key="lesson.id"
              >
                <v-card flat>
                  <v-card-actions
                    class="d-flex align-center"
                    @click="
                      () => {
                        $router.push(
                          `/course/${course.id}/lesson/${lesson.id}`
                        );
                        showVideo = true;
                      }
                    "
                  >
                    <v-checkbox
                      v-if="isStudent"
                      v-model="lesson.studentLessons[0].isLock"
                      class="ma-0 mr-2 d-flex align-center"
                      hide-details
                      @click="updateProgress(lesson.id)"
                    ></v-checkbox>
                    <div class="font-weight-bold">{{ lesson.name }}</div>
                    <v-icon class="ml-2 mr-2" size="20"
                      >mdi-television-play</v-icon
                    >
                  </v-card-actions>
                  <div class="d-flex">
                    <div v-for="(quiz, index) in lesson.quizzes" :key="index">
                      <v-btn
                        @click="updateQuestion(quiz)"
                        outlined
                        rounded
                        small
                        class="mr-1"
                        >{{ index + 1 }}</v-btn
                      >
                    </div>
                    <div
                      v-for="(practice, index) in lesson.practices"
                      :key="index"
                    >
                      <v-btn
                        @click="updatePractice(practice)"
                        outlined
                        rounded
                        small
                        class="mr-1"
                        >{{ index + lesson.quizzes.length + 1 }}</v-btn
                      >
                    </div>
                  </div>
                </v-card>
              </v-expansion-panel-content>
            </v-expansion-panel>
          </v-expansion-panels>
        </v-card>
      </v-col>
    </v-row>
  </v-container>
</template>
<script>
import CoreFooter from "@/components/core/CoreFooter.vue";
import { getCourseById } from "@/api/course";
import { getLessonById } from "@/api/lesson";
import {
  getStudentLesson,
  updateProgress,
  getProgress
} from "@/api/studentLesson";
import { mapGetters, mapActions } from "vuex";
import ProgressChart from "@/components/app/ProgressChart.vue";
import { getCommentsCourse } from "@/api/comment";
import AreaCodeMirror from "@/components/app/AreaCodeMirror.vue";

const connection = new signalR.HubConnectionBuilder()
  .withUrl("https://localhost:7254/chatHub", {
    skipNegotiation: true,
    transport: signalR.HttpTransportType.WebSockets
  })
  .build();

export default {
  components: { CoreFooter, ProgressChart, AreaCodeMirror },
  // components: { CoreFooter },

  data() {
    return {
      videoCard: 0,
      isShow: false,
      isNavigation: true,
      tab: null,
      course: {},
      lesson: {},
      studentLessons: [],
      dataProgress: [],
      comments: [],
      commentText: "",
      showVideo: true,
      showCodeArea: false,
      question: {},
      practice: {}
    };
  },

  computed: {
    ...mapGetters("auth", ["studentId", "userId", "role", "avatarUrl"]),
    ...mapGetters("alanAI", ["command", "value"]),

    isStudent() {
      return this.role === "Student";
    },
    isLecture() {
      return this.role === "Lecture";
    }
  },

  watch: {
    "$route.params.id"(val) {
      getLessonById(val).then(res => {
        this.lesson = res.data;
        this.videoCard++;
      });
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
    formatCommentContent(content) {
      return content.replace(/\n/g, "<br>");
    },
    selectLesson(lessonId) {
      getLessonById(lessonId).then(res => {
        this.lesson = res.data;
        this.videoCard++;
      });
    },

    checkAnswer(item) {
      if (item.isCorrect) {
        this.addSnackbar({
          isShow: true,
          text: "Congratulation! This is true answer!",
          priority: "success",
          timeout: 3000
        });
      } else {
        this.addSnackbar({
          isShow: true,
          text: "Oh no! This is wrong answer!",
          priority: "error",
          timeout: 3000
        });
      }
    },

    updatePractice(item) {
      this.showVideo = false;
      this.showCodeArea = true;
      this.practice = item;
    },
    updateQuestion(item) {
      this.question = item;
      this.showVideo = false;
      this.showCodeArea = false;
    },

    updateProgress(lessonId) {
      const params = {
        studentId: Number(this.studentId),
        lessonId: lessonId,
        courseId: this.course.id
      };
      updateProgress(params).then(res => {
        this.dataProgress = res.data;
      });
    },
    getCommentsCourse() {
      const params = {
        courseId: this.$route.params.courseId
      };
      getCommentsCourse(params).then(res => {
        this.comments = res.data;
      });
    },

    sendComment() {
      const payload = {
        content: this.commentText,
        createAt: "2023-10-29T08:02:44.274Z",
        updateAt: "2023-10-29T08:02:44.274Z",
        userId: this.userId,
        courseId: Number(this.$route.params.courseId)
      };
      connection.invoke("SendComment", payload);
    }
  },

  created() {
    getCourseById(this.$route.params.courseId).then(res => {
      this.course = res.data;
      this.isShow = true;
    });

    getLessonById(this.$route.params.id).then(res => {
      this.lesson = res.data;
    });
    const params = {
      courseId: this.$route.params.courseId,
      studentId: this.studentId
    };
    getStudentLesson(params).then(res => {
      this.studentLessons = res.data;
    });
    const progressParams = {
      courseId: this.$route.params.courseId,
      studentId: this.studentId
    };
    getProgress(progressParams).then(res => {
      this.dataProgress = res.data;
    });
    this.getCommentsCourse();
  },

  mounted() {
    var self = this;
    connection
      .start()
      .then(function() {
        console.log("SignalR Connected!");
        connection.on("ReceiveComment", () => {
          self.getCommentsCourse();
        });
      })
      .catch(function(err) {
        return console.error(err.toString());
      });
  }
};
</script>

<style lang="scss" scoped></style>
