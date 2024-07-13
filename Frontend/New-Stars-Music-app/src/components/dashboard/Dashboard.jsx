// Dashboard.jsx

import { Typography } from "@material-tailwind/react";
import React, { useState, useEffect } from "react";
import api from "../../api/api";
import styles from "./Dashboard.module.css";

const Dashboard = () => {
  const [users, setUsers] = useState(null);
  const [products, setProducts] = useState(null);
  const [saleOrders, setSaleOrders] = useState(null);
  const [error, setError] = useState(null);

  useEffect(() => {
    const fetchData = async () => {
      try {
        const [productListResponse, usersResponse, saleOrdersResponse] =
          await Promise.all([
            api.get("products"),
            api.get("users"),
            api.get("sale-orders/GetSaleOrdersForAdmin"),
          ]);

        setUsers(usersResponse.data);
        setProducts(productListResponse.data);
        setSaleOrders(saleOrdersResponse.data);
        setError(null);
      } catch (error) {
        console.log("Error", error);
        setError(error.message || "Error fetching data");
      }
    };
    fetchData();

    return () => {
      setUsers(null);
      setProducts(null);
      setSaleOrders(null);
    };
  }, []);

  return (
    <div>
      <Typography variant="h2" className="font-light">
        Dashboard
      </Typography>
      {error ? (
        <div>Error: {error}</div>
      ) : (
        <>
          <div>
            {users && users.length > 0 ? (
              <div>
                <Typography variant="h4">Users</Typography>
                <table className={styles["data-table"]}> 
                  <thead>
                    <tr>
                      <th>Email</th>
                      <th>Role</th>
                      <th>Phone</th>
                    </tr>
                  </thead>
                  <tbody>
                    {users.map((user) => (
                      <tr key={user.id}>
                        <td>{user.email}</td>
                        <td>{user.role}</td>
                        <td>{user.phone}</td>
                      </tr>
                    ))}
                  </tbody>
                </table>
              </div>
            ) : (
              "Loading users..."
            )}
          </div>
          <div>
            {products && products.length > 0 ? (
              <div>
                <Typography variant="h4">Products</Typography>
                <table className={styles["data-table"]}> 
                  <thead>
                    <tr>
                      <th>Name</th>
                      <th>Price</th>
                    </tr>
                  </thead>
                  <tbody>
                    {products.map((product) => (
                      <tr key={product.id}>
                        <td>{product.name}</td>
                        <td>${product.price}</td>
                      </tr>
                    ))}
                  </tbody>
                </table>
              </div>
            ) : (
              "Loading products..."
            )}
          </div>
          <div>
            <Typography variant="h4">Sale Orders</Typography>
            {saleOrders !== null ? (
              saleOrders.data !== "Sale Orders not found" ? (
                saleOrders.length > 0 ? (
                  <table className={styles["data-table"]}> 
                    <thead>
                      <tr>
                        <th>Order ID</th>
                        <th>Customer Name</th>
                      </tr>
                    </thead>
                    <tbody>
                      {saleOrders.map((order) => (
                        <tr key={order.id}>
                          <td>{order.id}</td>
                          <td>{order.customerName}</td>
                        </tr>
                      ))}
                    </tbody>
                  </table>
                ) : (
                  "No hay órdenes de venta"
                )
              ) : (
                "No hay órdenes de venta"
              )
            ) : (
              "Loading sale orders..."
            )}
          </div>
        </>
      )}
    </div>
  );
};

export default Dashboard;
