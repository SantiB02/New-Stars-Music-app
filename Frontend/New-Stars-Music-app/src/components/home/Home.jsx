import React, { useEffect, useState } from "react";
import FeaturedProducts from "./FeaturedProducts";
import Music from "./Music";
import { getAllProducts } from "../../services/productsService";

const Home = () => {
  const [products, setProducts] = useState([]);
  const [isLoading, setIsLoading] = useState(false);

  useEffect(() => {
    const fetchProducts = async () => {
      setIsLoading(true);
      try {
        const allProducts = await getAllProducts();
        console.log("ALL PRODUCTS", allProducts);
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
    <div className="flex flex-col min-h-screen">
      <div className="flex-grow overflow-auto flex mb-1">
        <div className="flex flex-col ml-4 mt-10 flex-grow">
          <h1 className="text-4xl">Welcome to New Stars Music!</h1>
          <p>
            The place where you can listen to your favorite songs and explore
            their products in our all-in-one store.
          </p>
          <div className="w-3/4">
            <FeaturedProducts products={products} isLoading={isLoading} />
          </div>
        </div>
        <div className="flex flex-col ml-4 mt-10 w-2/4 mr-8">
          <div className="flex flex-col h-full">
            <div className="flex-grow">
              <Music />
            </div>
          </div>
        </div>
      </div>
    </div>
  );
};

export default Home;
