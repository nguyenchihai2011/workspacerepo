import { apiClient } from "./apiClient";

const getCourse = (params = {}) => {
  return apiClient.get("/course", { params });
};

const getCourseById = id => {
  return apiClient.get(`/course/${id}`);
};

const addCourse = payload => {
  return apiClient.post("/course", payload);
};

const updateCourse = (id, payload) => {
  return apiClient.put(`/course/${id}`, payload);
};

const deleteCourse = payload => {
  return apiClient.delete(`course/bulkdelete`, { data: payload });
};

export { getCourse, getCourseById, addCourse, updateCourse, deleteCourse };
