import api from "./api";

export const getAuthSettings = async () => {
  try {
    const response = await api.get("/Settings/auth");
    console.log("response", response);
    return response.data;
  } catch (error) {
    console.error("There was an error fetching auth results", error);
  }
};
