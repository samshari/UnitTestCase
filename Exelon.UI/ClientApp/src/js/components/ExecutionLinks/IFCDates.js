import React from "react";
import Card from "../../utils/Card";

const IFCDates = (props) => {
  const data = [
    { type:"date",placeholder: "IFC Make Ready Scheduled Issue Date" },
    { type:"date",placeholder: "IFC Fiber current Scheduled Issue Date" },
  ];
  return (
    <>
      <Card
        data={data}
        disable={props.disableFields}
        cardTitle="IFC Dates"
        tabColor={props.tabColor}
      />
    </>
  );
};

export default IFCDates;
