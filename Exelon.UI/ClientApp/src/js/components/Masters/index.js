import React, { useEffect, useState } from "react";
import Form from "./Form";
import "../../../styles/components/HutPermitting.css";
import "../../../styles/components/Masters.css";
import { useSelector } from "react-redux";

import "../../../styles/components/Engineering.css";

const Dashboard = (props) => {
  const [disable, setDisable] = React.useState(false);
  // const PDValues = [
  //   {
  //     value: "1C224300 Backbone Ring 24",
  //     data: [
  //       {
  //         primaryKey: "BF-TSS67-TDC714",
  //         linkDescription: "BF-TSS67-TDC714",
  //         linkNickname: "1",
  //       },
  //       {
  //         primaryKey: "BF-TDC714-SS798",
  //         linkDescription: "BF-TDC714-SS798",
  //         linkNickname: "2",
  //       },
  //     ],
  //   },
  //   {
  //     value: "1C224302 - TSS30 COLUMBUS PARK",
  //     data: [
  //       {
  //         primaryKey: "DF-TSS30-TSS30-01",
  //         linkDescription: "DF-TSS30-TSS30-01",
  //         linkNickname: "1",
  //       },
  //       {
  //         primaryKey: "DF-TSS30-TSS38-01",
  //         linkDescription: "DF-TSS30-TSS38-01",
  //         linkNickname: "2",
  //       },
  //     ],
  //   },
  //   {
  //     value: "1C224302 - DCY310 Austin",
  //     data: [
  //       {
  //         primaryKey: "DF-DCY310-DCY310-01",
  //         linkDescription: "DF-DCY310-DCY310-01",
  //         linkNickname: "12",
  //       },
  //       {
  //         primaryKey: "DF-DCY310-DCY310-02",
  //         linkDescription: "DF-DCY310-DCY310-02",
  //         linkNickname: "13",
  //       },
  //       {
  //         primaryKey: "DF-DCY310-DCY310-01",
  //         linkDescription: "DF-DCY310-DCY310-01",
  //         linkNickname: "12",
  //       },
  //       {
  //         primaryKey: "DF-DCY310-DCY310-02",
  //         linkDescription: "DF-DCY310-DCY310-02",
  //         linkNickname: "13",
  //       },
  //       {
  //         primaryKey: "DF-DCY310-DCY310-01",
  //         linkDescription: "DF-DCY310-DCY310-01",
  //         linkNickname: "12",
  //       },
  //       {
  //         primaryKey: "DF-DCY310-DCY310-02",
  //         linkDescription: "DF-DCY310-DCY310-02",
  //         linkNickname: "13",
  //       },
  //     ],
  //   },
  // ];
  const PDValues = [];
  const selectedPD = useSelector((state) => state.headerReducer.selectedPD);
  const clearSelectedRow = useSelector(
    (state) => state.headerReducer.clearSelectedTableRow
  );

  const [isActive, setIsActive] = useState(null);
  useEffect(() => {
    props.disableTabs === "false" ? setDisable(false) : setDisable(true);
    if (clearSelectedRow) {
      setIsActive(null);
    }
    if (selectedPD === "") {
      setDisable(true);
    }
  }, [props.disableTabs, selectedPD, clearSelectedRow]);

  const unDisableTabs = () => {
    setDisable(false);
  };
  const handleClick = (i) => {
    unDisableTabs();
    if (i === isActive) {
      setIsActive(null);
    } else {
      setIsActive(i);
    }
  };

  const filteredData = PDValues.filter((item) => item.value === selectedPD).map(
    (itemm) => {
      return itemm;
    }
  );
  const selectedFilteredData = filteredData.reduce(
    (item, { data }) => [...item, ...data.map((i) => i)],
    []
  );
  const PDallValues = PDValues.reduce(
    (item, { data }) => [...item, ...data.map((i) => i)],
    []
  );
  const defaultPDValue = "--Select PD--";
  return (
    <div class="body">
      <div class="app TabContainer">
        <div class="screenCard">
          {selectedPD === defaultPDValue || selectedPD === "" ? (
            <div class="TableCard">
              <div class="Scrollbar ">
                <table>
                  <tr class="sticky">
                    <th class="primaryKey">Primary Key</th>
                    <th class="linkDescription">Link Description</th>
                    <th class="linkNickname">Link Nickname</th>
                  </tr>
                  {PDallValues[0] !== undefined ? (
                    PDallValues.map((element, index) => {
                      return (
                        <tr
                          class={
                            isActive === index ? "selectedRow" : "clickable"
                          }
                          onClick={() => handleClick(index)}
                        >
                          <td>{element.primaryKey}</td>
                          <td>{element.linkDescription}</td>
                          <td>{element.linkNickname}</td>
                        </tr>
                      );
                    })
                  ) : (
                    <div class="noRecords_container">
                      <span class="noRecords_Label">No Records Found Yet!</span>
                    </div>
                  )}
                </table>
              </div>
            </div>
          ) : (
            PDValues.filter((item) => item.value === selectedPD).map(
              (filteredData) => (
                <div class="TableCard">
                  <div class="Scrollbar">
                    <table>
                      <tr>
                        <th>Primary Key</th>
                        <th>Link Description</th>
                        <th>Link Nickname</th>
                      </tr>
                      {selectedFilteredData.map((element, index) => {
                        return (
                          <tr
                            class={
                              isActive === index ? "selectedRow" : "clickable"
                            }
                            onClick={() => handleClick(index)}
                          >
                            <td class="primaryKey">{element.primaryKey}</td>
                            <td class="linkDescription">
                              {element.linkDescription}
                            </td>
                            <td class="linkNickname">{element.linkNickname}</td>
                          </tr>
                        );
                      })}
                    </table>
                  </div>
                </div>
              )
            )
          )}
        </div>
        {/* <CustomTabs data={TabsArr} disable={disable} /> */}
        <div class="formScroll">
          <div class="Form">
            <Form disableFields={disable} />
          </div>
        </div>
      </div>
    </div>
  );
};

export default Dashboard;
