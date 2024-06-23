import { apiClient } from "./apiClient";

const changeProfileLecture = (id, payload) => {
  return apiClient.put(`/lecture/${id}`, payload);
};

const createProfileLecture = payload => {
  return apiClient.post(`/lecture`, payload);
};

const getCourseYourselfLecture = params => {
  return apiClient.get(`/courseoflecture`, { params });
};

const getRevenueLecture = lectureId => {
  return apiClient.get(`/statistical/revenue/${lectureId}`);
};

export {
  changeProfileLecture,
  createProfileLecture,
  getCourseYourselfLecture,
  getRevenueLecture
};
