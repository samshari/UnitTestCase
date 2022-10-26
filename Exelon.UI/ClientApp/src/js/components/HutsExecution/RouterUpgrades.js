import React from "react";
import Card from "../../utils/Card";

const RouterUpgrades = (props) => {
  const Phase3Data = [
    { placeholder: "Column3" },
    { placeholder: "Column4" }
  ];
  return (
    <Card
      data={Phase3Data}
      Phase3Data={Phase3Data}
      disable={props.disableFields}
      cardTitle="Router Upgrades"
      tabColor={props.tabColor}
      phase3={true}
      phase2={false}
    />
  );
};

export default RouterUpgrades;
