import { Typography, Button } from "@material-tailwind/react";
import React, { useEffect, useState } from "react";
import Swal from "sweetalert2";
import api from "../../api/api";
import styles from "./Dashboard.module.css";
import toast from "react-hot-toast";
import LoadingMessage from "../common/LoadingMessage";

const MessageReport = ({ theme }) => {
  const [isLoading, setIsLoading] = useState(false);
  const [messages, setMessages] = useState(null);

  useEffect(() => {
    const fetchMessages = async () => {
      setIsLoading(true);
      try {
        const response = await api.get("/messages");
        const messages = response.data;
        setMessages(messages);
      } catch (error) {
        toast.error("Error getting messages!");
        console.error("Error fetching messages", error);
      } finally {
        setIsLoading(false);
      }
    };

    fetchMessages();
  }, []);

  const createMessage = async () => {
    const { value: messageBody } = await Swal.fire({
      title: "Create new message",
      input: "textarea",
      inputPlaceholder: "Enter your message here...",
      showCancelButton: true,
    });

    if (messageBody) {
      try {
        const response = await api.post("/messages", { messageBody });

        if (response.status === 200) {
          Swal.fire("Message created successfully!", "", "success");
          const updatedMessages = await api.get("/messages");
          setMessages(updatedMessages.data);
        } else {
          Swal.fire("Error creating message", "", "error");
        }
      } catch (error) {
        console.error("Error creating message", error);
        Swal.fire("Error creating message", "", "error");
      }
    }
  };

  const editMessage = async (messageId, currentMessage) => {
    const { value: newMessageBody } = await Swal.fire({
      title: "Edit message",
      input: "textarea",
      inputValue: currentMessage,
      inputPlaceholder: "Enter the new message here...",
      showCancelButton: true,
    });

    if (newMessageBody) {
      try {
        const response = await api.put("/messages/edit", {
          messageId,
          newMessage: newMessageBody,
        });

        if (response.status === 200) {
          Swal.fire("Message updated successfully!", "", "success");
          const updatedMessages = await api.get("/messages");
          setMessages(updatedMessages.data);
        } else {
          Swal.fire("Error updating message", "", "error");
        }
      } catch (error) {
        console.error("Error updating message", error);
        Swal.fire("Error updating message", "", "error");
      }
    }
  };

  const deleteMessage = async (messageId) => {
    try {
      const result = await Swal.fire({
        title: "Delete message?",
        text: "Confirm to delete the message.",
        icon: "warning",
        showCancelButton: true,
        confirmButtonColor: "#3085d6",
        cancelButtonColor: "#d33",
        confirmButtonText: "Delete message",
      });

      if (result.isConfirmed) {
        const response = await api.delete(`/messages/${messageId}`);

        if (response.status === 200) {
          Swal.fire(
            "Message deleted",
            "The message has been successfully deleted.",
            "success"
          );
          const updatedMessages = await api.get("/messages");
          setMessages(updatedMessages.data);
        } else {
          Swal.fire("Error deleting message", "", "error");
        }
      }
    } catch (error) {
      console.error("Error deleting message", error);
      Swal.fire("Error deleting message", "", "error");
    }
  };

  if (isLoading) return <LoadingMessage message="Loading messages..." />;

  return (
    <div>
      <Typography variant="h4" className={theme ? "text-white" : "text-black"}>
        Messages
      </Typography>
      <Button
        onClick={createMessage}
        color="orange"
        size="sm"
        className="my-2 text-black mr-2"
      >
        Create New Message
      </Button>
      {messages !== null ? (
        messages.length > 0 ? (
          <table
            className={theme ? styles["data-table-dark"] : styles["data-table"]}
          >
            <thead className="text-sm">
              <tr>
                <th>Id</th>
                <th>Message</th>
                <th>Creation Date</th>
                <th>Modification Date</th>
                <th>Actions</th>
              </tr>
            </thead>
            <tbody
              className={theme ? "text-white text-sm" : "text-black text-sm"}
            >
              {messages.map((message) => (
                <tr key={message.id}>
                  <td>{message.id}</td>
                  <td>{message.messageBody}</td>
                  <td>{message.creationDate}</td>
                  <td>{message.lastModifiedDate}</td>
                  <td>
                    <Button
                      onClick={() =>
                        editMessage(message.id, message.messageBody)
                      }
                      color="green"
                      size="sm"
                      className="my-2 mx-2"
                    >
                      Edit
                    </Button>
                    <Button
                      onClick={() => deleteMessage(message.id)}
                      color="red"
                      size="sm"
                      className="my-2 mx-2"
                    >
                      Delete
                    </Button>
                  </td>
                </tr>
              ))}
            </tbody>
          </table>
        ) : (
          <div>
            <Typography
              variant="h6"
              className={theme ? "text-white" : "text-black"}
            >
              No messages yet
            </Typography>{" "}
          </div>
        )
      ) : (
        "Loading messages..."
      )}
    </div>
  );
};

export default MessageReport;
