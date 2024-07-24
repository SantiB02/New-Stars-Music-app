import { useAuth0 } from "@auth0/auth0-react";
import React from "react";
import { Navigate, Outlet } from "react-router-dom";

// función HOC (High Order Component). Una función que recibe un componente y devuelve otro dependiendo del resultado del if:
const withAuthentication = (Component) => {
  return (props) => {
    const { loginWithRedirect, user } = useAuth0();
    if (user) {
      return <Component {...props} />;
    } else {
      loginWithRedirect();
      return <Navigate to="/home" />;
    }
  };
};

const Protected = withAuthentication(Outlet);

export default Protected;
