import React, { useEffect } from "react";
import LoadingMessage from "../common/LoadingMessage";
import { Navigate, useNavigate } from "react-router-dom";
import { useAuth0 } from "@auth0/auth0-react";

const Banner = () => {
  const navigate = useNavigate();
  const { loginWithRedirect, isAuthenticated, user } = useAuth0();

  const navigateHandler = (path) => {
    navigate(path);
  };

  if (isAuthenticated && user) return <Navigate to="/home" replace />;

  return (
    <div>
      <section className="bg-primary text-white marginLoco">
        <div className="mx-auto max-w-screen-xl px-4 my-36 lg:flex lg:my-32 lg:items-center">
          <div className="mx-auto max-w-3xl text-center">
            <h1 className="bg-gradient-to-r pb-2 from-white via-secondary to-red-600 bg-clip-text text-3xl font-extrabold text-transparent sm:text-5xl">
              New Stars Music.
              <span className="sm:block">
                {" "}
                Music to your ears, merch to your style.{" "}
              </span>
            </h1>

            <p className="mx-auto mt-4 max-w-xl sm:text-xl/relaxed">
              Join us today for thousands of your favorite musical products!
            </p>

            <div className="mt-8 flex flex-wrap justify-center gap-4">
              <a
                className="block cursor-pointer w-full rounded border border-secondary bg-secondary px-8 py-3 text-sm font-medium text-white hover:bg-transparent hover:text-white focus:outline-none focus:ring active:text-opacity-75 sm:w-auto"
                onClick={() => loginWithRedirect()}
              >
                Log In or Register
              </a>

              <a
                className="block w-full rounded border border-secondary px-8 py-3 text-sm font-medium text-white hover:bg-secondary focus:outline-none focus:ring active:bg-blue-500 sm:w-auto"
                onClick={() => navigateHandler("/info")}
              >
                Learn More
              </a>
            </div>
          </div>
        </div>
      </section>
    </div>
  );
};

export default Banner;
