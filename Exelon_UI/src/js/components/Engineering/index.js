import { useState, useEffect } from "react";
import {
  getallPrimaryKey,
  getAllprimaryKeys,
  getLabelData,
  getLinkData,
  getLinkInfoByPrimaryKey,
  getPDID,
  getPrimaryKey,
  hideEngineeringForm,
  showUpdateButton,
} from "../../../redux/components/Engineering/EngineeringAction";
import { useSelector, useDispatch } from "react-redux";
import { selectPD } from "../../../redux/views/Header/HeaderAction";
import { selectPrimaryKey } from "../../../redux/views/Header/HeaderAction";
import { TextField, Autocomplete } from "@mui/material";
import "../../../styles/components/Engineering.css";
import "../../../styles/utils/DatePicker.css";

// ** MUI Imports
import { Checkbox } from "@material-ui/core";
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
import { getPDApi } from "../../../redux/components/Engineering/PD/PDAction";
import { disableTabs } from "../../../redux/utils/Tabs/TabsAction";
import { getProjectId, getProjectIDByPD } from "../../../redux/components/ExecutionLinks/ExecutionLinksAction";

const current = new Date();
const date = `${current.getMonth()}/${current.getDate() + 1
  }/${current.getFullYear()}`;
function createData(
  primaryKey,
  linkDescription,
  linkNickname,
  technology,
  status
) {
  return {
    primaryKey,
    linkDescription,
    linkNickname,
    technology,
    date,
    status,
  };
}
const statusObj = {
  Active: { color: "#9155FD" },
  Removed: { color: "#FF4C51" },
  Combined: { color: "#FFB400" },
  Closed: { color: "#56CA00" },
  "In Service": { color: "#b784a7" },
  "On Hold": { color: "#16B1FF" },
  NA: { color: "red" }
};


const PDValues = [
  {
    value: "1C224300 Backbone Ring 24",
    rows: [
      {
        primaryKey: "BF-TSS48-TDC212",
        linkDescription: "PD Loc. 1 to PD Loc. 2 AF",
        linkNickname: "1",
        technology: "ROP",
        date: date,
        status: "Active",
      },
      createData(
        "BF-TSS48-TDC213",
        "TSS48 Highland Park to TDC212 Northbrook BBF",
        "2",
        "ROP",
        "Closed"
      ),
      createData(
        "DF-TSS48-TSS48-01",
        "TSS48 Highland Park to TDC213 Deerfield BBF",
        "3",
        "ROP",
        "On Hold"
      ),
      createData(
        "AF-TSS48-TSS48-01.01",
        "TSS48 Highland Park to TSS48 Highland Park DFR",
        "4",
        "ROP",
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
        "ROP",
        "Removed"
      ),
      createData(
        "AF-TSS48-TSS48-01.04",
        "DCC73 Techny to DCC73 Techny AF",
        "6",
        "ROP",
        "Combined"
      ),
      createData("BF-TDC714-SS798", "BF-TDC714-SS798", "7", "NA", "In Service"),
      createData("BF-TSS38-TSS50", "BF-TSS50-SS798", "8", "ROP", "Active"),
      createData("BF-SS750-SS709", "BF-TSS38-TSS50", "1", "NA", "Combined"),
      createData("BF-TSS38-SS750", "BF-TSS38-SS750", "2", "ROP", "In Service"),
    ],
  },
  {
    value: "1C224302 - DCY310 Austin",
    rows: [
      createData(
        "BF-SS750-SS793",
        "(PD Loc. 3 to D5) to (D5 to Loc. 3) AF",
        "3",
        "ROP",
        "Active"
      ),
      createData("BF-TSS30-TSS67", "BF-TSS30-TSS67", "4", "ROP", "Active"),
      createData(
        "DF-TSS30-TSS30-01",
        "DF-DCY310-DCY310-01",
        "4",
        "ROP",
        "Active"
      ),
      createData(
        "DF-TSS30-TSS30-02",
        "DF-TSS30-TSS30-02",
        "5",
        "ROP",
        "Active"
      ),
      createData(
        "DF-TSS30-TSS30-03",
        "DF-TSS30-TSS30-03",
        "5",
        "ROP",
        "Active"
      ),
      createData(
        "DF-TSS30-TDC505-01",
        "DF-TSS30-TDC505-01",
        "6",
        "ROP",
        "Active"
      ),
    ],
  },
];

const allRows = PDValues.map((item) => {
  return [...item.rows];
});
const pd = PDValues.map((item) => {
  return item.value;
});
const id = pd.map((item, index) => {
  console.log(index)
})

const allRowsData = [].concat(...allRows);

