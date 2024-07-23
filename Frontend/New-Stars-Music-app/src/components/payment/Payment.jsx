import {
  Card,
  Input,
  Checkbox,
  Button,
  Typography,
  Alert,
} from "@material-tailwind/react";
import React, { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import { useCart } from "../../hooks/useCart";
import { useTheme } from "../../services/contexts/ThemeProvider";
import toast from "react-hot-toast";
import api from "../../api/api";
import LoadingMessage from "../common/LoadingMessage";
import InfoIcon from "../icons/InfoIcon";

const Payment = () => {
  const [open, setOpen] = useState(false);
  const [address, setAddress] = useState("");
  const [apartment, setApartment] = useState("");
  const [country, setCountry] = useState("");
  const [city, setCity] = useState("");
  const [postalCode, setPostalCode] = useState("");
  const [phone, setPhone] = useState("");
  const [cardNumber, setCardNumber] = useState("");
  const [expirationDate, setExpirationDate] = useState("");
  const [cvv, setCvv] = useState("");
  const [isProcessingPayment, setIsProcessingPayment] = useState(false);
  const [personalInfoAlreadySubmitted, setPersonalInfoAlreadySubmitted] =
    useState(false);
  const [isLoading, setIsLoading] = useState(false);
  const navigate = useNavigate();
  const { cart, cartTotal, clearCart } = useCart();
  const { theme } = useTheme();

  useEffect(() => {
    const fetchUserPersonalInfoStatus = async () => {
      setIsLoading(true);
      try {
        const response = await api.get("/users/has-personal-info");
        const hasPersonalInfo = response.data;

        if (hasPersonalInfo) {
          setPersonalInfoAlreadySubmitted(true);
        }
      } catch (error) {
        console.error("Error fetching user's personal info status", error);
      } finally {
        setIsLoading(false);
      }
    };

    fetchUserPersonalInfoStatus();
  }, []);

  const stateChangeHandler = (e, setState) => {
    setState(e.target.value);
  };

  const cardNumberChangeHandler = (e) => {
    const cardNumberString = e.target.value.toString();
    if (cardNumberString.length <= 12) {
      setCardNumber(e.target.value);
    }
  };

  const cvvChangeHandler = (e) => {
    const cvvString = e.target.value.toString();
    if (cvvString.length <= 4) {
      setCvv(e.target.value);
    }
  };

  const makePaymentHandler = async () => {
    setIsProcessingPayment(true);
    try {
      if (!personalInfoAlreadySubmitted) {
        const request = {
          address,
          apartment,
          country,
          city,
          postalCode,
          phone,
        };
        await api.put("/users/client", request);
      }

      const saleOrderLinesBySeller = cart.reduce((acc, product) => {
        const { sellerId, id, quantity, price } = product;

        // Si el vendedor no existe en el acumulador, lo agregamos
        if (!acc[sellerId]) {
          acc[sellerId] = {
            sellerId,
            linesDto: [],
            total: 0,
          };
        }

        // Agregamos la línea de orden de venta al vendedor correspondiente
        acc[sellerId].linesDto.push({
          quantity,
          productId: id,
        });

        acc[sellerId].total += quantity * price;

        return acc;
      }, {});

      // Convertimos el objeto en un arreglo de vendedores
      const sellersWithSaleOrderLines = Object.values(saleOrderLinesBySeller);

      console.log(sellersWithSaleOrderLines);

      const response = await api.post(
        "/sale-orders",
        sellersWithSaleOrderLines
      );
      const newSaleOrdersIds = response.data;

      const productsToUpdate = [];
      cart.forEach((product) =>
        productsToUpdate.push({
          id: product.id,
          quantityToBuy: product.quantity,
        })
      );
      console.log("PRODUCTS TO BUY:", productsToUpdate);
      await api.put("/products/buy", productsToUpdate);

      clearCart();
      localStorage.removeItem("cart");
      localStorage.removeItem("cartTotal");
      navigate("/shipping-details", { state: { newSaleOrdersIds } });
    } catch (error) {
      toast.error("Error buying product/s. Please try again later!");
      console.error("Error buying product", error);
    } finally {
      setIsProcessingPayment(false);
    }
  };

  if (isLoading) return <LoadingMessage message="Loading..." />;

  if (cart.length === 0) navigate("/home");

  return (
    <div className="ml-10 pt-4">
      <Typography variant="h2" className="font-light">
        Payment
      </Typography>
      <Typography variant="h3" className="mb-4 font-light">
        Total:{" "}
        <span className="text-orange-600">${cartTotal.toFixed(2)} ARS</span>
      </Typography>
      {personalInfoAlreadySubmitted && (
        <div className="mr-16 mb-4">
          <Alert
            className={theme ? "bg-gray-800" : undefined}
            icon={<InfoIcon />}
          >
            Your shipping location is already saved in your profile. You can pay
            for this order with it or modify it in your{" "}
            <a
              className="text-orange-800 cursor-pointer hover:underline"
              onClick={() => navigate("/profile")}
            >
              Profile
            </a>{" "}
            page.
          </Alert>
        </div>
      )}
      <div className="flex justify-center gap-16">
        {!personalInfoAlreadySubmitted && (
          <Card color="transparent" shadow={false}>
            <Typography
              variant="h4"
              className="font-light"
              color={theme ? "white" : "blue-gray"}
            >
              Where will you receive your order?
            </Typography>
            <Typography
              className={`mt-1 font-normal ${
                theme ? "text-gray-500" : "text-gray-600"
              }`}
            >
              This information will be saved for future purchases.
            </Typography>
            <form className="mt-8 mb-2 w-80 max-w-screen-lg sm:w-96">
              <div className="mb-1 flex flex-col gap-6">
                <Input
                  color={theme ? "white" : undefined}
                  label="Country"
                  size="md"
                  value={country}
                  onChange={() => stateChangeHandler(event, setCountry)}
                />
                <Input
                  color={theme ? "white" : undefined}
                  label="City"
                  size="md"
                  value={city}
                  onChange={() => stateChangeHandler(event, setCity)}
                />
                <Input
                  color={theme ? "white" : undefined}
                  label="Postal Code"
                  size="md"
                  value={postalCode}
                  onChange={() => stateChangeHandler(event, setPostalCode)}
                />
                <Input
                  color={theme ? "white" : undefined}
                  label="Address"
                  size="md"
                  value={address}
                  onChange={() => stateChangeHandler(event, setAddress)}
                />
                <Input
                  color={theme ? "white" : undefined}
                  label="Apartment / Floor"
                  size="md"
                  value={apartment}
                  onChange={() => stateChangeHandler(event, setApartment)}
                />
                <Input
                  color={theme ? "white" : undefined}
                  label="Phone"
                  size="md"
                  value={phone}
                  onChange={() => stateChangeHandler(event, setPhone)}
                />
              </div>
            </form>
          </Card>
        )}
        <Card color="transparent" shadow={false}>
          <Typography
            variant="h4"
            className="font-light"
            color={theme ? "white" : "blue-gray"}
          >
            Credit Card Information
          </Typography>
          <Typography
            color="gray"
            className={`mt-1 font-normal ${
              theme ? "text-gray-500" : "text-gray-600"
            }`}
          >
            This data is encrypted end-to-end.
          </Typography>
          <form className="mt-8 mb-2 w-80 max-w-screen-lg sm:w-96">
            <div className="mb-1 flex flex-col gap-6">
              <Input
                color={theme ? "white" : undefined}
                label="Number"
                type="number"
                size="md"
                value={cardNumber}
                onChange={cardNumberChangeHandler}
              />

              <Input
                type="date"
                color={theme ? "white" : undefined}
                label="Expiration Date"
                size="md"
                value={expirationDate}
                onChange={() => stateChangeHandler(event, setExpirationDate)}
              />
              <Input
                color={theme ? "white" : undefined}
                label="CVV"
                type="number"
                size="md"
                value={cvv}
                onChange={cvvChangeHandler}
              />
            </div>
          </form>
        </Card>
      </div>
      <div className="flex justify-center">
        <Button
          disabled={isProcessingPayment ? true : false}
          color={theme ? "white" : undefined}
          className="my-6 max-w-28"
          fullWidth
          onClick={makePaymentHandler}
        >
          Buy
        </Button>
      </div>
    </div>
  );
};

export default Payment;
