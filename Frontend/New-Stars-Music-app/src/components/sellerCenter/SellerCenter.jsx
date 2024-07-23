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
  Alert,
} from "@material-tailwind/react";
import { useTheme } from "../../services/contexts/ThemeProvider";
import EditProductForm from "./EditProductForm";
import InfoIcon from "../icons/InfoIcon";
import toast from "react-hot-toast";
import LoadingMessage from "../common/LoadingMessage";

const SellerCenter = () => {
  const [isLoadingPage, setIsLoadingPage] = useState(false);
  const [products, setProducts] = useState([]);
  const [selectedProduct, setSelectedProduct] = useState({});
  const { getAccessTokenSilently, isLoading } = useAuth0();
  const [categories, setCategories] = useState([]);
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

    const initialize = async () => {
      setIsLoadingPage(true);
      await fetchProducts();
      await fetchCategories();
      setIsLoadingPage(false);
    };

    initialize();
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
    try {
      if (
        productData.code &&
        productData.name &&
        productData.imageLink &&
        productData.price &&
        productData.price > 0 &&
        productData.artistOrBand &&
        productData.description &&
        productData.stock &&
        productData.stock > 0 &&
        productData.categoryId &&
        productData.categoryId > 0
      ) {
        const response = await api.post("/products", productData);

        if (response.status === 200) {
          console.log("Producto creado/editado exitosamente");
          setProducts((prevProducts) => [...prevProducts, response.data]);
          window.scrollTo(0, 0);
          setProductData({
            code: "",
            name: "",
            artistOrBand: "",
            price: 0,
            description: "",
            stock: 0,
            categoryId: 0,
            imageLink: "",
          });
        } else {
          console.error("Error al crear/editar el producto");
        }
      } else {
        if (productData.price <= 0 || productData.stock <= 0) {
          toast.error("Stock and price must be greater than 0!");
        }
        if (productData.categoryId <= 0) {
          toast.error("A category must be selected!");
        }
        console.error("Completa todos los campos antes de guardar");
      }
    } catch (error) {
      console.error("Error al enviar datos al backend:", error);
    }
  };

  const handleDeleteOrRestoreProduct = async (productId, restore) => {
    try {
      const response = restore
        ? await api.put(`/products/restore/${productId}`)
        : await api.delete(`/products/${productId}`);

      if (response.status === 200) {
        const updatedProducts = [...products];
        const index = updatedProducts.findIndex(
          (existingProduct) => existingProduct.id === productId
        );
        updatedProducts[index].state = restore;
        setProducts(updatedProducts);
        console.log("Producto deleted or restored successfully");
      } else {
        console.error("Error deleting product");
      }
    } catch (error) {
      console.error("Error sending delete request:", error);
    }
  };

  const updateProduct = (product) => {
    const updatedProducts = [...products];
    const index = updatedProducts.findIndex(
      (existingProduct) => existingProduct.id === product.id
    );
    updatedProducts[index] = product;
    setProducts(updatedProducts);
  };

  if (isLoadingPage) return <LoadingMessage message="Loading..." />;

  return (
    <div className="seller-center">
      <Typography variant="h3" className="pt-4 mb-0 mx-8 font-light">
        Seller Center
      </Typography>
      <Typography variant="h4" className="pt-4 mb-4 mx-8 font-light">
        Your Products
      </Typography>
      <Dialog open={open} handler={() => setOpen(false)}>
        <DialogHeader>Edit Product</DialogHeader>
        <DialogBody>
          <EditProductForm
            product={selectedProduct}
            setOpen={setOpen}
            categories={categories}
            updateProduct={updateProduct}
          />
        </DialogBody>
      </Dialog>
      <div className="product-list flex flex-wrap gap-4">
        {products.length > 0 ? (
          products.map((product) => (
            <div
              key={product.id}
              className="product-item flex-1 min-w-[300px] max-w-[calc(25%-1rem)]"
            >
              <ProductCard
                setSelectedProduct={setSelectedProduct}
                setOpen={setOpen}
                product={product}
                isSeller={true}
                handleDeleteOrRestoreProduct={handleDeleteOrRestoreProduct}
                className="my-2"
              />
            </div>
          ))
        ) : (
          <Alert
            className={theme ? "bg-gray-800 mx-6" : "mx-6"}
            icon={<InfoIcon />}
          >
            It appears you haven't published any products yet. Why don't you
            start adding them now with the form below?
          </Alert>
        )}
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
              required
            />
            <Input
              type="text"
              label="Name"
              value={productData.name}
              onChange={(e) =>
                setProductData({ ...productData, name: e.target.value })
              }
              required
            />
            <Input
              type="number"
              label="Price"
              value={productData.price}
              onChange={(e) =>
                setProductData({ ...productData, price: e.target.value })
              }
              required
            />
            <Input
              type="text"
              label="Artist or band"
              value={productData.artistOrBand}
              onChange={(e) =>
                setProductData({ ...productData, artistOrBand: e.target.value })
              }
              required
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
              required
            />
            <Input
              type="number"
              label="Stock"
              value={productData.stock}
              onChange={(e) =>
                setProductData({ ...productData, stock: e.target.value })
              }
              required
            />
            {!categories ? (
              <div>Loading categories...</div>
            ) : (
              <select
                className="text-black"
                value={productData.categoryId}
                onChange={(e) =>
                  setProductData({
                    ...productData,
                    categoryId: parseInt(e.target.value),
                  })
                }
              >
                <option value="0">Select a category</option>
                {categories.map((category) => (
                  <option key={category.id} value={category.id.toString()}>
                    {category.name}
                  </option>
                ))}
              </select>
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
