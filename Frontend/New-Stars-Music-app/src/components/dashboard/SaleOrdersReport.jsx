import { Typography, Button } from "@material-tailwind/react";
import React from "react";
import Swal from "sweetalert2";
import api from "../../api/api";
import styles from "./Dashboard.module.css";

const SaleOrdersReport = ({ saleOrders, setSaleOrders, theme }) => {
  const completeSaleOrder = async (orderId) => {
    try {
      const result = await Swal.fire({
        title: "Complete order?",
        text: "Confirm to complete the order.",
        icon: "question",
        showCancelButton: true,
        confirmButtonColor: "#3085d6",
        cancelButtonColor: "#d33",
        confirmButtonText: "Complete order",
      });

      if (result.isConfirmed) {
        const response = await api.put(`/sale-orders/${orderId}`);

        if (response.status === 200) {
          Swal.fire({
            title: "Order completed successfully",
            text: "The order has been successfully completed.",
            icon: "success",
          });

          const updatedSaleOrders = await api.get("/sale-orders");
          setSaleOrders(updatedSaleOrders.data);
        } else {
          Swal.fire({
            title: "Error",
            text: "Error completing the order.",
            icon: "error",
          });
        }
      }
    } catch (error) {
      console.log("Error", error);
      Swal.fire({
        title: "Error",
        text: "Error completing the order.",
        icon: "error",
      });
    }
  };

  const deleteSaleOrder = async (orderId) => {
    try {
      const result = await Swal.fire({
        title: "Delete order?",
        text: "Confirm to delete the order.",
        icon: "warning",
        showCancelButton: true,
        confirmButtonColor: "#3085d6",
        cancelButtonColor: "#d33",
        confirmButtonText: "Delete order",
      });

      if (result.isConfirmed) {
        const response = await api.delete(`/sale-orders/${orderId}`);

        if (response.status === 200) {
          Swal.fire({
            title: "Order deleted",
            text: "The order has been successfully deleted.",
            icon: "success",
          });

          const updatedSaleOrders = await api.get("/sale-orders");
          setSaleOrders(updatedSaleOrders.data);
        } else {
          Swal.fire({
            title: "Error",
            text: "Error deleting the order.",
            icon: "error",
          });
        }
      }
    } catch (error) {
      console.log("Error", error);
      Swal.fire({
        title: "Error",
        text: "Error deleting the order.",
        icon: "error",
      });
    }
  };

  return (
    <div>
      <Typography variant="h4">Sale Orders</Typography>
      {saleOrders !== null ? (
        saleOrders.length > 0 ? (
          <table
            className={theme ? styles["data-table-dark"] : styles["data-table"]}
          >
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
                      (order.client.apartment ? order.client.apartment : "")}
                  </td>
                  <td>{order.client.country}</td>
                  <td>{order.client.city}</td>
                  <td>{order.client.postalCode}</td>
                  <td>{order.completed ? "Yes" : "No"}</td>
                  <td>
                    <div>
                      {!order.completed ? (
                        <Button
                          onClick={() => completeSaleOrder(order.id)}
                          color="green"
                          size="sm"
                        >
                          Complete
                        </Button>
                      ) : (
                        <></>
                      )}
                    </div>

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
  );
};

export default SaleOrdersReport;
