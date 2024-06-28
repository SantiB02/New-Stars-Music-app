import {
  BrowserRouter as Router,
  Routes,
  Route,
  Navigate,
} from "react-router-dom";
import "./App.css";
import Home from "./components/home/Home";
import PlayerMusic from "./components/playerMusic/PlayerMusic";
import PageNotFound from "./components/pageNotFound/PageNotFound";
import NavBar from "./components/NavBar";
import Footer from "./components/Footer";
import Store from "./components/store/Store";
import ProductDetails from "./components/product/ProductDetails";
import { Toaster } from "react-hot-toast";
import Banner from "./components/banner/Banner";
import Protected from "./components/security/Protected";
import SiteInfo from "./components/siteInfo/SiteInfo";
import { useEffect } from "react";
import { useAuth0 } from "@auth0/auth0-react";
import { setAuthInterceptor } from "./api/api";
import { getToken } from "./api/auth";
import LoadingMessage from "./components/common/LoadingMessage";
import { Profile } from "./components/profile/Profile";
import { Settings } from "./components/settings/Settings";
import { Cart } from "./components/cart/Cart";
import { useAuthInterceptor } from "./hooks/useAuthInterceptor";

function App() {
  const auth0 = useAuth0();
  const { isAuthenticated, getAccessTokenSilently, isLoading } = useAuth0();

  useAuthInterceptor(isLoading, getAccessTokenSilently);

  if (isLoading) return <LoadingMessage message="Loading..." />;

  return (
    <Router>
      <div>
        <Toaster /> {/* allows us to use toast messages for every page */}
      </div>
      <div>
        <NavBar />
        <div className="main-content">
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
              <Route path="/search" element={<PlayerMusic />} />
              <Route path="/store" element={<Store />} />
              <Route path="/profile" element={<Profile />} />
              <Route path="/settings" element={<Settings />} />
              <Route path="/cart" element={<Cart />} />
            </Route>
          </Routes>
        </div>
        <Footer />
      </div>
    </Router>
  );
}

export default App;
