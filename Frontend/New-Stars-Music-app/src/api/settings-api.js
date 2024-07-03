import { authApi } from "./api";

export const getAuthSettings = async (setError) => {
  try {
    const response = await authApi.get("/settings/auth");
    return response.data;
  } catch (error) {
    setError(error.code);
    console.error("There was an error fetching auth results");
  }
};
