import axios from "axios";

const api = axios.create({
  baseURL: "../../mocks/products.json", //Por ahora es local, pero más adelante va a ser la API en backend
  headers: {
    "Content-Type": "application/json",
  },
});

export default api;
