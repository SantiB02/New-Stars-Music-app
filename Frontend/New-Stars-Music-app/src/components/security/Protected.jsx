import { useAuth0 } from "@auth0/auth0-react";
import React from "react";
import { Navigate } from "react-router-dom";

const Protected = ({ children }) => {
  const { isAuthenticate } = useAuth0();
  if (!isAuthenticate) {
    return <Navigate to="/" replace />;
  } else return children;
};

export default Protected;
