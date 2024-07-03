import { Fragment, useState } from "react";
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
import { GiBilledCap, GiSchoolBag } from "react-icons/gi";
import { FaTshirt } from "react-icons/fa";
import { RiFilePaperFill } from "react-icons/ri";
import { FaCompactDisc } from "react-icons/fa";

import { useAuth0 } from "@auth0/auth0-react";
import Dropdown from "./dropdown/Dropdown";
import ToggleTheme from "./common/ToggleTheme";
import { Badge, Tooltip } from "@material-tailwind/react";
import { useCart } from "../hooks/useCart";

const products = [
  {
    name: "Cap",
    description: "Get a better understanding of your traffic",
    href: "#",
    icon: GiBilledCap,
  },
  {
    name: "Bags",
    description: "Speak directly to your customers",
    href: "#",
    icon: GiSchoolBag,
  },
  {
    name: "T-shirt",
    description: "Your customers’ data will be safe and secure",
    href: "#",
    icon: FaTshirt,
  },
  {
    name: "CDs",
    description: "Connect with third-party tools",
    href: "#",
    icon: FaCompactDisc,
  },
  {
    name: "Posters",
    description: "Build strategic funnels that will convert",
    href: "#",
    icon: RiFilePaperFill,
  },
];
const callsToAction = [{ name: "Contact sales", href: "#", icon: PhoneIcon }];

function classNames(...classes) {
  return classes.filter(Boolean).join(" ");
}

export default function NavBar() {
  const [mobileMenuOpen, setMobileMenuOpen] = useState(false);

  const { loginWithRedirect, isAuthenticated, user, logout } = useAuth0();

  const navigate = useNavigate();
  const { cart } = useCart();

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
        className="mx-auto flex items-center justify-between p-6 lg:px-8 bg-secondary"
        aria-label="Global"
      >
        <div className="flex lg:flex-1 ">
          <a
            className="-m-1.5 "
            onClick={
              isAuthenticated && user
                ? () => navigateHandler("/home")
                : () => navigateHandler("/")
            }
          >
            <span className="sr-only">Your Company</span>
            <img
              className="h-14 w-auto cursor-pointer"
              src="/new-stars-music-high-resolution-logo-transparent.png"
              alt=""
            />
          </a>
        </div>
        <div className="flex lg:hidden">
          <button
            type="button"
            className="-m-2.5 inline-flex items-center justify-center rounded-md p-2.5 text-gray-700 hover:cursor-pointer"
            onClick={() => setMobileMenuOpen(true)}
          >
            <span className="sr-only">Open main menu</span>
            <Bars3Icon className="h-6 w-6" aria-hidden="true" />
          </button>
        </div>
        {isAuthenticated && user && (
          <Popover.Group className="hidden lg:flex lg:items-center lg:gap-x-12">
            <Popover className="relative">
              <Popover.Button className="flex hover:text-gray-300 items-center gap-x-1 text-sm font-semibold leading-6 text-white hover:cursor-pointer">
                Product
                <ChevronDownIcon
                  className="h-5 w-5 flex-none text-gray-400"
                  aria-hidden="true"
                />
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
                <Popover.Panel className="absolute -left-8 top-full z-10 mt-3 w-screen max-w-md overflow-hidden rounded-3xl bg-third shadow-lg ring-1 ring-gray-900/5">
                  <div className="p-4">
                    {products.map((item) => (
                      <div
                        key={item.name}
                        className="group relative flex items-center gap-x-6 rounded-lg p-4  text-sm leading-6 hover:bg-gray-50"
                      >
                        <div className="flex h-11 w-11 flex-none items-center justify-center rounded-lg bg-primary group-hover:">
                          <item.icon
                            className="h-6 w-6 text-white-600 group-hover:text-white-600"
                            aria-hidden="true"
                          />
                        </div>
                        <div className="flex-auto">
                          <a
                            href={item.href}
                            className="block font-semibold text-black"
                          >
                            {item.name}
                            <span className="absolute inset-0 " />
                          </a>
                          <p className="mt-1 text-black">{item.description}</p>
                        </div>
                      </div>
                    ))}
                  </div>
                  <div className="grid grid-cols-2 divide-x divide-gray-900/5 bg-gray-50">
                    {callsToAction.map((item) => (
                      <a
                        key={item.name}
                        href={item.href} //cuidado con las rutas y el navigate (no combinar)
                        className="flex items-center justify-center gap-x-2.5 p-3 text-sm font-semibold leading-6 text-gray-900 hover:bg-gray-100"
                      >
                        <item.icon
                          className="h-5 w-5 flex-none "
                          aria-hidden="true"
                        />
                        {item.name}
                      </a>
                    ))}
                  </div>
                </Popover.Panel>
              </Transition>
            </Popover>

            <a
              className="text-sm hover:text-gray-300 font-semibold leading-6 text-white hover:cursor-pointer"
              onClick={() => navigateHandler("/search")}
            >
              Search
            </a>

            <a
              className="text-sm hover:text-gray-300 font-semibold leading-6 text-white hover:cursor-pointer"
              onClick={() => navigateHandler("/store")}
            >
              Store
            </a>
            <a
              className="text-sm hover:text-gray-300 font-semibold leading-6 text-white hover:cursor-pointer"
              onClick={() =>
                user["https://localhost:7133/api/roles"] === "Seller"
                  ? navigateHandler("/seller-center")
                  : navigateHandler("/become-seller")
              }
            >
              {user["https://localhost:7133/api/roles"] === "Seller"
                ? "Seller Center"
                : "Become a Seller"}
            </a>
            <a className="text-sm font-semibold leading-6 text-white hover:cursor-pointer">
              <ToggleTheme />
            </a>
          </Popover.Group>
        )}

        <div className="hidden lg:flex lg:flex-1 lg:justify-end">
          {cart.length > 0 && (
            <Badge
              content={cart.length}
              color="white"
              className="mr-6 mt-1 select-none"
            >
              <Tooltip content="My Cart" className="bg-gray-700">
                <ShoppingCartIcon
                  width={30}
                  className="mr-6 select-none cursor-pointer hover:text-gray-300"
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
              className="text-sm font-semibold leading-6 text-white hover:cursor-pointer"
              onClick={() => loginWithRedirect()}
            >
              Log in <span aria-hidden="true">&rarr;</span>
            </a>
          )}
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
              <XMarkIcon className="h-6 w-6" aria-hidden="true" />
            </button>
          </div>
          <div className="mt-6 flow-root bg-fourth">
            <div className="-my-6 divide-y divide-gray-500/10 bg-fourth">
              <div className="space-y-2 py-6 bg-fourth">
                <Disclosure as="div" className="-mx-3 bg-secondary">
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
                        {[...products, ...callsToAction].map((item) => (
                          <Disclosure.Button
                            key={item.name}
                            as="a"
                            href={item.href}
                            className="block rounded-lg py-2 pl-6 pr-3 text-sm font-semibold leading-7 text-gray-900 hover:bg-gray-50"
                          >
                            {item.name}
                          </Disclosure.Button>
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
                  className="-mx-3 block rounded-lg px-3 py-2 text-base font-semibold leading-7 text-gray-900 hover:bg-gray-50"
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
