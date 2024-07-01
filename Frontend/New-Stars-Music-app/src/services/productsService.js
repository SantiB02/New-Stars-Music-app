import api from "../api/api";

export const getAllProducts = async () => {
  try {
    const response = await api.get("/products"); //en la API real, va a haber una ruta por parámetro
    return response.data;
  } catch (error) {
    console.error("Error getting all products:", error);
  }
};

export const getFeaturedProducts = async (quantity, minimumSales) => {
  try {
    const response = await api.get("/products/featured", {
      params: {
        quantity,
        minimumSales,
      },
    });
    return response.data;
  } catch (error) {
    console.error("Error getting featured products:", error);
  }
};

export const getProduct = async (productId) => {
  try {
    const response = await api.get(`/products/${productId}`);
    return response.data;
  } catch (error) {
    console.error("Error getting product", error);
    throw error;
  }
};
