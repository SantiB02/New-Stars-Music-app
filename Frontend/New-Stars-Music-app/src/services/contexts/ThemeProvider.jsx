import { createContext, useContext, useEffect, useState } from "react";

export const themeContext = createContext();

export const useTheme = () => {
  const context = useContext(themeContext);
  return context;
};

const ThemeProvider = ({ children }) => {
  const [theme, setTheme] = useState(
    localStorage.getItem("theme") === "true" ? true : false
  );

  const toggleTheme = () => {
    setTheme(!theme);
  };

  useEffect(() => {
    localStorage.setItem("theme", theme);
  }, [theme]);

  return (
    <themeContext.Provider value={{ theme, toggleTheme }}>
      {children}
    </themeContext.Provider>
  );
};

export default ThemeProvider;