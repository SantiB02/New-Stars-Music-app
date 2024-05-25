import React, { useEffect, useState } from "react";
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

  useEffect(() => {
    fetchProduct(productId); //fetch product when view is rendered
  }, []);

  return (
    <div>
      <h1>Product details</h1>
      <h2>Take a look before you buy it!</h2>
      <div>
        <img src={product.imageLink} alt="Selected product" />
        <p>{product.title}</p>
        <p>
          Artist: <span>{product.artist}</span>
        </p>
        {product.launchYear && (
          <p>
            Launched on <span>{product.launchYear}</span>
          </p>
        )}
        <p>{product.description}</p>
      </div>
    </div>
  );
};

export default ProductDetails;
