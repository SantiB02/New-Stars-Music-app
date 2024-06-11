import React from "react";
import ReactDOM from "react-dom/client";
import App from "./App.jsx";
import "./index.css";
import { Auth0Provider } from "@auth0/auth0-react";
import { getAuthSettings } from "./api/settings-api.js";

const root = ReactDOM.createRoot(document.getElementById("root"));
getAuthSettings().then((authSettings) => {
  root.render(
    <React.StrictMode>
      <Auth0Provider
        domain={authSettings.domain}
        clientId={authSettings.clientId}
        authorizationParams={{ redirect_uri: window.location.origin }}
      >
        <App />
      </Auth0Provider>
    </React.StrictMode>
  );
});
