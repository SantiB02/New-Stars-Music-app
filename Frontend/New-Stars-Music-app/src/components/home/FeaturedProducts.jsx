import React, { useEffect, useState } from "react";
import { getAllProducts } from "../../services/productsService";

const FeaturedProducts = () => {
  const [products, setProducts] = useState([]);
  const [isLoading, setIsLoading] = useState(false);

  useEffect(() => {
    const fetchProducts = async () => {
      setIsLoading(true);
      try {
        const allProducts = await getAllProducts();
        console.log("ALL PRODUCTS", allProducts);
        setProducts(allProducts);
      } catch (error) {
        console.error("Error fetching all products:", error);
      } finally {
        setIsLoading(false);
      }
    };

    fetchProducts();
  }, []);

  if (isLoading) {
    return (
      <div className="mt-8">
        <h2 className="text-3xl">Featured Products</h2>
        <p>Loading...</p>
      </div>
    );
  }

  return (
    <div className="mt-8">
      <h2 className="text-3xl">Featured Products</h2>
      <ul className=" flex flex-col mt-4 md:flex-row">
        {products.map((product) => (
          <li
            key={product.id}
            className="flex justify-between px-2 bg-black flex-col items-center mx-2"
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
        ))}
      </ul>
    </div>
  );
};

export default FeaturedProducts;
