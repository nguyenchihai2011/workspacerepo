<template>
  <div class="example">
    <apexchart
      :width="width"
      :height="height"
      :options="options"
      :series="data"
    ></apexchart>
  </div>
</template>

<script>
import VueApexCharts from "vue-apexcharts";

export default {
  name: "Chart",
  props: {
    title: {
      type: String
    },
    width: {
      type: Number
    },
    height: {
      type: Number
    },
    loading: {
      type: Boolean
    },
    data: {
      type: Array
    }
  },
  components: {
    apexchart: VueApexCharts
  },
  computed: {
    options() {
      const completedPercentage = (
        (this.data[1] / (this.data[0] + this.data[1])) *
        100
      ).toFixed(2); // Tính phần trăm
      return {
        chart: {
          type: "donut"
        },
        colors: ["#0066a4", "rgba(0,0,0,0.1)"],
        noData: {
          text: this.loading ? "Loading..." : "No Data"
        },
        // plotOptions: {
        //   pie: {
        //     donut: {
        //       labels: {
        //         show: true,
        //         total: {
        //           show: true,
        //           label: `${completedPercentage}%`, // Hiển thị dữ liệu của bạn vào đây
        //           fontSize: "10px",
        //           fontWeight: "regular",
        //           color: "black"
        //         }
        //       }
        //     }
        //   }
        // },
        labels: ["Completed", "Uncompleted"],
        dataLabels: {
          enabled: false // Ẩn nhãn trên biểu đồ
        },
        legend: {
          show: false // Ẩn ghi chú trên biểu đồ
        }
      };
    }
  }
};
</script>
