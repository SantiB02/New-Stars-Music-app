import { useState, useEffect } from "react";
import api from "../../api/api";
import { useAuth0 } from "@auth0/auth0-react";
import { Avatar } from "@material-tailwind/react";
export const Profile = () => {
  const { user } = useAuth0();
  return (
    <div className="flex items-center justify-center min-h-screen ">
      <div className=" shadow-lg rounded-lg p-8 border-2 border-gray-700 w-full max-w-2xl">
        <h2 className="text-2xl font-bold mb-6 border-2 border-primary border-b-gray-800">Profile</h2>
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

          <div className="col-span-2">
            <h3 className="font-semibold">Zone Info</h3>
            <p>{user.zoneinfo}</p>
          </div>
          <div className="col-span-2">
            <h3 className="font-semibold">Locale</h3>
            <p>{user.locale}</p>
          </div>
          <div className="col-span-2">
            <h3 className="font-semibold">Phone Number</h3>
            <p>{user.phone_number}</p>
          </div>
          <div className="col-span-2">
            <h3 className="font-semibold">Address</h3>
            <p>{user.address}</p>
          </div>
        </div>
      </div>
    </div>
  );
};
