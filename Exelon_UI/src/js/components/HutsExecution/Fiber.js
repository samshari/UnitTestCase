import React from "react";
import Card from "../../utils/Card";

const Fiber= (props) => {
  const Phase3Data = [
    { placeholder: "1st_Fiber_Install_Date" },
    { placeholder: "Fiber_Ring_Completed" },
  ];
  return (
    <Card
      data={Phase3Data}
      Phase3Data={Phase3Data}
      disable={props.disableFields}
      cardTitle="Fiber"
      tabColor={props.tabColor}
      phase3={true}
      phase2={false}
    />
  );
};

export default Fiber;
