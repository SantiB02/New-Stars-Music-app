import {
  Accordion,
  AccordionBody,
  AccordionHeader,
  Button,
  Input,
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

const DataAccordion = ({ users }) => {
  const [open, setOpen] = useState(0);

  const handleOpen = (value) => setOpen(open === value ? 0 : value);

  return (
    <div>
      <Accordion open={open === 1} icon={<Icon id={1} open={open} />}>
        <AccordionHeader onClick={() => handleOpen(1)}>
          Fill in your additional information, if you have not already done so
        </AccordionHeader>
        <AccordionBody>
          {users.address ? (
            <div className="col-span-2 pt-4">
              <Input
                label={`Address: ${users.address}`}
                placeholder="enter your address"
                
              />
            </div>
          ) : (
            <div className="col-span-2 pt-4">
              <Input label="Addres:" placeholder="enter your address" />
            </div>
          )}
          {users.phone ? (
            <div className="col-span-2 pt-4">
              <Input
                label={`Phone number: ${users.address}`}
                placeholder="enter your phone number"
                
              />
            </div>
          ) : (
            <div className="col-span-2 pt-4">
              <Input
                label="Phone Number:"
                placeholder="enter your phone number"
              />
            </div>
          )}
          <div className="pt-4">
            <Button variant="gradient" color="blue">
              <span>Changes my account</span>
            </Button>
          </div>
        </AccordionBody>
      </Accordion>
    </div>
  );
};

export default DataAccordion;
