import { useAuth0 } from "@auth0/auth0-react";
import React, { useEffect, useState } from "react";

const SellerCenter = () => {
  const { user, isAuthenticated, getAccessTokenSilently } = useAuth0();

  return (
    <div>
      SellerCenter
      {user && <p>Role claim: {user["role"]}</p>}
    </div>
  );
};

export default SellerCenter;