const Engineering = (props) => {
  const [loading, setLoading] = useState(true);
  const [PDID, selectedPDID] = useState(null);

  const selectedPD = useSelector((state) => state.headerReducer.selectedPD);
  const primaryKey = useSelector(
    (state) => state.headerReducer.selectedPrimaryKey
  );

  const filteredData = PDValues.filter((item) =>
    selectedPD.includes(item.value)
  ).map((itemm) => {
    return itemm;
  });

  const selectedFilteredData = filteredData.reduce(
    (item, { rows }) => [...item, ...rows.map((i) => i)],
    []
  );

  const globalPrimaryKey = useSelector((state)=>state.headerReducer.selectedPrimaryKey)
  // ** States
  const [allData, setFilteredData] = useState([]);
  const [indexData,setIndexData]=useState([]);
  const [linkingID, setLinkingId] = useState(0);
  const [selectedValue, setSelectedValue] = useState(selectedPD);
  const [selectedPrimaryKey, setSelectedPrimaryKey] = useState(null);
  const dispatch = useDispatch();
  const [allprimaryKey,setAllprimaryKey]=useState([])
  const PDData = useSelector((state) => {
    return state;
  });
  const createlinkID=useSelector((state)=>state.engineeringFormReducer?.linkingID)
  const updatelinkID=useSelector((state)=>state.engineeringFormReducer?.data?.linkingId);
  var data = [];
  const TabsArr = [
    {
      tabName: "Link Information",
      tabColor: "yellow",
      disable: selectedPD.length===0 && selectedPrimaryKey===null && true,
      component: (
        <LinkInformation
          // disableFields={disable}
          tabColor="yellow"
          linkingID={data}
          primaryKey={data}
          disableFields={selectedPD.length===0 && selectedPrimaryKey===null && true} 
        />
      ),
    },
    {
      tabName: "EOC/ Real Estate",
      tabColor: "#00bfff",
      disable:  true,
      component: <RealEstate tabColor="#00bfff" linkingID={linkingID} 
      disableFields={(createlinkID >0 ) || (updatelinkID>0) || selectedPD.length>0 ?false:true}
      />,
    },
    {
      tabName: "IFA Fiber",
      tabColor: "#00ff00",
      disable: true,
      component: (
        <IFAFiber
          tabColor="#00ff00"
          linkingID={linkingID}
          disableFields={(createlinkID >0 ) || (updatelinkID>0) ?false:true}
        />
      ),
    },
    {
      tabName: "IFC Fiber",
      tabColor: "orange",
      disable: true,
      component: (
        <IFCFiber
          tabColor="orange"
          linkingID={linkingID}
          disableFields={(createlinkID >0 ) || (updatelinkID>0) ?false:true}
        />
      ),
    },
    {
      tabName: "IFA Make Ready",
      tabColor: "#66b032",
      disable: true,
      component: (
        <IFAMakeReady
          tabColor="#66b032"
          linkingID={linkingID}
          disableFields={(createlinkID >0 ) || (updatelinkID>0) ?false:true}
        />
      ),
    },
    {
      tabName: "IFC Make Ready",
      tabColor: "#bcd4e6",
      disable: true,
      component: (
        <IFCMakeReady
          tabColor="#bcd4e6"
          linkingID={linkingID}
          disableFields={(createlinkID >0 ) || (updatelinkID>0) ?false:true}
        />
      ),
    },
    {
      tabName: "COC Bid Complete",
      tabColor: "#C5B4E3",
      disable: true,
      component: (
        <COCBidComplete
          tabColor="#C5B4E3"
          linkingID={linkingID}
          disableFields={(createlinkID >0 ) || (updatelinkID>0) ?false:true}
        />
      ),
    },
    {
      tabName: "Design Miles",
      tabColor: "#ffa500",
      linkingID: linkingID,
      disable: true,
      component: (
        <DesignMiles
          tabColor="#ffa500"
          linkingID={linkingID}
          disableFields={(createlinkID >0 ) || (updatelinkID>0) ?false:true}
        />
      ),
    },
    {
      tabName: "Devices",
      tabColor: "#dea5a4",
      disable: true,
      component: (
        <Devices
          tabColor="#dea5a4"
          linkingID={linkingID}
          disableFields={(createlinkID >0 ) || (updatelinkID>0) ?false:true}
        />
      ),
    },
    {
      tabName: "Planned Pole Replacements",
      tabColor: "#7BB2DD",
      disable: true,
      component: (
        <PlannedPoleReplacements
          tabColor="#7BB2DD"
          linkingID={linkingID}
          disableFields={(createlinkID >0 ) || (updatelinkID>0) ?false:true}
        />
      ),
    },
    {
      tabName: "Owners",
      tabColor: "gray",
      disable: true,
      component: (
        <Owners
          tabColor="gray"
          linkingID={linkingID}
          disableFields={(createlinkID >0 ) || (updatelinkID>0) ?false:true}
        />
      ),
    },
  ];
  const pdID = useSelector((state) => state.engineeringFormReducer.id);
  console.log('pdid',pdID);
  useEffect(() => {
    dispatch(showUpdateButton(false));
    dispatch(hideEngineeringForm(false));
    dispatch(getPDApi()).then((res) => setLoading(false))
    dispatch(getPrimaryKey(0)).then((res)=> { res?.status!==404 && 
      dispatch(getAllprimaryKeys(res.map((item)=>{
      return item.primaryKey;
    })))
    pdID!==undefined && pdID!==null && dispatch(getPrimaryKey(pdID)).then((Res) => {
      // setFilteredData(Res);
      dispatch(getallPrimaryKey(Res));
    })
  })
    return () => {
      dispatch(selectPrimaryKey(null))
    }
  }, [dispatch]);


  const PDValuesOptions = PDData?.PDReducer?.data!==null ? PDData?.PDReducer?.data.status!==404  ? PDData?.PDReducer?.data?.map((item) => {
    return item.name;
  }):[]:[];
  const PDValuesIDs = PDData?.PDReducer?.data!==null ? PDData?.PDReducer?.data.status!==404 ? PDData?.PDReducer?.data?.map((item) => {
    return item;
  }):[]:[];

  const allprimaryData = PDData?.engineeringFormReducer?.allPk;

  const allPrimaryKey = PDData?.engineeringFormReducer?.allPrimaryKey;
  const labelData = PDData?.engineeringFormReducer?.labelData;

  return (
    <>
      {
        !loading && <div style={{ margin: "4.5rem 8rem 0.8rem 8rem", width: "89%" }}>
          <div
            style={{
              display: "flex",
            }}
          >
            <Autocomplete
              size="medium"
              // multiple
              disablePortal
              ListboxProps={{
                sx: { fontSize: 13 },
              }}
              options={PDValuesOptions}
              onChange={(event, value) => {
                value===null && dispatch(disableTabs(true));
                setSelectedValue(value);
                dispatch(selectPrimaryKey(null));
                setSelectedPrimaryKey(null);
                dispatch(getLinkData([]));
                setLinkingId(0);
                PDValuesIDs?.filter((item) => {
                  if (item.name === value) {
                    dispatch(getPrimaryKey(item.pdid)).then((Res) => {
                      // setFilteredData(Res);
                      dispatch(getallPrimaryKey(Res));
                    })
                    dispatch(getProjectId(item.pdid)).then((Res) => {
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
                selectedPD.length===0 ?
                allPrimaryKey?.length>0? allPrimaryKey?.map((item)=>item):[]:
                 allprimaryData?.length>0 ? allprimaryData?.map((item) => {
                  return item.primaryKey;
                }):[]
              }
              onChange={(event, value) => {
                setSelectedPrimaryKey(value);
                value!==null ? dispatch(selectPrimaryKey(value)):dispatch(selectPrimaryKey(null));;
                dispatch(getLinkInfoByPrimaryKey(value)).then((res) => {
                  setIndexData(res);
                  dispatch(getLabelData(res));
                  dispatch(getLinkData(res[0]));
                  setLinkingId(res[0]?.linkingID);
                }) 
                value ===null && dispatch(getLinkInfoByPrimaryKey(value)).then((res) => {
                  setIndexData(res);
                  dispatch(getLinkData([]));
                  setLinkingId(0)})
   
              }}
              clearOnBlur
              style={{
                width: 340,
              }}
              renderInput={(params) => (
                <TextField {...params} label="Primary Key" />
              )}
              renderOption={(props, option, { selected }) => (
                <div {...props} style={{ height: "1.5rem", paddingLeft: "15px" }}>
                  <p>{props.key}</p>
                </div>
              )}
              value={globalPrimaryKey}
            />
            {selectedPrimaryKey && (
              <div class="informationLabels">
                <label class="linkDescriptionLabel">
                  Link Description:{" "}
                  <span>
                    {
                     labelData!==undefined && labelData.length>0  && labelData?.filter((item) =>  item.primaryKey === globalPrimaryKey)
                      .map((item) => item.description)}
                  </span>
                </label>
                <label>
                  Link Nickname:{" "}
                  <span>
                    {labelData!==undefined && labelData.length>0  && labelData?.filter((item) => item.primaryKey === globalPrimaryKey)
                      .map((item) => item.nickname)}
                  </span>
                </label>
                <label>
                  Status:{" "}
                  <span
                    class="Chip"
                  // style={{
                  //   backgroundColor:
                  //     statusObj[
                  //       {...allData
                  //       .filter((item) => item.primaryKey === selectedPrimaryKey)
                  //       .map((item) => [item.statusName]).map((item)=> item[0])}
                  //     ].color,
                  // }}
                  >
                    { labelData!==undefined && labelData.length>0  && labelData
                      .filter((item) => item.primaryKey === globalPrimaryKey)
                      .map((item) => [item.statusName ])}
                  </span>
                </label>
              </div>
            )}
          </div>

          <CustomTabs data={TabsArr} />
        </div>
      }
    </>
  );
};

export default Engineering;
