import React, { useEffect, useState } from "react";
import ProductCard from "../product/ProductCard";
import api from "../../api/api";
import {
  Radio,
  Card,
  List,
  ListItem,
  ListItemPrefix,
  Typography,
} from "@material-tailwind/react";
import { useLocation } from "react-router-dom";
import toast from "react-hot-toast";
import { useTheme } from "../../services/contexts/ThemeProvider";

const StoreProducts = ({ products, isLoading, userRole }) => {
  const [categories, setCategories] = useState([]);
  const [artistName, setArtistName] = useState("");
  const [selectedCategory, setSelectedCategory] = useState(null);
  const [filteredProducts, setFilteredProducts] = useState(products);
  const { theme } = useTheme();
  const data = useLocation();
  const dropdownCategoryId = data.state?.categoryId;
  const selectedArtistName = data.state?.artistName;

  const applyFilters = () => {
    let tempProducts = products;

    // Filtrar por categoría
    if (selectedCategory) {
      tempProducts = tempProducts.filter(
        (product) => product.categoryId === selectedCategory
      );
    }

    // Filtrar por nombre de artista
    if (artistName.trim() !== "") {
      tempProducts = tempProducts.filter((product) =>
        product.artistOrBand
          .trim()
          .toLowerCase()
          .includes(artistName.trim().toLowerCase())
      );
    }

    setFilteredProducts(tempProducts);
  };

  useEffect(() => {
    const fetchCategories = async () => {
      try {
        const response = await api.get("/products/categories");
        const categories = response.data.url;
        setCategories(categories);
      } catch (error) {
        console.error("Error getting product categories", error);
      }
    };

    if (dropdownCategoryId && products.length > 0) {
      setSelectedCategory(dropdownCategoryId);
    }

    if (selectedArtistName && products.length > 0) {
      setArtistName(selectedArtistName);
    }
    window.history.replaceState({}, "");
    fetchCategories();
  }, [dropdownCategoryId, products]);

  useEffect(() => {
    applyFilters();
  }, [artistName, selectedCategory, products]);

  const handleArtistFilter = (e) => {
    e.preventDefault();
    if (artistName.trim() === "") {
      toast.error("Artist's name can't be empty!");
      return;
    }
    applyFilters();
  };

  if (isLoading) {
    return (
      <div className="mt-8">
        <p>Loading...</p>
      </div>
    );
  }

  return (
    <div>
      <div className="flex justify-center">
        <Card className="w-full my-2 bg-gray-800 max-w-[44rem]">
          <List className="flex-row">
            <ListItem onClick={() => setSelectedCategory(null)} className="p-0">
              <label
                htmlFor="allProducts"
                className="flex w-full cursor-pointer items-center px-3 py-2"
              >
                <ListItemPrefix className="mr-3">
                  <Radio
                    defaultChecked={dropdownCategoryId ? false : true}
                    name="horizontal-list"
                    id="allProducts"
                    ripple={false}
                    color="orange"
                    className="hover:before:opacity-0"
                    containerProps={{
                      className: "p-0",
                    }}
                  />
                </ListItemPrefix>
                <Typography className="text-sm text-blue-gray-300">
                  All
                </Typography>
              </label>
            </ListItem>
            {categories.map((category) => (
              <ListItem
                key={category.id}
                onClick={() => setSelectedCategory(category.id)}
                className="p-0"
              >
                <label
                  htmlFor={category.name}
                  className="flex w-full cursor-pointer items-center px-0 md:px-3 py-2"
                >
                  <ListItemPrefix className="mr-3">
                    <Radio
                      defaultChecked={dropdownCategoryId === category.id}
                      name="horizontal-list"
                      id={category.name}
                      ripple={false}
                      color="orange"
                      className="hover:before:opacity-0"
                      containerProps={{
                        className: "p-0",
                      }}
                    />
                  </ListItemPrefix>
                  <Typography className="text-sm text-blue-gray-300">
                    {category.name}
                  </Typography>
                </label>
              </ListItem>
            ))}
          </List>
        </Card>
      </div>
      <form className="flex justify-center my-4" onSubmit={handleArtistFilter}>
        <input
          placeholder="Search by artist..."
          className={
            theme
              ? "bg-[#292929] mr-4 border-2 border-[#3e3e3e] rounded-lg text-white px-6 py-3 text-base hover:border-[#fff] cursor-pointer transition"
              : "bg-gray-50 mr-4 border-2 border-[#3e3e3e] rounded-lg text-black px-6 py-3 text-base hover:border-[#fff] cursor-pointer transition"
          }
          type="text"
          value={artistName}
          onChange={(e) => setArtistName(e.target.value)}
        />
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
        <button
          type="button"
          onClick={() => setArtistName("")}
          className={
            theme
              ? "ml-4 bg-[#292929] border-2 border-[#3e3e3e] rounded-lg text-white px-6 py-3 text-base hover:border-[#fff] cursor-pointer transition"
              : "ml-4 bg-gray-50 border-2 border-[#3e3e3e] rounded-lg text-black px-6 py-3 text-base hover:border-[#fff] cursor-pointer transition"
          }
        >
          Clear
        </button>
      </form>
      <div className="flex flex-wrap mt-4 justify-center">
        {filteredProducts.length > 0 ? (
          filteredProducts.map((product) => (
            <div
              key={product.id}
              className="w-full sm:w-1/2 lg:w-1/3 xl:w-1/4 p-4"
            >
              <ProductCard isAdmin={userRole === "Admin"} product={product} />
            </div>
          ))
        ) : (
          <Typography className="text-md mt-10">
            There aren't any products in this category. Try again later!
          </Typography>
        )}
      </div>
    </div>
  );
};

export default StoreProducts;
