import { useState, useEffect } from "react";
import api from "../api/api";

export const useRoles = (getToken, isAuthenticated) => {
  const [userRole, setUserRole] = useState(null);

  useEffect(() => {
    const getRole = async () => {
      try {
        const response = await api.get("users/role");
        setUserRole(response.data);
      } catch (error) {
        console.error("Error getting user role", error);
      }
    };

    if (isAuthenticated) {
      getRole();
    }
  }, [getToken, isAuthenticated]);

  return userRole;
};
