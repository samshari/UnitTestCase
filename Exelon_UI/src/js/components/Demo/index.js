// ** React Imports
import { useState } from "react";
import { hideForm } from "../../../redux/utils/Card/CardAction";
import { useSelector, useDispatch } from "react-redux";
import { selectPD } from "../../../redux/views/Header/HeaderAction";

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
} from "@material-ui/core";
import { Chip } from "@mui/joy";
import RealEstate from "../Engineering/RealEstate";
import LinkInformation from "../Engineering/LinkInformation";
import IFAFiber from "../Engineering/IFAFiber";
import IFCFiber from "../Engineering/IFCFiber";
import IFAMakeReady from "../Engineering/IFAMakeReady";
import IFCMakeReady from "../Engineering/IFCMakeReady";
import COCBidComplete from "../Engineering/COCBidComplete";
import DesignMiles from "../Engineering/DesignMiles";
import Devices from "../Engineering/Devices";
import PlannedPoleReplacements from "../Engineering/PlannedPoleReplacements";
import Owners from "../Engineering/Owners";
import CustomTabs from "../../utils/Tabs";
const columns = [
  { id: "sr_no", label: "Sr.No.", minWidth: 5, align: "center" },
  { id: "code", label: "Primary Key", minWidth: 120 },
  {
    id: "population",
    label: "Link Description",
    minWidth: 130,
    align: "left",
    format: (value) => value.toLocaleString("en-US"),
  },
  {
    id: "size",
    label: "Link Nickname",
    minWidth: 100,
    align: "left",
    format: (value) => value.toLocaleString("en-US"),
  },
  {
    id: "date",
    label: "Created At",
    minWidth: 30,
    paddingRight: 100,
    align: "left",
    format: (value) => value.toFixed(2),
  },
  {
    id: "status",
    label: "Status",
    minWidth: 0,
    align: "left",
  },
];

function createData(sr_no, code, population, size, status) {
  const current = new Date();
  const date = `${current.getDate()}/${
    current.getMonth() + 1
  }/${current.getFullYear()}`;
  return { sr_no, code, population, size, date, status };
}
const statusObj = {
  Active: { color: "#9155FD" },
  Removed: { color: "#FF4C51" },
  Combined: { color: "#FFB400" },
  Closed: { color: "#56CA00" },
  In_Service: { color: "#b784a7" },
  On_Hold: { color: "#16B1FF" },
};
const rows = [
  createData("1", "BF-TSS67-TDC714", "BF-TSS67-TDC714", 3287263, "Active"),
  createData("2", "BF-TSS67-TDC714", "DF-DCY310-DCY310-01", 9596961, "Closed"),
  createData("3", "BF-TSS67-TDC714", "DF-DCY310-DCY310-01", 301340, "On_Hold"),
  createData("4", "BF-TSS67-TDC714", "BF-TSS67-TDC714", 9833520, "Removed"),
  createData(
    "5",
    "BF-TSS67-TDC714",
    "DF-DCY310-DCY310-01",
    9984670,
    "Combined"
  ),
  createData("6", "BF-TSS67-TDC714", "BF-TSS67-TDC714", 7692024, "In_Service"),
  createData("7", "BF-TSS67-TDC714", "DF-DCY310-DCY310-01", 357578, "Active"),
  createData("8", "BF-TSS67-TDC714", "DF-DCY310-DCY310-01", 70273, "Combined"),
  createData(
    "9",
    "BF-TSS67-TDC714",
    "DF-DCY310-DCY310-01",
    1972550,
    "In_Service"
  ),
  createData("10", "BF-TSS67-TDC714", "DF-DCY310-DCY310-01", 377973, "Active"),
  createData("11", "BF-TSS67-TDC714", "DF-DCY310-DCY310-01", 640679, "Active"),
  createData("12", "BF-TSS67-TDC714", "DF-DCY310-DCY310-01", 242495, "Active"),
  createData(
    "13",
    "BF-TSS67-TDC714",
    "DF-DCY310-DCY310-01",
    17098246,
    "Active"
  ),
  createData("14", "BF-TSS67-TDC714", "DF-DCY310-DCY310-01", 923768, "Active"),
  createData("15", "BF-TSS67-TDC714", "DF-DCY310-DCY310-01", 8515767, "Active"),
];

