import React from "react";
import "./LoadingMessage.css";

const LoadingMessage = ({ message }) => {
  return (
    <div className="py-6 flex flex-col items-center" role="status">
      <p>{message}</p>
      <span className="loader"></span>
      <span className="sr-only">Loading...</span>
    </div>
  );
};

export default LoadingMessage;
