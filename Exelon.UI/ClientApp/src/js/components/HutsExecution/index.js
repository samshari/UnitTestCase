// ** React Imports
import { useState, createRef, useEffect } from "react";
import {
  hideHutsExecutionForm,
  showUpdateButton,
} from "../../../redux/components/HutsExecution/HutsExecutionAction";
import { useSelector, useDispatch } from "react-redux";
import { selectHutsExecutionLocation, selectPD } from "../../../redux/views/Header/HeaderAction";
import { FaEdit } from "react-icons/fa";
import { TextField, Autocomplete } from "@mui/material";
import "../../../styles/components/Engineering.css";

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
  IconButton,
  Checkbox,
} from "@material-ui/core";
import { Chip } from "@mui/joy";
import CivilSubgradeHut from "./CivilSubgradeHut";
import Phase1 from "./LinkInformationPhase1";
import AuxPowerCivilElectrical from "./AuxPowerCivilElectrical";
import RP from "./R&P";
import Fiber from "./Fiber";
import RouterUpgrades from "./RouterUpgrades";
import HutTestingLNL from "./HutTestingLNL";
import CustomTabs from "../../utils/Tabs";
import { FaAngleDown, FaAngleUp } from "react-icons/fa";

const columns = [
  {
    id: "location",
    label: "Location",
    minWidth: "28%",
    format: (value) => value.toLocaleString("en-US"),
    sort: "true",
  },
  { id: "deliveryYear", label: "Delivery Year", minWidth: 150, sort: "true",align: "left" },
  {
    id: "hutType",
    label: "Hut Type",
    minWidth: 150,
    align: "left",
    sort: "true",
  },
  {
    id: "barn",
    label: "Barn",
    minWidth: 150,
    align: "left",
    sort: "true",
  },
  {
    id: "region",
    label: "Region",
    minWidth: 70,
    paddingRight: 100,
    align: "center",
    format: (value) => value.toFixed(2),
    sort: "true",
  },
  {
    id: "date",
    label: "Created At (mm/dd/yyyy)",
    paddingLeft: "5%",
    minWidth: "22%",
    align: "center",
  },
  // {
  //   id: "editIcon",
  //   label: "Edit",
  //   minWidth: 0,
  //   align: "left",
  // },
];
const current = new Date();
const date = `${current.getMonth()}/${
  current.getDate() + 1
}/${current.getFullYear()}`;
function createData(location, deliveryYear, hutType, barn, region) {
  return {
    location,
    deliveryYear,
    hutType,
    barn,
    region,
    date,
  };
}
const statusObj = {
  Active: { color: "#9155FD" },
  Removed: { color: "#FF4C51" },
  Combined: { color: "#FFB400" },
  Closed: { color: "#56CA00" },
  "In Service": { color: "#b784a7" },
  "On Hold": { color: "#16B1FF" },
};

