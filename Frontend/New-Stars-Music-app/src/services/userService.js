import api from "../api/api";

// method that ensures that the user exists in our DB (or creates one if it doesn't)
export const ensureUser = async (userEmail) => {
  try {
    await api.post(`/users/ensure-user/${userEmail}`);
  } catch (error) {
    console.error("Error ensuring the Auth0 user in our database!");
  }
};

//method for search the user in our DB
export const getAllUsers = async () => {
  try {
    const response = await api.get("/users");
    return response.data;
  } catch (error) {
    console.log("Error", error);
  }
};
