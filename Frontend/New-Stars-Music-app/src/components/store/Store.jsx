import React, { useEffect, useState } from "react";
import StoreProducts from "./StoreProducts";
import { getAllProducts } from "../../services/productsService";
import { useTheme } from "../../services/contexts/ThemeProvider";

const Store = () => {
  const { theme } = useTheme();
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

  return (
    <div
      className={theme ? "min-h-screen" : "min-h-screen bg-gray-200 text-black"}
    >
      <div>
        <h1 className="text-3xl text-center">Welcome to our store!</h1>
        <p className="my-2 text-lg text-center">
          Feel free to explore our catalog and find the perfect product for you.
        </p>
      </div>
      <div>
        <StoreProducts products={products} isLoading={isLoading} />
      </div>
    </div>
  );
};

export default Store;
