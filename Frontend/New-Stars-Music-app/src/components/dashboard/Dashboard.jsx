import { Typography, Button } from "@material-tailwind/react";
import React, { useState, useEffect } from "react";
import api from "../../api/api";
import styles from "./Dashboard.module.css";
import Swal from 'sweetalert2'

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
            api.get("/products"),
            api.get("/users"),
            api.get("/sale-orders"),
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
  

  const completeSaleOrder = async (orderId) => {
    try {
      const result = await Swal.fire({
        title: "¿Completar orden?",
        text: "Confirma para completar la orden.",
        icon: "question",
        showCancelButton: true,
        confirmButtonColor: "#3085d6",
        cancelButtonColor: "#d33",
        confirmButtonText: "Completar orden"
      });

      if (result.isConfirmed) {
        const response = await api.put(`/sale-orders/${orderId}`);

        if (response.status === 200) {
          Swal.fire({
            title: "Orden completada",
            text: "La orden ha sido completada correctamente.",
            icon: "success",
          });

          const updatedSaleOrders = await api.get("/sale-orders");
          setSaleOrders(updatedSaleOrders.data);
        } else {
          Swal.fire({
            title: "Error",
            text: "Hubo un problema al completar la orden.",
            icon: "error",
          });
        }
      }
    } catch (error) {
      console.log("Error", error);
      Swal.fire({
        title: "Error",
        text: "Hubo un problema al completar la orden.",
        icon: "error",
      });
    }
  };

  const deleteSaleOrder = async (orderId) => {
    try {
      const result = await Swal.fire({
        title: "¿Eliminar orden?",
        text: "Confirma para eliminar la orden.",
        icon: "warning",
        showCancelButton: true,
        confirmButtonColor: "#3085d6",
        cancelButtonColor: "#d33",
        confirmButtonText: "Eliminar orden"
      });

      if (result.isConfirmed) {
        const response = await api.delete(`/sale-orders/${orderId}`);

        if (response.status === 200) {
          Swal.fire({
            title: "Orden eliminada",
            text: "La orden ha sido eliminada correctamente.",
            icon: "success",
          });

          const updatedSaleOrders = await api.get("/sale-orders");
          setSaleOrders(updatedSaleOrders.data);
        } else {
          Swal.fire({
            title: "Error",
            text: "Hubo un problema al eliminar la orden.",
            icon: "error",
          });
        }
      }
    } catch (error) {
      console.log("Error", error);
      Swal.fire({
        title: "Error",
        text: "Hubo un problema al eliminar la orden.",
        icon: "error",
      });
    }
  };

  return (
    <div className="max-w-7xl mx-8 py-6">
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
          <div>
            <Typography variant="h4">Sale Orders</Typography>
            {saleOrders !== null ? (
              saleOrders.length > 0 ? (
                <table className={styles["data-table"]}>
                  <thead>
                    <tr>
                      <th>Order ID</th>
                      <th>Buyer</th>
                      <th>Shipping Address</th>
                      <th>Country</th>
                      <th>City</th>
                      <th>Postal Code</th>
                      <th>Completed</th>

                      <th>Actions</th>
                    </tr>
                  </thead>
                  <tbody>
                    {saleOrders.map((order) => (
                      <tr key={order.id}>
                        <td>{order.id}</td>
                        <td>{order.client.email}</td>
                        <td>
                          {order.client.address +
                            " " +
                            (order.client.apartment
                              ? order.client.apartment
                              : "")}
                        </td>
                        <td>{order.client.country}</td>
                        <td>{order.client.city}</td>
                        <td>{order.client.postalCode}</td>
                        <td>{order.completed ? "Sí" : "No"}</td>                        
                        <td>
                        <td>{!order.completed ? <Button
                            onClick={() => completeSaleOrder(order.id)}
                            color="green"
                            size="sm"
                          >
                            Complete
                          </Button> : <></>}</td>                        

                          <Button
                            onClick={() => deleteSaleOrder(order.id)}
                            color="red"
                            size="sm"
                          >
                            Delete
                          </Button>
                        </td>
                      </tr>
                    ))}
                  </tbody>
                </table>
              ) : (
                "No sale orders yet"
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
