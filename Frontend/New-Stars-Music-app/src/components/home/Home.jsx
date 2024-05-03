import React from "react";
import NavBar from "../NavBar";
import Footer from "../Footer";
import FeaturedProducts from "./FeaturedProducts";

const Home = () => {
  return (
    <div className="flex flex-col min-h-screen">
      <NavBar />
      <div className="flex-grow overflow-auto">
        <div className="flex flex-col ml-4 mt-10">
          <h1 className="text-4xl">Welcome to New Stars Music!</h1>
          <p>
            The place where you can listen to your favorite songs and explore
            their products in our all-in-one store.
          </p>
          <div className="w-2/4">
            <FeaturedProducts />
          </div>
        </div>
      </div>
      <Footer />
    </div>
  );
};

export default Home;
