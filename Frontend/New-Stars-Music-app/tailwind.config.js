/** @type {import('tailwindcss').Config} */
export default {
  content: ["./index.html", "./src/**/*.{js,jsx}"],
  theme: {
    extend: {
      colors: {
        primary: "#242425",
        secondary: "#ff8f0f",
        third: "#b36812ff",
        fourth: "#d6ae7fff",
      },
    },
  },
  plugins: [],
};
