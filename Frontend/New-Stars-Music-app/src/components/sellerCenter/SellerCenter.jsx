import { useAuth0 } from "@auth0/auth0-react";
import React, { useEffect, useState } from "react";
import axios from "axios";
import api, { setAuthInterceptor } from "../../api/api";
import ProductCard from "../product/ProductCard";
import {
  Typography,
  Button,
  Dialog,
  DialogHeader,
  DialogBody,
  DialogFooter,
} from "@material-tailwind/react";

const SellerCenter = () => {
  const [products, setProducts] = useState([]);
  const { getAccessTokenSilently, isLoading } = useAuth0();
  const [file, setFile] = useState(null);
  const [categories, setCategories] = useState([]);
  const [productData, setProductData] = useState({
    name: "",
    image: "",
    color: "",
    size: "",
    description: "",
    stock: 0,
    category: "",
  });

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
    try {
      if (file) {
        const imageUrl = await handleImageUpload();
        setProductData((prevData) => ({
          ...prevData,
          image: imageUrl,
        }));
      }

      if (
        productData.name &&
        productData.image &&
        productData.color &&
        productData.size &&
        productData.description &&
        productData.stock &&
        productData.category
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
      <Typography variant="h1" className="font-light">
        Seller Center
      </Typography>
      <div className="product-list">
        {products.map((product) => (
          <div key={product.id} className="product-item">
            <ProductCard
              product={product}
              isSeller={true}
              handleDeleteProduct={handleDeleteProduct}
              className="my-2"
            />
          </div>
        ))}
      </div>
      <form onSubmit={handleSubmit} className="product-form">
        <input
          type="text"
          placeholder="Nombre del producto"
          value={productData.name}
          onChange={(e) =>
            setProductData({ ...productData, name: e.target.value })
          }
        />
        <input
          type="text"
          placeholder="Color"
          value={productData.color}
          onChange={(e) =>
            setProductData({ ...productData, color: e.target.value })
          }
        />
        <input
          type="text"
          placeholder="Talle"
          value={productData.size}
          onChange={(e) =>
            setProductData({ ...productData, size: e.target.value })
          }
        />
        <input
          type="text"
          placeholder="Descripción"
          value={productData.description}
          onChange={(e) =>
            setProductData({ ...productData, description: e.target.value })
          }
        />
        <input
          type="number"
          placeholder="Stock"
          value={productData.stock}
          onChange={(e) =>
            setProductData({ ...productData, stock: e.target.value })
          }
        />
{!categories ? (
  <div>Loading categories...</div>
) : (
  <select
    value={productData.category}
    onChange={(e) =>
      setProductData({ ...productData, category: e.target.value })
    }
  >
    <option value="">Select a category</option>
    {categories.map((category) => (
      <option key={category.id} value={category.name}>
        {category.name}
      </option>
    ))}
  </select>
)}
        <input
          type="file"
          accept="image/*"
          onChange={(e) => setFile(e.target.files[0])}
          required
        />
        <button type="submit">Guardar producto</button>
      </form>
    </div>
  );
};

export default SellerCenter;
