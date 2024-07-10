import { Alert, Typography } from "@material-tailwind/react";
import React, { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import api from "../../api/api";
import toast from "react-hot-toast";
import LoadingMessage from "../common/LoadingMessage";
import { useTheme } from "../../services/contexts/ThemeProvider";
import InfoIcon from "../icons/InfoIcon";
import SaleOrderChart from "../common/SaleOrderChart";

const ShippingDetails = () => {
  const [saleOrder, setSaleOrder] = useState({});
  const [isLoading, setIsLoading] = useState(false);
  const { theme } = useTheme();
  const { saleOrderId } = useParams();

  useEffect(() => {
    const fetchSaleOrder = async () => {
      setIsLoading(true);
      try {
        const response = await api.get(`/sale-orders/${saleOrderId}`);
        const saleOrder = response.data;
        setSaleOrder(saleOrder);
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
          <SaleOrderChart saleOrder={saleOrder} />
        </div>
      </div>
    </div>
  );
};

export default ShippingDetails;
