import React from "react";
import Card from "../../utils/Card";
import { useSelector } from "react-redux";

const ComEdExternal = (props) => {
  const datatest = useSelector((state) => state.hideExecutionLinksFormReducer?.data);
  const data = [
    { placeholder: "LNL/Labor for OH make ready" }
  ];
  return (
    <>
      <Card
        data={data}
        disable={props.disableFields}
        cardTitle="ComEd/External"
        tabColor={props.tabColor}
      />
    </>
  );
};

export default ComEdExternal;
