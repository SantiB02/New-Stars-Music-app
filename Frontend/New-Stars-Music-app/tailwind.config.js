/** @type {import('tailwindcss').Config} */
export default {
  content: ["./index.html", "./src/**/*.{js,jsx}"],
  theme: {
    extend: {
      colors: {
        primary: "#242425",
        secondary: "#ff8f0f",
        tertiary: "#b36812ff",
      },
    },
  },
  plugins: [],
};
