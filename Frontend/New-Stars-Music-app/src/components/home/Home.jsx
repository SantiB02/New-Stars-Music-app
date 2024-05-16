import React from "react";
import FeaturedProducts from "./FeaturedProducts";
import Music from "./Music";
import Login from "../login/Login";

const Home = () => {
  return (
    <div className="flex flex-col min-h-screen">
      <div className="flex-grow overflow-auto flex mb-1">
        <div className="flex flex-col ml-4 mt-10 flex-grow">
          <h1 className="text-4xl">Welcome to New Stars Music!</h1>
          <p>
            The place where you can listen to your favorite songs and explore
            their products in our all-in-one store.
          </p>
          <div className="w-3/4">
            <FeaturedProducts />
          </div>
        </div>
        <div className="flex flex-col ml-4 mt-10 w-2/4 mr-8">
          <div className="flex flex-col h-full">
            <div className="flex-grow">
              <Music />
            </div>
          </div>
        </div>
      </div>
    </div>
  );
};

export default Home;
