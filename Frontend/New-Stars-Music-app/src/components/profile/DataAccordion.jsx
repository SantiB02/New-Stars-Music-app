import {
  Accordion,
  AccordionBody,
  AccordionHeader,
  Button,
  Dialog,
  DialogHeader,
  DialogBody,
  Input,
  Typography,
} from "@material-tailwind/react";
import React, { useState } from "react";
import { useTheme } from "../../services/contexts/ThemeProvider";
import FormProfile from "./FormProfile";

function Icon({ id, open }) {
  return (
    <svg
      xmlns="http://www.w3.org/2000/svg"
      fill="none"
      viewBox="0 0 24 24"
      strokeWidth={2}
      stroke="currentColor"
      className={`${
        id === open ? "rotate-180" : ""
      } h-5 w-5 transition-transform`}
    >
      <path
        strokeLinecap="round"
        strokeLinejoin="round"
        d="M19.5 8.25l-7.5 7.5-7.5-7.5"
      />
    </svg>
  );
}

const DataAccordion = ({ users }) => {
  const [open, setOpen] = useState(0);
  const [openChange, setOpenChange] = useState(false);

  const { theme } = useTheme();

  const handleOpen = (value) => setOpen(open === value ? 0 : value);
  const openDialogHandler = () => {
    setOpenChange(!openChange);
    console.log(users);
  };

  return (
    <div>
      <Accordion open={open === 1} icon={<Icon id={1} open={open} />}>
        <AccordionHeader
          className={theme ? "text-white hover:text-gray-400" : "text-black"}
          onClick={() => handleOpen(1)}
        >
          Additional data
        </AccordionHeader>
        <AccordionBody>
          {!users.address ? (
            <>debe ingresar su direccion</>
          ) : (
            <Typography>your addres is : {users.address}</Typography>
          )}
          {!users.apartment ? (
            <Typography>debe ingresar tu numero de apartamento</Typography>
          ) : (
            <Typography>your apartment is : {users.apartment}</Typography>
          )}
          {!users.city ? (
            <Typography>debe ingresar su ciudad</Typography>
          ) : (
            <Typography>your city is : {users.city}</Typography>
          )}
          {!users.country ? (
            <Typography>debe ingresar su pais</Typography>
          ) : (
            <Typography>your country is : {users.country}</Typography>
          )}

          {!users.phone ? (
            <Typography>debe ingresar su telefono</Typography>
          ) : (
            <Typography>your phone is : {users.phone}</Typography>
          )}
          {!users.postalCode ? (
            <Typography>debe ingresar su codigo postal</Typography>
          ) : (
            <Typography>your postalcode is : {users.postalCode}</Typography>
          )}
          <Dialog
            open={openChange}
            className={theme ? "bg-primary text-white" : "bg-white text-black"}
            handler={() => setOpenChange(false)}
          >
            <DialogHeader>
              <Typography variant="h2"  color={theme ? "white" : "black"}>
                Additional data
              </Typography>
            </DialogHeader>
            <DialogBody className="flex items-center justify-center ">
              <div className="w-full max-w-md">
                <FormProfile setOpenChange={setOpenChange}/>
              </div>
            </DialogBody>
          </Dialog>

          <div className="pt-4">
            <Button variant="gradient" onClick={openDialogHandler} color="blue">
              <span>Changes my account</span>
            </Button>
          </div>
        </AccordionBody>
      </Accordion>
    </div>
  );
};

export default DataAccordion;
