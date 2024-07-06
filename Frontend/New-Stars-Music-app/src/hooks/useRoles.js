import { useState, useEffect } from "react";
import api from "../api/api";

export const useRoles = (getToken, isAuthenticated) => {
  const [userRole, setUserRole] = useState("Client"); //por defecto, todo usuario nuevo es Client

  useEffect(() => {
    const getRole = async () => {
      try {
        const response = await api.get("users/role");
        const role = response.data;
        if (role) {
          setUserRole(role);
        }
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
