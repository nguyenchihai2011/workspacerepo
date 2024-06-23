import { apiClient } from "./apiClient";

const getSections = () => {
  return apiClient.get("/section");
};

const getSectionById = id => {
  return apiClient.get(`/section/${id}`);
};

const addSection = payload => {
  return apiClient.post("/section", payload);
};

const updateSection = (id, payload) => {
  return apiClient.put(`/section/${id}`, payload);
};

const deleteSection = id => {
  return apiClient.delete(`/section/${id}`);
};

export {
  getSections,
  getSectionById,
  addSection,
  updateSection,
  deleteSection
};
