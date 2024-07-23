import { Button, Card, Input } from "@material-tailwind/react";
import React, { useState } from "react";
import { useTheme } from "../../services/contexts/ThemeProvider";
import toast from "react-hot-toast";
import api from "../../api/api";
import { useForm } from "../../hooks/useForm";


const FormProfile = ({ setOpenChange, users }) => {
  const [address, setAddress] = useState(users.address);
  const [apartment, setApartment] = useState(users.apartment);
  const [country, setCountry] = useState(users.country);
  const [city, setCity] = useState(users.city);
  const [postalCode, setPostalCode] = useState(users.postalCode);
  const [phone, setPhone] = useState(users.phone);
  
  const { theme } = useTheme();

  const { validateForm } = useForm();

  const stateChangeHandler = (e, setState) => {
    setState(e.target.value);
  };
  const changeDataHandler = async () => {
    
    try {
      const form = { address, apartment, country, city, postalCode, phone };
    if (!validateForm(form)) {
      toast.error("Please fill in all fields.");
      return;
    }
      const request = {
        address,
        apartment,
        country,
        city,
        postalCode,
        phone,
      };
      await api.put("/users/client", request);
      toast.success("User update!");
      
      setOpenChange(false);
     
    } catch (error) {
      toast.error("Error update!");
      console.error("Error buying user", error);
      setOpenChange(false);
    }
  };

  return (
    <div>
      <form
        className={
          theme
            ? " bg-primary p-5 w-70 max-w-screen-lg sm:w-96"
            : " p-5 w-70 max-w-screen-lg sm:w-96"
        }
      >
        <div className="mb-1 flex flex-col gap-6">
          <Input
            color={theme ? "white" : undefined}
            label="Country"
            size="md"
            value={country}
            onChange={(event) => stateChangeHandler(event, setCountry)}
          />
          <Input
            color={theme ? "white" : undefined}
            label="City"
            size="md"
            value={city}
            onChange={(event) => stateChangeHandler(event, setCity)}
          />
          <Input
            color={theme ? "white" : undefined}
            label="Postal Code"
            size="md"
            value={postalCode}
            onChange={(event) => stateChangeHandler(event, setPostalCode)}
          />
          <Input
            color={theme ? "white" : undefined}
            label="Address"
            size="md"
            value={address}
            onChange={(event) => stateChangeHandler(event, setAddress)}
          />
          <Input
            color={theme ? "white" : undefined}
            label="Apartment / Floor"
            size="md"
            value={apartment}
            onChange={(event) => stateChangeHandler(event, setApartment)}
          />
          <Input
            color={theme ? "white" : undefined}
            label="Phone"
            size="md"
            value={phone}
            onChange={(event) => stateChangeHandler(event, setPhone)}
          />
        </div>
        <div className="flex justify-center gap-4 mt-4">
          <div>
            <Button color="blue" onClick={changeDataHandler}>
              Change
            </Button>
          </div>
          <div>
            <Button color="red" onClick={() => setOpenChange(false)}>
              Cancel
            </Button>
          </div>
        </div>
      </form>
    </div>
  );
};

export default FormProfile;
