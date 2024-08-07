import { createContext, useContext, useEffect, useState } from "react";
import api from "../../api/api";
import { useAuth0 } from "@auth0/auth0-react";

export const themeContext = createContext();

export const useTheme = () => {
  const context = useContext(themeContext);
  return context;
};
const ThemeProvider = ({ children }) => {
  const [theme, setTheme] = useState(() => {
    const savedTheme = localStorage.getItem("theme");
    return savedTheme === "true";
  });
  const { user, isAuthenticated, getAccessTokenSilently } = useAuth0();

  useEffect(() => {
    const fetchDarkModePreference = async () => {
      try {
        const deletedResponse = await api.get(
          `/users/is-deleted/${user?.sub}`,
          {
            validateStatus: (status) => {
              return status === 200 || status === 404; // Accept only 200 y 404 as valid responses (to avoid throwing an error)
            },
          }
        );
        const isUserDeleted = deletedResponse.data;

        if (deletedResponse.status !== 404 && isUserDeleted === false) {
          const token = await getAccessTokenSilently();
          const response = await api.get("/users/has-dark-mode-on", {
            headers: {
              Authorization: `Bearer ${token}`,
            },
          });
          const hasDarkModeOn = response.data;
          if (hasDarkModeOn === true) {
            setTheme(true);
          }
        }
      } catch (error) {
        console.error("Error fetching user's dark mode preference", error);
      }
    };

    if (isAuthenticated) {
      fetchDarkModePreference();
    }
  }, [isAuthenticated, getAccessTokenSilently]);

  const toggleTheme = () => {
    setTheme(!theme);
  };

  useEffect(() => {
    localStorage.setItem("theme", theme.toString());
  }, [theme]);

  return (
    <themeContext.Provider value={{ theme, toggleTheme }}>
      {children}
    </themeContext.Provider>
  );
};
export default ThemeProvider;
