import api from "./api";

export const getAuthSettings = async () => {
  try {
    const response = await api.get("/settings/auth");
    return response.data;
  } catch (error) {
    console.error("There was an error fetching auth results", error);
  }
};
