import { Typography } from "@material-tailwind/react";
import React from "react";

const ServerError = () => {
  return (
    <div className="bg-gray-800 mt-20 mx-32 rounded-full py-6">
      <Typography variant="h2" color="red" className="text-center">
        Oops! It seems our server is having some issues...
      </Typography>
      <Typography variant="h4" className="text-center">
        Please come back later!
      </Typography>
    </div>
  );
};

export default ServerError;
