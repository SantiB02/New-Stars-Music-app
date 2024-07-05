import {
  Accordion,
  AccordionBody,
  AccordionHeader,
  Button,
  Typography,
} from "@material-tailwind/react";
import React, { useState } from "react";

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

const DataAccordion = () => {
  const [open, setOpen] = useState(0);

  const handleOpen = (value) => setOpen(open === value ? 0 : value);

  return (
    <div>
      <Accordion open={open === 1} icon={<Icon id={1} open={open} />}>
        <AccordionHeader onClick={() => handleOpen(1)}>
          Fill in your additional information, if you have not already done so
        </AccordionHeader>
        <AccordionBody>
          {user.address ? (
            <div className="col-span-2">
              <h3 className="font-semibold">Address</h3>
              <p>{user.address}</p>
            </div>
          ) : (
            <div className="col-span-2">
              <h3 className="font-semibold">Address</h3>
              <p>{user.address}</p>
            </div>
          )}
          {user.phone_number ? (
            <div className="col-span-2">
              <h3 className="font-semibold">Phone Number</h3>
              <p>{user.phone_number}</p>
            </div>
          ) : (
            <div className="col-span-2">
              <h3 className="font-semibold">Phone Number</h3>
              <p>{user.phone_number}</p>
            </div>
          )}
          <Button variant="gradient" color="blue">
            <span>Changes my account</span>
          </Button>
        </AccordionBody>
      </Accordion>
    </div>
  );
};

export default DataAccordion;
