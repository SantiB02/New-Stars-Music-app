import { Typography } from "@material-tailwind/react";
import React, { useEffect, useRef, useState } from "react";
import { useLocation, useNavigate } from "react-router-dom";
import api from "../../api/api";
import LoadingMessage from "../common/LoadingMessage";
import SaleOrderChart from "../common/SaleOrderChart";
import PageNotFound from "../pageNotFound/PageNotFound";

const ShippingDetails = () => {
  const [saleOrders, setSaleOrders] = useState([]);
  const [isLoading, setIsLoading] = useState(false);
  const [wrongPage, setWrongPage] = useState(false);
  const hasFetchedSaleOrders = useRef(false);
  const location = useLocation();
  const newSaleOrdersIds = location.state?.newSaleOrdersIds;

  useEffect(() => {
    const fetchSaleOrders = async () => {
      setIsLoading(true);
      try {
        const fetchedSaleOrders = await Promise.all(
          newSaleOrdersIds.map(async (newSaleOrderId) => {
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
      hasFetchedSaleOrders.current = true;
      fetchSaleOrders();
    } else if (!newSaleOrdersIds) {
      setWrongPage(true);
    }
  }, []);

  if (isLoading) return <LoadingMessage message="Loading sale order..." />;

  if (wrongPage) return <PageNotFound />;

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
        <Typography variant="h3" className="font-light mb-2">
          Shipping & Order Details
        </Typography>
        <div className="flex justify-center pb-12">
          <div className="lg:grid lg:grid-cols-2 lg:gap-x-16 lg:gap-y-12">
            {saleOrders.map((saleOrder) => (
              <div
                key={saleOrder.id}
                className="border-solid mx-6 sm:mx-6 mb-6 lg:mb-0"
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
