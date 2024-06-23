<template>
  <div id="buttonDiv"></div>
</template>

<script>
import axios from "axios";
export default {
  created() {
    async function handleCredentialResponse(res) {
      try {
        const access_token = res.credential;
        console.log(access_token);
        const response = await axios.get(
          // `https://www.googleapis.com/oauth2/v1/tokeninfo?access_token=${access_token}`
          `https://oauth2.googleapis.com/tokeninfo?id_token=${access_token}`
        );

        console.log("Credential hợp lệ:", response.data);
      } catch (error) {
        console.error(error);
      }
    }
    window.onload = function () {
      google.accounts.id.initialize({
        client_id:
          "830045231632-mms0pf29qm1fsjnq5d6sfn2eu3o42unl.apps.googleusercontent.com",
        callback: handleCredentialResponse,
      });
      google.accounts.id.renderButton(document.getElementById("buttonDiv"), {
        theme: "outline",
        size: "large",
      });
      // google.accounts.id.prompt();
    };
  },
};
</script>
