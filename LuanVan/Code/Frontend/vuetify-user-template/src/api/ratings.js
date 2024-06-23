import { apiClient } from "./apiClient";

const getRatingsCourse = params => {
  return apiClient.get(`getRatings?courseId=${params}`);
};

const postRating = payload => {
  return apiClient.post(`rating`, payload);
};

export { getRatingsCourse, postRating };
