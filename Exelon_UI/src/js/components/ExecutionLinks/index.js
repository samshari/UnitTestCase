// ** React Imports
import { useState, createRef, useEffect } from "react";
import { useSelector, useDispatch } from "react-redux";
import { selectPD, selectProjectID } from "../../../redux/views/Header/HeaderAction";
import { TextField, Autocomplete } from "@mui/material";
import "../../../styles/components/Execution.css";
import LinkInformation from "./LinkInformation";
import EnggInvestigation from "./EnggInvestigation";
import Boring from "./Boring";
import Civil from "./Civil";
import ComEdExternal from "./ComEdExternal";
import CompletedFiberMiles from "./CompletedFiberMiles";
import CompletedPoles from "./CompletedPoles";
import Devices from "./Devices";
import Fiber from "./Fiber";
import IFCDates from "./IFCDates";
import Innerduct from "./InnerDuct";
import OvhdMakeReady from "./OvhdMakeReady";
import PostCompletion from "./PostCompletion";
import PreConstruction from "./PreConstruction";
import CustomTabs from "../../utils/Tabs";
import { selectPrimaryKey } from "../../../redux/views/Header/HeaderAction";
import { getPDApi } from "../../../redux/components/Engineering/PD/PDAction";
import { getallProjectId, getExLabelData, getExLinkData, GetLinkInfoIdByProjectId, getPDID, getProjectId, getProjectIDByPD } from "../../../redux/components/ExecutionLinks/ExecutionLinksAction";

function createData(projectID, linkNickname, workOrder, status) {
  return { projectID, linkNickname, workOrder, status };
}
const statusObj = {
  Active: { color: "#9155FD" },
  Removed: { color: "#FF4C51" },
  Combined: { color: "#FFB400" },
  Closed: { color: "#56CA00" },
  "In Service": { color: "#b784a7" },
  "On Hold": { color: "#16B1FF" },
  NA: { color: "#99badd" }
};


const PDValues = [
  {
    value: "1C224300 Backbone Ring 24",
    rows: [
      {
        projectID: "21SPD414",
        linkNickname: "12",
        workOrder: "17162217",
        status: 'NA'
      },
      createData(
        "20SPD200",
        "null",
        "15921628",
        "NA"
      ),
      createData(
        "DF-TSS48-TSS48-01",
        "TSS48 Highland Park to TDC213 Deerfield BBF",
        "3",
        "On Hold"
      ),
      createData(
        "AF-TSS48-TSS48-01.01",
        "TSS48 Highland Park to TSS48 Highland Park DFR",
        "4",
        "Active"
      ),
    ],
  },
  {
    value: "1C224302 - TSS30 COLUMBUS PARK",
    rows: [
      createData(
        "AF-TSS48-TSS48-01.03",
        "(PD Loc. 3 to D5) to (D5 to Loc. 3) AF",
        "5",
        "Removed"
      ),
      createData(
        "AF-TSS48-TSS48-01.04",
        "DCC73 Techny to DCC73 Techny AF",
        "6",
        "Combined"
      ),
      createData("BF-TDC714-SS798", "BF-TDC714-SS798", "7", "In Service"),
      createData("BF-TSS38-TSS50", "BF-TSS50-SS798", "8", "Active"),
      createData("BF-SS750-SS709", "BF-TSS38-TSS50", "1", "Combined"),
      createData("BF-TSS38-SS750", "BF-TSS38-SS750", "2", "In Service"),
    ],
  },
  {
    value: "1C224302 - DCY310 Austin",
    rows: [
      createData(
        "BF-SS750-SS793",
        "(PD Loc. 3 to D5) to (D5 to Loc. 3) AF",
        "3",
        "Active"
      ),
      createData("BF-TSS30-TSS67", "BF-TSS30-TSS67", "4", "Active"),
      createData(
        "DF-TSS30-TSS30-01",
        "DF-DCY310-DCY310-01",
        "4",
        "Active"
      ),
      createData(
        "DF-TSS30-TSS30-02",
        "DF-TSS30-TSS30-02",
        "5",
        "Active"
      ),
      createData(
        "DF-TSS30-TSS30-03",
        "DF-TSS30-TSS30-03",
        "5",
        "Active"
      ),
      createData(
        "DF-TSS30-TDC505-01",
        "DF-TSS30-TDC505-01",
        "6",
        "Active"
      ),
    ],
  },
];

const allRows = PDValues.map((item) => {
  return [...item.rows];
});
const allRowsData = [].concat(...allRows);

