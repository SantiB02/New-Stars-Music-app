import { useAuth0 } from "@auth0/auth0-react";
import React from "react";
import toast from "react-hot-toast";
import { Navigate } from "react-router-dom";

const Protected = ({ children }) => {
  const { user, isLoading } = useAuth0();
  if (!user && !isLoading) {
    toast.error("Access denied. Please log in...");
    return <Navigate to="/" replace />;
  } else return children;
};

export default Protected;
