import {
  Card,
  Input,
  Checkbox,
  Button,
  Typography,
  useTheme,
} from "@material-tailwind/react";
import React, { useState } from "react";
import { useNavigate } from "react-router-dom";
import { useCart } from "../../hooks/useCart";

const Payment = () => {
  const [open, setOpen] = useState(false);
  const [address, setAddress] = useState("");
  const [apartment, setApartment] = useState("");
  const [country, setCountry] = useState("");
  const [city, setCity] = useState("");
  const [postalCode, setPostalCode] = useState("");
  const [phone, setPhone] = useState("");
  const navigate = useNavigate();
  const { cartTotal } = useCart();

  const stateChangeHandler = (e, setState) => {
    setState(e.target.value);
  };
  const theme = useTheme();

  return (
    <div className="ml-10 pt-4">
      <Typography variant="h2" className="font-light">
        Payment
      </Typography>
      <Typography variant="h3" className="mb-4 font-light">
        Total:{" "}
        <span className="text-orange-600">${cartTotal.toFixed(2)} ARS</span>
      </Typography>
      <div className="flex justify-center gap-16">
        <Card color="transparent" shadow={false}>
          <Typography
            variant="h4"
            className="font-light"
            color={theme ? "white" : "blue-gray"}
          >
            Where will you receive your order?
          </Typography>
          <Typography color="gray" className="mt-1 font-normal">
            This information will be saved for future purchases.
          </Typography>
          <form className="mt-8 mb-2 w-80 max-w-screen-lg sm:w-96">
            <div className="mb-1 flex flex-col gap-6">
              <Input
                label="Country"
                size="md"
                value={country}
                onChange={() => stateChangeHandler(event, setCountry)}
              />
              <Input
                label="City"
                size="md"
                value={city}
                onChange={() => stateChangeHandler(event, setCity)}
              />
              <Input
                label="Postal Code"
                size="md"
                value={postalCode}
                onChange={() => stateChangeHandler(event, setPostalCode)}
              />
              <Input
                label="Address"
                size="md"
                value={address}
                onChange={() => stateChangeHandler(event, setAddress)}
              />
              <Input
                label="Apartment / Floor"
                size="md"
                value={apartment}
                onChange={() => stateChangeHandler(event, setApartment)}
              />
              <Typography className="-mb-2" variant="h6">
                Your Contact Information
              </Typography>
              <Input
                label="Phone"
                size="md"
                value={phone}
                onChange={() => stateChangeHandler(event, setPhone)}
              />
            </div>
          </form>
        </Card>
        <Card color="transparent" shadow={false}>
          <Typography
            variant="h4"
            className="font-light"
            color={theme ? "white" : "blue-gray"}
          >
            Credit Card Information
          </Typography>
          <Typography color="gray" className="mt-1 font-normal">
            This data is encrypted end-to-end.
          </Typography>
          <form className="mt-8 mb-2 w-80 max-w-screen-lg sm:w-96">
            <div className="mb-1 flex flex-col gap-6">
              <Typography variant="h6" color="blue-gray" className="-mb-3">
                Your Name
              </Typography>
              <Input
                size="lg"
                placeholder="name@mail.com"
                className=" !border-t-blue-gray-200 focus:!border-t-gray-900"
                labelProps={{
                  className: "before:content-none after:content-none",
                }}
              />
              <Typography variant="h6" color="blue-gray" className="-mb-3">
                Your Email
              </Typography>
              <Input
                size="lg"
                placeholder="name@mail.com"
                className=" !border-t-blue-gray-200 focus:!border-t-gray-900"
                labelProps={{
                  className: "before:content-none after:content-none",
                }}
              />
              <Typography variant="h6" color="blue-gray" className="-mb-3">
                Password
              </Typography>
              <Input
                type="password"
                size="lg"
                placeholder="********"
                className=" !border-t-blue-gray-200 focus:!border-t-gray-900"
                labelProps={{
                  className: "before:content-none after:content-none",
                }}
              />
            </div>
          </form>
        </Card>
      </div>
      <div className="flex justify-center">
        <Button className="my-6 max-w-28 text-black bg-white" fullWidth>
          Buy
        </Button>
      </div>
    </div>
  );
};

export default Payment;