const ExecutionLinks = (props) => {

  const createlinkID=useSelector((state)=>state.hideExecutionLinksFormReducer?.globallinkID)
  const updatelinkID=useSelector((state)=>state.hideExecutionLinksFormReducer?.data?.executionLinkingID);
  const selectedPD = useSelector((state) => state.headerReducer.selectedPD);
  const [selectedProjectID, setSelectedProjectID] = useState(null);
  const TabsArr = [
    {
      tabName: "Link Information",
      tabColor: "yellow",
      disable: selectedPD.length === 0 && selectedProjectID === null && true,
      component: <LinkInformation tabColor="yellow" disableFields={selectedPD.length === 0 && selectedProjectID === null && true} />,
    },
    {
      tabName: "Eng. Investigation",
      tabColor: "#00bfff",
      disable: true,
      component: (
        <EnggInvestigation tabColor="#00bfff" disableFields={(createlinkID > 0) || (updatelinkID > 0) ? false : true} />
      ),
    },
    {
      tabName: "Innerduct (Rod and Rope)",
      tabColor: "#a8ee90",
      disable: true,
      component: <Innerduct tabColor="#a8ee90" disableFields={(createlinkID > 0) || (updatelinkID > 0) ? false : true} />,
    },
    {
      tabName: "ComEd/External",
      tabColor: "#FCC981",
      disable: true,
      component: <ComEdExternal tabColor="#FCC981" disableFields={(createlinkID > 0) || (updatelinkID > 0) ? false : true} />,
    },
    {
      tabName: "Pre-Construction",
      tabColor: "#C5B4E3",
      disable: true,
      component: <PreConstruction tabColor="#C5B4E3" disableFields={(createlinkID > 0) || (updatelinkID > 0) ? false : true} />,
    },
    {
      tabName: "IFC Dates",
      tabColor: "#0a7e8c",
      disable: true,
      component: <IFCDates tabColor="#0a7e8c" disableFields={(createlinkID > 0) || (updatelinkID > 0) ? false : true} />,
    },
    {
      tabName: "OVHD Make Ready",
      tabColor: "orange",
      disable: true,
      component: <OvhdMakeReady tabColor="orange" disableFields={(createlinkID > 0) || (updatelinkID > 0) ? false : true} />,
    },
    {
      tabName: "Boring",
      tabColor: "#99badd",
      disable: true,
      component: <Boring tabColor="#99badd" disableFields={(createlinkID > 0) || (updatelinkID > 0) ? false : true} />,
    },
    {
      tabName: "Civil",
      tabColor: "#00ff00",
      disable: true,
      component: <Civil tabColor="#00ff00" disableFields={(createlinkID > 0) || (updatelinkID > 0) ? false : true} />,
    },
    {
      tabName: "Fiber",
      tabColor: "red",
      disable: true,
      component: <Fiber tabColor="red" disableFields={(createlinkID > 0) || (updatelinkID > 0) ? false : true} />,
    },
    {
      tabName: "Completed Poles/Miles",
      tabColor: "#76ff7a",
      disable: true,
      component: <CompletedPoles tabColor="#76ff7a" disableFields={(createlinkID > 0) || (updatelinkID > 0) ? false : true} />,
    },
    {
      tabName: "Completed Fiber Miles",
      tabColor: "red",
      disable: true,
      component: (
        <CompletedFiberMiles tabColor="red" disableFields={(createlinkID > 0) || (updatelinkID > 0) ? false : true} />
      ),
    },
    {
      tabName: "Devices",
      tabColor: "#7BB2DD",
      disable: true,
      component: <Devices tabColor="#7BB2DD" disableFields={(createlinkID > 0) || (updatelinkID > 0) ? false : true} />,
    },
    {
      tabName: "Post-Completion",
      tabColor: "#ff9933",
      disable: true,
      component: <PostCompletion tabColor="#ff9933" disableFields={(createlinkID > 0) || (updatelinkID > 0) ? false : true} />,
    },
  ];
  const tableRef = createRef();
  
  const [loading, setLoading] = useState(true);
  const filteredData = PDValues.filter((item) => item.value === selectedPD).map(
    (itemm) => {
      return itemm;
    }
  );
  const selectedFilteredData = filteredData.reduce(
    (item, { rows }) => [...item, ...rows.map((i) => i)],
    []
  );

  // ** States
  const [allData, setFilteredData] = useState(allRowsData);
  
  const [selectedValue, setSelectedValue] = useState(selectedPD);
  const PDData = useSelector((state) => {
    return state;
  });

  const dispatch = useDispatch();
  // const PDValuesOptions = PDValues.map((item) => {
  //   return item.value;
  // });
  const allprojectIdData = PDData?.hideExecutionLinksFormReducer?.projectID;
  const allprojectData = PDData?.hideExecutionLinksFormReducer?.allprojectId;
  const labelData = PDData?.hideExecutionLinksFormReducer?.labelData;

  useEffect(() => {
    dispatch(getPDApi()).then((res) => setLoading(false));
    dispatch(getProjectId(0)).then((res) => {
      res?.status !== 404 && dispatch(getallProjectId(res.map((item) => {
        return item.projectId;
      })))
    })
    return () => {
      dispatch(selectProjectID(null))
    }
  }, [])

  const PDValuesOptions = PDData?.PDReducer?.data !== null ? PDData?.PDReducer?.data.status !== 404 ? PDData?.PDReducer?.data?.map((item) => {
    return item.name;
  }) : [] : [];
  const PDValuesIDs = PDData?.PDReducer?.data !== null ? PDData?.PDReducer?.data.status !== 404 ? PDData?.PDReducer?.data?.map((item) => {
    return item;
  }) : [] : [];
  return (
    <>
      {!loading && <div style={{ margin: "4.5rem 8rem 0.8rem 8rem", width: "89%" }}>
        <div
          style={{
            display: "flex"
          }}
        >
          <Autocomplete
            size="medium"
            // multiple
            disablePortal
            ListboxProps={{
              sx: { fontSize: 13 },
            }}

            options={
              PDValuesOptions
            }
            onChange={(event, value) => {
              setSelectedValue(value);
              dispatch(selectProjectID(null));
              dispatch(getExLinkData([]));
              PDValuesIDs?.filter((item) => {
                if (item.name === value) {
                  dispatch(getProjectId(item.pdid)).then((Res) => {
                    setFilteredData(Res);
                    dispatch(getProjectIDByPD(Res));
                  })
                }
              })
              PDData?.PDReducer?.data?.map((item) => {
                if (item.name === value) {
                  dispatch(getPDID(item.pdid));
                }
              })
              value !== null
                ? dispatch(selectPD(value, true))
                : dispatch(selectPD([], true));
            }}
            clearOnBlur
            style={{
              width: 340,
              marginTop: "3.2px",
            }}
            renderInput={(params) => <TextField {...params} label="PD *" />}
            renderOption={(props, option, { selected }) => (
              <div {...props} style={{ height: "1.5rem", paddingLeft: "10px" }}>
                <p>{props.key}</p>
              </div>
            )}
            value={selectedPD}
          />
        </div>
        <div class="informationContainer">
          <Autocomplete
            size="medium"
            // multiple
            disablePortal
            ListboxProps={{
              sx: { fontSize: 13 },
            }}
            options={
              selectedPD.length === 0
                ?allprojectData.length>0? allprojectData?.map((item) => {
                  return item;
                }):[]
                : allprojectIdData?.length > 0 ? allprojectIdData?.map((item) => {
                  return item.projectId;
                }) : []
            }
            onChange={(event, value) => {
              setSelectedProjectID(value);
              value !== null ? dispatch(selectProjectID(value)) : dispatch(selectProjectID(null));

              dispatch(GetLinkInfoIdByProjectId(value)).then((res)=>{
                  console.log('res',res);
                  dispatch(getExLabelData(res));
                  dispatch(getExLinkData(res[0]));
              })

              value === null && dispatch(GetLinkInfoIdByProjectId(value)).then((res) => {
                dispatch(getExLinkData([]));
              })
            }}
            clearOnBlur
            style={{
              width: 340,
            }}
            renderInput={(params) => (
              <TextField {...params} label="Project ID" />
            )}
            renderOption={(props) => (
              <div {...props} style={{ height: "1.5rem", paddingLeft: "15px" }}>
                <p>{props.key}</p>
              </div>
            )}
            value={selectedProjectID}
          />
          {selectedProjectID && (
            <div class="informationLabelsExecution">
              <label>
                Work Order:{" "}
                <span>
                  {labelData!==undefined && labelData.length>0  && labelData
                    .filter((item) => item.projectID === selectedProjectID)
                    .map((item) => item.workOrder)}
                </span>
              </label>
              <label>
                Link Nickname:{" "}
                <span>
                  {labelData!==undefined && labelData.length>0  && labelData
                    .filter((item) => item.projectID === selectedProjectID)
                    .map((item) => item.linkNickname)}
                </span>
              </label>
              <label>
                Status:{" "}
                <span
                  class="Chip"
                // style={{
                //   backgroundColor:
                //     statusObj[
                //       allData
                //         .filter(
                //           (item) => item.projectID === selectedProjectID
                //         )
                //         .map((item) => item.status)
                //     ].color,
                // }}
                >
                  {labelData!==undefined && labelData.length>0  && labelData
                    .filter((item) => item.projectID === selectedProjectID)
                    .map((item) => item.status)}
                </span>
              </label>
            </div>
          )}
        </div>
        <CustomTabs data={TabsArr} />
      </div>
      }
    </>
  )
};

export default ExecutionLinks;