const TabsArr = [
  {
    tabName: "Link Information",
    tabColor: "#967bb6",
    component: <Phase1 tabColor="#967bb6" phase1 />,
  },
  {
    tabName: "Civil/Subgrade Hut",
    tabColor: "#367588",
    component: <CivilSubgradeHut tabColor="#367588" />,
  },
  {
    tabName: "Aux Power Civil Electrical",
    tabColor: "orange",
    component: <AuxPowerCivilElectrical tabColor="orange" />,
  },
  {
    tabName: "R&P",
    tabColor: "#967bb6",
    component: <RP tabColor="#967bb6" />,
  },
  {
    tabName: "Fiber",
    tabColor: "#b94e48",
    component: <Fiber tabColor="#b94e48" />,
  },
  {
    tabName: "Router Upgrades",
    tabColor: "orange",
    component: <RouterUpgrades tabColor="orange" />,
  },
  {
    tabName: "Hut Testing LNL",
    tabColor: "#66b032",
    component: <HutTestingLNL tabColor="#66b032" />,
  },
];
const PDValues = [
  {
    value: "1C224300 Backbone Ring 24",
    rows: [
      {
        deliveryYear: "2020",
        location: "Tech Center",
        hutType: "Cabinet",
        technology: "ROP",
        barn: "Maywood",
        region: "N",
        date: date,
      },
      createData("TDC220 South Schaumburg", "2020", "Cabinet", "Maywood", "S"),
      createData("TDC214 Hoffman Estates", "2022", "Box", "Maywood", "C"),
      createData("TSS86 Davis Creek", "2021", "Cabinet", "Mt Prospect", "W"),
    ],
  },
  {
    value: "1C224302 - TSS30 COLUMBUS PARK",
    rows: [
      createData(
        "DCH62 Sterling (Station)",
        "2020",
        "Medium",
        "Mt Prospect",
        "E"
      ),
      createData("TSS179 Bloom", "2021", "Box", "University Park", "W"),
      createData("TDC452 Glenwood ", "2022", "Medium", "Dixon", "N"),
      createData("TDC461 Crestwood", "2023", "Cabinet", "University Park", "W"),
      createData(
        "TSS107 Dixon and TDC317 (Comb)",
        "2020",
        "Large",
        "Crestwood",
        "W"
      ),
      createData(
        "TSS154 Libertyville (Station)",
        "2021",
        "2 Boxes",
        "Dixon",
        "W"
      ),
    ],
  },
  {
    value: "1C224302 - DCY310 Austin",
    rows: [
      createData(
        "TSS133 Rock Falls (Station)",
        "2020",
        "Large",
        "Libertyville",
        "N"
      ),
      createData("TSS185 Tollway", "2022", "Medium", "Dixon", "E"),
      createData("TSS945 Crete Energy Center", "2021", "Cabinet", "Elgin", "E"),
      createData("TSS139 Mendota", "2022", "2 Boxes", "Elgin", "N"),
      createData("TSS60 Alsip", "2022", "Large", "Crestwood", "W"),
      createData(
        "TDC446 Lancing (Station)",
        "2023",
        "Medium",
        "University Park",
        "W"
      ),
    ],
  },
];

const allRows = PDValues.map((item) => {
  return [...item.rows];
});
const allRowsData = [].concat(...allRows);

