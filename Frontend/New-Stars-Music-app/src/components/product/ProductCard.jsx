import React from "react";
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

const ProductCard = ({ product }) => {
  const { theme } = useTheme();
  const navigate = useNavigate();

  const clickBuyHandler = () => {
    //navigate("/product-details", { state: { productId: product.id } });
    navigate(`/product-details/${product.id}`);
  };

  return (
    <Card className={theme ? "w-35 bg-black text-white ml-5" : "w-35 bg-gray-400 ml-5"}>
      <CardHeader shadow={false} floated={false} className="h-20">
        <img
          src={product.imageLink}
          alt="card-image"
          className="h-full w-full object-cover bg-gray-800"
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
          <Typography color={theme ? "white" : "blue-gray"} className="font-small">
            {product.description}
          </Typography>
        </div>
        <Typography
          variant="small"
          color={theme ? "white" : "gray"}
          className="font-normal opacity-75"
        >
          Artist/Band:{product.artist} <br /> ${product.price}
        </Typography>
      </CardBody>
      <CardFooter className="pt-0">
        <Button
          ripple={false}
          fullWidth={true}
          className={
            theme
              ? "bg-gray-50 text-blue-gray-900 shadow-none hover:scale-105 hover:shadow-none focus:scale-105 focus:shadow-none active:scale-100"
              : " shadow-none hover:scale-105 hover:shadow-none focus:scale-105 focus:shadow-none active:scale-100"
          }
          onClick={clickBuyHandler}
        >
          Add to Cart
        </Button>
      </CardFooter>
    </Card>
  );
};

export default ProductCard;
