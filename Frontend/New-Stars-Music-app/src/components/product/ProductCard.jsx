import React, { useEffect, useState } from "react";
import {
  Card,
  CardHeader,
  CardBody,
  CardFooter,
  Typography,
  Button,
} from "@material-tailwind/react";
import { useNavigate } from "react-router-dom";
import { useTheme } from "../../services/contexts/ThemeProvider";
import { MinusIcon, PlusIcon } from "@heroicons/react/20/solid";
import { MinusCircleIcon, PlusCircleIcon } from "@heroicons/react/24/outline";
import { useCart } from "../../hooks/useCart";

const ProductCard = ({ product, isSeller, handleDeleteProduct }) => {
  const [quantity, setQuantity] = useState(1);
  const [isProductInCart, setIsProductInCart] = useState(false);
  const { theme } = useTheme();
  const navigate = useNavigate();
  const { addToCart, removeFromCart, cart } = useCart();

  const checkProductInCart = (product) => {
    return cart.some((item) => item.id === product.id);
  };

  useEffect(() => {
    console.log("CURRENT CART:", cart);
    if (checkProductInCart(product)) {
      setIsProductInCart(true);
    } else {
      setIsProductInCart(false);
    }
  }, [cart]);

  // const clickBuyHandler = () => {
  //   //navigate("/product-details", { state: { productId: product.id } });
  //   navigate(`/product-details/${product.id}`);
  // };

  const decreaseQuantityClickHandler = () => {
    if (quantity > 1) {
      setQuantity(quantity - 1);
    }
  };

  const increaseQuantityClickHandler = () => {
    if (quantity < 10) {
      setQuantity(quantity + 1);
    }
  };

  const removeFromCartHandler = () => {
    setQuantity(1);
    removeFromCart(product);
  };

  return (
    <Card
      className={
        theme
          ? "max-w-72 bg-black text-white ml-5"
          : "max-w-72 bg-gray-400 ml-5"
      }
    >
      <CardHeader shadow={false} floated={false} className="h-40">
        <img
          src={product.imageLink}
          alt="card-image"
          className="h-full w-full object-contain bg-gray-800 "
        />
      </CardHeader>
      <CardBody>
        <div className="mb-2 flex items-center justify-between">
          <Typography
            color={theme ? "white" : "blue-gray"}
            className="font-medium"
          >
            {product.name}
          </Typography>
        </div>
        <div className="mb-2 flex items-center justify-between">
          <Typography
            color={theme ? "white" : "blue-gray"}
            className="font-small"
          >
            {product.description}
          </Typography>
        </div>
        <Typography
          variant="small"
          color={theme ? "white" : "gray"}
          className="font-normal opacity-75"
        >
          Artist/Band: {product.artistOrBand} <br /> ${product.price} ARS
        </Typography>
      </CardBody>
      {!isSeller ? (
        <CardFooter className="pt-0 flex">
          {!isProductInCart && (
            <MinusCircleIcon
              className="cursor-pointer select-none hover:text-orange-800 mr-3"
              color={theme ? "orange" : "black"}
              width={45}
              onClick={decreaseQuantityClickHandler}
            />
          )}

          <Button
            ripple={false}
            fullWidth={true}
            className={
              theme
                ? "bg-gray-50 text-blue-gray-900 shadow-none hover:scale-105 hover:shadow-none focus:scale-105 focus:shadow-none active:scale-100"
                : " shadow-none hover:scale-105 hover:shadow-none focus:scale-105 focus:shadow-none active:scale-100"
            }
            onClick={() =>
              isProductInCart
                ? removeFromCartHandler(product)
                : addToCart({ ...product, quantity })
            }
          >
            {!isProductInCart ? `Add ${quantity} to cart` : `Remove from cart`}
          </Button>
          {!isProductInCart && (
            <PlusCircleIcon
              className="cursor-pointer select-none hover:text-orange-800 ml-3"
              color={theme ? "orange" : "black"}
              width={45}
              onClick={increaseQuantityClickHandler}
            />
          )}
        </CardFooter>
      ) : (
        <CardFooter className="pt-0 flex">
          <Button
            ripple={false}
            fullWidth={true}
            className={
              theme
                ? "mr-2 bg-gray-50 text-blue-gray-900 shadow-none hover:scale-105 hover:shadow-none focus:scale-105 focus:shadow-none active:scale-100"
                : "mr-2  shadow-none hover:scale-105 hover:shadow-none focus:scale-105 focus:shadow-none active:scale-100"
            }
            onClick={() =>
              isProductInCart
                ? removeFromCartHandler(product)
                : addToCart({ ...product, quantity })
            }
          >
            Edit
          </Button>
          <Button
            ripple={false}
            fullWidth={true}
            className={
              theme
                ? "ml-2 bg-red-500 text-black shadow-none hover:scale-105 hover:shadow-none focus:scale-105 focus:shadow-none active:scale-100"
                : "ml-2 shadow-none hover:scale-105 hover:shadow-none focus:scale-105 focus:shadow-none active:scale-100"
            }
            onClick={() => handleDeleteProduct(product.id)}
          >
            Delete
          </Button>
        </CardFooter>
      )}
    </Card>
  );
};

export default ProductCard;
