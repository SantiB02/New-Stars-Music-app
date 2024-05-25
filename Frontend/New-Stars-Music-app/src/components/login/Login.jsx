import React from "react";
import LoginForm from "./LoginForm";
import NavBar from "../NavBar";
import Footer from "../Footer";

const Login = () => {
  return (
    <div className="flex flex-col min-h-screen">
      <div>
        <LoginForm />
      </div>
    </div>
  );
};

export default Login;
