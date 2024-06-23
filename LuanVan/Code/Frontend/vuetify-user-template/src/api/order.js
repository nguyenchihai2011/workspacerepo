import { apiClient } from "./apiClient";

const addOrder = payload => {
  return apiClient.post("/order", payload);
};

export { addOrder };
