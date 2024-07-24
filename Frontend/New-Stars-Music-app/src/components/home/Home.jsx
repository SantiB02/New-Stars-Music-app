import React, { useEffect, useRef, useState } from "react";
import "./Home.css";
import FeaturedProducts from "./FeaturedProducts";
import Music from "./Music";
import {
  getFeaturedProducts,
  getWelcomeMessages,
} from "../../services/productsService";
import { useAuth0 } from "@auth0/auth0-react";
import { useTheme } from "../../services/contexts/ThemeProvider";
import { useNavigate } from "react-router-dom";
import { Typography, IconButton } from "@material-tailwind/react";
import LoadingMessage from "../common/LoadingMessage";
import api, { setAuthInterceptor } from "../../api/api";
import SearchArtists from "../playerMusic/SearchArtists";
import { ChevronLeftIcon, ChevronRightIcon } from "@heroicons/react/24/outline";

const Home = () => {
  const [featuredProducts, setFeaturedProducts] = useState([]);
  const [isLoadingPage, setIsLoadingPage] = useState(false);
  const [messages, setMessages] = useState([]);
  const [currentMessageIndex, setCurrentMessageIndex] = useState(0);
  const { user, getAccessTokenSilently, isLoading, logout } = useAuth0();
  const { theme } = useTheme();
  const navigate = useNavigate();
  const messageRef = useRef(null);
  const [isOverflowing, setIsOverflowing] = useState(false);

  useEffect(() => {
    if (!isLoading) {
      setAuthInterceptor(getAccessTokenSilently);
    }
  }, [isLoading]);

  useEffect(() => {
    const fetchFeaturedProducts = async () => {
      try {
        const featuredProducts = await getFeaturedProducts(100);
        setFeaturedProducts(featuredProducts);
      } catch (error) {
        console.error("Error fetching all products:", error);
      }
    };

    const fetchMessages = async () => {
      try {
        const messages = await getWelcomeMessages();
        setMessages(messages);
      } catch (error) {
        console.error("Error fetching messages:", error);
      }
    };

    const ensureAuthUser = async () => {
      const response = await api.get(`/users/is-deleted/${user?.sub}`, {
        validateStatus: (status) => {
          return status === 200 || status === 404; // Accept only 200 y 404 as valid responses (to avoid throwing an error)
        },
      });
      const isUserDeleted = response.data;

      if (response.status === 404) {
        await api.post(`/users/${user.email}`);
      }

      if (!isUserDeleted) {
        localStorage.removeItem("isAccountDeleted");
      } else if (isUserDeleted === true) {
        localStorage.setItem("isAccountDeleted", "true");
        await logout();
      }
    };

    const initialize = async () => {
      setIsLoadingPage(true);
      await ensureAuthUser();
      await fetchFeaturedProducts();
      await fetchMessages();
      setIsLoadingPage(false);
    };

    if (user) {
      initialize();
    }
  }, [user, logout]);

  useEffect(() => {
    const checkOverflow = () => {
      if (messageRef.current) {
        const isOverflowing =
          messageRef.current.scrollWidth > messageRef.current.clientWidth;
        setIsOverflowing(isOverflowing);
      }
    };

    checkOverflow();
    window.addEventListener("resize", checkOverflow);
    return () => {
      window.removeEventListener("resize", checkOverflow);
    };
  }, [messages, currentMessageIndex]);

  const handlePreviousMessage = () => {
    setCurrentMessageIndex((prevIndex) =>
      prevIndex > 0 ? prevIndex - 1 : messages.length - 1
    );
  };

  const handleNextMessage = () => {
    setCurrentMessageIndex((prevIndex) =>
      prevIndex < messages.length - 1 ? prevIndex + 1 : 0
    );
  };

  if (isLoadingPage) return <LoadingMessage message="Loading..." />;

  return (
    <div
      className={
        theme
          ? "flex flex-col min-h-screen"
          : "flex flex-col min-h-screen bg-gray-200 text-black"
      }
    >
      {messages.length > 0 && (
        <div className="mt-4 flex items-center justify-center">
          <IconButton
            size="sm"
            className="z-10 mr-2 bg-orange-700 outline-none focus:outline-none"
            onClick={handlePreviousMessage}
          >
            <ChevronLeftIcon className="h-6 w-6" />
          </IconButton>
          <div className="overflow-auto">
            <Typography className="mx-6 max-w-xl whitespace-nowrap font-light text-md">
              {messages[currentMessageIndex].messageBody}
            </Typography>
          </div>
          <IconButton
            size="sm"
            className="z-10 ml-2 bg-orange-700 outline-none focus:outline-none"
            onClick={handleNextMessage}
          >
            <ChevronRightIcon className="h-6 w-6" />
          </IconButton>
        </div>
      )}
      <div className="flex-grow overflow-auto flex flex-col md:flex-row mt-o mb-10">
        <div className="md:w-1/2 p-4">
          <Typography variant="h2" className="ml-6 font-light">
            Welcome back,{" "}
            <a
              className="text-orange-800 cursor-pointer hover:underline"
              onClick={() => navigate("/profile")}
            >
              {user.nickname}
            </a>
            !
          </Typography>
          <div className="mt-8">
            <FeaturedProducts
              products={featuredProducts}
              isLoading={isLoadingPage}
            />
          </div>
        </div>
        <div className="md:w-1/2 p-4">
          <div className="h-full">
            <SearchArtists isHomePage={true} />
          </div>
        </div>
      </div>
    </div>
  );
};

export default Home;
