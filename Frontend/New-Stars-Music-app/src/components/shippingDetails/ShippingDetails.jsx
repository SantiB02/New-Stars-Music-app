import { Alert, Typography } from "@material-tailwind/react";
import React, { useEffect, useRef, useState } from "react";
import { useLocation, useNavigate } from "react-router-dom";
import api from "../../api/api";
import toast from "react-hot-toast";
import LoadingMessage from "../common/LoadingMessage";
import { useTheme } from "../../services/contexts/ThemeProvider";
import InfoIcon from "../icons/InfoIcon";
import SaleOrderChart from "../common/SaleOrderChart";
import PageNotFound from "../pageNotFound/PageNotFound";

const ShippingDetails = () => {
  const [saleOrders, setSaleOrders] = useState([]);
  const [isLoading, setIsLoading] = useState(false);
  const [wrongPage, setWrongPage] = useState(false);
  const { theme } = useTheme();
  const location = useLocation();
  const newSaleOrdersIds = location.state?.newSaleOrdersIds;
  const hasFetchedSaleOrders = useRef(false);

  useEffect(() => {
    const fetchSaleOrders = async () => {
      setIsLoading(true);
      try {
        const fetchedSaleOrders = await Promise.all(
          newSaleOrdersIds.map(async (newSaleOrderId) => {
            console.log("FETCHING ORDER WITH ID", newSaleOrderId);
            const response = await api.get(`/sale-orders/${newSaleOrderId}`);
            return response.data;
          })
        );

        setSaleOrders((prevSaleOrders) => [
          ...prevSaleOrders,
          ...fetchedSaleOrders,
        ]);
      } catch (error) {
        console.error("Error fetching sale orders:", error);
      } finally {
        setIsLoading(false);
      }
    };

    if (
      newSaleOrdersIds &&
      newSaleOrdersIds.length > 0 &&
      !hasFetchedSaleOrders.current
    ) {
      console.log("NEW SALE ORDERS IDS:", newSaleOrdersIds);
      hasFetchedSaleOrders.current = true;
      fetchSaleOrders();
    }
  }, [newSaleOrdersIds]);

  if (isLoading) return <LoadingMessage message="Loading sale order..." />;

  if (wrongPage) return <PageNotFound />;
  console.log("SALE ORDERS:", saleOrders);

  return (
    <div>
      <div className="ml-6 pt-6">
        <Typography variant="h2" className="font-light">
          {saleOrders.length > 1
            ? "Your orders have been successfully placed!"
            : "Your order has been successfully placed!"}
        </Typography>
        <Typography variant="h4" className="text-orange-900 font-light">
          Thank you for buying with us.
        </Typography>
      </div>
      <div className="ml-6 mt-6">
        <Typography variant="h3" className="font-light">
          Shipping & Order Details
        </Typography>
        <div className="flex justify-center pb-12">
          <div className="lg:grid lg:grid-cols-2 lg:gap-x-16 lg:gap-y-12">
            {saleOrders.map((saleOrder) => (
              <div
                key={saleOrder.id}
                className="border-solid mx-6 sm:mx-6 mb-6 lg:mb-0 border-2 rounded-lg border-orange-900"
              >
                <SaleOrderChart saleOrder={saleOrder} />
              </div>
            ))}
          </div>
        </div>
      </div>
    </div>
  );
};

export default ShippingDetails;
