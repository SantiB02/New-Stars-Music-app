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
  const [errors, setErrors] = useState({});
  const [imageLink, setImageLink] = useState(product.imageLink);
  const [stockOrPriceError, setStockOrPriceError] = useState(false);
  const [categoryError, setCategoryError] = useState(false);

  const { theme } = useTheme();

  const stateChangeHandler = (e, setState) => {
    setState(e.target.value);
  };
  const validateFields = () => {
    const newErrors = {};

    if (!name.trim()) newErrors.name = "Name is required";
    if (!description.trim()) newErrors.description = "Description is required";
    if (!artistOrBand.trim())
      newErrors.artistOrBand = "Artist/Band is required";
    if (!imageLink.trim()) newErrors.imageLink = "Image link is required";

    if (price <= 0) newErrors.price = "Price must be greater than 0";
    if (stock <= 0) newErrors.stock = "Stock must be greater than 0";
    if (selectedCategoryId <= 0) newErrors.category = "Category is required";

    setErrors(newErrors);
    return Object.keys(newErrors).length === 0;
  };

  const updateProductHandler = async () => {
    if (!validateFields()) return;

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
            onChange={(e) => setName(e.target.value)}
            required
          />
          {errors.name && (
            <Typography
              variant="small"
              color="red"
              className="mt-1 text-xs font-normal"
            >
              {errors.name}
            </Typography>
          )}
          <Input
            className={theme ? "text-white" : ""}
            label="Description:"
            size="md"
            value={description}
            onChange={(d) => setDescription(d.target.value)}
            required
          />
          {errors.description && (
            <Typography
              variant="small"
              color="red"
              className="mt-1 text-xs font-normal"
            >
              {errors.description}
            </Typography>
          )}
          <Input
            className={theme ? "text-white" : ""}
            label="Artist/band"
            size="md"
            value={artistOrBand}
            onChange={(e) => setArtistOrBand(e.target.value)}
            required
          />
          {errors.artistOrBand && (
            <Typography
              variant="small"
              color="red"
              className="mt-1 text-xs font-normal"
            >
              {errors.artistOrBand}
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
          {errors.selectedCategoryId == "0" && (
            <Typography
              variant="small"
              color="red"
              className="mt-1 text-xs font-normal"
            >
              {errors.categories}
            </Typography>
          )}
          <Input
            className={theme ? "text-white" : ""}
            label="Image Link:"
            size="md"
            value={imageLink}
            onChange={(e) => setImageLink(e.target.value)}
            required
          />
          {errors.imageLink && (
            <Typography
              variant="small"
              color="red"
              className="mt-1 text-xs font-normal"
            >
              {errors.imageLink}
            </Typography>
          )}

          <Input
            className={theme ? "text-white" : ""}
            label="Price:"
            size="md"
            value={price}
            onChange={(e) => setPrice(e.target.value)}
            required
          />
          {errors.price && (
            <Typography
              variant="small"
              color="red"
              className="mt-1 text-xs font-normal"
            >
              {errors.price}
            </Typography>
          )}
          <Input
            className={theme ? "text-white" : ""}
            label="Stock:"
            size="md"
            value={stock}
            onChange={(e) => setStock(e.target.value)}
            required
          />
          {errors.stock && (
            <Typography
              variant="small"
              color="red"
              className="mt-1 text-xs font-normal"
            >
              {errors.stock}
            </Typography>
          )}
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
