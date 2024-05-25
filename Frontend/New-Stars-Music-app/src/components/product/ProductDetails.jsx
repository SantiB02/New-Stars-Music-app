import React, { useState } from "react";
import { useLocation, useNavigate } from "react-router-dom";
import { getProduct } from "../../services/productsService";
import toast from "react-hot-toast";

const ProductDetails = () => {
  const navigate = useNavigate();
  const { state } = useLocation();
  const { productId } = state;
  const [product, setProduct] = useState(undefined);

  const fetchProduct = async (productId) => {
    try {
      const productFromApi = await getProduct(productId);
      setProduct(productFromApi);
    } catch (error) {
      toast.error("Error while loading this product!");
    }
  };

  return (
    <div>
      <h1>Product details</h1>
      <h2>Take a look before you buy it!</h2>
    </div>
  );
};

export default ProductDetails;
