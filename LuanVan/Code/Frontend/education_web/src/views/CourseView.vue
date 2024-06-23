<template>
  <div>
    <div class="black white--text">
      <v-container style="position: relative">
        <v-row>
          <v-col cols="12" class="pa-0">
            <div class="text-h4 my-2">Javascript Practicals Crash Course</div>
            <div class="text-subtitle-1">Learn javascript Concepts</div>
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
                4.5 (1020 ratings)
              </div>
            </div>
            <div>
              Created by
              <span class="purple--text text--lighten-4"
                >PROPER DOT INSTITUTE</span
              >
            </div>
            <div class="d-flex mt-2 my-8">
              <v-icon color="white">mdi-alert-octagram</v-icon>
              <div class="ml-2 text-subtitle-2">Last updated 7/2023</div>
              <v-icon color="white" class="ml-4">mdi-web</v-icon>
              <div class="ml-2 text-subtitle-2">English</div>
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
                ><u>đ</u>899.000</v-card-title
              >
              <v-card-title class="py-0">
                <v-btn class="text-none purple white--text" text width="100%"
                  >Add to card</v-btn
                >
              </v-card-title>
              <v-card-title class="pt-2 pb-8">
                <v-btn class="text-none" outlined width="100%">Buy now</v-btn>
              </v-card-title>
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
            <v-card-title class="text-h5 font-weight-bold">
              Course content
            </v-card-title>
            <v-card-subtitle>
              1 section <v-icon>mdi-circle-small</v-icon> 7 lectures
              <v-icon>mdi-circle-small</v-icon> 37m total
              lenght</v-card-subtitle
            >
            <v-row class="mx-4">
              <v-col cols="12">
                <v-expansion-panels>
                  <v-expansion-panel>
                    <v-expansion-panel-header class="font-weight-bold text-h6">
                      Introduction
                    </v-expansion-panel-header>
                    <v-expansion-panel-content>
                      <v-row>
                        <v-col cols="1"
                          ><v-icon>mdi-presentation-play</v-icon></v-col
                        >
                        <v-col cols="7"><div>Quick Wins!</div></v-col>
                        <v-col cols="2"
                          ><div class="d-flex justify-end">Preview</div></v-col
                        >
                        <v-col cols="2"
                          ><div class="d-flex justify-end">01:43</div></v-col
                        >
                      </v-row>
                    </v-expansion-panel-content>
                    <v-expansion-panel-content>
                      <v-row>
                        <v-col cols="1"
                          ><v-icon>mdi-presentation-play</v-icon></v-col
                        >
                        <v-col cols="7"><div>Quick Wins!</div></v-col>
                        <v-col cols="2"
                          ><div class="d-flex justify-end">Preview</div></v-col
                        >
                        <v-col cols="2"
                          ><div class="d-flex justify-end">01:43</div></v-col
                        >
                      </v-row>
                    </v-expansion-panel-content>
                    <v-expansion-panel-content>
                      <v-row>
                        <v-col cols="1"
                          ><v-icon>mdi-presentation-play</v-icon></v-col
                        >
                        <v-col cols="7"><div>Quick Wins!</div></v-col>
                        <v-col cols="2"
                          ><div class="d-flex justify-end">Preview</div></v-col
                        >
                        <v-col cols="2"
                          ><div class="d-flex justify-end">01:43</div></v-col
                        >
                      </v-row>
                    </v-expansion-panel-content>
                    <v-expansion-panel-content>
                      <v-row>
                        <v-col cols="1"
                          ><v-icon>mdi-presentation-play</v-icon></v-col
                        >
                        <v-col cols="7"><div>Quick Wins!</div></v-col>
                        <v-col cols="2"
                          ><div class="d-flex justify-end">Preview</div></v-col
                        >
                        <v-col cols="2"
                          ><div class="d-flex justify-end">01:43</div></v-col
                        >
                      </v-row>
                    </v-expansion-panel-content>
                  </v-expansion-panel>
                  <v-expansion-panel>
                    <v-expansion-panel-header class="font-weight-bold text-h6">
                      Introduction
                    </v-expansion-panel-header>
                    <v-expansion-panel-content>
                      <v-row>
                        <v-col cols="1"
                          ><v-icon>mdi-presentation-play</v-icon></v-col
                        >
                        <v-col cols="7"><div>Quick Wins!</div></v-col>
                        <v-col cols="2"
                          ><div class="d-flex justify-end">Preview</div></v-col
                        >
                        <v-col cols="2"
                          ><div class="d-flex justify-end">01:43</div></v-col
                        >
                      </v-row>
                    </v-expansion-panel-content>
                    <v-expansion-panel-content>
                      <v-row>
                        <v-col cols="1"
                          ><v-icon>mdi-presentation-play</v-icon></v-col
                        >
                        <v-col cols="7"><div>Quick Wins!</div></v-col>
                        <v-col cols="2"
                          ><div class="d-flex justify-end">Preview</div></v-col
                        >
                        <v-col cols="2"
                          ><div class="d-flex justify-end">01:43</div></v-col
                        >
                      </v-row>
                    </v-expansion-panel-content>
                    <v-expansion-panel-content>
                      <v-row>
                        <v-col cols="1"
                          ><v-icon>mdi-presentation-play</v-icon></v-col
                        >
                        <v-col cols="7"><div>Quick Wins!</div></v-col>
                        <v-col cols="2"
                          ><div class="d-flex justify-end">Preview</div></v-col
                        >
                        <v-col cols="2"
                          ><div class="d-flex justify-end">01:43</div></v-col
                        >
                      </v-row>
                    </v-expansion-panel-content>
                    <v-expansion-panel-content>
                      <v-row>
                        <v-col cols="1"
                          ><v-icon>mdi-presentation-play</v-icon></v-col
                        >
                        <v-col cols="7"><div>Quick Wins!</div></v-col>
                        <v-col cols="2"
                          ><div class="d-flex justify-end">Preview</div></v-col
                        >
                        <v-col cols="2"
                          ><div class="d-flex justify-end">01:43</div></v-col
                        >
                      </v-row>
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
              <v-icon color="amber">mdi-star</v-icon>
              <div class="text-h6 font-weight-bold">4.5 course rating</div>
            </v-card-title>
            <v-row class="px-4">
              <v-col cols="6">
                <v-card>
                  <div class="d-flex align-center">
                    <v-avatar color="teal" size="48" class="ma-4">
                      <span class="white--text text-h5">48</span>
                    </v-avatar>
                    <div>
                      <div class="font-weight-bold">Shine L.</div>
                      <v-rating
                        :value="4.5"
                        color="amber"
                        dense
                        half-increments
                        readonly
                        size="12"
                      ></v-rating>
                    </div>
                    <v-divider></v-divider>
                    <v-btn text small>
                      <v-icon size="20">mdi-dots-vertical</v-icon>
                    </v-btn>
                  </div>
                  <div class="pa-4 pb-6">Easy to understand</div>
                </v-card>
              </v-col>
              <v-col cols="6">
                <v-card>
                  <div class="d-flex align-center">
                    <v-avatar color="teal" size="48" class="ma-4">
                      <span class="white--text text-h5">48</span>
                    </v-avatar>
                    <div>
                      <div class="font-weight-bold">Shine L.</div>
                      <v-rating
                        :value="4.5"
                        color="amber"
                        dense
                        half-increments
                        readonly
                        size="12"
                      ></v-rating>
                    </div>
                    <v-divider></v-divider>
                    <v-btn text small>
                      <v-icon size="20">mdi-dots-vertical</v-icon>
                    </v-btn>
                  </div>
                  <div class="pa-4 pb-6">Easy to understand</div>
                </v-card>
              </v-col>
              <v-col cols="6">
                <v-card>
                  <div class="d-flex align-center">
                    <v-avatar color="teal" size="48" class="ma-2">
                      <span class="white--text text-h5">48</span>
                    </v-avatar>
                    <div>
                      <div class="font-weight-bold">Shine L.</div>
                      <v-rating
                        :value="4.5"
                        color="amber"
                        dense
                        half-increments
                        readonly
                        size="12"
                      ></v-rating>
                    </div>
                    <v-divider></v-divider>
                    <v-btn text small>
                      <v-icon size="20">mdi-dots-vertical</v-icon>
                    </v-btn>
                  </div>
                  <div class="pa-4 pb-6">Easy to understand</div>
                </v-card>
              </v-col>
              <v-col cols="6">
                <v-card>
                  <div class="d-flex align-center">
                    <v-avatar color="teal" size="48" class="ma-2">
                      <span class="white--text text-h5">48</span>
                    </v-avatar>
                    <div>
                      <div class="font-weight-bold">Shine L.</div>
                      <v-rating
                        :value="4.5"
                        color="amber"
                        dense
                        half-increments
                        readonly
                        size="12"
                      ></v-rating>
                    </div>
                    <v-divider></v-divider>
                    <v-btn text small>
                      <v-icon size="20">mdi-dots-vertical</v-icon>
                    </v-btn>
                  </div>
                  <div class="pa-4 pb-6">Easy to understand</div>
                </v-card>
              </v-col>
            </v-row>
          </div>
          <v-btn class="text-none ml-4 mt-4" outlined>Show all review</v-btn>
        </v-col>
      </v-row>
    </v-container>
  </div>
</template>
<script>
export default {
  data() {
    return {};
  },
};
</script>
