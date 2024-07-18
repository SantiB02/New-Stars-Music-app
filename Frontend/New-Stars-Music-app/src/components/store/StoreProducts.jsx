import React, { useEffect, useState } from "react";
import ProductCard from "../product/ProductCard";
import api from "../../api/api";

const StoreProducts = ({ products, isLoading, userRole }) => {
  const [categories, setCategories] = useState([]);

  useEffect(() => {
    const fetchCategories = async () => {
      try {
        const response = await api.get("/products/categories");
        const categories = response.data;
        setCategories(categories);
      } catch (error) {
        console.error("Error getting product categories", error);
      }
    };
  }, []);

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
      <ul className=" flex flex-col mt-4 md:flex-row m-10 justify-center">
        {products.map((product) => (
          <ProductCard
            isAdmin={userRole === "Admin"}
            key={product.id}
            product={product}
          />
        ))}
      </ul>
    </div>
  );
};

export default StoreProducts;
