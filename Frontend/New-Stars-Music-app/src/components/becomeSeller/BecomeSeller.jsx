import {
  Button,
  Dialog,
  Card,
  CardBody,
  CardFooter,
  Typography,
  Input,
  Alert,
} from "@material-tailwind/react";
import React, { useEffect, useState } from "react";
import api from "../../api/api";
import toast from "react-hot-toast";
import { useNavigate } from "react-router-dom";
import InfoIcon from "../icons/InfoIcon";
import { useForm } from "../../hooks/useForm";
import { useRoles } from "../../hooks/useRoles";
import { useAuth0 } from "@auth0/auth0-react";

const BecomeSeller = () => {
  const [open, setOpen] = useState(false);
  const [address, setAddress] = useState("");
  const [apartment, setApartment] = useState("");
  const [country, setCountry] = useState("");
  const [city, setCity] = useState("");
  const [postalCode, setPostalCode] = useState("");
  const [phone, setPhone] = useState("");
  const [isProcessingRequest, setIsProcessingRequest] = useState(false);
  const [requestAlreadySubmitted, setRequestAlreadySubmitted] = useState(false);
  const [personalInfoAlreadySubmitted, setPersonalInfoAlreadySubmitted] =
    useState(false);
  const [isLoadingPage, setIsLoadingPage] = useState(false);
  const navigate = useNavigate();
  const { validateForm } = useForm();
  const { getAccessTokenSilently, isAuthenticated } = useAuth0();
  const userRole = useRoles(getAccessTokenSilently, isAuthenticated);

  useEffect(() => {
    const fetchUserValidationStatus = async () => {
      const response = await api.get("/users/is-waiting-validation");
      const isWaitingValidation = response.data;

      if (isWaitingValidation) {
        setRequestAlreadySubmitted(true);
      } else {
        const response = await api.get("/users/has-personal-info");
        const hasPersonalInfo = response.data;
        if (hasPersonalInfo) {
          setPersonalInfoAlreadySubmitted(true);
        }
      }
    };

    const initialize = async () => {
      setIsLoadingPage(true);
      await fetchUserValidationStatus();
      setIsLoadingPage(false);
    };

    initialize();
  }, []);

  const stateChangeHandler = (e, setState) => {
    setState(e.target.value);
  };

  const handleOpen = () => setOpen(!open);

  const becomeSellerHandler = async () => {
    const form = { address, country, city, postalCode, phone };
    if (!validateForm(form)) {
      toast.error("Please fill in all fields.");
      return;
    }
    setIsProcessingRequest(true);
    handleOpen();
    try {
      const request = {
        address,
        apartment: apartment === "" ? null : apartment,
        country,
        city,
        postalCode,
        phone,
        waitingValidation: true,
      };
      await api.put("/users/client", request);
      toast.success("Your seller request has been submitted!");
      setRequestAlreadySubmitted(true);
    } catch (error) {
      toast.error("Error submitting seller request. Please try again!");
      console.error("Error updating user", error);
    } finally {
      setIsProcessingRequest(false);
    }
  };

  const becomeSellerWithSavedInfoHandler = async () => {
    setIsProcessingRequest(true);
    handleOpen();
    try {
      await api.put("/users/validation-status/true");
      toast.success("Your seller request has been submitted!");
      setRequestAlreadySubmitted(true);
    } catch (error) {
      toast.error("Error submitting seller request. Please try again!");
      console.error(
        "Error submitting seller request with saved personal info",
        error
      );
    } finally {
      setIsProcessingRequest(false);
    }
  };

  return (
    <div className="max-w-7xl mx-auto">
      <Typography variant="h3" className="pt-4 mx-8 font-light">
        Become a Seller
      </Typography>
      <Typography className="mx-8 text-justify">
        Are you passionate about music and have products to sell? Join our
        community of Sellers and start showcasing your merchandise to a global
        audience! As a Seller on our site, you can upload your own products, set
        your prices, and reach fans who are eager to support their favorite
        artists and discover new ones. Whether you&apos;re an artist with
        exclusive merch or a creative entrepreneur with unique items, our
        platform provides the perfect space for you to sell your products.
      </Typography>
      <Typography variant="h3" className="mt-4 mx-8 font-light">
        Why Sell With Us?
      </Typography>
      <Typography className="mx-8 text-justify">
        Becoming a Seller on our site is easy and rewarding. You&apos;ll have
        the freedom to manage your own online store, upload product photos,
        write descriptions, and track your sales. Our user-friendly interface
        makes it simple to list your items and start selling in no time. Plus,
        with our built-in audience of music lovers, you&apos;ll have the
        opportunity to connect with customers who share your passion for music
        and merchandise.
      </Typography>
      <Typography variant="h3" className="mt-4 mx-8 font-light">
        Join Our Community
      </Typography>
      <Typography className="mx-8 text-justify">
        Ready to take the next step? Sign up to become a Seller today and start
        turning your creativity into profit. By joining our platform,
        you&apos;ll be part of a vibrant community that celebrates music and the
        unique products that come with it. We&apos;re here to support you every
        step of the way, from setting up your store to making your first sale.
        Don&apos;t miss out on the chance to reach fans around the world -
        become a Seller now and let your products shine!
      </Typography>
      {!isLoadingPage && userRole === "Client" && (
        <Button
          disabled={isProcessingRequest || requestAlreadySubmitted}
          className="bg-orange-800 mt-6 ml-8"
          onClick={handleOpen}
        >
          {!requestAlreadySubmitted
            ? "Create Seller Request"
            : "Seller Request Already Sent"}
        </Button>
      )}
      <Dialog
        size="xs"
        open={open}
        handler={handleOpen}
        className="bg-transparent shadow-none"
      >
        <Card className="mx-auto w-full max-w-[24rem]">
          <CardBody className="flex flex-col gap-4">
            <Typography variant="h4" color="blue-gray">
              Seller Request
            </Typography>
            <Typography className="text-sm" color="gray">
              Enter some personal information to proceed. Your data will be
              reviewed by our staff within 48 hours. You will receive a
              confirmation email after your seller account has been successfully
              activated.
            </Typography>
            {!personalInfoAlreadySubmitted ? (
              <>
                <Typography className="-mb-2" variant="h6">
                  Your Location
                </Typography>
                <Input
                  label="Country"
                  size="md"
                  value={country}
                  onChange={(event) => stateChangeHandler(event, setCountry)}
                />
                <Input
                  label="City"
                  size="md"
                  value={city}
                  onChange={(event) => stateChangeHandler(event, setCity)}
                />
                <Input
                  label="Postal Code"
                  size="md"
                  value={postalCode}
                  onChange={(event) => stateChangeHandler(event, setPostalCode)}
                />
                <Input
                  label="Address"
                  size="md"
                  value={address}
                  onChange={(event) => stateChangeHandler(event, setAddress)}
                />
                <Input
                  label="Apartment / Floor"
                  size="md"
                  value={apartment}
                  onChange={(event) => stateChangeHandler(event, setApartment)}
                />
                <Typography className="-mb-2" variant="h6">
                  Your Contact Information
                </Typography>
                <Input
                  label="Phone"
                  size="md"
                  value={phone}
                  onChange={(event) => stateChangeHandler(event, setPhone)}
                />
              </>
            ) : (
              <Alert icon={<InfoIcon />}>
                Your personal information is already saved in your profile. You
                can submit this request with it or modify it in your{" "}
                <a
                  className="text-orange-800 cursor-pointer hover:underline"
                  onClick={() => navigate("/profile")}
                >
                  Profile
                </a>{" "}
                page.
              </Alert>
            )}
          </CardBody>
          <CardFooter className="pt-0">
            <Button
              variant="gradient"
              onClick={
                !personalInfoAlreadySubmitted
                  ? becomeSellerHandler
                  : becomeSellerWithSavedInfoHandler
              }
              fullWidth
            >
              Submit Seller Request
            </Button>
          </CardFooter>
        </Card>
      </Dialog>
    </div>
  );
};

export default BecomeSeller;
