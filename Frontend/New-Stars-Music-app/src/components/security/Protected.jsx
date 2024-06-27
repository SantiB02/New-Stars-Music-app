import { useAuth0 } from "@auth0/auth0-react";
import React from "react";
import toast from "react-hot-toast";
import { Navigate, Outlet } from "react-router-dom";

const Protected = () => {
  const { loginWithRedirect, user } = useAuth0();
  if (user) {
    return <Outlet />;
  } else {
    return <Navigate to={loginWithRedirect()} />;
  }
};

export default Protected;
