import React from "react";

const NoArtistsMessage = ({ theme }) => {
  return (
    <div className="grid text-center place-content-center mt-24 px-4">
      <h1
        className={
          theme
            ? "uppercase tracking-widest text-white"
            : "uppercase tracking-widest text-black"
        }
      >
        To view the available options, please enter an artist.
      </h1>
    </div>
  );
};

export default NoArtistsMessage;
