import { Button, Checkbox, Typography } from "@material-tailwind/react";
import React, { useEffect, useState } from "react";
import api from "../../api/api";
import toast from "react-hot-toast";
import LoadingMessage from "../common/LoadingMessage";

export const Settings = () => {
  const [isLoading, setIsLoading] = useState(false);
  const [darkModeOn, setDarkModeOn] = useState(false);
  const [applyingChanges, setApplyingChanges] = useState(false);

  useEffect(() => {
    const fetchDarkModePreference = async () => {
      setIsLoading(true);
      try {
        const response = await api.get("/users/has-dark-mode-on");
        const hasDarkModeOn = response.data;
        if (hasDarkModeOn === true) {
          setDarkModeOn(true);
        }
      } catch (error) {
        toast.error(
          "Error getting your dark mode preference. Try again later!"
        );
        console.error("Error fetching user's dark mode preference", error);
      } finally {
        setIsLoading(false);
      }
    };

    fetchDarkModePreference();
  }, []);

  const handleDarkModeSave = async () => {
    setApplyingChanges(true);
    try {
      await api.put(`/users/dark-mode-on/${darkModeOn}`);
      toast.success("Changes applied successfully!");
    } catch (error) {
      toast.error("Error applying your changes. Please try again later!");
      console.error("Error applying changes");
    } finally {
      setApplyingChanges(false);
    }
  };

  if (isLoading) return <LoadingMessage message="Loading settings..." />;

  return (
    <div className="ml-6 pt-6">
      <Typography variant="h4" className="font-light">
        {" "}
        Do you want to keep the "Dark Mode" turned on?
      </Typography>
      <div className="flex mt-2 items-center">
        <Checkbox
          checked={darkModeOn}
          onChange={() => setDarkModeOn(!darkModeOn)}
          color="orange"
        />
        <Typography variant="h5">
          {" "}
          <span className={`${darkModeOn && "text-orange-700"}`}>
            Always
          </span> /{" "}
          <span className={`${!darkModeOn && "text-orange-700"}`}>Nope</span>
        </Typography>
      </div>
      <Button
        disabled={applyingChanges}
        className="bg-orange-700 mt-4"
        onClick={handleDarkModeSave}
      >
        {!applyingChanges ? "Save Changes" : "Applying Changes"}
      </Button>
    </div>
  );
};
