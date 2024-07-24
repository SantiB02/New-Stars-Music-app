import React, { useEffect, useState } from "react";
import styles from "./Dashboard.module.css";
import { Typography } from "@material-tailwind/react";
import api from "../../api/api";
import toast from "react-hot-toast";
import LoadingMessage from "../common/LoadingMessage";

const ProductsReport = ({ theme }) => {
  const [isLoading, setIsLoading] = useState(false);
  const [isLoadingFilter, setIsLoadingFilter] = useState(false);
  const [noFilterYet, setNoFilterYet] = useState(true);
  const [products, setProducts] = useState([]);
  const [filteredProducts, setFilteredProducts] = useState([]);
  const [categories, setCategories] = useState([]);
  const [countryFilter, setCountryFilter] = useState("");
  const [categoryIdFilter, setCategoryIdFilter] = useState("0");
  const [isDataMissing, setIsDataMissing] = useState(false);

  useEffect(() => {
    const fetchProducts = async () => {
      setIsLoading(true);
      try {
        const response = await api.get("/products");
        const allProducts = response.data;
        setProducts(allProducts);
      } catch (error) {
        toast.error("Error getting all products!");
        console.error("Error fetching all products", error);
      } finally {
        setIsLoading(false);
      }
    };
    const fetchCategories = async () => {
      try {
        const response = await api.get("/products/categories");
        const categories = response.data.url;
        setCategories(categories);
      } catch (error) {
        console.error("Error getting product categories", error);
      }
    };

    fetchProducts();
    fetchCategories();
  }, []);

  const handleProductsFilter = async (e) => {
    e.preventDefault();

    if (countryFilter === "" || categoryIdFilter == 0) {
      setIsDataMissing(true);
      return;
    } else {
      setIsDataMissing(false);
    }
    setIsLoadingFilter(true);
    setNoFilterYet(false);
    try {
      const response = await api.get(
        `/products/country/${countryFilter}/category/${categoryIdFilter}`,
        {
          validateStatus: (status) => {
            return status === 200 || status === 404; // Accept only 200 y 404 as valid responses (to avoid throwing an error)
          },
        }
      );
      if (response.status === 200) {
        const filteredProducts = response.data;
        setFilteredProducts(filteredProducts);
      } else if (response.status === 404) {
        setFilteredProducts([]);
      }
    } catch (error) {
      toast.error("Error filtering products!");
      console.error("Error filtering products", error);
    } finally {
      setIsLoadingFilter(false);
    }
  };

  if (isLoading) return <LoadingMessage message="Loading products..." />;

  return (
    <div>
      {products && products.length > 0 ? (
        <div>
          <Typography
            variant="h4"
            className={theme ? "text-white" : "text-black"}
          >
            Products
          </Typography>
          <table
            className={theme ? styles["data-table-dark"] : styles["data-table"]}
          >
            <thead>
              <tr>
                <th>Name</th>
                <th>Price</th>
                <th>Seller</th>
              </tr>
            </thead>
            <tbody className={theme ? "text-white" : "text-black"}>
              {products.map((product) => (
                <tr key={product.id}>
                  <td>{product.name}</td>
                  <td className={theme ? "text-yellow-700" : ""}>
                    ${product.price} ARS
                  </td>
                  <td>{product.sellerId}</td>
                </tr>
              ))}
            </tbody>
          </table>
        </div>
      ) : (
        "Loading products..."
      )}
      <div className="pt-4">
        <Typography
          variant="h5"
          className={theme ? "text-white mb-4" : "text-black mb-4"}
        >
          Filter products
        </Typography>
        {isDataMissing && (
          <Typography className="text-red-500">
            Please enter a country and select a category!
          </Typography>
        )}
        <form onSubmit={handleProductsFilter}>
          <label
            htmlFor="countryFilter"
            className={theme ? "mr-4 text-white" : "mr-4 text-black"}
          >
            Country:
          </label>
          <input
            id="countryFilter"
            placeholder="Enter a country..."
            className={
              theme
                ? "mr-6 bg-[#292929] mr-4 border-2 border-[#3e3e3e] rounded-lg text-white px-6 py-3 text-base hover:border-[#fff] cursor-pointer transition"
                : "mr-6 bg-gray-50 mr-4 border-2 border-[#3e3e3e] rounded-lg text-black px-6 py-3 text-base hover:border-[#fff] cursor-pointer transition"
            }
            type="text"
            value={countryFilter}
            onChange={(e) => setCountryFilter(e.target.value)}
          />
          <select
            className="text-black pl-2 pr-7 mr-6"
            value={categoryIdFilter}
            onChange={(e) => setCategoryIdFilter(parseInt(e.target.value))}
          >
            <option value="0">Select a category</option>
            {categories.map((category) => (
              <option key={category.id} value={category.id.toString()}>
                {category.name}
              </option>
            ))}
          </select>
          <button
            type="submit"
            className={
              theme
                ? "bg-[#292929] border-2 border-[#3e3e3e] rounded-lg text-white px-6 py-3 text-base hover:border-[#fff] cursor-pointer transition"
                : "bg-gray-50 border-2 border-[#3e3e3e] rounded-lg text-black px-6 py-3 text-base hover:border-[#fff] cursor-pointer transition"
            }
          >
            Search
          </button>
        </form>
        {!isLoadingFilter && !noFilterYet && filteredProducts.length > 0 ? (
          <table
            className={theme ? styles["data-table-dark"] : styles["data-table"]}
          >
            <thead>
              <tr>
                <th>Name</th>
                <th>Price</th>
                <th>Seller</th>
              </tr>
            </thead>
            <tbody className={theme ? "text-white" : "text-black"}>
              {filteredProducts.map((product) => (
                <tr key={product.id}>
                  <td>{product.name}</td>
                  <td className={theme ? "text-yellow-700" : ""}>
                    ${product.price} ARS
                  </td>
                  <td>{product.sellerId}</td>
                </tr>
              ))}
            </tbody>
          </table>
        ) : isLoadingFilter ? (
          <LoadingMessage message="Filtering products..." />
        ) : (
          <Typography
            className={
              theme
                ? "text-center mt-8 italic mr-4 text-white"
                : "text-center mt-8 italic mr-4 text-black"
            }
          >
            No products match this country and category.
          </Typography>
        )}
      </div>
    </div>
  );
};

export default ProductsReport;
