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
    <div>
      <ul className="ml-10 my-4 list-disc pr-4 marker:text-orange-900">
        <li>
          <Typography>
            <span className="font-bold text-orange-900">Order ID:</span>{" "}
            {saleOrder.id}
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
        {!isIncomingOrder && (
          <li>
            <Typography>
              <span className="font-bold text-orange-900">Seller:</span>{" "}
              {saleOrder.sellerId}
            </Typography>
          </li>
        )}
        {!isIncomingOrder && (
          <li>
            <Typography>
              <span className="font-bold text-orange-900">Reception Date:</span>{" "}
              To be confirmed (via email)
            </Typography>
          </li>
        )}
        {isIncomingOrder && (
          <li>
            <Typography>
              <span className="font-bold text-orange-900">
                Shipment Location:
              </span>{" "}
              {`${saleOrder.client.address} ${
                saleOrder.client.apartment || ""
              } (${saleOrder.client.city}, ${saleOrder.client.country})`}
            </Typography>
          </li>
        )}
        {isIncomingOrder && (
          <li>
            <Typography>
              <span className="font-bold text-orange-900">Buyer:</span>{" "}
              {saleOrder.client.email}
            </Typography>
          </li>
        )}
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
                  <span className="text-orange-900">(x{line.quantity})</span>{" "}
                  <span
                    className={`ml-2 ${theme ? "text-yellow-700" : undefined} `}
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
        {isIncomingOrder && (
          <li className="mt-2">
            <Typography className={saleOrder.completed ? "text-green-500" : ""}>
              <span className="font-bold text-orange-900">Status:</span>{" "}
              {saleOrder.completed ? "Delivered" : "Pending delivery"}
            </Typography>
          </li>
        )}
      </ul>
      {isIncomingOrder && (
        <div className="flex justify-center mb-4">
          <Button
            onClick={() => completeSaleOrder(saleOrder.id)}
            color="green"
            size="sm"
            disabled={saleOrder.completed || isCompletingOrder}
          >
            {!saleOrder.completed
              ? isCompletingOrder
                ? "Completing order..."
                : "Complete"
              : "Completed"}
          </Button>
        </div>
      )}
    </div>
  );
};

export default SaleOrderChart;
