import api from "../api/api";

export const getAllProducts = async () => {
  try {
    const response = await api.get("/products"); //en la API real, va a haber una ruta por parámetro
    return response.data;
  } catch (error) {
    console.error("Error getting all products:", error);
  }
};

export const getFeaturedProducts = async (minimumSales) => {
  try {
    const response = await api.get("/products/featured", {
      params: {
        minimumSales,
      },
      validateStatus: (status) => {
        return status === 200 || status === 404; // Accept only 200 y 404 as valid responses (to avoid throwing an error)
      },
    });
    if (response.status === 200) return response.data;
    else {
      console.error(
        "No product meets the minimum sales criteria (Featured Products)"
      );
      return null;
    }
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
