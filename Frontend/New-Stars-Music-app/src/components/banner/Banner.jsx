import React, { useEffect, useState } from "react";
import { useLocation, useNavigate } from "react-router-dom";
import { useAuth0 } from "@auth0/auth0-react";
import RatingCard from "../home/RatingCard";
import { Alert, Typography } from "@material-tailwind/react";
import { useTheme } from "../../services/contexts/ThemeProvider";
import InfoIcon from "../icons/InfoIcon";

const Banner = () => {
  const [isAccountDeleted, setIsAccountDeleted] = useState(
    localStorage.getItem("isAccountDeleted") === "true"
  );
  const navigate = useNavigate();
  const { loginWithRedirect, isAuthenticated } = useAuth0();
  const { theme } = useTheme();

  const navigateHandler = (path) => {
    navigate(path);
  };

  useEffect(() => {
    if (!isAuthenticated) {
      localStorage.removeItem("isAccountDeleted");
    } else {
      navigateHandler("/home");
    }
  }, [isAuthenticated]);

  return (
    <div className={theme ? "bg-primary text-white" : "bg-gray-200 text-black"}>
      <section
        className={theme ? "bg-primary text-white" : "bg-gray-200 text-black"}
      >
        <div className="mx-auto max-w-screen-xl px-4 pt-10 lg:flex lg:pt-14 lg:items-center">
          <div className="mx-auto max-w-3xl text-center">
            {isAccountDeleted && (
              <Alert className="mb-4 bg-gray-800" icon={<InfoIcon />}>
                It seems your account has been deleted. This action will be
                irreversible after 30 days. If you wish to recover your account,
                please get in touch with us through{" "}
                <a
                  href="mailto:support@newstarsmusic.com?subject=Recover%20My%20Deleted%20Account"
                  target="_blank"
                  className="italic hover:underline text-orange-600"
                >
                  support@newstarsmusic.com
                </a>
              </Alert>
            )}
            <h1
              className={
                theme
                  ? "bg-gradient-to-r pb-2 from-white via-secondary to-red-600 bg-clip-text text-3xl font-extrabold text-transparent sm:text-5xl"
                  : "bg-gradient-to-r pb-2 from-black via-secondary to-red-600 bg-clip-text text-3xl font-extrabold text-transparent sm:text-5xl"
              }
            >
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
                className={
                  theme
                    ? "block cursor-pointer w-full rounded border border-secondary bg-secondary px-8 py-3 text-sm font-medium text-white hover:bg-transparent hover:text-white focus:outline-none focus:ring active:text-opacity-75 sm:w-auto"
                    : "block cursor-pointer w-full rounded border border-secondary bg-secondary px-8 py-3 text-sm font-medium text-white hover:bg-transparent hover:text-secondary focus:outline-none focus:ring active:text-opacity-75 sm:w-auto"
                }
                onClick={() => loginWithRedirect()}
              >
                Log In or Register
              </a>

              <a
                className={
                  theme
                    ? "block cursor-pointer w-full rounded border border-secondary px-8 py-3 text-sm font-medium text-white hover:bg-secondary focus:outline-none focus:ring active:bg-blue-500 sm:w-auto"
                    : "block cursor-pointer w-full rounded border border-secondary px-8 py-3 text-sm font-medium text-secondary hover:bg-secondary hover:text-white focus:outline-none focus:ring active:bg-blue-500 sm:w-auto"
                }
                onClick={() => navigateHandler("/info")}
              >
                Learn More
              </a>
            </div>
          </div>
        </div>
      </section>
      <Typography className="text-center mt-12" variant="h4">
        What our clients say...
      </Typography>
      <div className="grid grid-cols-1 sm:grid-cols-2 lg:grid-cols-3 gap-4">
        <RatingCard
          profilePicUrl="Andy-Profile-600.webp"
          fullName="John Doe"
          description='"Greatest site ever! Not only can I explore my favourite artists, but I can also discover their merchandising, either 3rd party or official products! My rating for New Stars Music speaks for itself."'
          rating={9.3}
        />
        <RatingCard
          profilePicUrl="girl-profile-pic.jpg"
          fullName="Mary Sue"
          description='"If you are looking for a site that links your favorite artists with your favorite products, look no further. New Stars Music has it all!"'
          rating={8.8}
        />
        <RatingCard
          profilePicUrl="smiling-african-man-looking-camera.avif"
          fullName="Marvin Gerard"
          description='"I believe these guys love music, because this idea is a breakthrough for the e-commerce community. Music and products all at once? Count me in."'
          rating={8}
        />
      </div>
    </div>
  );
};

export default Banner;
