import React from "react";
import { useTheme } from "../../services/contexts/ThemeProvider";

const ToggleTheme = () => {
  const { theme, toggleTheme } = useTheme();

  const isLight = theme === "light";

  return (
    <div className="flex items-center gap-2 select-none">
      <span className="text-white text-md">
        <svg
          xmlns="http://www.w3.org/2000/svg"
          fill="none"
          viewBox="0 0 24 24"
          strokeWidth={1.5}
          stroke="currentColor"
          className="size-5"
        >
          <path
            strokeLinecap="round"
            strokeLinejoin="round"
            d="M21.752 15.002A9.72 9.72 0 0 1 18 15.75c-5.385 0-9.75-4.365-9.75-9.75 0-1.33.266-2.597.748-3.752A9.753 9.753 0 0 0 3 11.25C3 16.635 7.365 21 12.75 21a9.753 9.753 0 0 0 9.002-5.998Z"
          />
        </svg>
      </span>

      <label
        for="AcceptConditions"
        class="relative block h-8 w-12 [-webkit-tap-highlight-color:transparent]"
      >
        <input
          type="checkbox"
          id="AcceptConditions"
          class="peer sr-only"
          onClick={toggleTheme}
        />

        <span class="absolute inset-0 m-auto h-2 rounded-full bg-gray-300"></span>

        <span class="absolute inset-y-0 start-0 m-auto size-6 rounded-full bg-gray-500 transition-[inset-inline-start] peer-checked:start-6 peer-checked:*:scale-0">
          <span class="absolute inset-0 m-auto size-4 rounded-full bg-gray-200 transition-transform"></span>
        </span>
      </label>

      <span className="text-white text-lg">
        <svg
          xmlns="http://www.w3.org/2000/svg"
          fill="none"
          viewBox="0 0 24 24"
          strokeWidth={1.5}
          stroke="currentColor"
          className="size-6"
        >
          <path
            strokeLinecap="round"
            strokeLinejoin="round"
            d="M12 3v2.25m6.364.386-1.591 1.591M21 12h-2.25m-.386 6.364-1.591-1.591M12 18.75V21m-4.773-4.227-1.591 1.591M5.25 12H3m4.227-4.773L5.636 5.636M15.75 12a3.75 3.75 0 1 1-7.5 0 3.75 3.75 0 0 1 7.5 0Z"
          />
        </svg>
      </span>
    </div>
  );
};

export default ToggleTheme;
