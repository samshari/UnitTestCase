// ** React Imports
import { useState, createRef, useEffect } from "react";
import {
  getallDataBysubstation,
  getApi,
  gethutPermitLabelData,
  getsubStation,
  hidePermittingForm,
  showUpdateButton,
} from "../../../redux/components/HutPermitting/HutPermittingAction";
import { useSelector, useDispatch } from "react-redux";
import { FaAngleDown, FaAngleUp } from "react-icons/fa";
import { selectPD, selectSubstation } from "../../../redux/views/Header/HeaderAction";

import "../../../styles/components/Demo.css";

// ** MUI Imports
import {
  Paper,
  Table,
  TableRow,
  TableHead,
  TableBody,
  TableCell,
  TableContainer,
  TablePagination,
  Button,
  Checkbox,
  IconButton,
} from "@material-ui/core";
import { TextField, Autocomplete } from "@mui/material";
import { Chip } from "@mui/joy";
import Form from "./Form";
import { amber } from "@mui/material/colors";
const columns = [
  { id: "substation", label: "Substation", minWidth: "25%", sort: "true" },
  {
    id: "installationYear",
    label: "Installation Year",
    minWidth: 120,
    align: "left",
    format: (value) => value.toLocaleString("en-US"),
    sort: "true",
  },
  {
    id: "size",
    label: "Size",
    minWidth: 100,
    align: "left",
    sort: "true",
  },
  {
    id: "eoc",
    label: "EOC",
    minWidth: 0,
    align: "left",
    sort: "true",
  },
  {
    id: "date",
    label: "Created At (mm/dd/yyyy)",
    minWidth: 120,
    paddingRight: 100,
    align: "center",
    format: (value) => value.toFixed(2),
  },
  {
    id: "status",
    label: "Status",
    minWidth: 0,
    align: "left",
    sort: "true",
  },
];

function createData(substation, installationYear, size, eoc, status) {
  const current = new Date();
  const date = `${current.getMonth()}/${current.getDate() + 1
    }/${current.getFullYear()}`;
  return { substation, installationYear, size, date, eoc, status };
}
const statusObj = {
  Permitted: { color: "#56CA00" },
  "Not Permitted": { color: "#FF4C51" },
  "In Progress": { color: "#16B1FF" },
};



const PDValues = [
  {
    value: "1C224300 Backbone Ring 24",
    rows: [
      createData("TSS185 Tollway", "2020", "Cabinet", "Millhouse", "Permitted"),
      createData("TSS945 Crete", "2020", "Cabinet", "BnM", "Not Permitted"),
      createData("TDC446 Lansing", "2020", "Medium", "S&L", "Permitted"),
      createData("TSS42 Round Lake", "2020 Q1", "Box", "BnM", "Permitted"),
    ],
  },
  {
    value: "1C224302 - TSS30 COLUMBUS PARK",
    rows: [
      createData("DCH59 Paw Paw", "2020 Q2", "Cabinet", "S&L", "In Progress"),
      createData(
        "TDC414 Roberts Road",
        "2020",
        "Cabinet",
        "Millhouse",
        "In Progress"
      ),
      createData(
        "DCJ15 Elwood",
        "2020 Q2",
        "2 Boxes",
        "Millhouse",
        "Permitted"
      ),
      createData("TSS89 Beverly", "2020 Q3", "2 Boxes", "S&L", "Not Permitted"),
      createData(
        "TDC251 Round Lake Beach Q3",
        "2020",
        "Medium",
        "S&L",
        "In Progress"
      ),
      createData("DCE17 Wonder Lake", "2020 Q2", "Box", "S&L", "In Progress"),
    ],
  },
  {
    value: "1C224302 - DCY310 Austin",
    rows: [
      createData("DCE29 Johnsburg", "2020 Q3", "Cabinet", "S&L", "Permitted"),
      createData(
        "DCE82 Richmond",
        "2020 Q1",
        "Cross Box",
        "S&L",
        "Not Permitted"
      ),
      createData(
        "DCC73 Techny ",
        "2020 Q2",
        "2 Boxes",
        "Millhouse",
        "Permitted"
      ),
      createData(
        "DCC85 Northbrook",
        "2020 Q2",
        "Cabinet",
        "Millhouse",
        "In Progress"
      ),
      createData(
        "DCC93 Highland Park",
        "2020",
        "Cabinet",
        "Millhouse",
        "Permitted"
      ),
      createData(
        "TSS193 McHenry",
        "2020 Q1",
        "2 Boxes",
        "Millhouse",
        "Not Permitted"
      ),
    ],
  },
];

