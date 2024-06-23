import { apiClient } from "./apiClient";

const signIn = function(payload) {
  return apiClient.post("authentication/login", payload);
};

const signUp = function(params, payload) {
  return apiClient.post("authentication/register", payload, { params });
};

const signUpStudent = function(payload) {
  return apiClient.post("/student", payload);
};

const signUpLecture = function(payload) {
  return apiClient.post("/lecture", payload);
};

const getUserInfo = function(params) {
  return apiClient.get(
    "authentication/getUserInfo",
    { params },
    {
      headers: {
        "Content-Type": "application/json"
        // Authorization: `Bearer ${token}`,
      }
    }
  );
};

const logout = () => {
  return apiClient.post("/authentication/logout", {});
};

export { signIn, signUp, signUpStudent, signUpLecture, getUserInfo, logout };
