import { useAuth0 } from "@auth0/auth0-react";
import React, { useEffect, useState } from "react";
import axios from "axios";
import api, { setAuthInterceptor } from "../../api/api";
import ProductCard from "../product/ProductCard";
import {
  Typography,
  Input,
  Button,
  Dialog,
  DialogHeader,
  DialogBody,
  DialogFooter,
  Select,
  Option,
  Card,
} from "@material-tailwind/react";
import { useTheme } from "../../services/contexts/ThemeProvider";
import EditProductForm from "./EditProductForm";

const SellerCenter = () => {
  const [products, setProducts] = useState([]);
  const { getAccessTokenSilently, isLoading } = useAuth0();
  const [categories, setCategories] = useState([]);
  const [selectedCategoryId, setSelectedCategoryId] = useState(0);
  const [productData, setProductData] = useState({
    code: "",
    name: "",
    artistOrBand: "",
    price: 0,
    description: "",
    stock: 0,
    categoryId: 0,
    imageLink: "",
  });
  const [open, setOpen] = useState(false);
  const [productSelected, setProductSelected] = useState([]);
  const { theme } = useTheme();

  useEffect(() => {
    if (!isLoading) {
      setAuthInterceptor(getAccessTokenSilently);
    }
  }, [isLoading, getAccessTokenSilently]);

  useEffect(() => {
    const fetchProducts = async () => {
      try {
        const response = await api.get("/products/by-seller");
        setProducts(response.data);
      } catch (error) {
        console.error("Error fetching products:", error);
      }
    };
    const fetchCategories = async () => {
      try {
        const response = await api.get("/products/categories");
        setCategories(response.data.url);
      } catch (error) {
        console.error("Error fetching products:", error);
      }
    };
    fetchProducts();
    fetchCategories();
  }, []);

  const handleImageUpload = async () => {
    const formData = new FormData();
    formData.append("file", file);

    try {
      const token = await getAccessTokenSilently();
      const response = await api.post("/products/upload", formData, {
        headers: {
          Authorization: `Bearer ${token}`,
          "Content-Type": "multipart/form-data",
        },
      });
      return response.data.url;
    } catch (error) {
      console.error("Error uploading image:", error);
      throw error;
    }
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    productData.categoryId = selectedCategoryId;
    try {
      if (
        productData.code &&
        productData.name &&
        productData.imageLink &&
        productData.price &&
        productData.artistOrBand &&
        productData.description &&
        productData.stock &&
        productData.categoryId
      ) {
        const response = await api.post("/products", productData);

        if (response.status === 200) {
          console.log("Producto creado/editado exitosamente");
          setProducts((prevProducts) => [...prevProducts, response.data]);
        } else {
          console.error("Error al crear/editar el producto");
        }
      } else {
        console.error("Completa todos los campos antes de guardar");
      }
    } catch (error) {
      console.error("Error al enviar datos al backend:", error);
    }
  };

  const handleDeleteProduct = async (productId) => {
    try {
      const response = await api.delete(`/products/${productId}`);

      if (response.status === 200) {
        console.log("Producto eliminado exitosamente");
        setProducts((prevProducts) =>
          prevProducts.filter((product) => product.id !== productId)
        );
      } else {
        console.error("Error al eliminar el producto");
      }
    } catch (error) {
      console.error("Error al enviar solicitud de eliminación:", error);
    }
  };

  return (
    <div className="seller-center">
      <Typography variant="h3" className="pt-4 mb-4 mx-8 font-light">
        Seller Center
      </Typography>
      <Dialog open={open} handler={() => setOpen(false)}>
        <DialogHeader>Edit Product</DialogHeader>
        <DialogBody>
          <EditProductForm product={productSelected} setOpen={setOpen} />
        </DialogBody>
      </Dialog>
      <div className="product-list flex flex-wrap gap-4">
        {products.map((product) => (
          <div
            key={product.id}
            className="product-item flex-1 min-w-[300px] max-w-[calc(25%-1rem)]"
          >
            <ProductCard
              setProductSelected={setProductSelected}
              setOpen={setOpen}
              product={product}
              isSeller={true}
              handleDeleteProduct={handleDeleteProduct}
              className="my-2"
            />
          </div>
        ))}
      </div>
      <div
        className={
          theme
            ? "flex items-center justify-center mt-16 pb-16 "
            : "flex items-center justify-center pt-16 pb-16 bg-gray-200"
        }
      >
        <div
          className={
            theme
              ? " shadow-lg rounded-lg p-8 border-2 border-gray-700  max-w-2xl"
              : " shadow-lg rounded-lg p-8 border-2 border-blue-200 max-w-2xl bg-white text-black"
          }
        >
          <Typography variant="h4">New product</Typography>
          <form
            onSubmit={handleSubmit}
            className={
              theme
                ? "flex flex-col gap-y-6 bg-primary p-5 w-70 max-w-screen-lg sm:w-96"
                : "flex flex-col gap-y-6 p-5 w-70 max-w-screen-lg sm:w-96"
            }
          >
            <Input
              type="text"
              label="Code"
              value={productData.code}
              onChange={(e) =>
                setProductData({ ...productData, code: e.target.value })
              }
            />
            <Input
              type="text"
              label="Name"
              value={productData.name}
              onChange={(e) =>
                setProductData({ ...productData, name: e.target.value })
              }
            />
            <Input
              type="number"
              label="Price"
              value={productData.price}
              onChange={(e) =>
                setProductData({ ...productData, price: e.target.value })
              }
            />
            <Input
              type="text"
              label="Artist or band"
              value={productData.artistOrBand}
              onChange={(e) =>
                setProductData({ ...productData, artistOrBand: e.target.value })
              }
            />
            <Input
              type="text"
              label="Description"
              value={productData.description}
              onChange={(e) =>
                setProductData({
                  ...productData,
                  description: e.target.value,
                })
              }
            />
            <Input
              type="number"
              label="Stock"
              value={productData.stock}
              onChange={(e) =>
                setProductData({ ...productData, stock: e.target.value })
              }
            />
            {!categories ? (
              <div>Loading categories...</div>
            ) : (
              <Select
                label="Select Category"
                value={selectedCategoryId.toString()}
                onChange={(val) => setSelectedCategoryId(val)}
              >
                <Option value="">Select a category</Option>
                {categories.map((category) => (
                  <Option key={category.id} value={category.id.toString()}>
                    {category.name}
                  </Option>
                ))}
              </Select>
            )}
            <Input
              type="text"
              label="Image link"
              value={productData.imageLink}
              onChange={(e) =>
                setProductData({ ...productData, imageLink: e.target.value })
              }
              required
            />
            <div className="flex justify-center pt-4">
              <Button type="submit" color="orange">
                load product
              </Button>
            </div>
          </form>
        </div>
      </div>
    </div>
  );
};

export default SellerCenter;
