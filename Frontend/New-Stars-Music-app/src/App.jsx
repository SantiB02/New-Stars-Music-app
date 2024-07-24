import { useEffect } from "react";

import "./App.css";

import Home from "./components/home/Home";
import SearchArtists from "./components/playerMusic/SearchArtists";
import PageNotFound from "./components/pageNotFound/PageNotFound";
import NavBar from "./components/NavBar";
import Footer from "./components/Footer";
import Store from "./components/store/Store";
import ProductDetails from "./components/product/ProductDetails";
import SellerCenter from "./components/sellerCenter/SellerCenter";
import BecomeSeller from "./components/becomeSeller/BecomeSeller";
import Protected from "./components/security/Protected";
import SiteInfo from "./components/siteInfo/SiteInfo";
import Payment from "./components/payment/Payment";
import Banner from "./components/banner/Banner";
import LoadingMessage from "./components/common/LoadingMessage";
import { Profile } from "./components/profile/Profile";
import { Cart } from "./components/cart/Cart";
import { Toaster } from "react-hot-toast";
import { Routes, Route } from "react-router-dom";
import { useAuth0 } from "@auth0/auth0-react";
import { setAuthInterceptor } from "./api/api";
import { Settings } from "./components/settings/Settings";
import { useTheme } from "./services/contexts/ThemeProvider";
import Dashboard from "./components/dashboard/Dashboard";
import ShippingDetails from "./components/shippingDetails/ShippingDetails";
import MyOrders from "./components/myOrders/MyOrders";
import FloatingButton from "./components/floatingButton/FloatingButton";
import SellerProtected from "./components/security/SellerProtected";
import AdminProtected from "./components/security/AdminProtected";

function App() {
  const { getAccessTokenSilently, isLoading, isAuthenticated } = useAuth0();
  const { theme } = useTheme();

  useEffect(() => {
    if (!isLoading) {
      setAuthInterceptor(getAccessTokenSilently);
    }
  }, [isLoading]);

  if (isLoading) return <LoadingMessage message="Loading..." />;

  return (
    <>
      <div>
        <Toaster /> {/* allows us to use toast messages for every page */}
      </div>
      {isAuthenticated && <NavBar />}
      <div className={`main-content ${theme ? `root` : `root-light`}`}>
        <Routes>
          <Route path="/" exact element={<Banner />} />
          <Route
            path="/product-details/:productId"
            element={<ProductDetails />}
          />
          <Route path="/info" element={<SiteInfo />} />
          <Route path="*" exact element={<PageNotFound />} />

          <Route element={<Protected />}>
            <Route path="/home" element={<Home />} />
            <Route path="/search" element={<SearchArtists />} />
            <Route path="/store" element={<Store />} />
            <Route path="/my-orders" element={<MyOrders />} />
            <Route path="/become-seller" element={<BecomeSeller />} />
            <Route element={<SellerProtected />}>
              <Route path="/seller-center" element={<SellerCenter />} />
            </Route>
            <Route path="/profile" element={<Profile />} />
            <Route path="/settings" element={<Settings />} />
            <Route path="/cart" element={<Cart />} />
            <Route path="/payment" element={<Payment />} />
            <Route path="/shipping-details" element={<ShippingDetails />} />
            <Route element={<AdminProtected />}>
              <Route path="/dashboard" element={<Dashboard />} />
            </Route>
          </Route>
        </Routes>
      </div>
      <FloatingButton />
      <Footer />
    </>
  );
}

export default App;
