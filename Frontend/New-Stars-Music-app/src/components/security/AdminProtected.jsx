import { useAuth0 } from "@auth0/auth0-react";
import React from "react";
import { Navigate, Outlet } from "react-router-dom";
import { useRoles } from "../../hooks/useRoles";

// función HOC (High Order Component). Una función que recibe un componente y devuelve otro dependiendo del resultado del if:
const withAuthentication = (Component) => {
  return (props) => {
    const { user, getAccessTokenSilently, isAuthenticated } = useAuth0();
    const userRole = useRoles(getAccessTokenSilently, isAuthenticated);
    if (user && userRole === "Admin") {
      return <Component {...props} />;
    } else {
      console.log("Forbidden role");
      return <Navigate to="/home" />;
    }
  };
};

const AdminProtected = withAuthentication(Outlet);

export default AdminProtected;
