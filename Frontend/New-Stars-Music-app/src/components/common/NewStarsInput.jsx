import React from "react";

//name: used to link label and input elements through "for" and "id" attributes
//type: "text" | "number" | "email" | "password" | "date" (text is default)
//label: text that should be displayed for this input
//placeholder: text displayed as an example before user input

//---styles---
const labelStyles =
  "block mb-2 text-sm font-medium text-gray-900 dark:text-white";

const inputStyles =
  "bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500";
//---styles---

const NewStarsInput = ({ name, type, label, placeholder, value, onChange }) => {
  const isTypeInvalid =
    type !== "text" &&
    type !== "number" &&
    type !== "password" &&
    type !== "date";

  if (isTypeInvalid && type !== undefined) {
    console.error(
      "Invalid input type (only 'text', 'number', 'email', 'password' or 'date' are supported)!'"
    );
  }

  return (
    <div className="mb-5">
      <label className={labelStyles} htmlFor={name}>
        {label}
      </label>
      <input
        className={inputStyles}
        type={type ? type : "text"}
        placeholder={placeholder && placeholder}
        value={value}
        onChange={onChange}
      />
    </div>
  );
};

export default NewStarsInput;
