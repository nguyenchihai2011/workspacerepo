<template>
  <v-card class="mx-auto" max-width="370">
    <template slot="progress">
      <v-progress-linear
        color="deep-purple"
        height="10"
        indeterminate
      ></v-progress-linear>
    </template>

    <v-img
      @click="$router.push(`/course/${courseId}`)"
      :src="courseImage"
      style="height: 130px;"
    ></v-img>

    <v-card-title class="course-name">{{ courseName }}</v-card-title>
    <v-card-subtitle class="course-title">{{ courseTitle }}</v-card-subtitle>

    <v-card-text class="pb-2">
      <div class="d-flex">
        <v-rating
          :value="courseRatingAvg"
          color="amber"
          dense
          half-increments
          readonly
          size="12"
        ></v-rating>
        <div class="grey--text ml-1">
          {{ courseRatingAvg }} ({{ totalRatings }})
        </div>
      </div>
    </v-card-text>
    <v-card-text class="py-0 font-weight-bold"
      >{{ coursePrice }} USD</v-card-text
    >
    <!-- <v-card-actions>
      <v-btn
        color="deep-purple lighten-2"
        text
        width="100%"
        class="d-flex justify-start"
      >
        <v-icon>mdi-cart-plus</v-icon>
        <div>Add to cart</div>
      </v-btn>
    </v-card-actions> -->
  </v-card>
</template>

<script>
export default {
  props: {
    courseId: {
      type: Number
    },
    courseImage: {
      type: String
    },

    courseName: {
      type: String
    },

    courseTitle: {
      type: String
    },

    coursePrice: {
      type: Number
    },

    courseRatingAvg: {
      type: Number
    },

    totalRatings: {
      type: Number
    }
  }
};
</script>

<style lang="scss" scoped>
.course-name {
  white-space: initial;
  overflow-y: hidden;
  text-overflow: ellipsis;
  display: -webkit-box;
  -webkit-line-clamp: 1;
  -webkit-box-orient: vertical;
  padding-bottom: 0;
}
.course-title {
  overflow: hidden;
  text-overflow: ellipsis;
  display: -webkit-box;
  -webkit-line-clamp: 3;
  -webkit-box-orient: vertical;
  padding-top: 20px;
  padding-bottom: 0;
}
</style>
