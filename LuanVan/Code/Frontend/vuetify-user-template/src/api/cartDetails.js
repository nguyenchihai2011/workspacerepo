import { apiClient } from "./apiClient";

const getCartDetails = id => {
  return apiClient.get(`/cartdetails/${id}`);
};

const createCartDetails = payload => {
  return apiClient.post(`/cartDetails/`, payload);
};

const deleteCartDetails = payload => {
  return apiClient.delete(`/cartdetails/bulkdelete`, { data: payload });
};

export { getCartDetails, deleteCartDetails, createCartDetails };
