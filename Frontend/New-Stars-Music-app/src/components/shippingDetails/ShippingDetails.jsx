import { Alert, Typography } from "@material-tailwind/react";
import React, { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import api from "../../api/api";
import toast from "react-hot-toast";
import LoadingMessage from "../common/LoadingMessage";
import { useTheme } from "../../services/contexts/ThemeProvider";
import InfoIcon from "../icons/InfoIcon";

const ShippingDetails = () => {
  const [saleOrder, setSaleOrder] = useState({});
  const [orderDate, setOrderDate] = useState(null);
  const [isLoading, setIsLoading] = useState(false);
  const { theme } = useTheme();
  const { saleOrderId } = useParams();

  const parseOrderDate = (dateString) => {
    const date = new Date(dateString);
    const parsedDate = `${date.getDate()}/${
      date.getMonth() + 1
    }/${date.getFullYear()} at ${
      (date.getHours() < 10 && "0") + date.getHours()
    }:${
      (date.getMinutes() < 10 && "0") + date.getMinutes()
    }:${date.getSeconds()}`;
    setOrderDate(parsedDate);
  };

  useEffect(() => {
    const fetchSaleOrder = async () => {
      setIsLoading(true);
      try {
        const response = await api.get(`/sale-orders/${saleOrderId}`);
        const saleOrder = response.data;
        setSaleOrder(saleOrder);
        parseOrderDate(saleOrder.date);
      } catch (error) {
        toast.error("Error getting sale order! Please refresh the page.");
        console.error("Error fetching sale order", error);
      } finally {
        setIsLoading(false);
      }
    };

    fetchSaleOrder();
  }, []);

  if (isLoading) return <LoadingMessage message="Loading sale order..." />;

  if (saleOrder.completed)
    return (
      <div className="max-w-xl mx-auto pt-16">
        <Alert
          className={theme ? "bg-gray-800" : undefined}
          icon={<InfoIcon />}
        >
          Oops! It seems this shipping order was already delivered...
        </Alert>
      </div>
    );

  return (
    <div>
      <div className="ml-6 pt-6">
        <Typography variant="h2" className="font-light">
          Your order has been successfully placed!
        </Typography>
        <Typography variant="h4" className="text-orange-900 font-light">
          Thank you for buying with us.
        </Typography>
      </div>
      <div className="ml-6 mt-6">
        <Typography variant="h3" className="font-light">
          Shipping & Order Details
        </Typography>
        <div className="md:w-2/4 mr-6 md:mr-0 mt-2 border-solid border-2 rounded-lg border-orange-900">
          <ul className="ml-10 my-4 list-disc marker:text-orange-900">
            <li>
              <Typography>
                <span className="font-bold text-orange-900">Order ID:</span>{" "}
                {saleOrderId}
              </Typography>
            </li>
            <li>
              <Typography>
                <span className="font-bold text-orange-900">Code:</span>{" "}
                {saleOrder.orderCode}
              </Typography>
            </li>
            <li>
              <Typography>
                <span className="font-bold text-orange-900">Date & Time:</span>{" "}
                {orderDate}
              </Typography>
            </li>
            <li>
              <Typography>
                <span className="font-bold text-orange-900">
                  Reception Date:
                </span>{" "}
                To be confirmed (via email)
              </Typography>
            </li>

            <li>
              <Typography>
                <span className="font-bold text-orange-900">Items:</span>
              </Typography>
              <ul>
                {saleOrder.saleOrderLines?.map((line, index) => (
                  <li key={line.id}>
                    <Typography>
                      <span className="font-bold text-orange-900">
                        {index + 1}.
                      </span>{" "}
                      {line.product.name}{" "}
                      <span className="text-orange-900">
                        (x{line.quantity})
                      </span>{" "}
                      <span
                        className={`ml-2 ${
                          theme ? "text-yellow-700" : undefined
                        } `}
                      >
                        ${line.total} ARS
                      </span>
                    </Typography>
                  </li>
                ))}
              </ul>
            </li>
            <li className="mt-2">
              <Typography>
                <span className="font-bold text-orange-900">Total:</span>{" "}
                <span className={theme ? "text-yellow-700" : undefined}>
                  ${saleOrder.total} ARS
                </span>
              </Typography>
            </li>
          </ul>
        </div>
      </div>
    </div>
  );
};

export default ShippingDetails;
