import React from "react";
import Card from "../../utils/Card";
import { useSelector } from "react-redux";

const Devices = (props) => {
  const datatest = useSelector((state) => state.hideExecutionLinksFormReducer?.data);
  const data = [
    { type:"number",placeholder: "No. of Devices Ready to be Cutover" },
  ];
  return (
    <>
      <Card
        data={data}
        disable={props.disableFields}
        cardTitle="Devices"
        tabColor={props.tabColor}
      />
    </>
  );
};

export default Devices;
