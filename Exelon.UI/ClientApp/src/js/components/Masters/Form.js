import React from "react";
import Card from "../../utils/Card";

const Form = (props) => {
  const data = [
    { type:"checkbox", checkboxLabel: "Checkbox" },
    { placeholder: "textbox" },
    { type:"button", buttonLabel: "Checkbox" },
  ];
  return (
    <Card
      data={data}
      // disable={props.disableFields}
      cardTitle="Project Development"
      tabColor="Purple"
    />
  );
};

export default Form;
