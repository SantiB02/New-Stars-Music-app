import { useAuth0 } from "@auth0/auth0-react";
import React, { useRef, useState } from "react";
import { IoSettingsOutline } from "react-icons/io5";
import { CgProfile } from "react-icons/cg";
import { MdOutlineShoppingCart } from "react-icons/md";
import { HiOutlineLogout } from "react-icons/hi";
import { useNavigate } from "react-router-dom";
import { ShoppingCartIcon } from "@heroicons/react/24/outline";
import { Typography } from "@material-tailwind/react";

const Dropdown = ({ mobileMenuLinkClickHandler, isMobile }) => {
  const { user, logout } = useAuth0();
  const [open, setOpen] = useState(false);

  const menuRef = useRef();
  const imgRef = useRef();

  window.addEventListener("click", (e) => {
    if (e.target !== menuRef.current && e.target !== imgRef.current) {
      setOpen(false);
    }
  });
  const navigate = useNavigate();

  const navigateHandler = (path) => {
    navigate(path);
  };

  return (
    <div>
      <div className="relative z-10">
        <div
          className="flex items-center hover:cursor-pointer"
          onClick={() => setOpen(!open)}
        >
          <img
            ref={imgRef}
            src={user.picture}
            alt={user.name}
            className="h-10 w-10 object-cover border-4 border-gray-400 rounded-full"
          />
          {isMobile && (
            <Typography className="ml-3 underline">{user.nickname}</Typography>
          )}
        </div>
        {open && (
          <div
            ref={menuRef}
            className="bg-third p-4 w-52 shadow-lg  absolute top-10 right-0 mr-4 rounded border"
          >
            <ul>
              <li
                className="p-2 text-white cursor-pointer rounded hover:bg-blue-100 hover:text-black"
                onClick={() => mobileMenuLinkClickHandler("/settings")}
              >
                <div className="flex items-center">
                  <IoSettingsOutline className="mr-2" /> Settings
                </div>
              </li>
              <li
                className="p-2 text-white cursor-pointer rounded hover:bg-blue-100 hover:text-black"
                onClick={() => mobileMenuLinkClickHandler("/profile")}
              >
                <div className="flex items-center">
                  <CgProfile className="mr-2" /> Profile
                </div>
              </li>
              <li
                className="p-2 text-white cursor-pointer rounded hover:bg-blue-100 hover:text-black"
                onClick={() => mobileMenuLinkClickHandler("/cart")}
              >
                <div className="flex items-center">
                  <ShoppingCartIcon width={16} className="mr-2" /> My Cart
                </div>
              </li>
              <li
                className="p-2  text-[#a10009] cursor-pointer rounded hover:bg-red-100 hover:text-red-600 border-t-red-600"
                onClick={() => logout()}
              >
                <div className="flex items-center">
                  <HiOutlineLogout className="mr-2" /> Logout
                </div>
              </li>
            </ul>
          </div>
        )}
      </div>
    </div>
  );
};

export default Dropdown;
