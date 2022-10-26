import React from "react";
import Card from "../../utils/Card";

const Phase1 = (props) => {
  const data = [
    { placeholder: "Hut_Delivery_Year" },
   
    { type: "number", placeholder: "WO" },
    {
      type: "dropdown",
      placeholder: "PID",
      dropDownValues: ["20SPD342", "19SPD517"],
    },
    { type: "dropdown", placeholder: "Region", dropDownValues: ["S", "W"] },
    {
      type: "dropdown",
      placeholder: "Barn",
      dropDownValues: ["Dixon", "University Park"],
    },
    { type: "dropdown", placeholder: "EOC", dropDownValues: ["BnM", "S&L"] },
    {
      type: "dropdown",
      placeholder: "Hut_Type",
      dropDownValues: ["small", "medium"],
    },
    { type: "number", placeholder: "PO" },
    { type: "number", placeholder: "CAT_ID" },
    {
      type: "YNOdropdown",
      placeholder: "Land_Acquisition",
      dropDownValues: ["No", "Yes", "Other"],
    },
    { type: "date", placeholder: "Phase_1_Feasibility" },
    { placeholder: "Land_Acquisition_Required" },
    { type: "textarea", placeholder: "Location" },
    { type: "textarea", placeholder: "Delivery_Address_On_PO" },
    { type: "textarea", placeholder: "Location2" },
    {
      type: "textarea",
      placeholder:
        "Site_Layout_Approval_Security_Ucomm_REACTs_Substation_Trans_Eng_Standards_AME_FLS",
    },
  ];
  return (
    <Card
      data={data}
      moveToTab={props.moveToTab}
      disable={props.disableFields}
      cardTitle="Link Information"
      tabColor={props.tabColor}
      phase1={true}
      phase2={false}
    />
  );
};

export default Phase1;
