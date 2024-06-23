import { apiClient } from "./apiClient";

const getCartId = id => {
  return apiClient.get(`/cart/${id}`);
};

const createCart = payload => {
  return apiClient.post(`/cart/`, payload);
};

export { getCartId, createCart };
