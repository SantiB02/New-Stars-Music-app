import axios from "axios";

const api = axios.create({
  baseURL: import.meta.env.VITE_AXIOS_BASE_URL, //Por ahora es local, pero más adelante va a ser la API en backend
  headers: {
    "Content-Type": "application/json",
  },
});

api.interceptors.request.use(
  (config) => {
    const token = localStorage.getItem("token"); //CHECK HOW AUTH0 SAVES THE TOKEN BECAUSE IT MAY HAVE ANOTHER NAME!!!
    if (token) {
      config.headers.Authorization = `Bearer ${token}`;
    }
    return config;
  },
  (error) => {
    return Promise.reject(error);
  }
);

export default api;
