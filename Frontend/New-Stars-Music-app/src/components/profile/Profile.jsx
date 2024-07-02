import { useState, useEffect } from "react";
import api from "../../api/api";
import { useAuth0 } from "@auth0/auth0-react";
import {
  Avatar,
  Button,
  Dialog,
  DialogBody,
  DialogHeader,
  DialogFooter,
} from "@material-tailwind/react";
import { useTheme } from "../../services/contexts/ThemeProvider";
import LoadingMessage from "../common/LoadingMessage";
import toast from "react-hot-toast";
export const Profile = () => {
  const { user, logout } = useAuth0();
  const { theme } = useTheme();
  const [open, setOpen] = useState(false);
  const [isLoading, setIsLoading] = useState(false);

  const handleOpen = () => setOpen(!open);

  const deleteAccountHandler = async () => {
    setIsLoading(true);
    try {
      await api.delete("/users");
      logout();
    } catch (error) {
      console.error("Error deleting profile");
      toast.error(
        "There was an error deleting your user... Please try again later!"
      );
    } finally {
      setIsLoading(false);
    }
  };

  if (isLoading) return <LoadingMessage message="Deleting your account..." />;

  return (
    <div
      className={
        theme
          ? "flex items-center justify-center mt-16"
          : "flex items-center justify-center mt-16 bg-gray-200"
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

          <div className="col-span-2 mt-6" onClick={handleOpen}>
            <Button color="red">Delete my profile</Button>
          </div>
          <Dialog open={open} handler={handleOpen}>
            <DialogHeader>
              Are you sure you want to delete your account?
            </DialogHeader>
            <DialogBody>
              Once you confirm this action, your account will be suspended for
              30 days. After this period, it will be permanently deleted from
              our database. If you wish to recover your account before this
              period ends or ask for additional information, please get in touch
              with us through{" "}
              <a
                href="mailto:support@newstarsmusic.com"
                target="_blank"
                className="italic hover:underline text-orange-600"
              >
                support@newstarsmusic.com
              </a>
              .
            </DialogBody>
            <DialogFooter>
              <Button
                variant="text"
                color="blue-gray"
                onClick={handleOpen}
                className="mr-1"
              >
                <span>Cancel</span>
              </Button>
              <Button
                variant="gradient"
                color="red"
                onClick={deleteAccountHandler}
              >
                <span>Delete my account</span>
              </Button>
            </DialogFooter>
          </Dialog>
        </div>
      </div>
    </div>
  );
};
