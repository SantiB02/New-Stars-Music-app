import { createContext, useState } from "react";

export const ThemeContext = createContext();
const valueTheme = localStorage.getItem("theme")

export const ThemeContextProvider = ({ children }) => {
  const [theme, setTheme] = useState(valueTheme);

  const toggleTheme = () => {
    setTheme((prevTheme) => (prevTheme === "LIGHT" ? "DARK" : "LIGHT"));
  };

  return (
    <ThemeContext.Provider value={{ toggleTheme, theme }}>
      {children}
    </ThemeContext.Provider>
  );
};