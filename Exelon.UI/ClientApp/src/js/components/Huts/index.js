// ** React Imports
import { useState, createRef, useEffect } from "react";
import {
  hideHutsForm,
  showUpdateButton,
} from "../../../redux/components/Huts/HutsAction";
import { useSelector, useDispatch } from "react-redux";
import { selectLocation, selectPD } from "../../../redux/views/Header/HeaderAction";
import "../../../styles/components/Demo.css";

// ** MUI Imports

import { TextField, Autocomplete } from "@mui/material";

import Form from "./Form";


function createData(location, region, size, vendor, pm) {
  const current = new Date();
  const date = `${current.getMonth()}/${current.getDate() + 1
    }/${current.getFullYear()}`;
  return { location, region, size, date, vendor, pm };
}


const PDValues = [
  {
    value: "1C224300 Backbone Ring 24",
    rows: [
      createData(
        "DCW236 Roselle",
        "West",
        "Trachte",
        "Trachte",
        "Simone Harris"
      ),
      createData(
        "ESS-W500 VVF Corporation",
        "West",
        "Trachte",
        "Trachte",
        "Simone Harris"
      ),
      createData(
        "TDC 552 Addison",
        "West",
        "Medium",
        "Fibrebond",
        "Simone Harris"
      ),
      createData(
        "TDC 555 Glen Ellyn",
        "North",
        "Medium",
        "Fibrebond",
        "Simone Harris"
      ),
    ],
  },
  {
    value: "1C224302 - TSS30 COLUMBUS PARK",
    rows: [
      createData(
        "TDC 592 Oswego",
        "North",
        "Large",
        "Fibrebond",
        "Kayli Altobelli"
      ),
      createData(
        "TDC206 Rollings Meadows",
        "North",
        "Medium",
        "Fibrebond",
        "Kayli Altobelli"
      ),
      createData(
        "TDC574  Bartlett",
        "North",
        "Large",
        "Fibrebond",
        "Kayli Altobelli"
      ),
      createData(
        "TSS 106 Montgomery",
        "North",
        "Cabinet",
        "Charles",
        "Simone Harris"
      ),
      createData(
        "TSS 143 Wolfs Crossing",
        "North",
        "NA",
        "Charles",
        "Simone Harris"
      ),
      createData(
        "TSS 198 Des Plaines",
        "South",
        "Medium",
        "Charles",
        "Kayli Altobelli"
      ),
    ],
  },
  {
    value: "1C224302 - DCY310 Austin",
    rows: [
      createData(
        "TSS 46 Des Plaines",
        "South",
        "Medium",
        "Charles",
        "Kayli Altobelli"
      ),
      createData(
        "Tech Center - Maywood",
        "North",
        "Large",
        "Charles",
        "Simone Harris"
      ),
      createData(
        "TDC220 Schaumburg (Staton)",
        "North",
        "Large",
        "Charles",
        "Simone Harris"
      ),
      createData(
        "TDC214 Hoffman Estates (Station)",
        "North",
        "Cabinet",
        "Charles",
        "Simone Harris"
      ),
      createData(
        "TDC253 Schaumburg (Station)",
        "North",
        "NA",
        "Charles",
        "Simone Harris"
      ),
      createData(
        "TDC372 Sterling (Station)",
        "North",
        "NA",
        "Charles",
        "Simone Harris"
      ),
    ],
  },
];

const allRows = PDValues.map((item) => {
  return [...item.rows];
});
const allRowsData = [].concat(...allRows);

const Huts = (props) => {
  const clearSelectedRow = useSelector(
    (state) => state.hutsFormReducer.clearSelectedTableRow
  );

  const selectedPD = useSelector((state) => state.headerReducer.selectedPD);

  const filteredData = PDValues.filter((item) =>
    selectedPD.includes(item.value)
  ).map((itemm) => {
    return itemm;
  });
  const selectedFilteredData = filteredData.reduce(
    (item, { rows }) => [...item, ...rows.map((i) => i)],
    []
  );
  // ** States
  const [page, setPage] = useState(0);
  const [rowsPerPage, setRowsPerPage] = useState(10);
  const [allData, setFilteredData] = useState(allRowsData);
  const [selectedValue, setSelectedValue] = useState([selectedPD]);
  const [FilteredData, setFilteredDataValues] = useState(selectedFilteredData);
  const [selectedLocationValue, setSelectedLocation] = useState(null)
  const [isActive, setIsActive] = useState(null);

  const dispatch = useDispatch();
  const PDValuesOptions = PDValues.map((item) => {
    return item.value;
  });

  useEffect(() => {
    dispatch(showUpdateButton(false));
    dispatch(hideHutsForm(false));
    if (clearSelectedRow) {
      setIsActive(null);
    }
    return () => {
      dispatch(selectLocation(null))
    }
  }, [clearSelectedRow, dispatch]);
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
            value !== null
              ? dispatch(selectPD(value, true))
              : dispatch(selectPD([], true));
          }}
          clearOnBlur
          style={{
            width: 340,
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
                ? allData.map((item) => {
                  return item.location;
                })
                : selectedFilteredData.map((item) => {
                  return item.location;
                })
            }
            onChange={(event, value) => {
              setSelectedLocation(value);
              dispatch(selectLocation(value));
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
                Region:{" "}
                <span>
                  {allData
                    .filter((item) => item.location === selectedLocationValue)
                    .map((item) => item.region)}
                </span>
              </label>
              <label>
                Hut Size:{" "}
                <span>
                  {allData
                    .filter((item) => item.location === selectedLocationValue)
                    .map((item) => item.size)}
                </span>
              </label>
              <label>
                Hut Vendor:{" "}
                <span>
                  {allData
                    .filter((item) => item.location === selectedLocationValue)
                    .map((item) => item.vendor)}
                </span>
              </label>
            </div>
          )}
        </div>
      </div>

      <div class="Form">
        <Form />
      </div>
    </div>
  );
};

export default Huts;