const TabsArr = [
  {
    tabName: "Link Information",
    tabColor: "yellow",
    component: (
      <LinkInformation
        //   disableFields={disable}
        tabColor="yellow"
      />
    ),
  },
  {
    tabName: "EOC/ Real Estate",
    tabColor: "#00bfff",
    component: (
      <RealEstate
        // //   disableFields={disable}
        tabColor="#00bfff"
      />
    ),
  },
  {
    tabName: "IFA Fiber",
    tabColor: "#00ff00",
    component: (
      <IFAFiber
        // //   disableFields={disable}
        tabColor="#00ff00"
      />
    ),
  },
  {
    tabName: "IFC Fiber",
    tabColor: "orange",
    component: (
      <IFCFiber
        // //   disableFields={disable}
        tabColor="orange"
      />
    ),
  },
  {
    tabName: "IFA Make Ready",
    tabColor: "#66b032",
    component: (
      <IFAMakeReady
        // //   disableFields={disable}
        tabColor="#66b032"
      />
    ),
  },
  {
    tabName: "IFC Make Ready",
    tabColor: "#bcd4e6",
    component: (
      <IFCMakeReady
        // //   disableFields={disable}
        tabColor="#bcd4e6"
      />
    ),
  },
  {
    tabName: "COC Bid Complete",
    tabColor: "#C5B4E3",
    component: (
      <COCBidComplete
        // //   disableFields={disable}
        tabColor="#C5B4E3"
      />
    ),
  },
  {
    tabName: "Design Miles",
    tabColor: "#ffa500",
    component: (
      <DesignMiles
        // //   disableFields={disable}
        tabColor="#ffa500"
      />
    ),
  },
  {
    tabName: "Devices",
    tabColor: "#dea5a4",
    component: (
      <Devices
        // //   disableFields={disable}
        tabColor="#dea5a4"
      />
    ),
  },
  {
    tabName: "Planned Pole Replacements",
    tabColor: "#7BB2DD",
    component: (
      <PlannedPoleReplacements
        // //   disableFields={disable}
        tabColor="#7BB2DD"
      />
    ),
  },
  {
    tabName: "Owners",
    tabColor: "gray",
    component: (
      <Owners
        // //   disableFields={disable}
        tabColor="gray"
      />
    ),
  },
];
const PDValues = [
  {
    value: "1C224300 Backbone Ring 24",
    data: [
      {
        primaryKey: "BF-TSS67-TDC714",
        linkDescription: "BF-TSS67-TDC714",
        linkNickname: "1",
      },
      {
        primaryKey: "BF-TDC714-SS798",
        linkDescription: "BF-TDC714-SS798",
        linkNickname: "2",
      },
    ],
  },
  {
    value: "1C224302 - TSS30 COLUMBUS PARK",
    data: [
      {
        primaryKey: "DF-TSS30-TSS30-01",
        linkDescription: "DF-TSS30-TSS30-01",
        linkNickname: "1",
      },
      {
        primaryKey: "DF-TSS30-TSS38-01",
        linkDescription: "DF-TSS30-TSS38-01",
        linkNickname: "2",
      },
    ],
  },
  {
    value: "1C224302 - DCY310 Austin",
    data: [
      {
        primaryKey: "DF-DCY310-DCY310-01",
        linkDescription: "DF-DCY310-DCY310-01",
        linkNickname: "12",
      },
      {
        primaryKey: "DF-DCY310-DCY310-02",
        linkDescription: "DF-DCY310-DCY310-02",
        linkNickname: "13",
      },
    ],
  },
];
const Demo = (props) => {
  // ** States
  const [page, setPage] = useState(0);
  const [rowsPerPage, setRowsPerPage] = useState(10);
  //   const [showForm, setShowForm] = useState(false);
  const [selectedValue, setSelectedValue] = useState("");

  const dispatch = useDispatch();

  const handleChangePage = (event, newPage) => {
    setPage(newPage);
  };

  const handleChangeRowsPerPage = (event) => {
    setRowsPerPage(parseInt(event.target.value, 10));
    setPage(0);
  };
  const showForm = useSelector((state) => state.hideFormReducer.hideForm);
  return (
    <div style={{ margin: "7rem 8rem 0.8rem 8rem", width: "89%" }}>
      <div
        style={{
          display: !showForm ? "flex" : "none",
          justifyContent: "space-between",
        }}
      >
        <Button
          variant="contained"
          style={{
            backgroundColor: "purple",
            color: "white",
            display: showForm && "none",
          }}
          onClick={() => dispatch(hideForm(true))}
        >
          Add New
        </Button>
        <select
          class="pdDropdown"
          onChange={(value) => {
            setSelectedValue(value.target.value);
            dispatch(selectPD(value.target.value, true));
          }}
        >
          <option>--Select PD--</option>
          {PDValues.map((item) => {
            return <option>{item.value}</option>;
          })}
        </select>
      </div>
      {showForm && <CustomTabs data={TabsArr} />}
      <Paper
        style={{
          width: "100%",
          marginTop: "1rem",
          transition: "all 100s ease-in-out",
        }}
      >
        <TableContainer style={{ maxHeight: "380px" }}>
          <Table stickyHeader aria-label="sticky table">
            <TableHead>
              <TableRow>
                {columns.map((column) => (
                  <TableCell
                    key={column.id}
                    align={column.align}
                    style={{
                      width: column.minWidth,
                      paddingRight: column.paddingRight,
                    }}
                  >
                    {column.label}
                  </TableCell>
                ))}
              </TableRow>
            </TableHead>
            <TableBody>
              {rows
                .slice(page * rowsPerPage, page * rowsPerPage + rowsPerPage)
                .map((row) => {
                  return (
                    <TableRow
                      hover
                      role="checkbox"
                      tabIndex={-1}
                      key={row.code}
                    >
                      {columns.map((column) => {
                        const value = row[column.id];
                        return (
                          <TableCell
                            key={column.id}
                            align={column.align}
                            style={{ paddingRight: column.paddingRight }}
                          >
                            {column.id !== "status" ? (
                              column.format && typeof value === "number" ? (
                                column.format(value)
                              ) : (
                                value
                              )
                            ) : (
                              <Chip
                                color="primary"
                                style={{
                                  height: 14,
                                  fontSize: "0.75rem",
                                  textTransform: "capitalize",
                                  "& .MuiChip-label": { fontWeight: 500 },
                                  backgroundColor: `${
                                    statusObj[row.status].color
                                  }`,
                                  color: "white",
                                }}
                              >
                                {value === "On_Hold" && "On Hold"}
                                {value === "In_Service" && "In Service"}
                                {value !== "On_Hold" &&
                                  value !== "In_Service" &&
                                  value}
                              </Chip>
                            )}
                          </TableCell>
                        );
                      })}
                    </TableRow>
                  );
                })}
            </TableBody>
          </Table>
        </TableContainer>
        <TablePagination
          rowsPerPageOptions={[10, 25, 100]}
          component="div"
          count={rows.length}
          rowsPerPage={rowsPerPage}
          page={page}
          onPageChange={handleChangePage}
          onRowsPerPageChange={handleChangeRowsPerPage}
          // style={{ overflow: "hidden" }}
        />
      </Paper>
    </div>
  );
};

export default Demo;
