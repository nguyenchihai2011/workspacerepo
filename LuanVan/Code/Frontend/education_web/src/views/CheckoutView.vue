<template>
  <v-container fluid>
    <v-row>
      <v-col cols="6">
        <v-row class="d-flex justify-end">
          <v-col cols="8">
            <v-card class="ma-8" flat>
              <div class="text-h5 font-weight-bold">Checkout</div>
              <div class="text-h6">Payment method</div>
              <v-radio-group v-model="radioGroup">
                <v-radio :key="1" :value="1">
                  <template v-slot:label>dawd </template>
                </v-radio>
                <v-radio :key="2" :value="2">
                  <template v-slot:label>daw </template>
                </v-radio>
              </v-radio-group>
              <div class="text-h6 my-2">Order details</div>
              <v-row>
                <v-col cols="12">
                  <v-row>
                    <v-col cols="3" class="pr-0">
                      <v-img
                        contain
                        src="https://cdn.vuetifyjs.com/images/cards/cooking.png"
                      ></v-img>
                    </v-col>
                    <v-col cols="6"
                      ><div class="font-weight-bold">
                        Javascript for beginners
                      </div></v-col
                    >
                    <v-col cols="3">
                      <div class="font-weight-bold"><u>đ</u>279,000</div>
                      <div class="text-decoration-line-through">
                        <u>đ</u>1,090,000
                      </div>
                    </v-col>
                  </v-row>
                </v-col>
                <v-col cols="12">
                  <v-row>
                    <v-col cols="3" class="pr-0">
                      <v-img
                        contain
                        src="https://cdn.vuetifyjs.com/images/cards/cooking.png"
                      ></v-img>
                    </v-col>
                    <v-col cols="6"
                      ><div class="font-weight-bold">
                        Javascript for beginners
                      </div></v-col
                    >
                    <v-col cols="3">
                      <div class="font-weight-bold"><u>đ</u>279,000</div>
                      <div class="text-decoration-line-through">
                        <u>đ</u>1,090,000
                      </div>
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
                <div><u>đ</u>1,090,000</div>
              </div>
              <div class="d-flex justify-space-between">
                <div>Discounts:</div>
                <div>- <u>đ</u>1,090,000</div>
              </div>
              <v-divider class="mt-2 mb-4"></v-divider>
              <v-btn
                class="purple white--text text-none"
                height="44"
                width="100%"
              >
                Complete Checkout
              </v-btn>
            </v-card>
          </v-col>
        </v-row>
      </v-col>
    </v-row>
  </v-container>
</template>
<script>
export default {
  data() {
    return {
      radioGroup: 1,
    };
  },
};
</script>
