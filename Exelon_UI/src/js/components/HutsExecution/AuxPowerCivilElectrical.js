import React from "react";
import Card from "../../utils/Card";

const AuxPowerCivilElectricalP2 = (props) => {
  const Phase2Data = [
    { placeholder: "Security_Infrastructure" },
    { placeholder: "Security_Notes_Next_Steps" },
    { placeholder: "Dist_Electrical_IFAs" },
    {
      type: "dropdown",
      placeholder: "Dist_Electrical_IFCs",
      dropDownValues: ["20SPD342", "19SPD517"],
    },
    { type: "dropdown", placeholder: "Above_Grade_Electrical_IFAs", dropDownValues: ["S", "W"] },
    {
      type: "dropdown",
      placeholder: "Above_Grade_Electrical_IFCs",
      dropDownValues: ["Dixon", "University Park"],
    },
    { type: "dropdown", placeholder: "Permit_Status", dropDownValues: ["BnM", "S&L"] }
  ];
  const Phase3Data = [
    { placeholder: "Aux_Power_Civil_Start" },
    { placeholder: "Aux_Power_Civil_Complete" },
    { placeholder: "Aux_Power_Electrical_Start" },
    {
      type: "dropdown",
      placeholder: "Aux_Power_Electrical_Complete_Approx_2_weeks",
      dropDownValues: ["20SPD342", "19SPD517"],
    },
    { type: "dropdown", placeholder: "Aux Power Tested by TG (Aux Transformers and ATO Settings)", dropDownValues: ["S", "W"] },
    {
      type: "dropdown",
      placeholder: "Outage_Cutover_Date",
      dropDownValues: ["Dixon", "University Park"],
    },
    { type: "dropdown", placeholder: "Dist_Ops_Notified_of_Work", dropDownValues: ["BnM", "S&L"] },
    {
      type: "dropdown",
      placeholder: "LNL_Submitted_for_HUT_Aux_Power_SSC",
      dropDownValues: ["small", "medium"],
    },
    { type: "number", placeholder: "ComEdContracting" },
    { placeholder:"Fiber - Hut to Control Building Start"},
    { placeholder:"Fiber - Hut to Control Building Finish"}
  ];
  return (
    <Card
      data={Phase2Data}
      Phase2Data={Phase2Data}
      Phase3Data={Phase3Data}
      disable={props.disableFields}
      cardTitle="Aux Power Civil Electrical"
      tabColor={props.tabColor}
      phase2={true}
      phase3={true}
    />
  );
};

export default AuxPowerCivilElectricalP2;
