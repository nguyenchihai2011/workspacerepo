<template>
  <v-container>
    <v-row>
      <v-col cols="3">
        <v-img
          alt="Education Logo"
          class="mr-2"
          contain
          src="https://cdn.vuetifyjs.com/images/cards/cooking.png"
        />
      </v-col>
      <v-col cols="6">
        <div class="font-weight-bold">Javascript Practicals Crash Course</div>
        <div class="text-subtitle-1">Learn javascript Concepts</div>
        <div class="text-caption">PROPER DOT INSTITUTE</div>
        <div class="d-flex mx-0">
          <v-rating
            :value="4.2"
            color="amber"
            dense
            half-increments
            readonly
            size="12"
          ></v-rating>
          <div class="grey--text ml-1">4.2 (413)</div>
        </div>
        <div class="text-caption">
          38 total mins <v-icon>mdi-circle-small</v-icon>7
          letures<v-icon>mdi-circle-small</v-icon>All Levels
        </div>
      </v-col>
      <v-col cols="3">
        <div class="py-0 px-4 font-weight-bold"><u>đ</u>2,449,000</div>
        <v-btn
          class="d-flex justify-start mt-2 deep-purple lighten-2 white--text text-none"
        >
          <v-icon>mdi-cart-plus</v-icon>
          <div class="ml-2">Add to cart</div>
        </v-btn>
      </v-col>
    </v-row>
  </v-container>
</template>

<script>
export default {};
</script>
