import React, { useState } from "react";
import ModalChat from "../modalChat/ModalChat";

const FloatingButton = () => {
  const [isModalOpen, setIsModalOpen] = useState(false);

  const toggleModal = () => {
    setIsModalOpen(!isModalOpen);
  };

  return (
    <>
      <button
        onClick={toggleModal}
        className="fixed bottom-10 right-6 bg-blue-500 text-white rounded-full w-16 h-16 flex items-center justify-center shadow-lg hover:bg-blue-600"
      >
        Chat
      </button>
      {isModalOpen && <ModalChat toggleModal={toggleModal} />}
    </>
  );
};

export default FloatingButton;
