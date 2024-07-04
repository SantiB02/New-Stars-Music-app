import React, { useEffect, useState } from "react";
import FeaturedProducts from "./FeaturedProducts";
import Music from "./Music";
import { getAllProducts } from "../../services/productsService";
import { useAuth0 } from "@auth0/auth0-react";
import { useTheme } from "../../services/contexts/ThemeProvider";
import { useLocation, useNavigate } from "react-router-dom";
import { Typography } from "@material-tailwind/react";
import LoadingMessage from "../common/LoadingMessage";
import api, { setAuthInterceptor } from "../../api/api";
import { ensureUser } from "../../services/userService";
import { useRoles } from "../../hooks/useRoles";

const Home = () => {
  const [products, setProducts] = useState([]);
  const [isLoadingPage, setIsLoadingPage] = useState(false);
  const { user, getAccessTokenSilently, isLoading, logout } = useAuth0();
  const { theme } = useTheme();
  const navigate = useNavigate();

  useEffect(() => {
    if (!isLoading) {
      setAuthInterceptor(getAccessTokenSilently);
    }
  }, [isLoading]);

  useEffect(() => {
    const fetchProducts = async () => {
      try {
        const allProducts = await getAllProducts();
        setProducts(allProducts);
        console.log("USER", user);
      } catch (error) {
        console.error("Error fetching all products:", error);
      }
    };
    const ensureAuthUser = async () => {
      const response = await api.get(`/users/is-deleted/${user?.sub}`, {
        validateStatus: (status) => {
          return status === 200 || status === 404; // Accept only 200 y 404 as valid responses (to avoid throwing an error)
        },
      });
      const isUserDeleted = response.data;

      if (!isUserDeleted || response.status === 404) {
        localStorage.removeItem("isAccountDeleted");
        ensureUser(user?.email);
      } else {
        localStorage.setItem("isAccountDeleted", "true");
        await logout();
      }
    };

    const initialize = async () => {
      setIsLoadingPage(true);
      await ensureAuthUser();
      await fetchProducts();
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
          <div className="mt-8">
            <FeaturedProducts products={products} isLoading={isLoadingPage} />
          </div>
        </div>
        <div className="md:w-1/2 p-4">
          <div className="h-full">
            <Music />
          </div>
        </div>
      </div>
    </div>
  );
};

export default Home;
