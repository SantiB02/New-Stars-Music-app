import {
  BrowserRouter as Router,
  Routes,
  Route,
  Navigate,
} from "react-router-dom";
import "./App.css";
import Home from "./components/home/Home";
import Login from "./components/login/Login";
import PlayerMusic from "./components/playerMusic/PlayerMusic";
import PageNotFound from "./components/pageNotFound/PageNotFound";
import NavBar from "./components/NavBar";
import Footer from "./components/Footer";
import Store from "./components/store/Store";
import ProductDetails from "./components/product/ProductDetails";
import { Toaster } from "react-hot-toast";

function App() {
  const router = [
    { path: "/", element: <Home /> },
    { path: "/login", element: <Login /> },
    { path: "/search", element: <PlayerMusic /> },
    { path: "/store", element: <Store /> },
    { path: "/product-details", element: <ProductDetails /> },
    { path: "*", element: <PageNotFound /> },
  ];
  return (
    <Router>
      <div>
        <Toaster /> {/* allows us to use toast messages for every page */}
      </div>
      <div>
        <NavBar />
        <div className="main-content">
          <Routes>
            {router.map(({ path, element }) => (
              <Route key={path} path={path} element={element} />
            ))}
          </Routes>
        </div>
        <Footer />
      </div>
    </Router>
  );
}

export default App;
