import {
  Navigate,
  RouterProvider,
  createBrowserRouter,
} from "react-router-dom";
import "./App.css";
import Home from "./components/home/Home";

function App() {
  const router = createBrowserRouter([
    { path: "/", element: <Navigate to="/home" replace /> },
    { path: "/home", element: <Home /> },
    //{ path: "/login", element: <Login /> },
    //{path: "*", element:}
  ]);
  return (
    <div>
      <RouterProvider router={router} />
    </div>
  );
}

export default App;
