import { useState, useEffect } from "react";
import api from "../api/api";

export const useRoles = (getToken) => {
  const [userRole, setUserRole] = useState(null);

  useEffect(() => {
    const getRole = async () => {
      try {
        const response = await api.get("users/role", {
          headers: {
            Authorization: `Bearer ${getToken()}`,
          },
        });
        setUserRole(response.data);
      } catch (error) {
        console.error("Error getting user role", error);
      }
    };

    getRole();
  }, [getToken]);

  return userRole;
};
