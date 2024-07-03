import { Typography } from "@material-tailwind/react";
import React from "react";

const ServerError = ({ errorCode }) => {
  return (
    <div className="bg-gray-800 mt-20 max-w-xl mx-auto rounded-full py-6">
      <Typography color="red" className="mx-6 text-center text-xl font-bold">
        Oops! It seems our server is having some issues...
      </Typography>
      <Typography className="text-center">Please come back later!</Typography>
      <Typography className="mt-4 text-sm font-sm text-center">
        <span className="text-red-400">Error code:</span> {errorCode}
      </Typography>
    </div>
  );
};

export default ServerError;
