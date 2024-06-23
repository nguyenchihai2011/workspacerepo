import axios from "axios";

const token = localStorage.getItem("token");

// Khởi tạo một instance của Axios
const apiClient = axios.create({
  baseURL: "https://localhost:7254/api/",
  // withCredentials: true,
  headers: {
    "Content-Type": "application/json",
    Authorization: `Bearer ${token}`,
  },
});

export { apiClient };
