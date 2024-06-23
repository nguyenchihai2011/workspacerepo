import { apiClient } from "./apiClient";

const signIn = function (payload) {
  return apiClient.post("authentication/login", payload);
};

const signUp = function (params, payload) {
  return apiClient.post("authentication/register", payload, { params });
};

const signUpStudent = function (payload) {
  return apiClient.post("student", payload);
};

const getUserInfo = function (token) {
  return apiClient.get(
    "authentication/getUserInfo",
    {},
    {
      headers: {
        "Content-Type": "application/json",
        Authorization: `Bearer ${token}`,
      },
    }
  );
};

export { signIn, signUp, signUpStudent, getUserInfo };
