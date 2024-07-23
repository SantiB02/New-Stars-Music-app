import React, { useEffect, useState } from "react";
import styles from "./Dashboard.module.css";
import { Typography } from "@material-tailwind/react";
import api from "../../api/api";
import toast from "react-hot-toast";
import LoadingMessage from "../common/LoadingMessage";

const ProductsReport = ({ theme }) => {
  const [isLoading, setIsLoading] = useState(false);
  const [products, setProducts] = useState(null);

  useEffect(() => {
    const fetchProducts = async () => {
      setIsLoading(true);
      try {
        const response = await api.get("/products");
        const allProducts = response.data;
        setProducts(allProducts);
      } catch (error) {
        toast.error("Error getting all products!");
        console.error("Error fetching all products", error);
      } finally {
        setIsLoading(false);
      }
    };

    fetchProducts();
  }, []);

  if (isLoading) return <LoadingMessage message="Loading products..." />;

  return (
    <div>
      {products && products.length > 0 ? (
        <div>
          <Typography
            variant="h4"
            className={theme ? "text-white" : "text-black"}
          >
            Products
          </Typography>
          <table
            className={theme ? styles["data-table-dark"] : styles["data-table"]}
          >
            <thead>
              <tr>
                <th>Name</th>
                <th>Price</th>
                <th>Seller</th>
              </tr>
            </thead>
            <tbody className={theme ? "text-white" : "text-black"}>
              {products.map((product) => (
                <tr key={product.id}>
                  <td>{product.name}</td>
                  <td className={theme ? "text-yellow-700" : ""}>
                    ${product.price} ARS
                  </td>
                  <td>{product.sellerId}</td>
                </tr>
              ))}
            </tbody>
          </table>
        </div>
      ) : (
        "Loading products..."
      )}
    </div>
  );
};

export default ProductsReport;
