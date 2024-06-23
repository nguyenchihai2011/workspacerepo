import { apiClient } from "./apiClient";

const getListCategory = (params, signal = undefined) => {
  return apiClient.get("category", {
    params,
    signal
  });
};

const getCategory = id => {
  return apiClient.get(`category/${id}`);
};

export { getListCategory, getCategory };
