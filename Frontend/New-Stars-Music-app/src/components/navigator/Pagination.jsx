import React from "react";
import { IconButton, Typography } from "@material-tailwind/react";
import { ArrowRightIcon, ArrowLeftIcon } from "@heroicons/react/24/outline";
import { useTheme } from "../../services/contexts/ThemeProvider";

const Pagination = ({ active, totalPages, onChange }) => {
  const { theme } = useTheme();
  const next = () => {
    if (active === totalPages) return;
    onChange(active + 1);
  };

  const prev = () => {
    if (active === 1) return;
    onChange(active - 1);
  };

  return (
    <div className="flex items-center gap-8">
      <IconButton
        size="sm"
        color={theme ? "white" : "black"}
        variant="outlined"
        onClick={prev}
        disabled={active === 1}
      >
        <ArrowLeftIcon strokeWidth={2} className="h-4 w-4" />
      </IconButton>

      <Typography color="gray" className="font-normal">
        Page{" "}
        <strong className={theme ? "text-white" : "text-gray-900"}>
          {active}
        </strong>{" "}
        of{" "}
        <strong className={theme ? "text-white" : "text-gray-900"}>
          {totalPages}
        </strong>
      </Typography>

      <IconButton
        size="sm"
        color={theme ? "white" : "black"}
        variant="outlined"
        onClick={next}
        disabled={active === totalPages}
      >
        <ArrowRightIcon strokeWidth={2} className="h-4 w-4" />
      </IconButton>
    </div>
  );
};

export default Pagination;
