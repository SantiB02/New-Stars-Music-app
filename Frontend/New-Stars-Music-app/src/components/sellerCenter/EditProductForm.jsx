import { Button, Input } from "@material-tailwind/react";
import React, { useState } from "react";
import { useTheme } from "../../services/contexts/ThemeProvider";

const EditProductForm = ({ setOpen, product }) => {
  const [nameProduct, setNamePoduct] = useState(product.name);
  const [price, setPrice] = useState(product.price);
  const [ArtistOrBand, setArtistOrBand] = useState(product.artistOrBand);
  const [description, setDescription] = useState(product.description);
  const [imageUrl, setImageUrl] = useState(product.imageLink);

  const { theme } = useTheme();
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
          <Input label="Name:" value={nameProduct}></Input>
          <Input label="Description:" value={description}></Input>
          <Input label="Artist/band" value={ArtistOrBand}></Input>
          <Input label="Image Link:" value={imageUrl}></Input>
          <Input label="Price:" value={price}></Input>
        </div>
        <div className="flex justify-center gap-4 mt-4">
          <div>
            <Button color="blue">Change</Button>
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
