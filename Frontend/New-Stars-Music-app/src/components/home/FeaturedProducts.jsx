import React, { useEffect, useState } from "react";
import ProductCard from "../product/ProductCard";
import LoadingMessage from "../common/LoadingMessage";
import { useRoles } from "../../hooks/useRoles";
import { useAuth0 } from "@auth0/auth0-react";
import { Alert, Typography } from "@material-tailwind/react";
import InfoIcon from "../icons/InfoIcon";
import { useTheme } from "../../services/contexts/ThemeProvider";

const FeaturedProducts = ({ products, isLoading }) => {
  const { getAccessTokenSilently, isAuthenticated } = useAuth0();
  const userRole = useRoles(getAccessTokenSilently, isAuthenticated);
  const { theme } = useTheme();

  if (isLoading) {
    return <LoadingMessage message="Loading featured products..." />;
  }

  if (!products)
    return (
      <Alert className={theme ? "bg-gray-800" : undefined} icon={<InfoIcon />}>
        No featured products yet!
      </Alert>
    );

  return (
    <div className="container mx-auto px-4">
      <Typography variant="h3" className="font-light">
        Featured Products
      </Typography>

      <div className="grid grid-cols-1 sm:grid-cols-2 md:grid-cols-3 gap-4 mt-4">
        {products.map((product) => (
          <div key={product.id} className="w-full ">
            <ProductCard
              product={product}
              isAdmin={userRole === "Admin"}
              className="my-2"
            />
          </div>
        ))}
      </div>
    </div>
  );
};

export default FeaturedProducts;
