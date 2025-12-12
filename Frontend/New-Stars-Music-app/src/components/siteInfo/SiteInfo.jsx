import { ArrowLeftCircleIcon } from "@heroicons/react/24/outline";
import { Typography } from "@material-tailwind/react";
import React from "react";
import { useNavigate } from "react-router-dom";

const SiteInfo = () => {
  const navigate = useNavigate();

  return (
    <div className="max-w-7xl mx-auto">
      <div
        className="flex hover:cursor-pointer ml-7 mt-6"
        onClick={() => navigate("/")}
      >
        <ArrowLeftCircleIcon width={25} />
        <Typography className="ml-1 hover:underline">Back to Home</Typography>
      </div>

      <Typography variant="h3" className="mt-4 mx-8 font-light">
        About Our Site
      </Typography>
      <Typography className="mx-8 text-justify">
        Welcome to our unique online store where music meets merchandise! Here,
        you can explore your favorite artists and discover a variety of products
        associated with them. From exclusive band t-shirts to limited edition
        vinyl records, our site offers a one-stop shop for music lovers and
        merch enthusiasts alike. But that&apos;s not all - we also empower users
        to become Sellers, allowing them to upload and sell their own products
        on our platform. Whether you&apos;re an artist looking to connect with
        fans or a fan wanting to show support, our site is the perfect place for
        you.
      </Typography>
      <Typography variant="h3" className="mt-4 mx-8 font-light">
        Our Story
      </Typography>
      <Typography className="p-8 text-justify">
        We are a group of five friends from Argentina who share a deep passion
        for music and creativity. One day, we came up with the idea to create a
        space where music and merchandise could coexist, offering fans a unique
        shopping experience and giving artists a new way to reach their
        audience. After months of brainstorming and hard work, we brought this
        vision to life. Our mission is to create a community where artists and
        fans can connect through the power of music and merchandise. Thank you
        for being a part of our journey!
      </Typography>
    </div>
  );
};

export default SiteInfo;