const HutsExecution = (props) => {
  const tableRef = createRef();
  const selectedPD = useSelector((state) => state.headerReducer.selectedPD);
  const clearSelectedRow = useSelector(
    (state) => state.hutsExecutionFormReducer.clearSelectedTableRow
  );
  useEffect(() => {
    dispatch(showUpdateButton(false));
    dispatch(hideHutsExecutionForm(false));
    if (clearSelectedRow) {
      setIsActive(null);
    }
      return()=>{
      dispatch(selectHutsExecutionLocation(null))
    }
  }, [clearSelectedRow]);
  const filteredData = PDValues.filter((item) =>
    selectedPD.includes(item.value)
  ).map((itemm) => {
    return itemm;
  });

  const selectedFilteredData = filteredData.reduce(
    (item, { rows }) => [...item, ...rows.map((i) => i)],
    []
  );

  const defaultPDValue = [];
  // ** States
  const [page, setPage] = useState(0);
  const [rowsPerPage, setRowsPerPage] = useState(10);
  const [allData, setFilteredData] = useState(allRowsData);
  const [selectedValue, setSelectedValue] = useState([selectedPD]);
  const [FilteredData, setFilteredDataValues] = useState(selectedFilteredData);
  const [selectedLocationValue, setSelectedLocation]=useState(null)
  const [isActive, setIsActive] = useState(null);

  const dispatch = useDispatch();

  const handleChangePage = (event, newPage) => {
    setPage(newPage);
    // tableRef.current?.scrollTop = 0;
    tableRef.current && tableRef.current.scrollIntoView();
  };

  const handleChangeRowsPerPage = (event) => {
    setRowsPerPage(parseInt(event.target.value, 10));
    setPage(0);
  };
  const PDValuesOptions = PDValues.map((item) => {
    return item.value;
  });
  const editData = () => {
    dispatch(showUpdateButton(true));
  };
  const handleFilter = (value) => {
    if ([...selectedPD].length === 0) {
      const data = allData.filter(
        (item) =>
          // lowerCase search
          item.deliveryYear.toLowerCase().includes(value) ||
          item.location.toLowerCase().includes(value) ||
          item.hutType.toLowerCase().includes(value) ||
          item.barn.toLowerCase().includes(value) ||
          item.region.toLowerCase().includes(value) ||
          //Upper Case search
          item.deliveryYear.includes(value) ||
          item.location.includes(value) ||
          item.hutType.includes(value) ||
          item.barn.includes(value) ||
          item.region.includes(value)
      );
      value === "" ? setFilteredData(allRowsData) : setFilteredData([...data]);
    } else {
      const data = selectedFilteredData.filter(
        (item) =>
          // lowerCase search
          item.deliveryYear.toLowerCase().includes(value) ||
          item.location.toLowerCase().includes(value) ||
          item.hutType.toLowerCase().includes(value) ||
          item.barn.toLowerCase().includes(value) ||
          item.region.toLowerCase().includes(value) ||
          //Upper Case search
          item.deliveryYear.includes(value) ||
          item.location.includes(value) ||
          item.hutType.includes(value) ||
          item.barn.includes(value) ||
          item.region.includes(value)
      );
      value === ""
        ? setFilteredDataValues([...selectedFilteredData])
        : setFilteredDataValues([...data]);
    }
  };
  const handleRowClick = (i) => {
    if (i === isActive) {
      setIsActive(null);
    } else {
      setIsActive(i);
    }
  };
  return (
    <div style={{ margin: "4.5rem 8rem 0.8rem 8rem", width: "89%" }}>
      <div
        
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
            value!==null
              ? dispatch(selectPD(value, true))
              : dispatch(selectPD([], true));
          }}
          clearOnBlur
          style={{
            width:340,
            marginTop: "3.2px",
          }}
          renderInput={(params) => <TextField {...params} label="PD" />}
          renderOption={(props, option, { selected }) => (
            <div {...props} style={{ height: "1.5rem", paddingLeft: "10px" }}>
              <p>{props.key}</p>
            </div>
          )}
          disableCloseOnSelect
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
            selectedPD.length===0
              ? allData.map((item) => {
                  return item.location;
                })
              : selectedFilteredData.map((item) => {
                  return item.location;
                })
          }
          onChange={(event, value) => {
            setSelectedLocation(value);
            dispatch(selectHutsExecutionLocation(value));
          }}
          clearOnBlur
          style={{
            width: 340,
          }}
          renderInput={(params) => (
            <TextField {...params} label="Location" />
          )}
          renderOption={(props) => (
            <div {...props} style={{ height: "1.5rem", paddingLeft: "15px" }}>
              <p>{props.key}</p>
            </div>
          )}
          disableCloseOnSelect
          value={selectedLocationValue}
        />
        {selectedLocationValue && (
          <div class="informationLabelsExecution">
            <label>
              Delivery Year:{" "}
              <span>
                {allData
                  .filter((item) => item.location === selectedLocationValue)
                  .map((item) => item.deliveryYear)}
              </span>
            </label>
            <label>
              Hut Type:{" "}
              <span>
                {allData
                  .filter((item) => item.location === selectedLocationValue)
                  .map((item) => item.hutType)}
              </span>
            </label>
            <label>
              Barn:{" "}
              <span>
                {allData
                  .filter((item) => item.location === selectedLocationValue)
                  .map((item) => item.barn)}
              </span>
            </label>
          </div>
        )}
      </div>
      <CustomTabs data={TabsArr} />
    </div>
  );
};

export default HutsExecution;
