import React from "react";

const submitButtonStyles =
  "text-white bg-orange-700 hover:bg-orange-800 focus:ring-4 focus:outline-none focus:ring-orange-300 font-medium rounded-lg text-sm w-full sm:w-auto px-5 py-2.5 text-center dark:bg-orange-600 dark:hover:bg-orange-700 dark:focus:ring-orange-800";

//This form already has a button for submission and it should wrap around every input

/**
 * Common form component (with custom styles and a submit button) that must wrap around *every input.*
 * @param onSubmit function that will run when submit button is clicked
 * @param buttonText label for the integrated button (submit, send, save, etc.)
 */

const NewStarsForm = ({ children, onSubmit, buttonText }) => {
  return (
    <form className="max-w-sm my-4 mx-auto" onSubmit={onSubmit}>
      {children}
      <button type="submit" className={submitButtonStyles}>
        {buttonText}
      </button>
    </form>
  );
};

export default NewStarsForm;
