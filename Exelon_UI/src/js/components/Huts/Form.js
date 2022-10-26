import React from "react";
import Card from "../../utils/Card";

const Form = (props) => {
  const data = [
    {
      placeholder: "Region",
    },

    { type: "number", placeholder: "Phase" },
    { placeholder: "SR#" },
    { placeholder: "Year" },
    {
      type: "dropdown",
      placeholder: "Land Acquisition",
      dropDownValues: ["Yes", "No"],
    },
    { placeholder: "REEF Results" },
    { placeholder: "ComEd Ownership" },
    { type: "dropdown", placeholder: "Survey", dropDownValues: ["Yes", "No"] },
    {
      type: "dropdown",
      placeholder: "Land Acquisition / Env. due diligence/",
      dropDownValues: ["Yes", "No"],
    },
    {
      type: "dropdown",
      placeholder: "Site Plan Submitted",
      dropDownValues: ["Yes", "No"],
    },
    {
      type: "dropdown",
      placeholder: "Location (ComEd Property)",
      dropDownValues: ["Yes", "No"],
    },
    {
      type: "dropdown",
      placeholder: "Transmission ROW Permit Status",
      dropDownValues: ["Yes", "No"],
    },
    { type: "dropdown", placeholder: "Geotech", dropDownValues: ["Yes", "No"] },
    {
      type: "dropdown",
      placeholder: "Civil IFA",
      dropDownValues: ["Yes", "No"],
    },
    {
      type: "dropdown",
      placeholder: "Landscaping Plan",
      dropDownValues: ["Yes", "No"],
    },
    { placeholder: "Stormwater" },
    { placeholder: "Civil IFC" },
    { placeholder: "Electrical IFA" },
    { placeholder: "Electrical IFC" },
    { placeholder: "Completion Status" },
    { type: "date", placeholder: "Hut PlannedDelivery Date" },
    { type: "textarea", placeholder: "Substation Electrical" },
    { type: "textarea", placeholder: "Substation Civil/Structural" },
    { type: "textarea", placeholder: "Substation Support Designer" },
    { type: "textarea", placeholder: "SCADA" },
    { type: "textarea", placeholder: "RELAY" },
    { type: "textarea", placeholder: "COMM" },
    { type: "textarea", placeholder: "UComm - Fiber Eng" },
    { type: "textarea", placeholder: "UComm - Network Eng" },
    { type: "textarea", placeholder: "REACTs Eng" },
    { type: "textarea", placeholder: "Enclosure Lead time" },
    { type: "textarea", placeholder: "Remarks" },
    { type: "textarea", placeholder: "Location" },
    { type: "textarea", placeholder: "Address" },
    {
      type: "textarea",
      placeholder: "HUT Size",
    },
    {
      type: "textarea",
      placeholder: "Hut Vendor",
    },
    {
      type: "textarea",
      placeholder: "WO#",
    },
    { type: "textarea", placeholder: "PID" },
    { type: "textarea", placeholder: "PM" },
    { type: "textarea", placeholder: "EOC Contract issued" },
  ];
  return (
    <Card
      data={data}
      moveToTab={props.moveToTab}
      disable={props.disableFields}
      cardTitle="Huts"
      tabColor="DarkGray"
    />
  );
};

export default Form;
