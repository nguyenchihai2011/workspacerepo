import { apiClient } from "./apiClient";

const getLessonById = id => {
  return apiClient.get(`/lesson/${id}`);
};

const addLesson = payload => {
  return apiClient.post("/lesson", payload);
};

const updateLesson = (id, payload) => {
  return apiClient.put(`/lesson/${id}`, payload);
};

const deleteLesson = id => {
  return apiClient.delete(`/lesson/${id}`);
};

export { getLessonById, addLesson, updateLesson, deleteLesson };
