import React from "react";
import Card from "../../utils/Card";

const Civil = (props) => {
  const data = [
    { placeholder: "Civil COC" },
    { type: "date", placeholder: "Civil Start" },
    { type: "date", placeholder: "Civil Finish" },
    { type: "textarea", placeholder: "Civil Issues/Comments" },
    { type: "textarea", placeholder: "Civil Weekly FTE Count" },
  ];
  return (
    <>
      <Card
        data={data}
        disable={props.disableFields}
        cardTitle="Civil"
        tabColor={props.tabColor}
      />
    </>
  );
};

export default Civil;
