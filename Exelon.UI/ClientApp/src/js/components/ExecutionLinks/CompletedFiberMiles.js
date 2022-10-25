import React from "react";
import Card from "../../utils/Card";

const CompletedFiberMiles = (props) => {
  const data = [
    { type:"number", placeholder: "Fiber Miles Installed" },
    { type:"number", placeholder: "Fiber Miles Complete (OTDR Tested)" }
  ];
  return (
    <>
      <Card
        data={data}
        disable={props.disableFields}
        cardTitle="Completed Fiber Miles"
        tabColor={props.tabColor}
      />
    </>
  );
};

export default CompletedFiberMiles;
