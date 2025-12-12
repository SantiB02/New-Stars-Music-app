/** @type {import('tailwindcss').Config} */
const withMT = require("@material-tailwind/react/utils/withMT");

module.exports = withMT({
  content: ["./index.html", "./src/**/*.{js,jsx}"],
  theme: {
    extend: {
      colors: {
        primary: "#13747d",
        secondary: "#166665",
        third: "#2eb8ac",
        fourth: "#80a8a8",
        fivenigth: "#1A1C1E"
      },
    },fontFamily: {
        sans: ['Inter', 'ui-sans-serif', 'system-ui', 'Segoe UI', 'Roboto'],
        display: ['Poppins', 'sans-serif']
      },
  },
  plugins: [],
});
