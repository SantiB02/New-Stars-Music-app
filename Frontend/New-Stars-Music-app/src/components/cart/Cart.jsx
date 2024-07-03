import React from "react";
import { useCart } from "../../hooks/useCart";
import { useTheme } from "../../services/contexts/ThemeProvider";

import {
  Card,
  CardBody,
  Typography,
  CardHeader,
  Button,
  CardFooter,
} from "@material-tailwind/react";

export const Cart = () => {
  const { cart, removeFromCart } = useCart();
  const { theme } = useTheme();

  const onRemoveProductHandler = (product) => {
    console.log("proximamente removido");
    removeFromCart(product);
  };

  return (
    <div className="container mx-auto px-4 py-8">
      <div className=" flex p-4 pb-6">
        <Typography variant="h5">
          By clicking on the following button you will proceed to continue with
          the payment of the cart:
        </Typography>
        <div className=" flex pl-4">
          <Button color="green"> BUY </Button>
        </div>
      </div>
      <div className="grid grid-cols-1 sm:grid-cols-2 lg:grid-cols-4 gap-4">
        {cart.map((cart) => (
          <Card
            className={
              theme
                ? "pt-10 h-full w-full h-86 bg-black text-gray-200"
                : "pt-10 w-full h-86 "
            }
            key={cart.id}
          >
            <CardHeader className=" h-40 object-cover ">
              <img
                src={cart.imageLink}
                className={theme ? "bg-white" : "bg-gray-700"}
              />
            </CardHeader>
            <CardBody>
              <Typography>{cart.description}</Typography>
              <Typography>{cart.quantity}</Typography>
              <Typography>
                <b>Price unit:</b>${cart.price}
              </Typography>
              <Typography>
                <b>Price total:</b> ${cart.price * cart.quantity}
              </Typography>
            </CardBody>
            <CardFooter className="mt-2 flex justify-center">
              <Button
                color="red"
                onClick={() => onRemoveProductHandler(cart.id)}
              >
                Delete Product
              </Button>
            </CardFooter>
          </Card>
        ))}
      </div>
    </div>
  );
};
