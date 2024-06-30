import axios from "axios";

const api = axios.create({
  baseURL: import.meta.env.VITE_AXIOS_BASE_URL || "https://localhost:7133/api", //Por ahora es local, pero más adelante va a ser la API en backend
});

export const authApi = axios.create({
  baseURL: import.meta.env.VITE_AXIOS_BASE_URL || "https://localhost:7133/api", //Por ahora es local, pero más adelante va a ser la API en backend
  timeout: 4000,
});

export const setAuthInterceptor = (getToken) => {
  api.interceptors.request.use(
    async (config) => {
      const token = await getToken();
      console.log("TOKEN:", { token });
      config.headers.Authorization = `Bearer ${token}`;
      return config;
    },
    (error) => {
      return Promise.reject(error);
    }
  );
};

export default api;
