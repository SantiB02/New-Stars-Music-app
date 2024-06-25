import React, { useEffect, useState } from "react";
import { useNavigate, useParams } from "react-router-dom";
import { getProduct } from "../../services/productsService";
import toast from "react-hot-toast";
import LoadingMessage from "../common/LoadingMessage";
import PageNotFound from "../pageNotFound/PageNotFound";

const ProductDetails = () => {
  const navigate = useNavigate();
  const [product, setProduct] = useState(undefined);
  const [isLoading, setIsLoading] = useState(false);
  const [productNotFound, setProductNotFound] = useState(false);

  const { productId } = useParams();

  const fetchProduct = async (productId) => {
    setIsLoading(true);
    try {
      const productFromApi = await getProduct(productId);
      setProduct(productFromApi);
      console.log("SUCCESS");
    } catch (error) {
      toast.error("Error while loading this product!");
      console.log("ERROR");
      setProductNotFound(true);
    } finally {
      setIsLoading(false);
    }
  };

  useEffect(() => {
    fetchProduct(productId); //fetch product when view is rendered
  }, []);

  if (isLoading) {
    return <LoadingMessage message="Loading product..." />;
  }

  if (productNotFound) {
    return <PageNotFound />;
  }

  return (
    <div>
      <h1>Product details</h1>
      <h2>Take a look before you buy it!</h2>
      <div>
        <img src={product?.imageLink} alt="Selected product" />
        <p>{product?.title}</p>
        <p>
          Artist: <span>{product?.artist}</span>
        </p>
        {product?.launchYear && (
          <p>
            Launched on <span>{product?.launchYear}</span>
          </p>
        )}
        <p>{product?.description}</p>
      </div>
    </div>
  );
};

export default ProductDetails;
