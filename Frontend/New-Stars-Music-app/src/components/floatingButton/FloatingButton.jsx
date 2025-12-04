import React, { useContext, useState } from "react";
import ModalChat from "../modalChat/ModalChat";
import { themeContext } from "../../services/contexts/ThemeProvider";

const FloatingButton = () => {
  const [isModalOpen, setIsModalOpen] = useState(false);
  const { theme } = useContext(themeContext);

  const toggleModal = () => {
    setIsModalOpen(!isModalOpen);
  };

  return (
    <>
      <button
        onClick={toggleModal}
        className={
          !theme
            ? "fixed bottom-10 z-50 right-6  items-center gap-2 px-6 py-3 font-semibold text-teal-50 bg-gradient-to-tr from-teal-900/50 via-teal-900/90 to-teal-900/40 ring-4 ring-teal-900/50 rounded-full overflow-hidden hover:opacity-90 transition-opacity before:absolute before:top-4 before:left-1/2 before:-translate-x-1/2 before:w-[100px] before:h-[100px] before:rounded-full before:bg-gradient-to-b before:from-teal-50/10 before:blur-xl"
            : "fixed bottom-10 z-50 right-6  items-center gap-2 px-6 py-3 font-semibold text-teal-50 bg-gradient-to-tr from-teal-400/30 via-teal-400/70 to-teal-400/30 ring-4 ring-teal-400/20 rounded-full overflow-hidden hover:opacity-90 transition-opacity before:absolute before:top-4 before:left-1/2 before:-translate-x-1/2 before:w-[100px] before:h-[100px] before:rounded-full before:bg-gradient-to-b before:from-teal-50/10 before:blur-xl"
        }
        //className="fixed bottom-10 z-50 right-6 bg-blue-500 text-white rounded-full w-16 h-16 flex items-center justify-center shadow-lg hover:bg-blue-600"
        style={{ bottom: "12%", right: "2%" }}
      >
        Chat
      </button>
      {isModalOpen && <ModalChat toggleModal={toggleModal} />}
    </>
  );
};

export default FloatingButton;
