import React, { useEffect, useState } from "react";
import { useTheme } from "../../services/contexts/ThemeProvider";
import { Typography } from "@material-tailwind/react";

const SaleOrderChart = ({ saleOrder }) => {
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
      <li>
        <Typography>
          <span className="font-bold text-orange-900">Reception Date:</span> To
          be confirmed (via email)
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
                <span className="font-bold text-orange-900">{index + 1}.</span>{" "}
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
    </ul>
  );
};

export default SaleOrderChart;
