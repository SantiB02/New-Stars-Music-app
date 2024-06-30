import { useAuth0 } from "@auth0/auth0-react";
import React, { useEffect, useState } from "react";

const SellerCenter = () => {
  const { user, isAuthenticated, getAccessTokenSilently } = useAuth0();
  const [roles, setRoles] = useState([]);

  useEffect(() => {
    const fetchRoles = async () => {
      try {
        const token = await getAccessTokenSilently();
        const decodedToken = JSON.parse(atob(token.split(".")[1]));
        const userRoles =
          decodedToken[
            "https://dev-a64glq5ygldhuy1g.us.auth0.com/api/v2/roles"
          ] || [];
        setRoles(userRoles);
      } catch (error) {
        console.error("Error obteniendo roles del token", error);
      }
    };

    if (isAuthenticated) {
      fetchRoles();
    }
  }, [isAuthenticated, getAccessTokenSilently]);
  return (
    <div>
      SellerCenter
      <p>ROLE:</p>
      {user && (
        <p>
          name of role:{" "}
          {user["https://dev-a64glq5ygldhuy1g.us.auth0.com/roles"]}
        </p>
      )}
    </div>
  );
};

export default SellerCenter;
