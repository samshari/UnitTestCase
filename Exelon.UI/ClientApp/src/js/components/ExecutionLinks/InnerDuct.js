import React from "react";
import Card from "../../utils/Card";

const Innerduct = (props) => {
  const data = [
    { type:"date",placeholder: "Innerduct Start" },
    { type:"date",placeholder: "Innerduct Finish" },
    { type:"textarea",placeholder: "Innerduct Comments" },
  ];
  return (
    <>
      <Card
        data={data}
        disable={props.disableFields}
        cardTitle="Innerduct (Rod and Rope)"
        tabColor={props.tabColor}
      />
    </>
  );
};

export default Innerduct;
