<template>
  <v-container>
    <v-row>
      <v-col cols="12">
        <div class="text-h4">JavaScript Courses</div>
      </v-col>

      <v-col cols="12" class="d-flex py-0">
        <v-icon>mdi-account-supervisor</v-icon>
        <div>15 000 learners</div>
      </v-col>

      <v-col cols="12" class="pb-0">
        <div class="text-h5">Courses to get you started</div>
      </v-col>
      <v-col cols="12" class="d-flex">
        <v-row>
          <v-col cols="2">
            <course-item />
          </v-col>
          <v-col cols="2">
            <course-item />
          </v-col>
          <v-col cols="2">
            <course-item />
          </v-col>
          <v-col cols="2">
            <course-item />
          </v-col>
          <v-col cols="2">
            <course-item />
          </v-col>
          <v-col cols="2">
            <course-item />
          </v-col>
        </v-row>
      </v-col>

      <v-col cols="12" class="pb-0">
        <div class="text-h5">Top courses in JavaScript</div>
      </v-col>
      <v-col cols="12" class="d-flex">
        <v-row>
          <v-col cols="2">
            <course-item />
          </v-col>
          <v-col cols="2">
            <course-item />
          </v-col>
          <v-col cols="2">
            <course-item />
          </v-col>
          <v-col cols="2">
            <course-item />
          </v-col>
          <v-col cols="2">
            <course-item />
          </v-col>
          <v-col cols="2">
            <course-item />
          </v-col>
        </v-row>
      </v-col>

      <v-col cols="12" class="pb-0">
        <div class="text-h5">All JavaScript courses</div>
      </v-col>
      <v-col cols="12">
        <v-row>
          <v-col cols="3">
            <div class="font-weight-bold">Ratings</div>
            <v-radio-group v-model="radioGroup" hide-details>
              <v-radio
                v-for="item in radioItems"
                :key="item.value"
                :value="item.value"
              >
                <template v-slot:label>
                  <div class="d-flex mx-0">
                    <v-rating
                      :value="item.label"
                      color="amber"
                      dense
                      half-increments
                      readonly
                      size="12"
                    ></v-rating>
                    <div class="grey--text ml-1">{{ item.label }} & up</div>
                  </div>
                </template>
              </v-radio>
            </v-radio-group>
            <v-divider class="my-4"></v-divider>
            <div class="font-weight-bold">Level</div>
            <div>
              <v-checkbox
                v-model="checkbox"
                label="All levels"
                hide-details
                class="mt-2"
              ></v-checkbox>
              <v-checkbox
                v-model="checkbox"
                label="Beginner"
                hide-details
                class="mt-2"
              ></v-checkbox>
              <v-checkbox
                v-model="checkbox"
                label="Intermediate"
                hide-details
                class="mt-2"
              ></v-checkbox>
              <v-checkbox
                v-model="checkbox"
                label="Expert"
                hide-details
                class="mt-2"
              ></v-checkbox>
            </div>
            <v-divider class="my-4"></v-divider>
            <div class="font-weight-bold">Price</div>
            <div>
              <v-checkbox
                v-model="checkbox"
                label="Paid"
                hide-details
                class="mt-2"
              ></v-checkbox>
              <v-checkbox
                v-model="checkbox"
                label="Free"
                hide-details
                class="mt-2"
              ></v-checkbox>
            </div>
          </v-col>
          <v-col cols="9">
            <course-item-details />
            <course-item-details />
            <course-item-details />
            <course-item-details />
            <course-item-details />
          </v-col>
          <v-col cols="12">
            <v-pagination
              v-model="page"
              :length="15"
              :total-visible="7"
            ></v-pagination>
          </v-col>
        </v-row>
      </v-col>
    </v-row>
  </v-container>
</template>
<script>
import CourseItem from "@/components/layout/Course/CourseItem.vue";
import CourseItemDetails from "@/components/layout/Course/CourseItemDetails.vue";
export default {
  components: { CourseItem, CourseItemDetails },
  data() {
    return {
      radioGroup: 0,
      radioItems: [
        { label: "4.5", value: 1 },
        { label: "4.0", value: 2 },
        { label: "3.5", value: 3 },
        { label: "3.0", value: 4 },
      ],
      checkbox: false,
      page: 1,
    };
  },
};
</script>
