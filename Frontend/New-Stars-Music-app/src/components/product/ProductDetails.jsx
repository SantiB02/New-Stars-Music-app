import React, { useEffect, useState } from "react";
import { useLocation, useNavigate, useParams } from "react-router-dom";
import { getProduct } from "../../services/productsService";
import toast from "react-hot-toast";
import NewStarsForm from "../common/NewStarsForm";
import NewStarsInput from "../common/NewStarsInput";
import LoadingMessage from "../common/LoadingMessage";

const ProductDetails = () => {
  const navigate = useNavigate();
  const [product, setProduct] = useState(undefined);
  const [username, setUsername] = useState("");
  const [isLoading, setIsLoading] = useState(false);

  const { productId } = useParams();

  const handleUsernameChange = (e) => {
    setUsername(e.target.value);
  };

  const fetchProduct = async (productId) => {
    setIsLoading(true);
    try {
      const productFromApi = await getProduct(productId);
      setProduct(productFromApi);
    } catch (error) {
      toast.error("Error while loading this product!");
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

  return (
    // <div>
    //   <h1>Product details</h1>
    //   <h2>Take a look before you buy it!</h2>
    //   <div>
    //     <img src={product.imageLink} alt="Selected product" />
    //     <p>{product.title}</p>
    //     <p>
    //       Artist: <span>{product.artist}</span>
    //     </p>
    //     {product.launchYear && (
    //       <p>
    //         Launched on <span>{product.launchYear}</span>
    //       </p>
    //     )}
    //     <p>{product.description}</p>
    //   </div>
    // </div>
    <div>
      <h1>Product details</h1>
      <h2>Take a look before you buy it!</h2>
      <div>
        <img
          src="../../../public/Flo_Rida_-Wild_Ones.jpg"
          alt="Selected product"
        />
        <p>'Wild Ones' CD</p>
        <p>
          Artist: <span>Flo Rida</span>
        </p>

        <p>
          Launched on <span>2012</span>
        </p>

        <p>Best hits from Flo Rida's 2012 album 'Wild Ones'!</p>
      </div>
      <NewStarsForm buttonText="Save">
        <NewStarsInput
          value={username}
          onChange={handleUsernameChange}
          placeholder="Your username"
          label="Username (TEST para que vean cómo vamos a usar los forms):"
          name="username"
        />
      </NewStarsForm>
    </div>
  );
};

export default ProductDetails;
