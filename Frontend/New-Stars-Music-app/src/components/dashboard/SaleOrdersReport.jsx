import { Typography, Button } from "@material-tailwind/react";
import React, { useEffect, useState } from "react";
import Swal from "sweetalert2";
import api from "../../api/api";
import styles from "./Dashboard.module.css";
import toast from "react-hot-toast";
import LoadingMessage from "../common/LoadingMessage";

const SaleOrdersReport = ({ theme }) => {
  const [isLoading, setIsLoading] = useState(false);
  const [saleOrders, setSaleOrders] = useState(null);

  useEffect(() => {
    const fetchSaleOrders = async () => {
      setIsLoading(true);
      try {
        const response = await api.get("/sale-orders");
        const allSaleOrders = response.data;
        setSaleOrders(allSaleOrders);
      } catch (error) {
        toast.error("Error getting all sale orders!");
        console.error("Error fetching all sale orders", error);
      } finally {
        setIsLoading(false);
      }
    };

    fetchSaleOrders();
  }, []);

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

  if (isLoading) return <LoadingMessage message="Loading sale orders..." />;

  return (
    <div>
      <Typography variant="h4" className={theme ? "text-white" : "text-black"}>
        Sale Orders
      </Typography>
      {saleOrders !== null ? (
        saleOrders.length > 0 ? (
          <table
            className={theme ? styles["data-table-dark"] : styles["data-table"]}
          >
            <thead className="text-sm">
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
            <tbody
              className={theme ? "text-white text-sm" : "text-black text-sm"}
            >
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
                    <Button
                      onClick={() => deleteSaleOrder(order.id)}
                      color="red"
                      size="sm"
                      className="my-2"
                      disabled={!order.state}
                    >
                      {order.state ? "Delete" : "Deleted"}
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
