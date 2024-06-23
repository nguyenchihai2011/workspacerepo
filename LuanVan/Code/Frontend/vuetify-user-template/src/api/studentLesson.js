import { apiClient } from "./apiClient";

const getStudentLesson = (params = {}) => {
  return apiClient.get("/studentlesson", { params });
};

const updateProgress = (params = {}) => {
  return apiClient.put("/studentlesson", {}, { params });
};

const getProgress = (params = {}) => {
  return apiClient.get("/getprogress", { params });
};

export { getStudentLesson, updateProgress, getProgress };
