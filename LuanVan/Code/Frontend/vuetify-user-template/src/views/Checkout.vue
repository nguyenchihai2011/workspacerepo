<template>
  <v-container fluid>
    <v-row>
      <v-col cols="6">
        <v-row class="d-flex justify-end">
          <v-col cols="8">
            <v-card class="ma-8" flat>
              <div class="text-h5 font-weight-bold">Checkout</div>
              <div class="text-h6">Payment method</div>
              <v-radio-group v-model="radioGroup" @change="changePayment()">
                <v-radio :key="1" :value="1">
                  <template v-slot:label>Payment with Paypal</template>
                </v-radio>
                <v-radio :key="2" :value="2">
                  <template v-slot:label>Payment with Other</template>
                </v-radio>
              </v-radio-group>
              <div class="text-h6 my-2">Order details</div>
              <v-row>
                <v-col v-if="isBuyNow" cols="12">
                  <v-row>
                    <v-col cols="3" class="pr-0">
                      <v-img contain :src="courseBuyNow.imageUrl"></v-img>
                    </v-col>
                    <v-col cols="6"
                      ><div class="font-weight-bold">
                        {{ courseBuyNow.name }}
                      </div></v-col
                    >
                    <v-col cols="3">
                      <div class="font-weight-bold">
                        {{ courseBuyNow.price }} USD
                      </div>
                      <!-- <div class="text-decoration-line-through">
                        <u>đ</u>1,090,000
                      </div> -->
                    </v-col>
                  </v-row>
                </v-col>
                <v-col cols="12" v-else>
                  <v-row v-for="course in courses" :key="course.id">
                    <v-col cols="3" class="pr-0">
                      <v-img contain :src="course.imageUrl"></v-img>
                    </v-col>
                    <v-col cols="6"
                      ><div class="font-weight-bold">
                        {{ course.name }}
                      </div></v-col
                    >
                    <v-col cols="3">
                      <div class="font-weight-bold">{{ course.price }} USD</div>
                      <!-- <div class="text-decoration-line-through">
                        <u>đ</u>1,090,000
                      </div> -->
                    </v-col>
                  </v-row>
                </v-col>
              </v-row>
            </v-card>
          </v-col>
        </v-row>
      </v-col>
      <v-col cols="6" class="grey lighten-4">
        <v-row>
          <v-col cols="6">
            <v-card class="ma-8" flat color="transparent">
              <div class="text-h6 mt-16 mb-4">Summary</div>
              <div class="d-flex justify-space-between mb-2">
                <div>Original Price:</div>
                <div>{{ originalPrice }} USD</div>
              </div>
              <!-- <div class="d-flex justify-space-between">
                <div>Discounts:</div>
                <div>- <u>đ</u>1,090,000</div>
              </div> -->
              <v-divider class="mt-2 mb-4"></v-divider>
              <!-- <v-btn
                class="purple white--text text-none"
                height="44"
                width="100%"
              >
                Complete Checkout
              </v-btn> -->
              <div v-if="isPaymentPaypal" id="paypal-button-container"></div>
            </v-card>
          </v-col>
        </v-row>
      </v-col>
    </v-row>
  </v-container>
</template>
<script>
import { mapGetters, mapActions } from "vuex";
import { addOrder } from "@/api/order";
import { getCartId } from "@/api/cart";
import { deleteCartDetails } from "@/api/cartDetails";
import _ from "lodash";
export default {
  data() {
    return {
      radioGroup: 0,
      isPaymentPaypal: false,
      courses: []
    };
  },

  computed: {
    ...mapGetters("buy", [
      "isBuyNow",
      "courseBuyNow",
      "cartQuantity",
      "listCourseSelectToBuy"
    ]),
    ...mapGetters("auth", ["studentId", "cartId"]),
    ...mapGetters("alanAI", ["command", "value"]),

    originalPrice() {
      if (this.isBuyNow) {
        return this.courseBuyNow.price;
      } else {
        return this.courses.reduce(
          (accumulator, currentValue) => accumulator + currentValue.price,
          0
        );
      }
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
    ...mapActions("buy", ["setIsBuyNow", "setCartQuantity"]),
    ...mapActions("snackbar", ["addSnackbar"]),
    changePayment() {
      if (this.radioGroup === 1) {
        this.isPaymentPaypal = true;
      } else {
        this.isPaymentPaypal = false;
      }
    }
  },

  created() {
    if (!this.isBuyNow) {
      getCartId(this.cartId).then(res => {
        this.courses = res.data.cartDetails
          .filter(item => this.listCourseSelectToBuy.includes(item.course.id))
          .map(item => {
            return {
              ...item.course,
              saveForLater: false
            };
          });
      });
    }
  },

  beforeDestroy() {
    this.setIsBuyNow(false);
  },

  updated() {
    if (this.isPaymentPaypal) {
      let originalPrice = this.originalPrice;
      let studentId = this.studentId;
      let cartId = this.cartId;
      let orderDetailsDTO = [];
      let self = this;
      if (this.isBuyNow) {
        orderDetailsDTO = _.cloneDeep(
          [this.courseBuyNow].map(item => {
            return { courseId: item.id, price: item.price };
          })
        );
      } else {
        orderDetailsDTO = _.cloneDeep(
          this.courses.map(item => {
            return { courseId: item.id, price: item.price };
          })
        );
      }

      paypal
        .Buttons({
          createOrder: function(data, actions) {
            // Tạo đơn hàng khi người dùng bấm nút thanh toán

            return actions.order.create({
              purchase_units: [
                {
                  amount: {
                    value: originalPrice // Giá trị cần thanh toán
                  }
                }
              ]
            });
          },
          onApprove: function(data, actions) {
            return actions.order.capture().then(function(details) {
              const payload = {
                payment: "Paypal",
                totalPrice: originalPrice,
                createAt: new Date().toISOString(),
                studentId: studentId,
                orderDetailsDTO: orderDetailsDTO
              };
              addOrder(payload).then(() => {
                const cartDetails = [];
                orderDetailsDTO.forEach(element => {
                  cartDetails.push({
                    cartId: cartId,
                    courseId: element.courseId
                  });
                });
                deleteCartDetails(cartDetails).then(() => {
                  self.setCartQuantity(
                    self.cartQuantity - orderDetailsDTO.length
                  );
                });
                self.$router.push("/");
              });
            });
          }
        })
        .render("#paypal-button-container");
    }
  }
};
</script>
