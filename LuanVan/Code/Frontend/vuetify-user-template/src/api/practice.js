import { apiClient } from "./apiClient";

const createPractice = payload => {
  return apiClient.post("/practice", payload);
};

export { createPractice };
