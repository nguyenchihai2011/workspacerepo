<template>
  <v-card class="mx-auto" max-width="374">
    <template slot="progress">
      <v-progress-linear
        color="deep-purple"
        height="10"
        indeterminate
      ></v-progress-linear>
    </template>

    <v-img src="https://cdn.vuetifyjs.com/images/cards/cooking.png"></v-img>

    <v-card-title>Cafe Badilico</v-card-title>
    <v-card-subtitle class="pb-2">$ • Italian, Cafe</v-card-subtitle>

    <v-card-text class="pb-2">
      <div class="d-flex">
        <v-rating
          :value="4.5"
          color="amber"
          dense
          half-increments
          readonly
          size="12"
        ></v-rating>
        <div class="grey--text ml-1">4.5 (413)</div>
      </div>
    </v-card-text>
    <v-card-text class="py-0 font-weight-bold"><u>đ</u>2,449,000</v-card-text>
    <v-card-actions>
      <v-btn
        color="deep-purple lighten-2"
        text
        width="100%"
        class="d-flex justify-start"
      >
        <v-icon>mdi-cart-plus</v-icon>
        <div>Add to cart</div>
      </v-btn>
    </v-card-actions>
  </v-card>
</template>

<script>
export default {};
</script>
