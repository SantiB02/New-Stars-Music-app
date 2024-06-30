import api from "../api/api";

// method that ensures that the user exists in our DB (or creates one if it doesn't)
export const ensureUser = async (userPostDto) => {
  try {
    console.log("ENSURE REQUEST BODY:", userPostDto);
    await api.post("/users/ensure-user", userPostDto);
  } catch (error) {
    console.error("Error ensuring the Auth0 user in our database!");
  }
};
