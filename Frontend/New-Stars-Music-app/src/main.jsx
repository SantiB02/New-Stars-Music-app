import React from "react";
import ReactDOM from "react-dom/client";
import App from "./App.jsx";
import "./index.css";
import { Auth0Provider } from "@auth0/auth0-react";

const root = ReactDOM.createRoot(document.getElementById("root"));
root.render(
  <React.StrictMode>
    <Auth0Provider
      domain="dev-a64glq5ygldhuy1g.us.auth0.com"
      clientId="tlfvwom9x9e6ylmyXrLxxKYhth1hKA5l"
      authorizationParams={{ redirectUri: window.location.origin }}
    >
      <App />
    </Auth0Provider>
  </React.StrictMode>
);
