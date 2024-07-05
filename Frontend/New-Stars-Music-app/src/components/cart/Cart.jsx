import React from "react";
import { useCart } from "../../hooks/useCart";
import { useTheme } from "../../services/contexts/ThemeProvider";
import { useNavigate } from "react-router";
import {
  Card,
  CardBody,
  Typography,
  CardHeader,
  Button,
  CardFooter,
} from "@material-tailwind/react";

export const Cart = () => {
  const { cart, cartTotal, removeFromCart } = useCart();
  const { theme } = useTheme();
  const navigate = useNavigate();

  const onRemoveProductHandler = (cartProduct) => {
    console.log(cartProduct);
    removeFromCart(cartProduct);
  };
  const navigateHandler = (path) => {
    navigate(path);
  };

  return (
    <>
      {cart.length === 0 ? (
        <>
          <div className=" pt-10 text-center">
            <div className="pt-10 pb-10">
              <Typography variant="h2">
                Your cart is empty, you can be redirected to the store
                <br /> by pressing the following button:
              </Typography>
            </div>
            <div className="pt-10">
              <Button
                color="green"
                ripple={false}
                onClick={() => navigateHandler("/store")}
              >
                Store
              </Button>
            </div>
            <div></div>
          </div>
        </>
      ) : (
        <>
          <div className="container mx-auto px-4 py-4">
            <div className="p-4 pb-6">
              <Typography variant="h2" className="font-light">
                Your Cart
              </Typography>
              <Typography variant="h3" className="mb-4 font-light">
                Total:{" "}
                <span className="text-orange-600">
                  ${cartTotal.toFixed(2)} ARS
                </span>
              </Typography>
              <div className="flex items-center">
                <Typography variant="h5" className="font-light ">
                  By clicking on the following button you will proceed to the
                  payment screen:
                </Typography>
                <div className=" flex pl-4">
                  <Button
                    color="green"
                    onClick={() => navigateHandler("/payment")}
                  >
                    BUY
                  </Button>
                </div>
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
                  <CardHeader className=" h-40 object-contain ">
                    <img
                      src={cart.imageLink}
                      className={theme ? "bg-white" : "bg-gray-700"}
                    />
                  </CardHeader>
                  <CardBody>
                    <Typography>{cart.description}</Typography>
                    <Typography>Quantity: {cart.quantity}</Typography>
                    <Typography>
                      <b>Unit price: </b>${cart.price} ARS
                    </Typography>
                    <Typography>
                      <b>Total price: </b> ${cart.price * cart.quantity} ARS
                    </Typography>
                  </CardBody>
                  <CardFooter className="mt-2 flex justify-center">
                    <Button
                      color="red"
                      onClick={() => onRemoveProductHandler(cart)}
                    >
                      Delete Product
                    </Button>
                  </CardFooter>
                </Card>
              ))}
            </div>
          </div>
        </>
      )}
    </>
  );
};
