import React from "react";
import LoginForm from "./LoginForm";
import NavBar from "../NavBar";
import Footer from "../Footer";

const Login = () => {
  return (
    <div className="flex flex-col min-h-screen">
      <NavBar />
      <div>
        <LoginForm />
      </div>
      <Footer />
    </div>
  );
};

export default Login;
