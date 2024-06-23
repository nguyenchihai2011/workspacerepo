import { apiClient } from "./apiClient";

const mostPurchaseCourse = params => {
  return apiClient.get("/alanai/most-purchase", { params });
};

const topRatingCourse = params => {
  return apiClient.get("/alanai/top-rating", { params });
};

export { mostPurchaseCourse, topRatingCourse };
