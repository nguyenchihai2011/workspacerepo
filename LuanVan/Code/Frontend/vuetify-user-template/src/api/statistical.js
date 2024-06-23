import { apiClient } from "./apiClient";

const getTopCourses = () => {
  return apiClient.get("/statistical/topcourses");
};

export { getTopCourses };
