import { apiClient } from "./apiClient";

const getCommentsCourse = params => {
  return apiClient.get("/getComments", { params });
};

export { getCommentsCourse };
