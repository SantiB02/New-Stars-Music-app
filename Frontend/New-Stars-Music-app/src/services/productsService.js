import api from "../api/api";

export const getAllProducts = async () => {
  try {
    const response = await api.get(); //en la API real, va a haber una ruta por parámetro
    return response.data;
  } catch (error) {
    console.error("Error getting all products:", error);
  }
};

export const getFeaturedProducts = async (minimumSales) => {
  try {
    const response = await api.get("/products/featured", {
      //se pasa un parámetro por query (ver en .NET)
      params: {
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
  }
};
