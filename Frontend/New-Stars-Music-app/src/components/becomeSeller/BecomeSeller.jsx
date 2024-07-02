import { Button, Typography } from "@material-tailwind/react";
import React from "react";

const BecomeSeller = () => {
  return (
    <div className="mx-4 mt-6 lg:mx-10 flex flex-col items-center">
      <Typography variant="h2">Become a seller today!</Typography>
      <Typography className="text-center text-justify">
        Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit quis
        eum repellendus minima labore error sunt eius unde in dolorum, alias
        neque necessitatibus deserunt. Possimus velit facilis similique
        aspernatur illum. Lorem ipsum dolor sit amet consectetur adipisicing
        elit. Aut alias pariatur explicabo veniam eius, est, aliquid ipsa nobis
        cupiditate quas expedita quam, harum veritatis fugiat eaque qui error at
        velit! Lorem ipsum dolor sit amet, consectetur adipisicing elit.
        Perspiciatis animi doloremque consectetur labore enim alias dolor
        voluptas sunt tempora optio ab est, ratione tenetur sed id. Laborum
        ducimus magni natus.
      </Typography>
      <Typography className="text-center text-justify">
        Lorem ipsum dolor sit, amet consectetur adipisicing elit. Sit explicabo
        nam labore voluptatum tempora beatae culpa atque veniam placeat, facere
        eum iure id officiis, harum similique? Aut assumenda hic accusantium.
      </Typography>
      {/* onclick: navegar a "/seller-center", desloguearse y volverse a loguear */}
      <Button className="bg-orange-800 mt-6">Become a Seller</Button>{" "}
    </div>
  );
};

export default BecomeSeller;
