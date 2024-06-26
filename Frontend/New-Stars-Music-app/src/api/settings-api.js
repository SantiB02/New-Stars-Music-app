import { authApi } from "./api";

export const getAuthSettings = async () => {
  try {
    const response = await authApi.get("/settings/auth");
    return response.data;
  } catch (error) {
    console.error("There was an error fetching auth results", error);
  }
};
