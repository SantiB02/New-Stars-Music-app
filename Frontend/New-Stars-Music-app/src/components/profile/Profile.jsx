import { useState, useEffect } from "react";
import api from "../../api/api";
import { useAuth0 } from "@auth0/auth0-react";
import { Avatar, Button } from "@material-tailwind/react";
import { useTheme } from "../../services/contexts/ThemeProvider";
export const Profile = () => {
  const { user } = useAuth0();
  const { theme } = useTheme();
  return (
    <div
      className={
        theme
          ? "flex items-center justify-center min-h-screen "
          : "flex items-center justify-center min-h-screen bg-gray-200"
      }
    >
      <div
        className={
          theme
            ? " shadow-lg rounded-lg p-8 border-2 border-gray-700 w-full max-w-2xl"
            : " shadow-lg rounded-lg p-8 border-2 border-blue-200 w-full max-w-2xl bg-white text-black"
        }
      >
        <h2
          className={
            theme
              ? "text-2xl font-bold mb-6 border-2 border-primary border-b-gray-800"
              : "text-2xl font-bold mb-6 border-2 border-white border-b-blue-600"
          }
        >
          Profile
        </h2>
        <div className="grid grid-cols-2 gap-4 text-center">
          <div className="col-span-2">
            <Avatar src={user.picture} alt="avatar" size="xxl" />
          </div>
          <div className="col-span-2">
            <h3 className="font-semibold">Email</h3>
            <p>{user.email}</p>
          </div>
          <div className="col-span-2">
            <h3 className="font-semibold">Name</h3>
            <p>{user.name}</p>
          </div>
          {user.address && (
            <div className="col-span-2">
              <h3 className="font-semibold">Address</h3>
              <p>{user.address}</p>
            </div>
          )}
          {user.phone_number && (
            <div className="col-span-2">
              <h3 className="font-semibold">Phone Number</h3>
              <p>{user.phone_number}</p>
            </div>
          )}

          <div className="col-span-2 mt-6">
            <Button color="red">Delete my profile</Button>
          </div>
        </div>
      </div>
    </div>
  );
};
