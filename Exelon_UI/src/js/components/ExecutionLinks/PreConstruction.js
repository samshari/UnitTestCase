import React from "react";
import Card from "../../utils/Card";
import { useSelector } from "react-redux";

const PreConstruction = (props) => {
  const datatest = useSelector((state) => state.hideExecutionLinksFormReducer?.data);
  const data = [
    { placeholder: "Environmental COC" },
    {
      type: "YNOdropdown",
      placeholder: "Veg. Required?",
      dropDownValues: ["No", "Yes", "Other"],
    },
    {
      type: "YNOdropdown",
      placeholder: "Staking Required?",
      dropDownValues: ["No", "Yes", "Other"],
    },
    {
      type: "YNOdropdown",
      placeholder: "Matting Required?",
      dropDownValues: ["No", "Yes", "Other"],
    },
  ];
  return (
    <>
      <Card
        data={data}
        disable={props.disableFields}
        cardTitle="Pre-Construction"
        tabColor={props.tabColor}
      />
    </>
  );
};

export default PreConstruction;
