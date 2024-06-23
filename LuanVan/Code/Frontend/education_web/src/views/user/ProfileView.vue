<template>
  <v-row no-gutters class="flex-column align-center my-8">
    <v-col cols="6" class="d-flex justify-space-between align-center mb-4">
      <div class="text-h3">Edit Profile</div>
      <div style="width: 200px">
        <v-avatar size="60" class="text-center">
          <img src="https://cdn.vuetifyjs.com/images/john.jpg" alt="John" />
        </v-avatar>
        <v-file-input
          label="Take a photo"
          prepend-icon="mdi-camera"
          small-chips
        ></v-file-input>
      </div>
    </v-col>
    <v-col cols="6">
      <v-row no-gutters>
        <v-col cols="6" class="d-flex flex-column pr-4">
          <div>First Name</div>
          <v-text-field dense outlined class="rounded-lg"></v-text-field>
        </v-col>
        <v-col cols="6" class="d-flex flex-column pl-4">
          <div>Last Name</div>
          <v-text-field dense outlined class="rounded-lg"></v-text-field>
        </v-col>
        <v-col cols="12" class="d-flex flex-column">
          <div>Email</div>
          <v-text-field dense outlined class="rounded-lg"></v-text-field>
        </v-col>
        <v-col cols="12" class="d-flex flex-column">
          <div>Address</div>
          <v-text-field dense outlined class="rounded-lg"></v-text-field>
        </v-col>
        <v-col cols="12" class="d-flex flex-column">
          <div>Phone Number</div>
          <v-text-field dense outlined class="rounded-lg"></v-text-field>
        </v-col>
        <v-col cols="12" class="d-flex justify-end">
          <core-button outlined class="primary--text">Cancel</core-button>
          <core-button class="ml-4 primary white--text">Save</core-button>
        </v-col>
      </v-row>
    </v-col>
  </v-row>
</template>

<script>
// import cloudinary from "cloudinary.v2";
import CoreButton from "@/components/core/CoreButton.vue";

// cloudinary.config({
//   cloud_name: "drampapfw",
//   api_key: "991484839899152",
//   api_secret: "siVvPiEi-sF7XM9l4_8hhUoGLOg",
// });
export default {
  components: {
    CoreButton,
  },

  methods: {
    // handleFileUpload(event) {
    //   const file = event.target.files[0];
    //   const formData = new FormData();
    //   formData.append("file", file);
    //   formData.append("upload_preset", "YOUR_UPLOAD_PRESET"); // tùy chỉnh upload_preset của bạn
    //   // Tải lên lên Cloudinary
    //   cloudinary.v2.uploader.upload(formData, (error, result) => {
    //     if (result) {
    //       console.log("Tải lên thành công: ", result);
    //       // Xử lý kết quả tại đây
    //     } else {
    //       console.error("Lỗi khi tải lên: ", error);
    //       // Xử lý lỗi tại đây
    //     }
    //   });
    // },
  },
};
</script>
