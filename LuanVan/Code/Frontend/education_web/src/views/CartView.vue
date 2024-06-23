<template>
  <v-container>
    <v-row>
      <v-col cols="12">
        <div class="text-h4 mt-4 font-weight-bold">Shopping Cart</div>
      </v-col>
      <v-col cols="12">
        <v-row>
          <v-col cols="8">
            <div class="font-weight-bold">1 Course in Cart</div>
            <v-divider class="my-2"></v-divider>
            <course-item-details />
          </v-col>
          <v-col class="ml-8">
            <div class="font-weight-bold">Total:</div>
            <div class="text-h5 font-weight-bold my-2"><u>đ</u>2,449,000</div>
            <v-btn
              width="100%"
              class="purple white--text text-none mt-2"
              height="44"
              >Checkout</v-btn
            >
          </v-col>
        </v-row>
      </v-col>
    </v-row>
  </v-container>
</template>

<script>
import CourseItemDetails from "@/components/layout/Course/CourseItemDetails.vue";
export default {
  components: { CourseItemDetails },
};
</script>
