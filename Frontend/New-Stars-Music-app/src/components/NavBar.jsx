import { Fragment, useEffect, useState } from "react";
import { useNavigate } from "react-router";
import { Dialog, Disclosure, Popover, Transition } from "@headlessui/react";
import {
  ArrowPathIcon,
  Bars3Icon,
  ChartPieIcon,
  CursorArrowRaysIcon,
  FingerPrintIcon,
  ShoppingCartIcon,
  SquaresPlusIcon,
  XMarkIcon,
} from "@heroicons/react/24/outline";
import {
  ChevronDownIcon,
  PhoneIcon,
  PlayCircleIcon,
} from "@heroicons/react/20/solid";

import { useAuth0 } from "@auth0/auth0-react";
import Dropdown from "./dropdown/Dropdown";
import ToggleTheme from "./common/ToggleTheme";
import { Badge, Tooltip } from "@material-tailwind/react";
import { useCart } from "../hooks/useCart";
import { useRoles } from "../hooks/useRoles";
import api, { setAuthInterceptor } from "../api/api";
import { Link } from "react-router-dom";

const callsToAction = [{ name: "Contact support", href: "#", icon: PhoneIcon }];

function classNames(...classes) {
  return classes.filter(Boolean).join(" ");
}

export default function NavBar() {
  const [categories, setCategories] = useState([]);
  const [mobileMenuOpen, setMobileMenuOpen] = useState(false);

  const {
    loginWithRedirect,
    getAccessTokenSilently,
    isAuthenticated,
    user,
    isLoading,
  } = useAuth0();

  const navigate = useNavigate();
  const { cart } = useCart();

  useEffect(() => {
    if (!isLoading) {
      setAuthInterceptor(getAccessTokenSilently);
    }
  }, [isLoading]);

  useEffect(() => {
    const fetchCategories = async () => {
      try {
        const response = await api.get("/products/categories");
        const categories = response.data.url;
        setCategories(categories);
      } catch (error) {
        console.error("Error getting product categories", error);
      }
    };

    fetchCategories();
  }, []);

  const userRole = useRoles(getAccessTokenSilently, isAuthenticated);

  const navigateHandler = (path) => {
    navigate(path);
  };

  const mobileMenuLinkClickHandler = (path) => {
    navigateHandler(path);
    setMobileMenuOpen(false);
  };

  if (localStorage.getItem("isAccountDeleted") === "true") return;

  return (
    <header>
      <nav
        className="w-full bg-secondary text-white shadow-md"
        aria-label="Global"
      >
        <div className="max-w-screen-2xl mx-auto px-6">
          <div className="flex items-center justify-between h-14">
            {/* LOGO */}
            <div className="flex items-center">
              <a
                className="cursor-pointer select-none"
                onClick={
                  isAuthenticated && user
                    ? () => navigateHandler("/home")
                    : () => navigateHandler("/")
                }
              >
                <img
                  className="h-10 w-auto" // altura precisa
                  src="/perfect-glowing-neon-white-star-png.png"
                  alt="Logo"
                />
              </a>
            </div>

            {/* MOBILE BUTTON */}
            <div className="flex lg:hidden">
              <button
                type="button"
                className="p-2.5 rounded-md text-white hover:text-gray-200"
                onClick={() => setMobileMenuOpen(true)}
              >
                <Bars3Icon className="h-6 w-6" aria-hidden="true" />
              </button>
            </div>

            {/* DESKTOP MENU */}
            {isAuthenticated && user && (
              <Popover.Group className="hidden lg:flex lg:items-center lg:gap-x-8 text-white">
                {/* PRODUCT DROPDOWN */}
                <Popover className="relative">
                  <Popover.Button className="flex items-center gap-x-1 text-sm font-medium hover:text-gray-200 cursor-pointer">
                    Product
                    <ChevronDownIcon className="h-4 w-4 text-gray-200" />
                  </Popover.Button>

                  <Transition
                    as={Fragment}
                    enter="transition ease-out duration-200"
                    enterFrom="opacity-0 translate-y-1"
                    enterTo="opacity-100 translate-y-0"
                    leave="transition ease-in duration-150"
                    leaveFrom="opacity-100 translate-y-0"
                    leaveTo="opacity-0 translate-y-1"
                  >
                    <Popover.Panel className="absolute z-50 -left-8 mt-3 w-screen max-w-md rounded-2xl bg-third shadow-xl ring-1 ring-black/10">
                      {/* CATEGORIES */}
                      <div className="p-4">
                        {categories.map((category) => (
                          <Link
                            key={category.id}
                            state={{ categoryId: category.id }}
                            to="/store"
                          >
                            <div className="group flex items-center gap-x-4 rounded-lg p-3 text-sm font-normal text-white hover:bg-blue-gray-100 hover:text-black transition">
                              {category.name}
                            </div>
                          </Link>
                        ))}
                      </div>

                      {/* CALLS TO ACTION */}
                      <div className="grid grid-cols-2 divide-x rounded-lg divide-black/10 bg-white text-black">
                        {callsToAction.map((item) => (
                          <a
                            key={item.name}
                            href={item.href}
                            className="flex items-center justify-center gap-x-2.5 p-3 text-sm font-semibold hover:bg-gray-200 transition"
                          >
                            <item.icon className="h-5 w-5" />
                            {item.name}
                          </a>
                        ))}
                      </div>
                    </Popover.Panel>
                  </Transition>
                </Popover>

                {/* MENU LINKS */}
                <a
                  className="text-sm font-medium hover:text-gray-200 cursor-pointer"
                  onClick={() => navigateHandler("/search")}
                >
                  Search
                </a>

                <a
                  className="text-sm font-medium hover:text-gray-200 cursor-pointer"
                  onClick={() => navigateHandler("/store")}
                >
                  Store
                </a>

                {(userRole === "Client" || userRole === "Seller") && (
                  <a
                    className="text-sm font-medium hover:text-gray-200 cursor-pointer"
                    onClick={() => navigateHandler("/my-orders")}
                  >
                    My Orders
                  </a>
                )}

                {userRole === "Client" && (
                  <a
                    className="text-sm font-medium hover:text-gray-200 cursor-pointer"
                    onClick={() => navigateHandler("/become-seller")}
                  >
                    Become a Seller
                  </a>
                )}

                {userRole === "Seller" && (
                  <a
                    className="text-sm font-medium hover:text-gray-200 cursor-pointer"
                    onClick={() => navigateHandler("/seller-center")}
                  >
                    Seller Center
                  </a>
                )}

                {userRole === "Admin" && (
                  <a
                    className="text-sm font-medium hover:text-gray-200 cursor-pointer"
                    onClick={() => navigateHandler("/dashboard")}
                  >
                    Dashboard
                  </a>
                )}

                {/* THEME TOGGLE */}
                <ToggleTheme />
              </Popover.Group>
            )}

            {/* RIGHT SIDE: CART + USER */}
            <div className="hidden lg:flex items-center space-x-5">
              {cart.length > 0 && (
                <Badge content={cart.length} color="white">
                  <Tooltip content="My Cart" className="bg-gray-700 text-sm">
                    <ShoppingCartIcon
                      width={28}
                      className="cursor-pointer hover:text-gray-200"
                      onClick={() => navigateHandler("/cart")}
                    />
                  </Tooltip>
                </Badge>
              )}

              {isAuthenticated && user ? (
                <Dropdown
                  mobileMenuLinkClickHandler={mobileMenuLinkClickHandler}
                  isMobile={false}
                />
              ) : (
                <a
                  className="text-sm font-medium hover:text-gray-200 cursor-pointer"
                  onClick={() => loginWithRedirect()}
                >
                  Log in →
                </a>
              )}
            </div>
          </div>
        </div>
      </nav>

      <Dialog
        as="div"
        className="lg:hidden bg-fourth"
        open={mobileMenuOpen}
        onClose={setMobileMenuOpen}
      >
        <div className="fixed bg-blur-100 z-10 bg-secondary " />
        <Dialog.Panel className="fixed  inset-y-0 right-0 z-10 w-full overflow-y-auto  px-6 py-6 sm:max-w-sm sm:ring-1 sm:ring-gray-900/10 bg-fourth">
          <div className="flex items-center justify-between bg-fourth">
            <a href="#" className="-m-1.5 p-1.5">
              <span className="sr-only">Your Company</span>
            </a>
            <button
              type="button"
              className="-m-2.5 rounded-md p-2.5 text-gray-700"
              onClick={() => setMobileMenuOpen(false)}
            >
              <span className="sr-only">Close menu</span>
              <XMarkIcon className=" h-6 w-6" aria-hidden="true" />
            </button>
          </div>
          <div className="mt-6 flow-root bg-fourth">
            <div className="-my-6 divide-y divide-gray-500/10 bg-fourth">
              <div className="space-y-2 py-6 bg-fourth">
                <Disclosure as="div" className="-mx-3 bg-fourth">
                  {({ open }) => (
                    <>
                      <Disclosure.Button className="flex w-full items-center justify-between rounded-lg py-2 pl-3 pr-3.5 text-base font-semibold leading-7 text-gray-900 hover:bg-gray-50">
                        Product
                        <ChevronDownIcon
                          className={classNames(
                            open ? "rotate-180" : "",
                            "h-5 w-5 flex-none"
                          )}
                          aria-hidden="true"
                        />
                      </Disclosure.Button>
                      <Disclosure.Panel className="mt-2 space-y-2">
                        {[...categories, ...callsToAction].map((category) => (
                          <Link
                            to="/store"
                            state={{ categoryId: category.id }}
                            key={category.name}
                          >
                            <Disclosure.Button className="block rounded-lg py-2 pl-6 pr-3 text-sm font-semibold leading-7 text-gray-900 hover:bg-white">
                              <p>{category.name}</p>
                            </Disclosure.Button>
                          </Link>
                        ))}
                      </Disclosure.Panel>
                    </>
                  )}
                </Disclosure>
                <a
                  className="-mx-3 block rounded-lg px-3 py-2 text-base font-semibold leading-7 text-gray-900 hover:bg-gray-50"
                  onClick={() => mobileMenuLinkClickHandler("/store")}
                >
                  Store
                </a>
                <a
                  className="-mx-3 block rounded-lg px-3 py-2 text-base font-semibold leading-7 text-gray-900 hover:bg-gray-50"
                  onClick={() => mobileMenuLinkClickHandler("/search")}
                >
                  Search
                </a>
                <a
                  className="-mx-3 block rounded-lg px-3 py-2 text-base font-semibold leading-7 text-gray-900 hover:bg-gray-50"
                  onClick={() =>
                    user["https://localhost:7133/api/roles"] === "Seller"
                      ? mobileMenuLinkClickHandler("/seller-center")
                      : mobileMenuLinkClickHandler("/become-seller")
                  }
                >
                  {user["https://localhost:7133/api/roles"] === "Seller"
                    ? "Seller Center"
                    : "Become a Seller"}
                </a>
                <a
                  href="#"
                  className="-mx-3 block rounded-lg px-3 py-2 text-base font-semibold leading-7 text-gray-900"
                >
                  <ToggleTheme />
                </a>
              </div>
              <div className="py-6">
                {isAuthenticated && user ? (
                  <a className="-mx-3 block rounded-lg px-3 py-2.5 text-base font-semibold leading-7 text-gray-900 hover:bg-gray-50 ">
                    <Dropdown
                      mobileMenuLinkClickHandler={mobileMenuLinkClickHandler}
                      isMobile={true}
                    />
                  </a>
                ) : (
                  <a
                    className="-mx-3 block rounded-lg px-3 py-2.5 text-base font-semibold leading-7 text-gray-900 hover:bg-gray-50"
                    onClick={() => loginWithRedirect()}
                  >
                    Log in
                  </a>
                )}
              </div>
            </div>
          </div>
        </Dialog.Panel>
      </Dialog>
    </header>
  );
}
