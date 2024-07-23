import { Typography } from "@material-tailwind/react";
import React from "react";
import styles from "./Dashboard.module.css";

const UsersReport = ({ users, theme }) => {
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
            <thead>
              <tr>
                <th>Email</th>
                <th>Role</th>
                <th>Phone</th>
              </tr>
            </thead>
            <tbody className={theme ? "text-white" : "text-black"}>
              {users.map((user) => (
                <tr key={user.id}>
                  <td>{user.email}</td>
                  <td>{user.role}</td>
                  <td>{user.phone}</td>
                </tr>
              ))}
            </tbody>
          </table>
        </div>
      ) : (
        "Loading users..."
      )}
    </div>
  );
};

export default UsersReport;
