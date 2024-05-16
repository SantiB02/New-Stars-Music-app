import React from "react";

const ProductCard = ({ product }) => {
  return (
    <li
      key={product.id}
      className="flex justify-between rounded-xl px-2 bg-black flex-col items-center mx-2"
    >
      <img
        className="max-w-20 mt-4"
        src={product.imageURL}
        alt="product image"
      />
      <div className="flex flex-col items-center">
        <p className="font-bold text-center my-2">{product.title}</p>
        <p className="text-center">{product.description}</p>
        <p>
          <span className="font-medium">Artist:</span> {product.artist}
        </p>
        <p>
          <span className="font-medium">Year:</span> {product.launchYear}
        </p>

        <button className="my-4 bg-secondary transition hover:bg-orange-600 text-white font-bold py-2 px-4 rounded">
          BUY
        </button>
      </div>
    </li>
  );
};

export default ProductCard;
