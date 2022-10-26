import React from "react";
import Card from "../../utils/Card";

const HutTestingLNL = (props) => {
  const data = [
    { placeholder: "Fiber_Ring_Completed5" },
    { placeholder: "HUT_IN_SERVICE" },
    { placeholder: "Security_Equipment_Install_ecard" }
  ];
  return (
    <Card
      data={data}
      disable={props.disableFields}
      cardTitle="Hut Testing LNL"
      tabColor={props.tabColor}
    />
  );
};

export default HutTestingLNL;
