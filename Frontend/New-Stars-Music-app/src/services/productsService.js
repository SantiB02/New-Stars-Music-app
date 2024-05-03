import api from "../api/api";

export const getAllProducts = async () => {
  try {
    const response = await api.get();
    return response;
  } catch (error) {
    console.error("Error getting all products:", error);
  }
};
