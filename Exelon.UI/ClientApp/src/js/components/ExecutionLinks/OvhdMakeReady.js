import React from "react";
import Card from "../../utils/Card";

const OvhdMakeReady = (props) => {
  const data = [
    { placeholder: "OVHD COC" },
    { type:"date",placeholder: "OVHD Start" },
    { type:"date",placeholder:"OVHD Finish"},
    { type:"textarea",placeholder: "Make-Ready Issues/ Comments" },
    { type:"textarea",placeholder:"OVHD Weekly FTE Count"}
  ];
  return (
    <>
      {/* <h1>RealEstate</h1> */}
      <Card
        data={data}
        disable={props.disableFields}
        cardTitle="OVHD Make Ready"
        tabColor={props.tabColor}
      />
    </>
  );
};

export default OvhdMakeReady;
