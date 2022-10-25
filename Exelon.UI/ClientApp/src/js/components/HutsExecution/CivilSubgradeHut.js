import React from "react";
import Card from "../../utils/Card";

const CivilSubgradeHutPhase2 = (props) => {
  const Phase2Data = [
    { placeholder: "Civil_IFAs" },
    { placeholder: "Civil_IFCs_" },
    { placeholder: "Permit_Ready_Date" },
    {
      type: "dropdown",
      placeholder: "Create_MR",
      dropDownValues: ["20SPD342", "19SPD517"],
    },
    { type: "dropdown", placeholder: "RFP_Submitted", dropDownValues: ["S", "W"] },
    {
      type: "dropdown",
      placeholder: "HRE_Submitted",
      dropDownValues: ["Dixon", "University Park"],
    },
    { type: "dropdown", placeholder: "Permits_Outstanding", dropDownValues: ["BnM", "S&L"] },
    {
      type: "dropdown",
      placeholder: "Pre_Construction_Walkdown",
      dropDownValues: ["small", "medium"],
    },
    { type: "number", placeholder: "HASP_Reqd" }
  ];
  const Phase3Data = [
    { placeholder: "Civil_Award" },
    { placeholder: "Env_RFP" },
    { placeholder: "Survey" },
    {
      type: "dropdown",
      placeholder: "Civil_Execution_Start_Date_based_on_permit_approval_or_IFC",
      dropDownValues: ["20SPD342", "19SPD517"],
    },
    { type: "dropdown", placeholder: "Foundation_Poured", dropDownValues: ["S", "W"] },
    {
      type: "dropdown",
      placeholder: "GroundingConduit_InstallPed_Boxes",
      dropDownValues: ["Dixon", "University Park"],
    },
    { type: "dropdown", placeholder: "ComEdContractingLNL#", dropDownValues: ["BnM", "S&L"] },
    {
      type: "dropdown",
      placeholder: "Foundation_Ready_for_Hut_Offload_12_day_cure_time",
      dropDownValues: ["small", "medium"],
    },
    { type: "number", placeholder: "Hut_Offload" },
    { type: "number", placeholder: "Civil_Complete" },
    { type: "number", placeholder: "Fence_install" },
    { placeholder:"Construction_Notes"},
    {
        placeholder:"Grounding Testing Completed"
    },
    {
        placeholder:"Outage_Required_for_Delivery"
    }
  ];
  return (
    <Card
      data={Phase2Data}
      Phase2Data={Phase2Data}
      Phase3Data={Phase3Data}
      disable={props.disableFields}
      cardTitle="Civil/Subgrade Hut"
      tabColor={props.tabColor}
      phase2={true}
      phase3={true}
    />
  );
};

export default CivilSubgradeHutPhase2;
