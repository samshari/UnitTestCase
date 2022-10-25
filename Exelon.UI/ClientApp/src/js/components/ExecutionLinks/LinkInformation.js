import React from "react";
import Card from "../../utils/Card";

const LinkInformation = (props) => {
  const data = [
    { placeholder: "Engineering Year" },
    { placeholder: "Execution Year" },
    { placeholder: "Technology" },
    { placeholder: "Region" },
    { placeholder: "Barn" },
    { placeholder: "Work Order" },
    { placeholder: "Project Id" },
    {placeholder:"Fiber PID Split"},
    { type: "number", placeholder: "Fiber Count" },
    { placeholder: "Link Information Comments" },
    { placeholder: "ITN" },
    {
      type: "dropdown",
      placeholder: "Project Status",
      dropDownValues: ["Active", "InActive"],
    },
    { type: "textarea", placeholder: "Scope Comments" },
  ];
  return (
    <Card
      data={data}
      moveToTab={props.moveToTab}
      disable={props.disableFields}
      cardTitle="Link Information"
      tabColor={props.tabColor}
    />
  );
};

export default LinkInformation;
