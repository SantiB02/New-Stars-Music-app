import React, { useContext } from "react";
import { ThemeContext } from "../../services/contexts/ThemeProvider";

const ToggleTheme = () => {
  const { theme, toggleTheme } = useContext(ThemeContext);
  localStorage.setItem("theme", theme);
  const handleToggleTheme = () => {
    toggleTheme();
    console.log(theme);
  };
  return (
    <label class="relative inline-flex items-center cursor-pointer">
  <input class="sr-only peer" value="" type="checkbox" onClick={handleToggleTheme}/>
  <div
    class="w-20 h-10 rounded-full ring-0 peer duration-500 outline-none bg-gray-400 overflow-hidden before:flex before:items-center before:justify-center after:flex after:items-center after:justify-center before:content-['☀️'] before:absolute before:h-8 before:w-8 before:top-1/2 before:bg-white before:rounded-full before:left-1 before:-translate-y-1/2 before:transition-all before:duration-700 peer-checked:before:opacity-0 peer-checked:before:rotate-90 peer-checked:before:-translate-y-full shadow-lg shadow-gray-400 peer-checked:shadow-lg peer-checked:shadow-gray-700 peer-checked:bg-[#383838] after:content-['🌑'] after:absolute after:bg-[#1d1d1d] after:rounded-full after:top-[4px] after:right-1 after:translate-y-full after:w-8 after:h-8 after:opacity-0 after:transition-all after:duration-700 peer-checked:after:opacity-100 peer-checked:after:rotate-180 peer-checked:after:translate-y-0"
  ></div>
</label>

  );
};

export default ToggleTheme;
