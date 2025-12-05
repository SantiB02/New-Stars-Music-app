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
import { IoIosAdd, IoIosClose } from "react-icons/io";
import toast from "react-hot-toast";
import LoadingMessage from "../common/LoadingMessage";
import Pagination from "../navigator/Pagination";

const SellerCenter = () => {
  const [isLoadingPage, setIsLoadingPage] = useState(false);
  const [deletingOrRestoringProductId, setDeletingOrRestoringProductId] =
    useState(null);
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
  const [openNewProductForm, setOpenNewProductForm] = useState(false);
  const [currentPage, setCurrentPage] = useState(1);
  const itemsPerPage = 4;

  const { theme } = useTheme();

  const totalPages = Math.ceil(products.length / itemsPerPage) || 1;

  const start = (currentPage - 1) * itemsPerPage;
  const end = start + itemsPerPage;
  const paginatedProducts = products.slice(start, end);

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
  useEffect(() => {
    console.log("categoryId seleccionado:", productData.categoryId);
  }, [productData.categoryId]);

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
    setDeletingOrRestoringProductId(productId);
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
        setDeletingOrRestoringProductId(null);
        console.log("Product deleted or restored successfully");
      } else {
        console.error("Error deleting product");
      }
    } catch (error) {
      console.error("Error sending delete request:", error);
    } finally {
      setIsDeletingOrRestoring(false);
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
      <div className="flex justify-between items-center w-full px-8 pt-4 mb-4">
        {/* TITLES */}
        <div>
          <Typography variant="h3" className="mb-0 font-light">
            Seller Center
          </Typography>
          <Typography variant="h4" className="font-light">
            Your Products
          </Typography>
        </div>

        {/* BUTTON */}
        <Button
          className="flex items-center gap-2"
          color={openNewProductForm ? "orange" : "green"}
          onClick={() => setOpenNewProductForm(!openNewProductForm)}
        >
          {openNewProductForm ? (
            <>
              <IoIosClose size={28} /> Close form
            </>
          ) : (
            <>
              <IoIosAdd size={28} /> Add New Product
            </>
          )}
        </Button>
      </div>
      {/* <Button>Add New product</Button> */}
      <Dialog
        className={theme ? "bg-primary" : "bg-white"}
        open={open}
        handler={() => setOpen(false)}
      >
        <DialogHeader className={theme ? "text-white" : ""}>
          Edit Product
        </DialogHeader>
        <DialogBody>
          <EditProductForm
            product={selectedProduct}
            setOpen={setOpen}
            categories={categories}
            updateProduct={updateProduct}
          />
        </DialogBody>
      </Dialog>
      <div className="flex flex-wrap mt-4 justify-center">
        {paginatedProducts.length > 0 ? (
          paginatedProducts.map((product) => (
            <>
              <div
                key={product.id}
                className="w-full sm:w-1/2 lg:w-1/3 xl:w-1/4 p-4"
              >
                <ProductCard
                  setSelectedProduct={setSelectedProduct}
                  setOpen={setOpen}
                  product={product}
                  isSeller={true}
                  handleDeleteOrRestoreProduct={handleDeleteOrRestoreProduct}
                  deletingOrRestoringProductId={deletingOrRestoringProductId}
                />
              </div>
            </>
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

      <div className="flex justify-center mt-4">
        <Pagination
          active={currentPage}
          totalPages={totalPages}
          onChange={setCurrentPage}
        />
      </div>

      <div
        className={
          theme
            ? "flex items-center justify-center mt-16 pb-16 "
            : "flex items-center justify-center pt-16 pb-16 bg-gray-200"
        }
      >
        {openNewProductForm && (
          <div
            className={
              theme
                ? " shadow-lg rounded-lg p-8 border-2 border-gray-700  max-w-2xl bg-primary"
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
                className={theme ? "text-white" : ""}
                type="text"
                label="Code"
                value={productData.code}
                onChange={(e) =>
                  setProductData({ ...productData, code: e.target.value })
                }
                required
              />
              <Input
                className={theme ? "text-white" : ""}
                type="text"
                label="Name"
                value={productData.name}
                onChange={(e) =>
                  setProductData({ ...productData, name: e.target.value })
                }
                required
              />
              <Input
                className={theme ? "text-white" : ""}
                type="number"
                label="Price"
                value={productData.price}
                onChange={(e) =>
                  setProductData({ ...productData, price: e.target.value })
                }
                required
              />
              <Input
                className={theme ? "text-white" : ""}
                type="text"
                label="Artist or band"
                value={productData.artistOrBand}
                onChange={(e) =>
                  setProductData({
                    ...productData,
                    artistOrBand: e.target.value,
                  })
                }
                required
              />
              <Input
                className={theme ? "text-white" : ""}
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
                className={theme ? "text-white" : ""}
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
                <Select
                  label="Category"
                  className={theme ? "text-white" : ""}
                  value={productData.categoryId.toString() ?? "0"}
                  onChange={(value) =>
                    setProductData({
                      ...productData,
                      categoryId: value, // <- MANTENERLO EN STRING
                    })
                  }
                >
                  <Option value="0">Select a category</Option>
                  {categories.map((category) => (
                    <Option key={category.id} value={category.id.toString()}>
                      {category.name}
                    </Option>
                  ))}
                </Select>
              )}
              <Input
                className={theme ? "text-white" : ""}
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
        )}
      </div>
    </div>
  );
};

export default SellerCenter;
