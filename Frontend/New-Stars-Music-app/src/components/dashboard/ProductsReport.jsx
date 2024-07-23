import React from "react";
import styles from "./Dashboard.module.css";
import { Typography } from "@material-tailwind/react";

const ProductsReport = ({ products, theme }) => {
  return (
    <div>
      {products && products.length > 0 ? (
        <div>
          <Typography variant="h4">Products</Typography>
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
            <tbody>
              {products.map((product) => (
                <tr key={product.id}>
                  <td>{product.name}</td>
                  <td>${product.price} ARS</td>
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
