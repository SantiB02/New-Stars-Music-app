import React, { useEffect, useState } from "react";
import ProductCard from "../product/ProductCard";
import LoadingMessage from "../common/LoadingMessage";
import { Typography } from "@material-tailwind/react";

const FeaturedProducts = ({ products, isLoading }) => {
  if (isLoading) {
    return <LoadingMessage message="Loading featured products..." />;
  }

  return (
    <div className="mt-8">
      <Typography variant="h3" className="ml-6">
        Featured Products
      </Typography>
      <div className="grid grid-cols-1 sm:grid-cols-2 gap-4 mt-4">
        {products.map((product) => (
          <ProductCard key={product.id} product={product} className="my-2" />
        ))}
      </div>
    </div>
  );
};

export default FeaturedProducts;
