import React from "react";
import Card from "../../utils/Card";
import { useSelector } from "react-redux";

const Boring = (props) => {
  const datatest = useSelector((state) => state.hideExecutionLinksFormReducer?.data);
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
