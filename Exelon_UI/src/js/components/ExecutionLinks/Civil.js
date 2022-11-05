import React from "react";
import Card from "../../utils/Card";
import { useSelector } from "react-redux";

const Civil = (props) => {
  const datatest = useSelector((state) => state.hideExecutionLinksFormReducer?.data);
  const data = [
    { type:"dropdown",placeholder: "Civil COC" },
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
