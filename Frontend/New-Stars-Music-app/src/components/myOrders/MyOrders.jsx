import { Alert, Typography } from "@material-tailwind/react";
import React, { useEffect, useState } from "react";
import api from "../../api/api";
import LoadingMessage from "../common/LoadingMessage";
import toast from "react-hot-toast";
import InfoIcon from "../icons/InfoIcon";
import SaleOrderChart from "../common/SaleOrderChart";
import { useTheme } from "../../services/contexts/ThemeProvider";
import { useNavigate } from "react-router-dom";

const MyOrders = () => {
  const [saleOrders, setSaleOrders] = useState([]);
  const [isLoading, setIsLoading] = useState(false);
  const [noSaleOrders, setNoSaleOrders] = useState(false);
  const { theme } = useTheme();
  const navigate = useNavigate();

  useEffect(() => {
    const fetchSaleOrders = async () => {
      setIsLoading(true);
      try {
        const response = await api.get("/sale-orders/by-client", {
          validateStatus: (status) => {
            return status === 200 || status === 404; // Accept only 200 y 404 as valid responses (to avoid throwing an error)
          },
        });

        if (response.status === 404) {
          setNoSaleOrders(true);
        } else {
          const saleOrders = response.data;
          setSaleOrders(saleOrders);
        }
      } catch (error) {
        toast.error("Error getting your orders. Please try again later!");
        console.error("Error getting sale orders", error);
      } finally {
        setIsLoading(false);
      }
    };

    fetchSaleOrders();
  }, []);

  if (isLoading) return <LoadingMessage message="Loading orders..." />;

  return (
    <div className="max-w-7xl mx-auto">
      <Typography
        variant="h3"
        className="text-center pt-4 mb-4 mx-8 font-light"
      >
        My Orders
      </Typography>
      {noSaleOrders ? (
        <div className="mx-16 mt-4 mb-4">
          <Alert
            className={theme ? "bg-gray-800" : undefined}
            icon={<InfoIcon />}
          >
            It appears you don't have any orders yet. Why don't you head to our{" "}
            <a
              className="text-orange-800 cursor-pointer hover:underline"
              onClick={() => navigate("/store")}
            >
              Store
            </a>{" "}
            and order something you like?
          </Alert>
        </div>
      ) : (
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
      )}
    </div>
  );
};

export default MyOrders;
