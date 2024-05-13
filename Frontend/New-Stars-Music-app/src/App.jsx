import {
  Navigate,
  RouterProvider,
  createBrowserRouter,
} from "react-router-dom";
import "./App.css";
import Home from "./components/home/Home";
import Login from "./components/login/Login";
import PlayerMusic from "./components/playerMusic/PlayerMusic";

function App() {
  const router = createBrowserRouter([
    { path: "/", element: <Navigate to="/home" replace /> },
    { path: "/home", element: <Home /> },
    { path: "/login", element: <Login /> },
    { path: "/player", element: <PlayerMusic /> },
    { path: "*", element: <>Ups algo salio mal </> },
  ]);
  return (
    <div>
      <RouterProvider router={router} />
    </div>
  );
}

export default App;
