import { apiClient } from "./apiClient";

const getCourseYourselfStudent = id => {
  return apiClient.get(`/student/${id}`);
};

const createProfileStudent = payload => {
  return apiClient.post(`/student`, payload);
};

const changeProfileStudent = (id, payload) => {
  return apiClient.put(`/student/${id}`, payload);
};

export { getCourseYourselfStudent, createProfileStudent, changeProfileStudent };
