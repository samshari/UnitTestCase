import React from "react";
import Card from "../../utils/Card";

const Form = (props) => {
  const data = [
    { placeholder: "Install Year" },
    { placeholder: "Substation" },
    {
      type: "dropdown",
      placeholder: "EOC",
      dropDownValues: ["Millhouse", "BnM", "S&L"],
    },
    {
      type: "dropdown",
      placeholder: "Size",
      dropDownValues: ["Cabinet", "Box", "Medium"],
    },
    {
      type: "dropdown",
      placeholder: "Municipality",
      dropDownValues: ["Crete", "Unincorporated"],
    },
    {
      type: "dropdown",
      placeholder: "County",
      dropDownValues: ["Cook", "Will", "Lake"],
    },
    // {
    //   type: "radiobutton",
    //   fields: [
    //     {id:0,val:"County Stormwater Permit or MWRD Required?"},
    //     {id:1,val:"Army Corps Permit Required?"},
    //     {id:2,val:"TROW Permit Required?"},
    //     {id:3,val:"Site Development Permit Required?"},
    //     {id:4,val:"Hwy/IDOT Permit"}
    //   ]
    // },
    {
      type: "YNOdropdown",
      placeholder: "County Stormwater Permit Required?",
      dropDownValues: ["No", "Yes", "Other"],
    },
    {
      type: "YNOdropdown",
      placeholder: "Army Corps Permit Required?",
      dropDownValues: ["No", "Yes", "Other"],
    },
    {
      type: "YNOdropdown",
      placeholder: "TROW Permit Required?",
      dropDownValues: ["No", "Yes", "Other"],
    },
    {
      type: "YNOdropdown",
      placeholder: "Site Development Permit Required?",
      dropDownValues: ["No", "Yes", "Other"],
    },
    {
      type: "YNOdropdown",
      placeholder: "Hwy/IDOT Permit",
      dropDownValues: ["No", "Yes", "Other"],
    },
    {
      type: "dropdown",
      placeholder: "Building Permit Required",
      dropDownValues: ["No", "Yes"],
    },
    { placeholder: "Civil IFA Date" },
    { placeholder: "Civil IFC Date" },

    { type: "date", placeholder: "Permit Submission Date" },

    { placeholder: " Permit Ready Date" },
    {
      placeholder:
        "Permit Expiration",
    },
    {
      type: "textarea",
      placeholder: "Permit Processing Duration/Including Comments",
    },
    { type: "textarea", placeholder: "Status" },
    { type: "textarea", placeholder: "Notes" },
  ];
  return (
    <Card
      data={data}
      moveToTab={props.moveToTab}
      disable={props.disableFields}
      cardTitle="Hut Permitting"
      tabColor="green"
    />
  );
};

export default Form;
