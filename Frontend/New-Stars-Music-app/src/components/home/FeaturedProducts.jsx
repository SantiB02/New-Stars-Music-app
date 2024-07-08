import React, { useEffect, useState } from "react";
import ProductCard from "../product/ProductCard";
import LoadingMessage from "../common/LoadingMessage";
import { useRoles } from "../../hooks/useRoles";
import { useAuth0 } from "@auth0/auth0-react";

const FeaturedProducts = ({ products, isLoading }) => {
  const { getAccessTokenSilently, isAuthenticated } = useAuth0();
  const userRole = useRoles(getAccessTokenSilently, isAuthenticated);

  if (isLoading) {
    return <LoadingMessage message="Loading featured products..." />;
  }

  return (
    <div className="container mx-auto px-4">
      <h2 className="text-3xl">Featured Products</h2>
      <div className="grid grid-cols-1 sm:grid-cols-2  gap-4 mt-4">
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
