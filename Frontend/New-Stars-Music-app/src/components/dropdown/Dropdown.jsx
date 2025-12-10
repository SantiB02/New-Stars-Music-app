import { useAuth0 } from "@auth0/auth0-react";
import React, { useRef, useState } from "react";
import { Disclosure, Transition } from "@headlessui/react";
import { IoSettingsOutline } from "react-icons/io5";
import { CgProfile } from "react-icons/cg";
import { MdOutlineDashboardCustomize } from "react-icons/md";
import { HiOutlineLogout } from "react-icons/hi";
import { useNavigate } from "react-router-dom";
import { ShoppingCartIcon } from "@heroicons/react/24/outline";
import { Typography } from "@material-tailwind/react";
import { useRoles } from "../../hooks/useRoles";
import { ChevronDownIcon } from "@heroicons/react/20/solid";

const Dropdown = ({ mobileMenuLinkClickHandler, isMobile }) => {
  const { user, logout, getAccessTokenSilently, isAuthenticated } = useAuth0();
  const [open, setOpen] = useState(false);

  const menuRef = useRef();
  const imgRef = useRef();
  const userRole = useRoles(getAccessTokenSilently, isAuthenticated);

  const navigate = useNavigate();

  const logoutHandler = () => {
    localStorage.clear();
    logout();
  };

  // ---------------------------------------------
  // 🔥 1) MOBILE VERSION (NO DROPDOWN FLOTANTE)
  // ---------------------------------------------
  if (isMobile) {
    return (
      <Disclosure as="div" >
        {({ open }) => (
          <>
            {/* BUTTON */}
            <Disclosure.Button className="flex w-full items-center justify-between rounded-lg py-2 px-2 text-base font-semibold leading-7 text-gray-900 hover:bg-gray-100">
              <div className="flex items-center gap-3">
                <img
                  src={user.picture}
                  alt={user.name}
                  className="h-10 w-10 rounded-full border-4 border-gray-400"
                />
                <span>{user.nickname}</span>
              </div>

              <ChevronDownIcon
                className={`h-5 w-5 transition-transform duration-300 ${
                  open ? "rotate-180" : ""
                }`}
              />
            </Disclosure.Button>

            {/* PANEL WITH ANIMATION */}
            <Transition
              show={open}
              enter="transition-all duration-300 ease-out"
              enterFrom="opacity-0 -translate-y-2"
              enterTo="opacity-100 translate-y-0"
              leave="transition-all duration-200 ease-in"
              leaveFrom="opacity-100 translate-y-0"
              leaveTo="opacity-0 -translate-y-2"
            >
              <Disclosure.Panel
                static
                className="mt-3 ml-4 space-y-3 origin-top"
              >
                <button
                  className="flex items-center gap-2 p-2 rounded hover:bg-gray-100 w-full text-left"
                  onClick={() => mobileMenuLinkClickHandler("/settings")}
                >
                  <IoSettingsOutline /> Settings
                </button>

                <button
                  className="flex items-center gap-2 p-2 rounded hover:bg-gray-100 w-full text-left"
                  onClick={() => mobileMenuLinkClickHandler("/profile")}
                >
                  <CgProfile /> Profile
                </button>

                {userRole === "Admin" ? (
                  <button
                    className="flex items-center gap-2 p-2 rounded hover:bg-gray-100 w-full text-left"
                    onClick={() => mobileMenuLinkClickHandler("/dashboard")}
                  >
                    <MdOutlineDashboardCustomize /> Dashboard
                  </button>
                ) : (
                  <button
                    className="flex items-center gap-2 p-2 rounded hover:bg-gray-100 w-full text-left"
                    onClick={() => mobileMenuLinkClickHandler("/cart")}
                  >
                    <ShoppingCartIcon className="h-5 w-5" /> My Cart
                  </button>
                )}

                <button
                  className="flex items-center gap-2 p-2 rounded hover:bg-red-200 text-red-600 w-full text-left"
                  onClick={logoutHandler}
                >
                  <HiOutlineLogout /> Logout
                </button>
              </Disclosure.Panel>
            </Transition>
          </>
        )}
      </Disclosure>
    );
  }

  // ---------------------------------------------
  // 🔥 2) DESKTOP VERSION (DROPDOWN FLOTANTE)
  // ---------------------------------------------
  window.addEventListener("click", (e) => {
    if (e.target !== menuRef.current && e.target !== imgRef.current) {
      setOpen(false);
    }
  });

  return (
    <div className="relative z-50">
      {/* Avatar desktop */}
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
      </div>

      {open && (
        <div
          ref={menuRef}
          className="bg-third p-4 w-52 shadow-lg absolute top-10 right-0 rounded border"
        >
          <ul>
            <li
              className="p-2 text-white cursor-pointer rounded hover:bg-blue-100 hover:text-black"
              onClick={() => navigate("/settings")}
            >
              <div className="flex items-center">
                <IoSettingsOutline className="mr-2" /> Settings
              </div>
            </li>

            <li
              className="p-2 text-white cursor-pointer rounded hover:bg-blue-100 hover:text-black"
              onClick={() => navigate("/profile")}
            >
              <div className="flex items-center">
                <CgProfile className="mr-2" /> Profile
              </div>
            </li>

            {userRole === "Admin" ? (
              <li
                className="p-2 text-white cursor-pointer rounded hover:bg-blue-100 hover:text-black"
                onClick={() => navigate("/dashboard")}
              >
                <div className="flex items-center">
                  <MdOutlineDashboardCustomize className="mr-2" />
                  Dashboard
                </div>
              </li>
            ) : (
              <li
                className="p-2 text-white cursor-pointer rounded hover:bg-blue-100 hover:text-black"
                onClick={() => navigate("/cart")}
              >
                <div className="flex items-center">
                  <ShoppingCartIcon className="h-5 w-5 mr-2" />
                  My Cart
                </div>
              </li>
            )}

            <li
              className="p-2 text-[#a10009] cursor-pointer rounded hover:bg-red-100 hover:text-red-600 border-t-red-600"
              onClick={logoutHandler}
            >
              <div className="flex items-center">
                <HiOutlineLogout className="mr-2" /> Logout
              </div>
            </li>
          </ul>
        </div>
      )}
    </div>
  );
};

export default Dropdown;
