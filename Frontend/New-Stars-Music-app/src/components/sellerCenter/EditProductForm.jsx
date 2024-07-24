import { Button, Input, Typography } from "@material-tailwind/react";
import React, { useState } from "react";
import { useTheme } from "../../services/contexts/ThemeProvider";
import api from "../../api/api";
import toast from "react-hot-toast";

const EditProductForm = ({ setOpen, product, categories, updateProduct }) => {
  const [name, setName] = useState(product.name);
  const [price, setPrice] = useState(product.price);
  const [stock, setStock] = useState(product.stock);
  const [artistOrBand, setArtistOrBand] = useState(product.artistOrBand);
  const [description, setDescription] = useState(product.description);
  const [selectedCategoryId, setSelectedCategoryId] = useState(
    product.categoryId
  );
  const [imageLink, setImageLink] = useState(product.imageLink);
  const [stockOrPriceError, setStockOrPriceError] = useState(false);
  const [categoryError, setCategoryError] = useState(false);

  const { theme } = useTheme();

  const stateChangeHandler = (e, setState) => {
    setState(e.target.value);
  };

  const updateProductHandler = async () => {
    if (stock <= 0 || price <= 0) {
      setStockOrPriceError(true);
      return;
    } else {
      setStockOrPriceError(false);
    }

    if (selectedCategoryId <= 0) {
      setCategoryError(true);
      return;
    } else {
      setCategoryError(false);
    }

    try {
      const request = {
        id: product.id,
        name,
        price,
        stock,
        artistOrBand,
        description,
        imageLink,
        categoryId: selectedCategoryId,
      };
      await api.put("/products", request);
      updateProduct({ ...request, state: true });
      toast.success("Product updated successfully!");
    } catch (error) {
      toast.error("Error updating product!");
      console.error("Error updating product", error);
    } finally {
      setOpen(false);
    }
  };

  return (
    <div className="flex items-center justify-center">
      <form
        className={
          theme
            ? " bg-primary p-5 w-70 max-w-screen-lg sm:w-96"
            : " p-5 w-70 max-w-screen-lg sm:w-96"
        }
      >
        <div className="mb-1 flex flex-col gap-6">
          <Input
            className={theme ? "text-white" : ""}
            label="Name:"
            size="md"
            value={name}
            onChange={() => stateChangeHandler(event, setName)}
            required
          />
          <Input
            className={theme ? "text-white" : ""}
            label="Description:"
            size="md"
            value={description}
            onChange={() => stateChangeHandler(event, setDescription)}
            required
          />
          <Input
            className={theme ? "text-white" : ""}
            label="Artist/band"
            size="md"
            value={artistOrBand}
            onChange={() => stateChangeHandler(event, setArtistOrBand)}
            required
          />
          {categoryError && (
            <Typography className="-mb-5" color="red">
              A category must be selected!
            </Typography>
          )}
          <select
            className="text-black"
            value={selectedCategoryId}
            onChange={(e) => setSelectedCategoryId(parseInt(e.target.value))}
          >
            <option value="0">Select a category</option>
            {categories.map((category) => (
              <option key={category.id} value={category.id.toString()}>
                {category.name}
              </option>
            ))}
          </select>
          <Input
            className={theme ? "text-white" : ""}
            label="Image Link:"
            size="md"
            value={imageLink}
            onChange={() => stateChangeHandler(event, setImageLink)}
            required
          />
          {stockOrPriceError && (
            <Typography className="-mb-5" color="red">
              Price and stock must be greater than 0!
            </Typography>
          )}
          <Input
            className={theme ? "text-white" : ""}
            label="Price:"
            size="md"
            value={price}
            onChange={() => stateChangeHandler(event, setPrice)}
            required
          />
          <Input
            className={theme ? "text-white" : ""}
            label="Stock:"
            size="md"
            value={stock}
            onChange={() => stateChangeHandler(event, setStock)}
            required
          />
        </div>
        <div className="flex justify-center gap-4 mt-4">
          <div>
            <Button color="red" onClick={() => setOpen(false)}>
              Cancel
            </Button>
          </div>
          <div>
            <Button color="blue" onClick={updateProductHandler}>
              Edit
            </Button>
          </div>
        </div>
      </form>
    </div>
  );
};

export default EditProductForm;
