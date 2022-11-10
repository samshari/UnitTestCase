// Redux and Component Imports
import React from "react";
import Card from "../../utils/Card";
import { useEffect, useState } from "react";
import { useDispatch, useSelector } from "react-redux";
import CustomSnackBar from "../../utils/Snackbar";
import { getApi, updateApi, createApi } from "../../../redux/components/ExecutionLinks/Boring/BoringAction"
import { getBoringApi } from '../../../redux/components/ExecutionLinks/Boring/BoringCocAction'

//Static State Data
// let id = 6;


//Compnent RAFCE CODE
const Boring = (props) => {
  let fK_BORINGCOCID = 6;
  let boringName = ''
  let count = 0;
  const datatest = useSelector((state) => state.hideExecutionLinksFormReducer?.data);
  //UseState Declarations
  const [apiData, setapiData] = useState([]);
  const [loading, setLoading] = useState(true);
  const [loading1, setLoading1] = useState(true);
  const [ID, setID] = useState(0);
  const [isDataUpdated,setDataUpdated]=useState(false);
  const [open, setOpen] = React.useState(false);

  const [message, setMessage] = useState("");
  const handleToClose = (event, reason) => {
    if ("clickaway" == reason) return;
    setOpen(false);
  };
  console.log('mssge',message);
  //Selector and Dispatcher
  const data2 = useSelector((state) => {
    return state;
  })
  const dispatch = useDispatch();

  const createLink = useSelector((state)=>state.hideExecutionLinksFormReducer?.globallinkID);
  // Update Boring through API CALL

  const updateData = (data, dropData) => {
    updateApi(ID, data, dropData, datatest?.executionLinkingID).then((res) => {
      if (res.status === 200){
        setDataUpdated(!isDataUpdated);
        setOpen(true);
        setMessage(`Data Updated SuccessFully!`);
      }
      else if(res.id>0){
        setID(res.id);
        setOpen(true);
        setMessage(`Data Created SuccessFully`);
      }
      else{
        setOpen(true);
        setMessage(res.message);
      }
    })
  }

  // Create Boring through API CALL
  const createData = (data,dropData) => {
    createApi(data,dropData,createLink).then((res) => {
      if (res.id > 0){
        setID(res.id);
        setOpen(true)
        setMessage(`Data Created SuccessFully!`);
      }
      else{
      setOpen(true)
      setMessage(res.message);
      }
    })
  }

  //Loading Conditions  
  useEffect(() => {
   if(datatest?.executionLinkingID!==undefined){dispatch(getApi()).then((res) => {
      res?.status !== 404 && res.map((data) => {
        if (data.fK_LinkingID === datatest?.executionLinkingID) {
          setID(data.boringID);
          setapiData(data);
          count = count+1;
        }
        return data;
      })
      if(count === 0){
        setID(0);
        setapiData([]);
      }
      setLoading(false)
    })
  }
  else
  { 
      setLoading(false);
      setapiData([])
  }
    dispatch(getBoringApi()).then((res) => {
      setLoading1(false);
    })
  }, [dispatch,datatest?.executionLinkingID,ID>0,isDataUpdated])


  //Set Coc credentials
  let item = data2?.BoringCOCReducer?.data;
  item?.status !==404 && item?.map((value) => {
    let boring_id = 0;
    if (data2?.BoringReducer?.data && data2?.BoringReducer?.data?.status!=404) {
      data2?.BoringReducer?.data.filter((res) => {
        if (res.fK_LinkingID === datatest?.executionLinkingID)
          boring_id = res.fK_BoringCOCID;
      })
    }
    if (value.cocid === boring_id) {
      fK_BORINGCOCID = boring_id
      boringName = value.name
    }
  })


  //Data Prop for PreConstruction Card
  const data = [
    {
      type: "dropdown", placeholder: "Boring COC", dropDownValues: data2?.BoringCOCReducer?.data === null ? [] : data2?.BoringCOCReducer?.data, defaultDrop: fK_BORINGCOCID,
      defaultValue: boringName
    },
    { type: "date", placeholder: "startDate", defaultValue: apiData?.boringID > 0 ? apiData.startDate : '' },
    { type: "date", placeholder: "endDate", defaultValue: apiData?.boringID > 0 ? apiData.endDate : '' },
    { type: "textarea", placeholder: "Weekly FTE Count", defaultValue: apiData?.boringID > 0 ? apiData.weeklyFTECount : '' },
    { type: "textarea", placeholder: "Issues/ Comments", defaultValue: apiData?.boringID > 0 ? apiData.issuesOrComments : '' }
  ];

  //Return Card if both loading complete
  return (
    <>
      {/* <h1>RealEstate</h1> */}
      {!loading && !loading1 && <Card
        data={data}
        disable={props.disableFields}
        cardTitle="Boring"
        tabColor={props.tabColor}
        onClick={updateData}
        onSubmit={createData}
      />}
      <CustomSnackBar
        open={open}
        onClose={() => handleToClose()}
        message={message}
      />
    </>
  );
};

//Default Export
export default Boring;