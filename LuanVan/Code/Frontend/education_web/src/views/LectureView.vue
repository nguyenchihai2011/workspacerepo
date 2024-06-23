<template>
  <v-container fluid class="py-0 mt-20">
    <v-row no-gutters>
      <v-col>
        <v-card style="position: relative">
          <video controls width="100%" height="500">
            <source src="@/assets/videos/Demo.mp4" />
          </video>
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
              <v-card-text> </v-card-text>
            </v-card>
          </v-tab-item>
          <v-tab-item>
            <v-card flat class="ma-4">
              <div class="d-flex align-start mb-16">
                <v-avatar color="primary" size="48" class="mr-4"></v-avatar>
                <v-textarea
                  outlined
                  placeholder="Enter the text comment"
                  color="#000"
                  hide-details
                  height="80"
                  class="rounded-l lecture-comment"
                ></v-textarea>
                <v-btn text><v-icon>mdi-send</v-icon></v-btn>
              </div>
              <div class="d-flex mb-6">
                <v-avatar color="primary" size="48" class="mr-4"></v-avatar>
                <div>
                  <div class="font-weight-bold">Khang Trần</div>
                  <div>
                    This is good course This is good course This is good course
                    This is good course This is good course This is good course
                    This is good course This is good course This is good course
                    This is good course This is good course This is good course
                    This is good course This is good course This is good course
                    This is good course This is good course This is good course
                    This is good course This is good course This is good course
                  </div>
                </div>
              </div>
              <div class="d-flex mb-6">
                <v-avatar color="primary" size="48" class="mr-4"></v-avatar>
                <div>
                  <div class="font-weight-bold">Khang Trần</div>
                  <div>
                    This is good course This is good course This is good course
                    This is good course This is good course This is good course
                    This is good course This is good course This is good course
                    This is good course This is good course This is good course
                    This is good course This is good course This is good course
                    This is good course This is good course This is good course
                    This is good course This is good course This is good course
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
          style="position: fixed; height: calc(100vh - 80px)"
          flat
        >
          <div class="d-flex justify-space-between align-center py-2">
            <div class="ml-4 text-h6">Course Content</div>
            <v-btn @click="isNavigation = false" text>
              <v-icon>mdi-close</v-icon>
            </v-btn>
          </div>
          <v-expansion-panels multiple flat>
            <v-expansion-panel class="mt-0">
              <v-expansion-panel-header class="font-weight-bold text-h6">
                Introduction
              </v-expansion-panel-header>
              <v-expansion-panel-content>
                <div class="d-flex align-start">
                  <v-checkbox class="ma-0 mr-2"></v-checkbox>
                  <div>
                    <div class="font-weight-bold">1. Modern JavaScript</div>
                    <v-icon class="mr-2" size="20">mdi-television-play</v-icon>
                    <span class="text-body-2">2min</span>
                  </div>
                </div>
              </v-expansion-panel-content>
              <v-expansion-panel-content>
                <div class="d-flex align-start">
                  <v-checkbox class="ma-0 mr-2"></v-checkbox>
                  <div>
                    <div class="font-weight-bold">1. Modern JavaScript</div>
                    <v-icon class="mr-2" size="20">mdi-television-play</v-icon>
                    <span class="text-body-2">2min</span>
                  </div>
                </div>
              </v-expansion-panel-content>
              <v-expansion-panel-content>
                <div class="d-flex align-start">
                  <v-checkbox class="ma-0 mr-2"></v-checkbox>
                  <div>
                    <div class="font-weight-bold">1. Modern JavaScript</div>
                    <v-icon class="mr-2" size="20">mdi-television-play</v-icon>
                    <span class="text-body-2">2min</span>
                  </div>
                </div>
              </v-expansion-panel-content>
              <v-expansion-panel-content>
                <div class="d-flex align-start">
                  <v-checkbox class="ma-0 mr-2"></v-checkbox>
                  <div>
                    <div class="font-weight-bold">1. Modern JavaScript</div>
                    <v-icon class="mr-2" size="20">mdi-television-play</v-icon>
                    <span class="text-body-2">2min</span>
                  </div>
                </div>
              </v-expansion-panel-content>
              <v-expansion-panel-content>
                <div class="d-flex align-start">
                  <v-checkbox class="ma-0 mr-2"></v-checkbox>
                  <div>
                    <div class="font-weight-bold">1. Modern JavaScript</div>
                    <v-icon class="mr-2" size="20">mdi-television-play</v-icon>
                    <span class="text-body-2">2min</span>
                  </div>
                </div>
              </v-expansion-panel-content>
            </v-expansion-panel>
            <v-expansion-panel class="mt-0">
              <v-expansion-panel-header class="font-weight-bold text-h6">
                Introduction
              </v-expansion-panel-header>
              <v-expansion-panel-content>
                <div class="d-flex align-start">
                  <v-checkbox class="ma-0 mr-2"></v-checkbox>
                  <div>
                    <div class="font-weight-bold">1. Modern JavaScript</div>
                    <v-icon class="mr-2" size="20">mdi-television-play</v-icon>
                    <span class="text-body-2">2min</span>
                  </div>
                </div>
              </v-expansion-panel-content>
              <v-expansion-panel-content>
                <div class="d-flex align-start">
                  <v-checkbox class="ma-0 mr-2"></v-checkbox>
                  <div>
                    <div class="font-weight-bold">1. Modern JavaScript</div>
                    <v-icon class="mr-2" size="20">mdi-television-play</v-icon>
                    <span class="text-body-2">2min</span>
                  </div>
                </div>
              </v-expansion-panel-content>
              <v-expansion-panel-content>
                <div class="d-flex align-start">
                  <v-checkbox class="ma-0 mr-2"></v-checkbox>
                  <div>
                    <div class="font-weight-bold">1. Modern JavaScript</div>
                    <v-icon class="mr-2" size="20">mdi-television-play</v-icon>
                    <span class="text-body-2">2min</span>
                  </div>
                </div>
              </v-expansion-panel-content>
              <v-expansion-panel-content>
                <div class="d-flex align-start">
                  <v-checkbox class="ma-0 mr-2"></v-checkbox>
                  <div>
                    <div class="font-weight-bold">1. Modern JavaScript</div>
                    <v-icon class="mr-2" size="20">mdi-television-play</v-icon>
                    <span class="text-body-2">2min</span>
                  </div>
                </div>
              </v-expansion-panel-content>
              <v-expansion-panel-content>
                <div class="d-flex align-start">
                  <v-checkbox class="ma-0 mr-2"></v-checkbox>
                  <div>
                    <div class="font-weight-bold">1. Modern JavaScript</div>
                    <v-icon class="mr-2" size="20">mdi-television-play</v-icon>
                    <span class="text-body-2">2min</span>
                  </div>
                </div>
              </v-expansion-panel-content>
              <v-expansion-panel-content>
                <div class="d-flex align-start">
                  <v-checkbox class="ma-0 mr-2"></v-checkbox>
                  <div>
                    <div class="font-weight-bold">1. Modern JavaScript</div>
                    <v-icon class="mr-2" size="20">mdi-television-play</v-icon>
                    <span class="text-body-2">2min</span>
                  </div>
                </div>
              </v-expansion-panel-content>
            </v-expansion-panel>
            <v-expansion-panel class="mt-0">
              <v-expansion-panel-header class="font-weight-bold text-h6">
                Introduction
              </v-expansion-panel-header>
              <v-expansion-panel-content>
                <div class="d-flex align-start">
                  <v-checkbox class="ma-0 mr-2"></v-checkbox>
                  <div>
                    <div class="font-weight-bold">1. Modern JavaScript</div>
                    <v-icon class="mr-2" size="20">mdi-television-play</v-icon>
                    <span class="text-body-2">2min</span>
                  </div>
                </div>
              </v-expansion-panel-content>
              <v-expansion-panel-content>
                <div class="d-flex align-start">
                  <v-checkbox class="ma-0 mr-2"></v-checkbox>
                  <div>
                    <div class="font-weight-bold">1. Modern JavaScript</div>
                    <v-icon class="mr-2" size="20">mdi-television-play</v-icon>
                    <span class="text-body-2">2min</span>
                  </div>
                </div>
              </v-expansion-panel-content>
              <v-expansion-panel-content>
                <div class="d-flex align-start">
                  <v-checkbox class="ma-0 mr-2"></v-checkbox>
                  <div>
                    <div class="font-weight-bold">1. Modern JavaScript</div>
                    <v-icon class="mr-2" size="20">mdi-television-play</v-icon>
                    <span class="text-body-2">2min</span>
                  </div>
                </div>
              </v-expansion-panel-content>
              <v-expansion-panel-content>
                <div class="d-flex align-start">
                  <v-checkbox class="ma-0 mr-2"></v-checkbox>
                  <div>
                    <div class="font-weight-bold">1. Modern JavaScript</div>
                    <v-icon class="mr-2" size="20">mdi-television-play</v-icon>
                    <span class="text-body-2">2min</span>
                  </div>
                </div>
              </v-expansion-panel-content>
              <v-expansion-panel-content>
                <div class="d-flex align-start">
                  <v-checkbox class="ma-0 mr-2"></v-checkbox>
                  <div>
                    <div class="font-weight-bold">1. Modern JavaScript</div>
                    <v-icon class="mr-2" size="20">mdi-television-play</v-icon>
                    <span class="text-body-2">2min</span>
                  </div>
                </div>
              </v-expansion-panel-content>
              <v-expansion-panel-content>
                <div class="d-flex align-start">
                  <v-checkbox class="ma-0 mr-2"></v-checkbox>
                  <div>
                    <div class="font-weight-bold">1. Modern JavaScript</div>
                    <v-icon class="mr-2" size="20">mdi-television-play</v-icon>
                    <span class="text-body-2">2min</span>
                  </div>
                </div>
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

export default {
  components: { CoreFooter },

  data() {
    return {
      isNavigation: true,
      drawer: false,
      items: [
        { title: "Home", icon: "mdi-home-city" },
        { title: "My Account", icon: "mdi-account" },
        { title: "Users", icon: "mdi-account-group-outline" },
      ],
      mini: true,
      tab: null,
    };
  },
};
</script>

<style lang="scss" scoped>
.lecture-comment {
  ::v-deep .v-input__slot {
    min-height: 40px;
  }
}
</style>
