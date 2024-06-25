import { useAuth0 } from "@auth0/auth0-react";

export const getToken = async () => {
  const { getAccessTokenSilently } = useAuth0();
  try {
    return await getAccessTokenSilently();
  } catch (error) {
    console.error("Error getting Auth0 access token", error);
    return null;
  }
};
