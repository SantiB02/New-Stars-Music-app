import { Button, Card, Input } from "@material-tailwind/react";
import React, { useState } from "react";
import { useTheme } from "../../services/contexts/ThemeProvider";

const FormProfile = ({ setOpenChange }) => {
  const [address, setAddress] = useState("");
  const [apartment, setApartment] = useState("");
  const [country, setCountry] = useState("");
  const [city, setCity] = useState("");
  const [postalCode, setPostalCode] = useState("");
  const [phone, setPhone] = useState("");

  const stateChangeHandler = (e, setState) => {
    setState(e.target.value);
  };
  const changeDataHandler = () => {
    
  };

  const { theme } = useTheme();
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
            onChange={() => stateChangeHandler(event, setCountry)}
          />
          <Input
            color={theme ? "white" : undefined}
            label="City"
            size="md"
            value={city}
            onChange={() => stateChangeHandler(event, setCity)}
          />
          <Input
            color={theme ? "white" : undefined}
            label="Postal Code"
            size="md"
            value={postalCode}
            onChange={() => stateChangeHandler(event, setPostalCode)}
          />
          <Input
            color={theme ? "white" : undefined}
            label="Address"
            size="md"
            value={address}
            onChange={() => stateChangeHandler(event, setAddress)}
          />
          <Input
            color={theme ? "white" : undefined}
            label="Apartment / Floor"
            size="md"
            value={apartment}
            onChange={() => stateChangeHandler(event, setApartment)}
          />
          <Input
            color={theme ? "white" : undefined}
            label="Phone"
            size="md"
            value={phone}
            onChange={() => stateChangeHandler(event, setPhone)}
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
