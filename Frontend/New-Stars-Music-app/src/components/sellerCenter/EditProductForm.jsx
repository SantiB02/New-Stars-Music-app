import { Button, Input } from "@material-tailwind/react";
import React, { useState } from "react";
import { useTheme } from "../../services/contexts/ThemeProvider";
import toast from "react-hot-toast/headless";
import api from "../../api/api";

const EditProductForm = ({ setOpen, product }) => {
  const [nameProduct, setNamePoduct] = useState(product.name);
  const [price, setPrice] = useState(product.price);
  const [ArtistOrBand, setArtistOrBand] = useState(product.artistOrBand);
  const [description, setDescription] = useState(product.description);
  const [imageUrl, setImageUrl] = useState(product.imageLink);

  const { theme } = useTheme();
  const stateChangeHandler = (e, setState) => {
    setState(e.target.value);
  };
  const changeProductHandler = async () => {
    try {
      const request = {
        nameProduct,
        price,
        ArtistOrBand,
        description,
        imageUrl,
      };
      await api.put("", request);
      toast.success("product update!");

      setOpen(false);
    } catch (error) {
      toast.error("Error update!");
      console.error("Error buying product", error);
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
            label="Name:"
            size="md"
            value={nameProduct}
            onChange={() => stateChangeHandler(event, setNamePoduct)}
          ></Input>
          <Input
            label="Description:"
            size="md"
            value={description}
            onChange={() => stateChangeHandler(event, setDescription)}
          ></Input>
          <Input
            label="Artist/band"
            size="md"
            value={ArtistOrBand}
            onChange={() => stateChangeHandler(event, setArtistOrBand)}
          ></Input>
          <Input
            label="Image Link:"
            size="md"
            value={imageUrl}
            onChange={() => stateChangeHandler(event, setImageUrl)}
          ></Input>
          <Input
            label="Price:"
            size="md"
            value={price}
            onChange={() => stateChangeHandler(event, setPrice)}
          ></Input>
        </div>
        <div className="flex justify-center gap-4 mt-4">
          <div>
            <Button color="blue" onClick={changeProductHandler}>
              Edit
            </Button>
          </div>
          <div>
            <Button color="red" onClick={() => setOpen(false)}>
              Cancel
            </Button>
          </div>
        </div>
      </form>
    </div>
  );
};

export default EditProductForm;
