import { useAuth0 } from "@auth0/auth0-react";
import React, { useRef, useState } from "react";

const Dropdown = () => {
  const { user, logout } = useAuth0();
  const [open, setOpen] = useState(false);

  const menuRef = useRef();
  const imgRef = useRef();

  window.addEventListener("click", (e) => {
    if (e.target !== menuRef.current && e.target !== imgRef.current) {
      setOpen(false);
    }
  });

  return (
    <div>
      <div className=" relative">
        <img
          ref={imgRef}
          onClick={() => setOpen(!open)}
          src={user.picture}
          alt={user.name}
          className="h-10 w-10 object-cover border-4 border-gray-400 rounded-full hover:cursor-pointer"
        />
        {open && (
          <div
            ref={menuRef}
            className="bg-third p-4 w-52 shadow-lg  absolute top-10 right-0 mr-4 rounded"
          >
            <ul>
              <li className="p-2 text-white cursor-pointer rounded hover:bg-blue-100 hover:text-black">
                settings
              </li>
              <li className="p-2 text-white cursor-pointer rounded hover:bg-blue-100 hover:text-black">
                profile
              </li>
              <li className="p-2 text-white cursor-pointer rounded hover:bg-blue-100 hover:text-black">
                yout cart
              </li>
              <li
                className="p-2  text-red-500 cursor-pointer rounded hover:bg-red-100 hover:text-red-600"
                onClick={() => logout()}
              >
                Logout
              </li>
            </ul>
          </div>
        )}
      </div>
    </div>
  );
};

export default Dropdown;
