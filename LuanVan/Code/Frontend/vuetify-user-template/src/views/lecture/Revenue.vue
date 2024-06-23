<template>
  <v-row no-gutters>
    <v-container>
      <v-row>
        <v-col cols="12" class="d-flex align-center justify-space-between mt-6">
          <!-- <div class="text-h4">My teaching</div> -->
        </v-col>
        <v-col cols="12">
          <RevenueChart :dataRevenue="dataRevenue"></RevenueChart>
        </v-col>
      </v-row>
    </v-container>
  </v-row>
</template>

<script>
import { mapGetters } from "vuex";
import { getRevenueLecture } from "@/api/lecture";
import RevenueChart from "@/components/app/RevenueChart.vue";
export default {
  components: { RevenueChart },
  data: () => ({
    dataRevenue: []
  }),
  computed: {
    ...mapGetters("auth", ["lectureId"])
  },

  methods: {},
  created() {
    getRevenueLecture(this.lectureId).then(res => {
      this.dataRevenue = res.data;
    });
  }
};
</script>
