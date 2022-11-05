import React from "react";
import Card from "../../utils/Card";
import { useState, useEffect } from "react";
import { getApi,updateApi,createApi } from "../../../redux/components/Engineering/IFCFiber/IFCFiberActions";
import { useSelector,useDispatch } from "react-redux";
import {Circles} from 'react-loader-spinner'
import CustomSnackBar from "../../utils/Snackbar";

let stepID = 1;
const IFCFiber = (props) => {

  const [apiData,setapiData]=useState([]);  
  const [loading,setLoading]=useState(true) 
  const [ID,setID]=useState(0);
  const [open, setOpen] = React.useState(false);
  const [isDataUpdated,setDataUpdated]=useState(false);

  const [message, setMessage] = useState("");
  const handleToClose = (event, reason) => {
    if ("clickaway" == reason) return;
    setOpen(false);
  };

  const dispatch = useDispatch();
  const updateData=(data,dropData)=>{
    updateApi(ID,data,datatest.linkingId).then((res)=>{
      if(res.status === 200){
        setOpen(true);
        setMessage(`Data Updated SuccessFully!`);
        setDataUpdated(!isDataUpdated);
      }
      else if(res.id>0){
        setID(res.id);
        setOpen(true);
        setMessage(`Data Created SuccessFully!`);
      }
      else{
        setOpen(true);
        setMessage(res.message);}
      })
  }

  const datatest=useSelector((state)=>state.engineeringFormReducer?.data)
  const datatest1=useSelector((state)=>state.engineeringFormReducer?.linkId)

  const createData=(data,dropData,multiDrop)=>{
    createApi(data,datatest1,stepID).then(res=>{
      if(res.id>0){
        setOpen(true);
        setMessage(`Data Created SuccessFully!`);
      }
      else{
        setOpen(true);
        setMessage(res.message);
      }
    });
  }


useEffect( ()=>{
  {datatest?.linkingId!==undefined? dispatch(getApi()).then((res)=>{
    res?.status!==404 && res.map((data)=>{
      if(data.fK_LinkingID === datatest.linkingId){
        setID(data.ifcFiberID);
        setapiData(data);
      }
      return data;
    })
    setLoading(false);
  }):setLoading(false)
setapiData([])}
},[dispatch,datatest?.linkingId,ID,isDataUpdated])


  const data = [
    { type: "date", placeholder: "Original Scheduled Date",defaultValue: apiData?.ifcFiberID>0?apiData.strOriginalScheduledDate:'' },
    { type: "date", placeholder: "Current Scheduled Date", defaultValue: apiData?.ifcFiberID>0?apiData.strCurrentScheduledDate:'' },
    { type: "date", placeholder: "Missed Dates",  defaultValue: apiData?.ifcFiberID>0?apiData.strMissedDates:'' },
    { type: "date", placeholder: "Initial Issue Date", defaultValue: apiData?.ifcFiberID>0?apiData.strInitialIssueDate:'' },
    { type: "date", placeholder: "Final Issue Date", defaultValue: apiData?.ifcFiberID>0?apiData.strFinalIssueDate:'' },
    { type: "textarea", placeholder: "Missed Reasons", defaultValue: apiData?.ifcFiberID>0?apiData.missedReason:'' }
  ];

  

  return (
    <>
      {/* <h1>RealEstate</h1> */}
      {!loading && <Card
        data={data}
        disable={props.disableFields}
        cardTitle="IFC Fiber"
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

export default IFCFiber;
