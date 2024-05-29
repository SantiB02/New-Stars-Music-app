/** @type {import('tailwindcss').Config} */
export default {
  content: ["./index.html", "./src/**/*.{js,jsx}"],
  theme: {
    extend: {
      colors: {
        primary: "#242425",
        secondary: "#e25418",
        third: "#e96d30",
        fourth: "#f18647",
      },
    },
  },
  plugins: [],
};
