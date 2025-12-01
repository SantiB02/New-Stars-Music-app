import React, { useEffect, useState } from "react";
import StoreProducts from "./StoreProducts";
import { getAllProducts } from "../../services/productsService";
import { useTheme } from "../../services/contexts/ThemeProvider";
import { useRoles } from "../../hooks/useRoles";
import { useAuth0 } from "@auth0/auth0-react";
import Pagination from "../navigator/Pagination";

const Store = () => {
  const { theme } = useTheme();
  const [products, setProducts] = useState([]);
  const [isLoading, setIsLoading] = useState(false);
  const { getAccessTokenSilently, isAuthenticated } = useAuth0();
  const userRole = useRoles(getAccessTokenSilently, isAuthenticated);

  useEffect(() => {
    const fetchProducts = async () => {
      setIsLoading(true);
      try {
        const allProducts = await getAllProducts();

        setProducts(allProducts);
        console.log(products);
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
        theme ? "min-h-screen pt-4" : "min-h-screen pt-4 bg-gray-200 text-black"
      }
    >
      <div>
        <h1 className="text-3xl text-center">Welcome to our store!</h1>
        <p className="my-2 text-lg text-center">
          Feel free to explore our catalog and find the perfect product for you.
        </p>
      </div>
      <div>
        <StoreProducts
          products={products}
          isLoading={isLoading}
          userRole={userRole}
        />
      </div>
    </div>
  );
};

export default Store;
