import React, { useEffect, useState } from "react";
import { useTheme } from "../../services/contexts/ThemeProvider";
import { Typography, Button } from "@material-tailwind/react";

const SaleOrderChart = ({
  saleOrder,
  isIncomingOrder = false,
  completeSaleOrder,
  isCompletingOrder,
}) => {
  const [orderDate, setOrderDate] = useState(null);
  const { theme } = useTheme();

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
    parseOrderDate(saleOrder.date);
  }, []);

  return (
    <div
      className={`rounded-xl p-6 max-w-xl mx-auto transition-all duration-300
    ${
      theme
        ? "bg-[#1f1f23] hover:bg-black text-gray-200 border border-orange-500 shadow-xl" // DARK MODE
        : "bg-white hover:bg-blue-gray-50 text-[#2b2b2b] border border-orange-300  shadow-lg"
    }        // LIGHT MODE
  `}
    >
      {/* HEADER */}
      <div className="flex items-center justify-between mb-4">
        <h2
          className={`text-xl font-semibold 
        ${theme ? "text-orange-400" : "text-orange-600"}
      `}
        >
          Order #{saleOrder.id}
        </h2>

        <span
          className={`px-3 py-1 text-xs rounded-full font-medium 
          ${
            saleOrder.completed
              ? theme
                ? "bg-green-700 text-green-100"
                : "bg-green-500 text-white"
              : theme
              ? "bg-yellow-600 text-yellow-100"
              : "bg-yellow-300 text-yellow-900"
          }
        `}
        >
          {saleOrder.completed ? "Delivered" : "Pending delivery"}
        </span>
      </div>

      {/* BODY LIST */}
      <ul className="space-y-3">
        <li>
          <p>
            <span
              className={`${
                theme ? "text-orange-400" : "text-orange-600"
              } font-semibold`}
            >
              Code:
            </span>{" "}
            {saleOrder.orderCode}
          </p>
        </li>

        <li>
          <p>
            <span
              className={`${
                theme ? "text-orange-400" : "text-orange-600"
              } font-semibold`}
            >
              Date & Time:
            </span>{" "}
            {orderDate}
          </p>
        </li>

        {!isIncomingOrder && (
          <>
            <li>
              <p>
                <span
                  className={`${
                    theme ? "text-orange-400" : "text-orange-600"
                  } font-semibold`}
                >
                  Seller:
                </span>{" "}
                {saleOrder.seller.email}
              </p>
            </li>

            <li>
              <p>
                <span
                  className={`${
                    theme ? "text-orange-400" : "text-orange-600"
                  } font-semibold`}
                >
                  Origin:
                </span>{" "}
                {saleOrder.seller.city}, {saleOrder.seller.country}
              </p>
            </li>

            <li>
              <p>
                <span
                  className={`${
                    theme ? "text-orange-400" : "text-orange-600"
                  } font-semibold`}
                >
                  Reception Date:
                </span>{" "}
                To be confirmed (via email)
              </p>
            </li>
          </>
        )}

        {isIncomingOrder && (
          <>
            <li>
              <p>
                <span
                  className={`${
                    theme ? "text-orange-400" : "text-orange-600"
                  } font-semibold`}
                >
                  Shipment Location:
                </span>{" "}
                {saleOrder.client.address} {saleOrder.client.apartment || ""} (
                {saleOrder.client.city}, {saleOrder.client.country})
              </p>
            </li>

            <li>
              <p>
                <span
                  className={`${
                    theme ? "text-orange-400" : "text-orange-600"
                  } font-semibold`}
                >
                  Buyer:
                </span>{" "}
                {saleOrder.client.email}
              </p>
            </li>
          </>
        )}

        {/* ITEMS */}
        <li>
          <p
            className={`${
              theme ? "text-orange-400" : "text-orange-600"
            } font-semibold`}
          >
            Items:
          </p>

          <ul className="ml-3 space-y-1">
            {saleOrder.saleOrderLines?.map((line, index) => (
              <li key={line.id}>
                <p>
                  <span
                    className={`${
                      theme ? "text-orange-400" : "text-orange-600"
                    } font-semibold`}
                  >
                    {index + 1}.
                  </span>{" "}
                  {line.product.name}{" "}
                  <span
                    className={`${
                      theme ? "text-orange-300" : "text-orange-500"
                    }`}
                  >
                    (x{line.quantity})
                  </span>{" "}
                  <span
                    className={`${
                      theme ? "text-yellow-300" : "text-yellow-700"
                    } ml-2`}
                  >
                    ${line.total} ARS
                  </span>
                </p>
              </li>
            ))}
          </ul>
        </li>

        {/* TOTAL */}
        <li className="pt-2">
          <p>
            <span
              className={`${
                theme ? "text-orange-400" : "text-orange-600"
              } font-semibold`}
            >
              Total:
            </span>{" "}
            <span
              className={`${theme ? "text-yellow-300" : "text-yellow-700"}`}
            >
              ${saleOrder.total} ARS
            </span>
          </p>
        </li>

        {/* STATUS */}

        <li>
          <p
            className={
              saleOrder.completed
                ? theme
                  ? "text-green-400"
                  : "text-green-600"
                : theme
                ? "text-yellow-300"
                : "text-yellow-600"
            }
          >
            <span
              className={`${
                theme ? "text-orange-400" : "text-orange-600"
              } font-semibold`}
            >
              Status:
            </span>{" "}
            {saleOrder.completed ? "Delivered" : "Pending delivery"}
          </p>
        </li>
      </ul>

      {/* BUTTON */}
      {isIncomingOrder && (
        <div className="flex justify-center mt-6">
          <button
            onClick={() => completeSaleOrder(saleOrder.id)}
            disabled={saleOrder.completed || isCompletingOrder}
            className={`
          px-8 py-2 rounded-lg font-semibold transition-all duration-200
          ${
            saleOrder.completed
              ? theme
                ? "bg-green-200 text-white"
                : "bg-green-200 blur-1 text-white"
              : theme
              ? "bg-orange-500 hover:bg-orange-800 text-white"
              : "bg-orange-400 hover:bg-orange-700 text-white"
          }
        `}
          >
            {!saleOrder.completed
              ? isCompletingOrder
                ? "Completing..."
                : "Complete Order"
              : "Completed"}
          </button>
        </div>
      )}
    </div>
  );
};

export default SaleOrderChart;
