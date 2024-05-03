import React, { useEffect, useState } from "react";
import { getAllProducts } from "../../services/productsService";

const FeaturedProducts = () => {
  const [products, setProducts] = useState([]);
  const [isLoading, setIsLoading] = useState(false);

  useEffect(() => {
    const fetchProducts = async () => {
      setIsLoading(true);
      try {
        const allProducts = await getAllProducts();
        setProducts(allProducts);
      } catch (error) {
        console.error("Error fetching all products:", error);
      } finally {
        setIsLoading(false);
      }
    };

    fetchProducts();
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
    <div className="mt-8">
      <h2 className="text-3xl">Featured Products</h2>
      <ul>{}</ul>
    </div>
  );
};

export default FeaturedProducts;
