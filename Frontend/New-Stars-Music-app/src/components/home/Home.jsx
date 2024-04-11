import React from "react";
import NavBar from "../NavBar";

const Home = () => {
  return (
    <>
    <NavBar/>
      <div>
        <div className="flex flex-col">
          <h1 className="text-4xl">Welcome to New Stars Music!</h1>
          <p>
            The place where you can listen to your favorite songs and explore
            their products in our all-in-one store.
          </p>
        </div>
      </div>
    </>
  );
};

export default Home;
