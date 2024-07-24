import React, { useState } from "react";
import PropTypes from "prop-types";

const ModalChat = ({ toggleModal }) => {
  const [option, setOption] = useState("");
  const [response, setResponse] = useState("");
  const [error, setError] = useState("");

  const handleSubmit = () => {
    if (option === "" || !["1", "2", "3"].includes(option)) {
      setError("Please choose a valid option (1, 2, or 3).");
      setResponse("");
      return;
    }

    let response;
    switch (option) {
      case "1":
        response = (
          <ul className="list-disc pl-5">
            <li>Standard Shipping: 5 to 7 business days.</li>
            <li>Express Shipping: 2 to 3 business days.</li>
            <li>Same-day Shipping: Available only in metropolitan areas.</li>
          </ul>
        );
        break;
      case "2":
        response = (
          <ul className="list-disc pl-5">
            <li>Credit/Debit Card: Visa, MasterCard, American Express.</li>
            <li>PayPal</li>
            <li>Bank Transfer</li>
          </ul>
        );
        break;
      case "3":
        response = (
          <ul className="list-disc pl-5">
            <li>Returns: We accept returns within 30 days of purchase.</li>
            <li>
              Refunds: Refunds are processed to the original payment method.
            </li>
            <li>
              Conditions: The item must be in its original, unused condition.
            </li>
          </ul>
        );
        break;
      default:
        response = "Invalid option, please choose 1, 2, or 3";
    }
    setResponse(response);
    setError("");
  };

  return (
    <div className="fixed z-50 inset-0 bg-gray-800 bg-opacity-50 flex items-center justify-center">
      <div className="bg-white p-6 rounded-lg shadow-lg w-80 relative">
        <button
          onClick={toggleModal}
          className="absolute top-2 right-2 text-gray-600 hover:text-gray-900 text-2xl"
        >
          &times;
        </button>
        <h2 className="text-xl text-black mb-4">Chat with Us</h2>
        <p className="mb-4 text-gray-600">
          How can we help you?
          <br />
          <span className="font-bold">1.</span>{" "}
          <span className="italic">Shipping Options</span>
          <br />
          <span className="font-bold">2.</span>{" "}
          <span className="italic">Payment Methods</span>
          <br />
          <span className="font-bold">3.</span>{" "}
          <span className="italic">Return Policy</span>
        </p>
        <input
          placeholder="Enter an option..."
          type="number"
          value={option}
          onChange={(e) => setOption(e.target.value)}
          className="block w-full p-2 border border-gray-300 rounded mb-4 text-gray-900"
          min="1"
          max="3"
        />
        <button
          onClick={handleSubmit}
          className="bg-green-500 text-white px-2 py-1 rounded hover:bg-green-600"
        >
          Submit
        </button>
        {error && <p className="mt-4 text-red-500">{error}</p>}
        {response && (
          <div className="mt-4 text-gray-700">Response: {response}</div>
        )}
        {/* <button 
                    onClick={toggleModal} 
                    className="absolute bottom-2 right-2 bg-red-500 text-white px-1 py-1 rounded hover:bg-red-600"
                >
                    Close
                </button> */}
      </div>
    </div>
  );
};
ModalChat.propTypes = {
  toggleModal: PropTypes.func.isRequired,
};

export default ModalChat;
