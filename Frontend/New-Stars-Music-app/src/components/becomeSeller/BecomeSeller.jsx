import {
  Button,
  Dialog,
  Card,
  CardBody,
  CardFooter,
  Typography,
  Input,
  Checkbox,
} from "@material-tailwind/react";
import React, { useState } from "react";

const BecomeSeller = () => {
  const [open, setOpen] = useState(false);

  const handleOpen = () => setOpen(!open);

  return (
    <div className="max-w-7xl mx-auto">
      <Typography variant="h3" className="mt-4 mx-8 font-light">
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
      {/* onclick: navegar a "/seller-center", desloguearse y volverse a loguear */}
      <Button className="bg-orange-800 mt-6 ml-8" onClick={handleOpen}>
        Become a Seller
      </Button>{" "}
      <Dialog
        size="xs"
        open={open}
        handler={handleOpen}
        className="bg-transparent shadow-none"
      >
        <Card className="mx-auto w-full max-w-[24rem]">
          <CardBody className="flex flex-col gap-4">
            <Typography variant="h4" color="blue-gray">
              Become a Seller
            </Typography>
            <Typography
              className="mb-3 font-normal"
              variant="paragraph"
              color="gray"
            >
              Enter your email and password to Sign In.
            </Typography>
            <Typography className="-mb-2" variant="h6">
              Your Email
            </Typography>
            <Input label="Email" size="lg" />
            <Typography className="-mb-2" variant="h6">
              Your Password
            </Typography>
            <Input label="Password" size="lg" />
            <div className="-ml-2.5 -mt-3">
              <Checkbox label="Remember Me" />
            </div>
          </CardBody>
          <CardFooter className="pt-0">
            <Button variant="gradient" onClick={handleOpen} fullWidth>
              Sign In
            </Button>
            <Typography variant="small" className="mt-4 flex justify-center">
              Don&apos;t have an account?
              <Typography
                as="a"
                href="#signup"
                variant="small"
                color="blue-gray"
                className="ml-1 font-bold"
                onClick={handleOpen}
              >
                Sign up
              </Typography>
            </Typography>
          </CardFooter>
        </Card>
      </Dialog>
    </div>
  );
};

export default BecomeSeller;
