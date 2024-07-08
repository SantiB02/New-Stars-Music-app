import React, { useState, useEffect } from "react";
import ReactDOM from "react-dom/client";
import App from "./App.jsx";
import "./index.css";
import { Auth0Provider } from "@auth0/auth0-react";
import { getAuthSettings } from "./api/settings-api.js";
import ServerError from "./components/error/ServerError.jsx";
import ThemeProvider from "./services/contexts/ThemeProvider.jsx";
import { CartProvider } from "./services/contexts/CartContext.jsx";
import { BrowserRouter, useLocation } from "react-router-dom";
import LoadingMessage from "./components/common/LoadingMessage.jsx";

const AppProviders = ({ children }) => {
  const location = useLocation();
  const [authSettings, setAuthSettings] = useState(null);
  const [error, setError] = useState(null);

  useEffect(() => {
    getAuthSettings(setError).then((settings) => setAuthSettings(settings));
  }, []);

  if (error !== null) {
    return <ServerError errorCode={error} />;
  }

  if (!authSettings) {
    return <LoadingMessage message="Loading..." />;
  }

  return (
    <Auth0Provider
      domain={authSettings.domain}
      clientId={authSettings.clientId}
      authorizationParams={{
        redirect_uri: "http://localhost:5173/home",
        audience: authSettings.audience,
      }}
    >
      <ThemeProvider>
        <CartProvider>{children}</CartProvider>
      </ThemeProvider>
    </Auth0Provider>
  );
};

const AppWrapper = () => (
  <BrowserRouter>
    <AppProviders>
      <App />
    </AppProviders>
  </BrowserRouter>
);

const root = ReactDOM.createRoot(document.getElementById("root"));
root.render(
  <React.StrictMode>
    <AppWrapper />
  </React.StrictMode>
);
