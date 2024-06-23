<template>
  <v-container>
    <v-row>
      <v-col cols="12">
        <div class="text-h4 mt-4 font-weight-bold">Shopping Cart</div>
      </v-col>
      <v-col cols="12" v-if="courses.length === 0">
        <div style="font-size: 40px; font-weight: 200;" class="mt-4">
          Cart is empty
        </div>
      </v-col>
      <v-col cols="12" v-else>
        <v-row>
          <v-col cols="8">
            <div v-if="totalInCart > 0">
              <div class="font-weight-bold">
                {{ totalInCart }} Course in Cart
              </div>
              <v-divider class="my-2"></v-divider>
              <div v-for="course in courses" :key="course.id">
                <div class="d-flex" v-if="!course.saveForLater">
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
                  <div class="mt-2">
                    <v-menu offset-y>
                      <template v-slot:activator="{ on, attrs }">
                        <v-btn text v-bind="attrs" v-on="on">
                          <v-icon>mdi-dots-vertical</v-icon>
                        </v-btn>
                      </template>
                      <v-list>
                        <v-list-item
                          v-if="!course.saveForLater"
                          @click="saveForLater(course)"
                        >
                          <v-list-item-title>
                            Save for later
                          </v-list-item-title>
                        </v-list-item>
                        <v-list-item
                          v-if="course.saveForLater"
                          @click="moveToCart(course)"
                        >
                          <v-list-item-title>
                            Move to cart
                          </v-list-item-title>
                        </v-list-item>
                        <v-list-item @click="removeItem(course)">
                          <v-list-item-title>
                            Remove
                          </v-list-item-title>
                        </v-list-item>
                      </v-list>
                    </v-menu>
                  </div>
                </div>
              </div>
            </div>
            <div v-if="totalLater > 0">
              <div class="font-weight-bold">
                {{ totalLater }} Course Save for Later
              </div>
              <v-divider class="my-2"></v-divider>
              <div v-for="course in courses" :key="course.id">
                <div class="d-flex" v-if="course.saveForLater">
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
                  <div class="mt-2">
                    <v-menu offset-y>
                      <template v-slot:activator="{ on, attrs }">
                        <v-btn text v-bind="attrs" v-on="on">
                          <v-icon>mdi-dots-vertical</v-icon>
                        </v-btn>
                      </template>
                      <v-list>
                        <v-list-item
                          v-if="!course.saveForLater"
                          @click="saveForLater(course)"
                        >
                          <v-list-item-title>
                            Save for later
                          </v-list-item-title>
                        </v-list-item>
                        <v-list-item
                          v-if="course.saveForLater"
                          @click="moveToCart(course)"
                        >
                          <v-list-item-title>
                            Move to cart
                          </v-list-item-title>
                        </v-list-item>
                        <v-list-item @click="removeItem(course)">
                          <v-list-item-title>
                            Remove
                          </v-list-item-title>
                        </v-list-item>
                      </v-list>
                    </v-menu>
                  </div>
                </div>
              </div>
            </div>
          </v-col>
          <v-col class="ml-8">
            <div class="font-weight-bold">Total:</div>
            <div class="text-h5 font-weight-bold my-2">{{ totalCost }} USD</div>
            <v-btn
              width="100%"
              class="purple white--text text-none mt-2"
              height="44"
              link
              to="/checkout"
              >Checkout</v-btn
            >
          </v-col>
        </v-row>
      </v-col>
    </v-row>
  </v-container>
</template>

<script>
import CourseDetails from "@/components/course/CourseDetails.vue";
import { getCartId } from "@/api/cart";
import { deleteCartDetails } from "@/api/cartDetails";
import { mapGetters, mapActions } from "vuex";
import _ from "lodash";
export default {
  components: { CourseDetails },
  data() {
    return {
      courses: []
    };
  },

  computed: {
    ...mapGetters("auth", ["cartId"]),
    ...mapGetters("buy", ["listCourseSelectToBuy", "cartQuantity"]),
    ...mapGetters("alanAI", ["command", "value"]),
    totalInCart() {
      return this.courses.filter(item => !item.saveForLater).length;
    },
    totalLater() {
      return this.courses.filter(item => item.saveForLater).length;
    },
    totalCost() {
      return this.courses.reduce(
        (accumulator, currentValue) =>
          accumulator + (currentValue.saveForLater ? 0 : currentValue.price),
        0
      );
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
    ...mapActions("buy", ["setListCourseSelectToBuy", "setCartQuantity"]),
    ...mapActions("snackbar", ["addSnackbar"]),
    saveForLater(item) {
      this.courses = this.courses.map(course => {
        if (course.id === item.id) {
          course.saveForLater = true;
        }
        return course;
      });
      const listCourse = _.cloneDeep(this.listCourseSelectToBuy);
      listCourse.splice(listCourse.indexOf(item.id), 1);
      this.setListCourseSelectToBuy(listCourse);
    },

    moveToCart(item) {
      this.courses = this.courses.map(course => {
        if (course.id === item.id) {
          course.saveForLater = false;
        }
        return course;
      });
      const listCourse = _.cloneDeep(this.listCourseSelectToBuy);
      listCourse.push(item.id);
      this.setListCourseSelectToBuy(listCourse);
    },

    removeItem(item) {
      deleteCartDetails([{ cartId: this.cartId, courseId: item.id }]).then(
        async () => {
          await getCartId(this.cartId).then(res => {
            this.courses = res.data.cartDetails.map(item => {
              return {
                ...item.course,
                saveForLater: false
              };
            });
          });
          this.setListCourseSelectToBuy(this.courses.map(item => item.id));
          this.setCartQuantity(this.cartQuantity - 1);
        }
      );
    }
  },

  async created() {
    await getCartId(this.cartId).then(res => {
      this.courses = res.data.cartDetails.map(item => {
        return {
          ...item.course,
          saveForLater: false
        };
      });
    });
    this.setListCourseSelectToBuy(this.courses.map(item => item.id));
  }
};
</script>
