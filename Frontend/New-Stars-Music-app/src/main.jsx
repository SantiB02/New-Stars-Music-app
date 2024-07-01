import React, { useState, useEffect } from "react";
import ReactDOM from "react-dom/client";
import App from "./App.jsx";
import "./index.css";
import { Auth0Provider } from "@auth0/auth0-react";
import { getAuthSettings } from "./api/settings-api.js";
import ServerError from "./components/error/ServerError.jsx";
import ThemeProvider from "./services/contexts/ThemeProvider.jsx";
import { BrowserRouter, useLocation } from "react-router-dom";

const Auth0ProviderWithRouter = ({ children }) => {
  const location = useLocation();
  const [authSettings, setAuthSettings] = useState(null);
  const [error, setError] = useState(null);

  useEffect(() => {
    getAuthSettings()
      .then((settings) => setAuthSettings(settings))
      .catch((err) => setError(err));
  }, []);

  if (error) {
    return <ServerError />;
  }

  if (!authSettings) {
    return <div>Loading...</div>;
  }

  return (
    <Auth0Provider
      domain={authSettings.domain}
      clientId={authSettings.clientId}
      authorizationParams={{
        redirect_uri: window.location.origin,
        audience: "https://dev-a64glq5ygldhuy1g.us.auth0.com/api/v2/",
        request_url: window.location.origin + location.pathname,
      }}
    >
      {children}
    </Auth0Provider>
  );
};

const AppWrapper = () => (
  <BrowserRouter>
    <Auth0ProviderWithRouter>
      <ThemeProvider>
        <App />
      </ThemeProvider>
    </Auth0ProviderWithRouter>
  </BrowserRouter>
);

const root = ReactDOM.createRoot(document.getElementById("root"));
root.render(<AppWrapper />);
