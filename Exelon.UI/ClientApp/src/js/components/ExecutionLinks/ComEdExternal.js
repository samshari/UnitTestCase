import React from "react";
import Card from "../../utils/Card";

const ComEdExternal = (props) => {
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
