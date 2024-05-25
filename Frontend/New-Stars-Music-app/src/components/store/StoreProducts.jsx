import React from "react";
import ProductCard from "../product/ProductCard";

const StoreProducts = ({ products, isLoading }) => {
  if (isLoading) {
    return (
      <div className="mt-8">
        <h2 className="text-3xl">Featured Products</h2>
        <p>Loading...</p>
      </div>
    );
  }

  return (
    <div>
      <h2 className="text-3xl">Featured Products</h2>
      <ul className=" flex flex-col mt-4 md:flex-row">
        {products.map((product) => (
          <ProductCard key={product.id} product={product} />
        ))}
      </ul>
    </div>
  );
};

export default StoreProducts;
