import React from "react";
import Card from "../../utils/Card";

const CompletedPoles = (props) => {
  const data = [
    { type: "number", placeholder: "Total Number of Poles Needed" },
    { type: "number", placeholder: "Poles Installed" },
    { type: "number", placeholder: "OH miles Total" },
    { type: "number", placeholder: "Make-Ready OH Miles Completed" },
    {
      type: "number",
      placeholder: "UG miles (Innerduct, Boring + Civil) Total",
    },
    {
      type: "number",
      placeholder: "UG miles (Innerduct, Boring + Civil)",
    },
  ];
  return (
    <>
      <Card
        data={data}
        disable={props.disableFields}
        cardTitle="Completed Poles/Miles"
        tabColor={props.tabColor}
      />
    </>
  );
};

export default CompletedPoles;
