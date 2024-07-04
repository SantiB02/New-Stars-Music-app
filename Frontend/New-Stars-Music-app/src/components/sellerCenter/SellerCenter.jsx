import { useAuth0 } from "@auth0/auth0-react";
import React, { useEffect, useState } from "react";
import api, { setAuthInterceptor } from "../../api/api";
import { Typography } from "@material-tailwind/react";
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
  }, [isLoading]);

  useEffect(() => {
    const fetchProducts = async () => {
      try {
        const response = await api.get("/products/by-seller");
        const allProducts = response.data;
        setProducts(allProducts);
      } catch (error) {
        console.error("Error fetching all products:", error);
      }
    };
    fetchProducts();
  }, []);

  const handleSubmit = async (e) => {
    e.preventDefault();
    try {
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
      } else {
        console.error("Error al eliminar el producto");
      }
    } catch (error) {
      console.error("Error al enviar solicitud de eliminación:", error);
    }
  };

  useEffect(() => {
    if (!isLoading) {
      setAuthInterceptor(getAccessTokenSilently);
    }
  }, [isLoading]);

  return (
    <div>
      <Typography variant="h1" className="font-light">
        Seller Center
      </Typography>
      {products.map((product) => (
        <div key={product.id} className="w-full ">
          <ProductCard
            product={product}
            isSeller={true}
            handleDeleteProduct={handleDeleteProduct}
            className="my-2"
          />
        </div>
      ))}
      <form onSubmit={handleSubmit}>
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
          placeholder="URL de la imagen"
          value={productData.image}
          onChange={(e) =>
            setProductData({ ...productData, image: e.target.value })
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
        <input
          type="text"
          placeholder="Categoría"
          value={productData.category}
          onChange={(e) =>
            setProductData({ ...productData, category: e.target.value })
          }
        />
        <button type="submit">Guardar producto</button>
      </form>
      <button onClick={() => handleDeleteProduct(productId)}>
        Eliminar producto
      </button>
    </div>
  );
};

export default SellerCenter;
