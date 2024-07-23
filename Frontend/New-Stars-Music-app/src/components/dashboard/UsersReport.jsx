import {
  Button,
  Dialog,
  DialogHeader,
  DialogBody,
  DialogFooter,
  Typography,
} from "@material-tailwind/react";
import React, { useEffect, useState } from "react";
import styles from "./Dashboard.module.css";
import api from "../../api/api";
import toast from "react-hot-toast";
import LoadingMessage from "../common/LoadingMessage";
import { useAuth0 } from "@auth0/auth0-react";

const UsersReport = ({ theme }) => {
  const [isLoading, setIsLoading] = useState(false);
  const [isUpgradingUser, setIsUpgradingUser] = useState(false);
  const [open, setOpen] = useState(false);
  const [users, setUsers] = useState([]);
  const [userToUpgrade, setUserToUpgrade] = useState({ id: "", email: "" });
  const [usersWaitingValidation, setUsersWaitingValidation] = useState(null);
  const { user } = useAuth0();
  const auth0UserEmail = user?.email;

  useEffect(() => {
    const fetchUsers = async () => {
      setIsLoading(true);
      try {
        const response = await api.get("/users");
        const allUsers = response.data;
        setUsers(allUsers);
      } catch (error) {
        toast.error("Error getting all users!");
        console.error("Error fetching all users", error);
      } finally {
        setIsLoading(false);
      }
    };

    fetchUsers();
  }, []);

  const handleOpen = () => setOpen(!open);

  const handleUpgradeToSeller = async (clientId) => {
    setIsUpgradingUser(true);
    try {
      await api.put(`/users/${clientId}/role/Seller`);
      const updatedUsers = [...users];
      const index = users.findIndex((user) => user.id === clientId);
      updatedUsers[index].waitingValidation = false;
      updatedUsers[index].role = "Seller";
      setUsers(updatedUsers);
      toast.success("User upgraded to seller successfully!");
    } catch (error) {
      toast.error("Error upgrading user!");
      console.error("Error upgrading user", error);
    } finally {
      setOpen(false);
    }
  };

  if (isLoading) return <LoadingMessage message="Loading users..." />;

  return (
    <div>
      {users && users.length > 0 ? (
        <div>
          <Typography
            variant="h4"
            className={theme ? "text-white" : "text-black"}
          >
            Users
          </Typography>
          <table
            className={theme ? styles["data-table-dark"] : styles["data-table"]}
          >
            <thead className="text-sm">
              <tr>
                <th>Email</th>
                <th>Address</th>
                <th>Location</th>
                <th>Role</th>
                <th>Phone</th>
                <th>Waiting Validation</th>
              </tr>
            </thead>
            <tbody
              className={theme ? "text-white text-sm" : "text-black text-sm"}
            >
              {users.map((user) => (
                <tr key={user.id}>
                  <td>
                    {user.email}{" "}
                    <span className="text-orange-600">
                      {auth0UserEmail === user.email && "(you)"}
                    </span>
                  </td>
                  <td>{`${user.address || "unknown"} ${
                    user.apartment || ""
                  }`}</td>
                  <td>
                    {user.city && user.country
                      ? `${user.city}, ${user.country}`
                      : "unknown"}
                  </td>
                  <td>{user.role}</td>
                  <td>{user.phone}</td>
                  <td>
                    {user.waitingValidation ? (
                      <Button
                        onClick={() => {
                          setUserToUpgrade({ id: user.id, email: user.email });
                          handleOpen();
                        }}
                        color="green"
                        className="px-2"
                        size="sm"
                      >
                        Upgrade
                      </Button>
                    ) : (
                      "No"
                    )}
                  </td>
                </tr>
              ))}
            </tbody>
          </table>
          <Dialog open={open} handler={handleOpen}>
            <DialogHeader>
              Upgrade{" "}
              <span className="text-orange-600">
                &nbsp;{userToUpgrade.email}&nbsp;
              </span>{" "}
              to seller?
            </DialogHeader>
            <DialogBody>
              Are you sure you want to upgrade{" "}
              <span className="text-orange-600">{userToUpgrade.email}</span> to
              seller? This action will enable them to upload and sell products
              in <i>New Stars Music</i>.
            </DialogBody>
            <DialogFooter>
              <Button
                variant="text"
                color="red"
                onClick={handleOpen}
                className="mr-4"
                disabled={isUpgradingUser}
              >
                Cancel
              </Button>
              <Button
                variant="gradient"
                color="green"
                onClick={() => handleUpgradeToSeller(userToUpgrade.id)}
                disabled={isUpgradingUser}
              >
                {isUpgradingUser
                  ? "Upgrading to seller..."
                  : "Upgrade to seller"}
              </Button>
            </DialogFooter>
          </Dialog>
        </div>
      ) : (
        "Loading users..."
      )}
    </div>
  );
};

export default UsersReport;
