import React from "react";
import { useNavigate } from "react-router-dom";

const ProductCard = ({ product }) => {
  const navigate = useNavigate();

  const clickBuyHandler = () => {
    //navigate("/product-details", { state: { productId: product.id } });
    navigate(`/product-details/${product.id}`);
  };

  return (
    <li
      key={product.id}
      className="flex justify-between rounded-xl px-2 bg-black flex-col items-center mx-2"
    >
      <img
        className="max-w-20 mt-4"
        src={product.imageLink}
        alt="product image"
      />
      <div className="flex flex-col items-center">
        <p className="font-bold text-center my-2">{product.name}</p>
        <p className="text-center">{product.description}</p>
        <p>
          <span className="font-medium">Artist/Band:</span> {product.artist}
        </p>
        <p>
          <span className="font-medium">$</span> {product.price}
        </p>

        <button
          onClick={clickBuyHandler}
          className="my-4 bg-secondary transition hover:bg-orange-600 text-white font-bold py-2 px-4 rounded"
        >
          BUY
        </button>
      </div>
    </li>
  );
};

export default ProductCard;