const allRows = PDValues.map((item) => {
  return [...item.rows];
});
const allRowsData = [].concat(...allRows);
// const substationValuesOptions = allRowsData.map(
//   (element) => element.substation
// );
const HutPermitting = (props) => {
  const [substationValuesOptions,setsubstationValuesOptions]=useState([]);
  const tableRef = createRef();
  const clearSelectedRow = useSelector(
    (state) => state.hutPermittingFormReducer.clearSelectedTableRow
  );
  const [allData, setFilteredData] = useState(allRowsData);
  const dataState = useSelector((state)=>state.hutPermittingFormReducer);

  const substateOptions= dataState.subState;
  

  const [selectedValue, setSelectedValue] = useState(null);
  const [isActive, setIsActive] = useState(null);
  useEffect(() => {
    dispatch(showUpdateButton(false));
    dispatch(hidePermittingForm(false));
    if (clearSelectedRow) {
      setIsActive(null);
    }
      return()=>{
      dispatch(selectSubstation(null))
    }
  }, [clearSelectedRow]);
  const gridData = PDValues.reduce(
    (item, { rows }) => [...item, ...rows.map((i) => i)],
    []
  );
  const filteredDataValues = allRowsData
    .filter((item) => selectedValue===item.substation)
    .map((itemm) => {
      return itemm;
    });

  const selectedSubstationValue=useSelector((state)=>state.headerReducer.selectedSubstation);
  console.log('substation',selectedSubstationValue);
  // ** States
  const [page, setPage] = useState(0);
  const [rowsPerPage, setRowsPerPage] = useState(10);
  const [FilteredData, setFilteredDataValues] = useState(filteredDataValues);
  const dispatch = useDispatch();
  const hutstate=useSelector((state)=>state.hutPermittingFormReducer)
  const labelData = hutstate.hutLabel;
  useEffect(()=>{
    dispatch(getApi()).then((res)=>{
      if(res.status!== 404) {
        dispatch(getsubStation(res.map((data)=>{
          return data.substation
      }))) 
    }})
  },[])
  
  return (
    <div style={{ margin: "4.5rem 8rem 0.8rem 8rem", width: "89%" }}>
      <div class="informationContainer">
      <Autocomplete
        size="medium"
        disablePortal
        ListboxProps={{
          sx: { fontSize: 13 },
        }}
        options={substateOptions}
        onChange={(event, value) => {
          setSelectedValue(value);
          dispatch(getallDataBysubstation(value)).then((res)=>{
            dispatch(gethutPermitLabelData(res));
          })
          dispatch(selectSubstation(value))
        }}
        clearOnBlur
        value={selectedSubstationValue}
        style={{
          width: 340,
          marginTop: "3.2px",
        }}
        renderInput={(params) => (
          <TextField {...params} label="Substation" />
        )}
      />
      {selectedValue && (
          <div class="informationLabelsExecution">
            <label>
              EOC:{" "}
              <span>
                {labelData!==undefined && labelData.length>0  && labelData
                  .filter((item) => item.substation === selectedSubstationValue)
                  .map((item) => item.eocName)}
              </span>
            </label>
            <label>
              Size:{" "}
              <span>
                {labelData!==undefined && labelData.length>0  && labelData
                  .filter((item) => item.substation === selectedSubstationValue)
                  .map((item) => item.sizeName)}
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
                //           (item) => item.substation === selectedValue
                //         )
                //         .map((item) => item.status)
                //     ].color,
                // }}
              >
                {labelData!==undefined && labelData.length>0  && labelData
                  .filter((item) => item.substation === selectedSubstationValue)
                  .map((item) => item.status)}
              </span>
            </label>
          </div>
        )}
        </div>
      <div class="Form">
        <Form />
      </div>
    </div>
  );
};

export default HutPermitting;
