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

const StoreProducts = ({ products, isLoading, userRole, setProducts }) => {
  const [categories, setCategories] = useState([]);
  const [filteredProducts, setFilteredProducts] = useState(products);
  const [showAllProducts, setShowAllProducts] = useState(true);

  useEffect(() => {
    const fetchCategories = async () => {
      try {
        const response = await api.get("/products/categories");
        const categories = response.data.url;
        console.log(products);
        setCategories(categories);
      } catch (error) {
        console.error("Error getting product categories", error);
      }
    };

    fetchCategories();
  }, []);

  if (isLoading) {
    return (
      <div className="mt-8">
        <p>Loading...</p>
      </div>
    );
  }

  const applyCategoryFilter = (categoryId) => {
    setShowAllProducts(false);
    const filteredProducts = products.filter(
      (product) => product.categoryId === categoryId
    );
    setFilteredProducts(filteredProducts);
  };

  const productsToMap = showAllProducts ? products : filteredProducts;

  return (
    <div>
      <div className="flex justify-center">
        <Card className="w-full bg-gray-800 max-w-[44rem]">
          <List className="flex-row">
            <ListItem onClick={() => setShowAllProducts(true)} className="p-0">
              <label
                htmlFor="allProducts"
                className="flex w-full cursor-pointer items-center px-3 py-2"
              >
                <ListItemPrefix className="mr-3">
                  <Radio
                    defaultChecked={true}
                    name="horizontal-list"
                    id="allProducts"
                    ripple={false}
                    className="hover:before:opacity-0"
                    containerProps={{
                      className: "p-0",
                    }}
                  />
                </ListItemPrefix>
                <Typography className="font-medium text-blue-gray-300">
                  All
                </Typography>
              </label>
            </ListItem>
            {categories.map((category) => (
              <ListItem
                key={category.id}
                onClick={() => applyCategoryFilter(category.id)}
                className="p-0"
              >
                <label
                  htmlFor={category.name}
                  className="flex w-full cursor-pointer items-center px-3 py-2"
                >
                  <ListItemPrefix className="mr-3">
                    <Radio
                      name="horizontal-list"
                      id={category.name}
                      ripple={false}
                      className="hover:before:opacity-0"
                      containerProps={{
                        className: "p-0",
                      }}
                    />
                  </ListItemPrefix>
                  <Typography className="font-medium text-blue-gray-300">
                    {category.name}
                  </Typography>
                </label>
              </ListItem>
            ))}
          </List>
        </Card>
      </div>
      <div className="flex flex-col mt-4 md:flex-row m-10 justify-center">
        {productsToMap.length > 0 ? (
          productsToMap.map((product) => (
            <ProductCard
              isAdmin={userRole === "Admin"}
              key={product.id}
              product={product}
            />
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
