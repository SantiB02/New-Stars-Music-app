import { useAuth0 } from "@auth0/auth0-react";
import React, { useEffect, useState } from "react";
import { ensureUser } from "../../services/userService";
import { setAuthInterceptor } from "../../api/api";

const SellerCenter = () => {
  const { user, isAuthenticated, getAccessTokenSilently, isLoading } =
    useAuth0();

  useEffect(() => {
    if (!isLoading) {
      setAuthInterceptor(getAccessTokenSilently);
    }
  }, [isLoading]);

  return (
    <div>
      SellerCenter
      {user && <p>Role claim: {user["https://localhost:7133/api/roles"]}</p>}
    </div>
  );
};

export default SellerCenter;
