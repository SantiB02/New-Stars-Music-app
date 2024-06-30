import React, { useEffect, useState } from "react";
import FeaturedProducts from "./FeaturedProducts";
import Music from "./Music";
import { getAllProducts } from "../../services/productsService";
import { useAuth0 } from "@auth0/auth0-react";
import { useTheme } from "../../services/contexts/ThemeProvider";
import { useLocation } from "react-router-dom";

const Home = () => {
  const [products, setProducts] = useState([]);
  const [isLoading, setIsLoading] = useState(false);
  const { user } = useAuth0();
  const { theme } = useTheme();

  useEffect(() => {
    const fetchProducts = async () => {
      setIsLoading(true);
      try {
        const allProducts = await getAllProducts();
        setProducts(allProducts);
        console.log("USER", user);
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
      className={
        theme
          ? "flex flex-col min-h-screen"
          : "flex flex-col min-h-screen bg-gray-200 text-black"
      }
    >
      <div className="flex-grow overflow-auto flex flex-col md:flex-row mb-1">
        <div className="md:w-1/2 p-4">
          <h1 className="text-4xl">Welcome to New Stars Music!</h1>
          <p>
            The place where you can listen to your favorite songs and explore
            their products in our all-in-one store.
          </p>
          <div className="mt-8">
            <FeaturedProducts products={products} isLoading={isLoading} />
          </div>
        </div>
        <div className="md:w-1/2 p-4">
          <div className="h-full">
            <Music />
          </div>
        </div>
      </div>
    </div>
  );
};

export default Home;
