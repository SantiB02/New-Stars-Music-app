import { useAuth0 } from "@auth0/auth0-react";
import React, { useEffect, useState } from "react";
import api, { setAuthInterceptor } from "../../api/api";

const SellerCenter = () => {
  const { getAccessTokenSilently, isLoading } = useAuth0();

  // Estado para almacenar los datos del producto
  const [productData, setProductData] = useState({
    name: "",
    image: "",
    color: "",
    size: "", 
    description: "", 
    stock: 0, 
    category: "", 
  });

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
        // Lógica para enviar los datos al backend (crear o editar)
        
        const response = await api.post("/productos", productData); //enrutar

        if (response.status === 200) {
          console.log("Producto creado/editado exitosamente");
          // (redireccionar, actualizar estado, etc.)
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
  // Función para eliminar un producto
  const handleDeleteProduct = async (productId) => {
    try {
      const response = await api.delete(`/productos/${productId}`); //enrutar

      if (response.status === 200) {
        console.log("Producto eliminado exitosamente");
        // (actualizar estado, recargar la lista, etc.)
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
      <h1>Seller Center</h1>
      <form onSubmit={handleSubmit}>
        <input
          type="text"
          placeholder="Nombre del producto"
          value={productData.name}
          onChange={(e) =>
            setProductData({ ...productData, name: e.target.value })
          }
        />
        {/* Agregar campos adicionales */}
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