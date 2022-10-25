import React from "react";
import Card from "../../utils/Card";

const RPPhase2 = (props) => {
  const Phase2Data = [{ placeholder: "R&P IFA" }, { placeholder: "R&P IFC" }];
  const Phase3Data = [
    { placeholder: "Relay Execution Start Date" },
    { placeholder: "Outage" },
    { placeholder: "Completion_Date" },
  ];
  return (
    <Card
      data={Phase2Data}
      Phase2Data={Phase2Data}
      Phase3Data={Phase3Data}
      disable={props.disableFields}
      cardTitle="R&P"
      tabColor={props.tabColor}
      phase2={true}
      phase3={true}
    />
  );
};

export default RPPhase2;
