import React, { useEffect, useState } from "react";
import ProductCard from "../product/ProductCard";
import LoadingMessage from "../common/LoadingMessage";

const FeaturedProducts = ({ products, isLoading }) => {
  if (isLoading) {
    return <LoadingMessage message="Loading featured products..." />;
  }

  return (
    <div className="container mx-auto px-4 py-8">
      <h2 className="text-3xl">Featured Products</h2>
      <div className="grid grid-cols-1 sm:grid-cols-2  gap-4 mt-4">
        {products.map((product) => (
          <div key={product.id} className="w-full ">
            <ProductCard product={product} className="my-2" />
          </div>
        ))}
      </div>
    </div>
  );
};

export default FeaturedProducts;
