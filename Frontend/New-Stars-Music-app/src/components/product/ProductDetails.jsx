import React, { useEffect, useState } from "react";
import { useNavigate, useParams } from "react-router-dom";
import { getProduct } from "../../services/productsService";
import toast from "react-hot-toast";
import LoadingMessage from "../common/LoadingMessage";
import PageNotFound from "../pageNotFound/PageNotFound";
import { useAuth0 } from "@auth0/auth0-react";
import { setAuthInterceptor } from "../../api/api";
import { Typography } from "@material-tailwind/react";
import { useAuthInterceptor } from "../../hooks/useAuthInterceptor";
import { useTheme } from "../../services/contexts/ThemeProvider";
import { useCart } from "../../hooks/useCart";
import dayjs from "dayjs";
const ProductDetails = () => {
  const navigate = useNavigate();
  const { theme } = useTheme();
  const [product, setProduct] = useState(undefined);
  const [isLoadingProduct, setIsLoadingProduct] = useState(false);
  const [productNotFound, setProductNotFound] = useState(false);
  const [isProductInCart, setIsProductInCart] = useState(false);
  const [quantity, setQuantity] = useState(1);

  const { getAccessTokenSilently, isLoading } = useAuth0();
  const { id: productId } = useParams();
  const { addToCart, removeFromCart, cart } = useCart();

  const dateFormat = dayjs(product?.creationDate).format("DD/MM/YYYY");

  const checkProductInCart = (product) => {
    return cart.some((item) => item.id === product.id);
  };

  useEffect(() => {
    if (!isLoading) {
      setAuthInterceptor(getAccessTokenSilently);
    }
  }, [isLoading]);

  const fetchProduct = async (productId) => {
    setIsLoadingProduct(true);

    try {
      const productFromApi = await getProduct(productId);
      setProduct(productFromApi);
      console.log(product);
    } catch (error) {
      toast.error("Error while loading this product!");
      console.error(`Error while fetching product with id ${productId}`);
      setProductNotFound(true);
    } finally {
      setIsLoadingProduct(false);
    }
  };
  useEffect(() => {
    if (checkProductInCart(product)) {
      setIsProductInCart(true);
    } else {
      setIsProductInCart(false);
    }
  }, [cart]);

  useEffect(() => {
    if (productId) {
      fetchProduct(productId);
    }
  }, [productId]);

  if (isLoadingProduct) {
    return <LoadingMessage message="Loading product..." />;
  }

  if (productNotFound) {
    return <PageNotFound />;
  }

  //carrito
  const removeFromCartHandler = () => {
    setQuantity(1);
    removeFromCart(product);
  };
  const increaseQuantityClickHandler = () => {
    if (quantity < 10) {
      setQuantity(quantity + 1);
    }
  };
  const decreaseQuantityClickHandler = () => {
    if (quantity > 1) {
      setQuantity(quantity - 1);
    }
  };

  return (
    <div
      className={`w-full min-h-screen px-10 py-6 ${
        theme ? "bg-[#1f1f23] text-gray-200" : " text-[#2b2b2b]"
      }`}
    >
      {/* HEADER */}
      <div className="mb-6">
        <Typography variant="h2" className="font-bold tracking-tight">
          Product Details
        </Typography>
        <Typography variant="h6" className="opacity-80">
          Take a look before you buy it!
        </Typography>
      </div>

      {/* MAIN GRID */}
      <div className="grid grid-cols-1 lg:grid-cols-2 gap-10">
        {/* LEFT: IMAGE GALLERY */}
        <div>
          {/* MAIN IMAGE */}
          <div
            className="w-[550px] h-[550px] mx-auto rounded-2xl overflow-hidden shadow-[0_8px_30px_rgba(0,0,0,0.12)]
  bg-gradient-to-br from-white to-gray-100 border border-gray-200
  flex items-center justify-center
  "
          >
            <img
              src={product?.imageLink}
              alt={product?.title}
              className="w-full h-full object-contain p-4 transition-transform duration-500 hover:scale-105"
            />
          </div>

          {/* THUMBNAILS */}
          <div className="flex gap-3 mt-4 justify-center">
            {[product?.imageLink, product?.imageLink, product?.imageLink].map(
              (img, index) => (
                <button
                  key={index}
                  className="w-40 h-40 flex items-center justify-center 
        rounded-xl bg-gray-100 border border-gray-200 
        shadow-sm hover:shadow-md transition p-1"
                >
                  <img src={img} className="w-full h-full object-contain" />
                </button>
              )
            )}
          </div>
        </div>

        {/* RIGHT PANEL - PREMIUM PRODUCT INFO */}
        <div className="flex flex-col items-center text-center pt-14 gap-6 w-full">
          {/* ARTIST / CATEGORY */}
          <h3
            className={`uppercase tracking-wider text-sm font-medium 
    ${theme ? "text-gray-400" : "text-gray-500"}`}
          >
            {product?.artistOrBand || "Unknown Artist"}
          </h3>

          {/* TITLE */}
          <h1
            className={`text-3xl font-extrabold leading-tight 
    ${theme ? "text-white" : "text-[#222]"}`}
          >
            {product?.name}
          </h1>

          {/* PRICE */}
          <p className="text-3xl font-bold text-green-600">
            ${product?.price} ARS
          </p>

          {/* DESCRIPTION */}
          <p
            className={`leading-relaxed text-[15px] max-w-xl 
    ${theme ? "text-gray-300" : "text-gray-700"}`}
          >
            {product?.description}
          </p>

          {/* EXTRA INFO */}
          {product?.creationDate && (
            <p className={`${theme ? "text-gray-400" : "text-gray-600"}`}>
              <span className="font-semibold">Launched:</span> {dateFormat}
            </p>
          )}
          {product?.stock && (
            <p className={`${theme ? "text-gray-400" : "text-gray-600"}`}>
              <span className="font-semibold">Stock available:</span>{" "}
              {product.stock}
            </p>
          )}

          {/* QUANTITY SELECTOR */}
          <div className="flex items-center gap-4 mt-4">
            <button
              onClick={decreaseQuantityClickHandler}
              className={`px-3 py-2 text-xl rounded-md transition 
        ${
          theme
            ? "bg-gray-700 hover:bg-gray-600 text-white"
            : "bg-gray-200 hover:bg-gray-300 text-gray-700"
        }`}
            >
              -
            </button>

            <span
              className={`text-xl font-semibold 
      ${theme ? "text-white" : "text-gray-900"}`}
            >
              {quantity}
            </span>

            <button
              onClick={increaseQuantityClickHandler}
              className={`px-3 py-2 text-xl rounded-md transition 
        ${
          theme
            ? "bg-gray-700 hover:bg-gray-600 text-white"
            : "bg-gray-200 hover:bg-gray-300 text-gray-700"
        }`}
            >
              +
            </button>
          </div>

          {/* ADD TO CART BUTTON */}
          <button
            onClick={() =>
              isProductInCart
                ? removeFromCartHandler(product)
                : addToCart({ ...product, quantity })
            }
            className="w-2/4 py-3 mt-6 rounded-lg text-lg font-semibold
      bg-green-600 hover:bg-green-700 text-white shadow-md 
      transition-all duration-200"
          >
            Add to Cart
          </button>
        </div>
      </div>

      {/* CUSTOMER REVIEWS (próximamente) */}
      <div className="mt-12 border-r-2 border-t-2 border-l-2 border-gray-300 p-6 rounded-lg">
        <h2 className="text-2xl font-bold mb-4">Customer Reviews</h2>
        <p className="opacity-70">No reviews yet.</p>
      </div>
    </div>
  );
};

export default ProductDetails;
