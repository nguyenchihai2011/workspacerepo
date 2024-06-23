<template>
  <v-row no-gutters>
    <v-col cols="12">
      <div>My learning</div>
    </v-col>
    <v-col cols="12">
      <course-item-details></course-item-details>
    </v-col>
  </v-row>
</template>

<script>
import CourseItemDetails from "@/components/layout/Course/CourseItemDetails.vue";
export default {
  components: { CourseItemDetails },
};
</script>
