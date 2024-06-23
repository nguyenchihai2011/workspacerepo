<template>
  <v-row no-gutters>
    <v-container>
      <v-row>
        <v-col cols="12" class="d-flex align-center justify-space-between mt-6">
          <div class="text-h4">My learning</div>
        </v-col>
        <v-btn @click="sendEmail()">Click</v-btn>
      </v-row>
    </v-container>
  </v-row>
</template>

<script>
import { mapGetters } from "vuex";
export default {
  data() {
    return {
      student: {}
    };
  },

  computed: {
    ...mapGetters("auth", ["studentId"]),
    ...mapGetters("alanAI", ["command", "value"])
  },

  methods: {
    sendEmail() {
      Email.send({
        SecureToken: "91a0717f-d526-4268-8017-f48cffa3a1f5",
        To: "haib1906662@student.ctu.edu.vn",
        From: "nguyenchihai2011it@gmail.com",
        Subject: "This is the subject",
        Body: "And this is the body"
      }).then(message => alert(message));
    }
  },

  created() {
    this.fetchCourseYourself();
  }
};
</script>
