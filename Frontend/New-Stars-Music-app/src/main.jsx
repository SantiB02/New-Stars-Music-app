import React from "react";
import ReactDOM from "react-dom/client";
import App from "./App.jsx";
import "./index.css";
import { Auth0Provider } from "@auth0/auth0-react";
import { getAuthSettings } from "./api/settings-api.js";

//import { ThemeContextProvider } from "./services/contexts/ThemeProvider.jsx";

import ServerError from "./components/error/ServerError.jsx";


const root = ReactDOM.createRoot(document.getElementById("root"));
getAuthSettings()
  .then((authSettings) => {
    root.render(
      <Auth0Provider
        domain={authSettings.domain}
        clientId={authSettings.clientId}
        authorizationParams={{
          redirect_uri: window.location.origin,
          audience: "https://dev-a64glq5ygldhuy1g.us.auth0.com/api/v2/",
        }}
      >
        <App />
      </Auth0Provider>
    );
  })
  .catch(() => {
    console.error("Error! Backend isn't running!");
    root.render(<ServerError />);
  });
