import { Alert, Typography } from "@material-tailwind/react";
import React, { useEffect, useState } from "react";
import api from "../../api/api";
import LoadingMessage from "../common/LoadingMessage";
import toast from "react-hot-toast";
import InfoIcon from "../icons/InfoIcon";
import SaleOrderChart from "../common/SaleOrderChart";
import { useTheme } from "../../services/contexts/ThemeProvider";
import { useNavigate } from "react-router-dom";
import Swal from "sweetalert2";
import { useAuth0 } from "@auth0/auth0-react";
import { useRoles } from "../../hooks/useRoles";

const MyOrders = () => {
  const [saleOrders, setSaleOrders] = useState([]);
  const [incomingSaleOrders, setIncomingSaleOrders] = useState([]);
  const [isLoading, setIsLoading] = useState(false);
  const [isCompletingOrder, setIsCompletingOrder] = useState(false);
  const [noSaleOrders, setNoSaleOrders] = useState(false);
  const [noIncomingSaleOrders, setNoIncomingSaleOrders] = useState(false);
  const { theme } = useTheme();
  const navigate = useNavigate();
  const { getAccessTokenSilently, isAuthenticated } = useAuth0();
  const userRole = useRoles(getAccessTokenSilently, isAuthenticated);

  useEffect(() => {
    const fetchSaleOrders = async () => {
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
      }
    };

    const fetchIncomingSaleOrders = async () => {
      try {
        const response = await api.get("/sale-orders/by-seller", {
          validateStatus: (status) => {
            return status === 200 || status === 404; // Accept only 200 y 404 as valid responses (to avoid throwing an error)
          },
        });

        if (response.status === 404) {
          setNoIncomingSaleOrders(true);
        } else {
          const incomingSaleOrders = response.data;
          setIncomingSaleOrders(incomingSaleOrders);
        }
      } catch (error) {
        toast.error("Error getting incoming orders. Please try again later!");
        console.error("Error getting incoming sale orders", error);
      }
    };

    const initialize = async () => {
      setIsLoading(true);
      await fetchSaleOrders();
      if (userRole === "Seller") {
        await fetchIncomingSaleOrders();
      }
      setIsLoading(false);
    };

    initialize();
  }, [userRole]);

  const completeSaleOrder = async (orderId) => {
    setIsCompletingOrder(true);
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

          const updatedIncomingSaleOrders = [...incomingSaleOrders];
          const index = updatedIncomingSaleOrders.findIndex(
            (incomingSaleOrder) => incomingSaleOrder.id === orderId
          );
          updatedIncomingSaleOrders[index].completed = true;
          setIncomingSaleOrders(updatedIncomingSaleOrders);
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
    } finally {
      setIsCompletingOrder(false);
    }
  };

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
      {userRole === "Seller" && (
        <>
          <Typography
            variant="h3"
            className="text-center pt-4 mb-4 mx-8 font-light"
          >
            Incoming Orders
          </Typography>
          {noIncomingSaleOrders ? (
            <div className="mx-16 mt-4 mb-4">
              <Alert
                className={theme ? "bg-gray-800" : undefined}
                icon={<InfoIcon />}
              >
                It appears clients haven't ordered your products yet.
              </Alert>
            </div>
          ) : (
            <div className="flex justify-center pb-12">
              <div className="lg:grid lg:grid-cols-2 lg:gap-x-16 lg:gap-y-12">
                {incomingSaleOrders.map((incomingSaleOrder) => (
                  <div
                    key={incomingSaleOrder.id}
                    className="border-solid mx-6 sm:mx-6 mb-6 lg:mb-0 "
                  >
                    <SaleOrderChart
                      saleOrder={incomingSaleOrder}
                      isIncomingOrder={true}
                      completeSaleOrder={completeSaleOrder}
                      isCompletingOrder={isCompletingOrder}
                    />
                  </div>
                ))}
              </div>
            </div>
          )}
        </>
      )}
    </div>
  );
};

export default MyOrders;
