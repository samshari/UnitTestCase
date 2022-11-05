import React from "react";
import Card from "../../utils/Card";

const Boring = (props) => {
  const data = [
    { type:"dropdown",placeholder: "Boring COC" },
    { type: "date", placeholder: "Boring Start" },
    { type: "date", placeholder: "Boring Finish" },
    { type: "textarea", placeholder: "Boring Issues/Comments" },
    { type: "textarea", placeholder: "Boring Weekly FTE Count" },
  ];
  return (
    <>
      <Card
        data={data}
        disable={props.disableFields}
        cardTitle="Boring"
        tabColor={props.tabColor}
      />
    </>
  );
};

export default Boring;
