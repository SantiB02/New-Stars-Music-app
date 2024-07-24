import React, { useEffect, useState } from "react";
import FeaturedProducts from "./FeaturedProducts";
import Music from "./Music";
import { getFeaturedProducts, getWelcomeMessages } from "../../services/productsService";
import { useAuth0 } from "@auth0/auth0-react";
import { useTheme } from "../../services/contexts/ThemeProvider";
import { useNavigate } from "react-router-dom";
import { Typography } from "@material-tailwind/react";
import LoadingMessage from "../common/LoadingMessage";
import api, { setAuthInterceptor } from "../../api/api";
import SearchArtists from "../playerMusic/SearchArtists";

const Home = () => {
  const [featuredProducts, setFeaturedProducts] = useState([]);
  const [isLoadingPage, setIsLoadingPage] = useState(false);
  const [messages, setMessages] = useState([]);
  const { user, getAccessTokenSilently, isLoading, logout } = useAuth0();
  const { theme } = useTheme();
  const navigate = useNavigate();

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

  if (isLoadingPage) return <LoadingMessage message="Loading..." />;

  return (
    <div
      className={
        theme
          ? "flex flex-col min-h-screen"
          : "flex flex-col min-h-screen bg-gray-200 text-black"
      }
    >
      <div className="flex-grow overflow-auto flex flex-col md:flex-row mt-4 mb-10">
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
          {messages.length > 0 && (
            <div className="mt-8">
              
              {messages.map((message) => (
                  <Typography variant="h4" className="ml-6 font-light" key={message.id}>{message.messageBody}</Typography>
                ))}
              
            </div>
          )}
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
