import React from "react";
import Card from "../../utils/Card";
import { useState,useEffect } from "react";
import {getApi,createApi,updateApi} from '../../../redux/components/Engineering/IFCMakeReady/IFCMakeReadyAction'
import { useDispatch, useSelector } from "react-redux";
import {Circles} from 'react-loader-spinner'
import CustomSnackBar from "../../utils/Snackbar";



let stepID = 1;
const IFCMakeReady = (props) => {
  const [apiData,setapiData]=useState([]);  
  const [loading,setLoading]=useState(true) 
  const [ID,setID]=useState(0);
  const [open, setOpen] = React.useState(false);
  const [isDataUpdated,setDataUpdated]=useState(false);

  let count =0;
  const [message, setMessage] = useState("");
  const handleToClose = (event, reason) => {
    if ("clickaway" == reason) return;
    setOpen(false);
  };

  const dispatch = useDispatch();
  const updateData=(data)=>{
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
  const createData=(data)=>{
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
  {datatest?.linkingId!==undefined ? dispatch(getApi()).then((res)=>{
    res?.status!==404 && res.map((data)=>{
      if(data.fK_LinkingID === datatest.linkingId){
        setID(data.ifcMakeReadyID);
        setapiData(data);
        count = count +1;
      }
      return data;
    })
    if(count === 0){
      setID(0);
      setapiData([]);
    }
    setLoading(false);
  }):setLoading(false)
    setapiData([])}
},[dispatch,datatest?.linkingId,ID>0,isDataUpdated]);


  const data = [
    { type: "date", placeholder: "Original Scheduled Date" ,defaultValue: apiData?.ifcMakeReadyID>0? apiData.strCurrentScheduledDate:'' },
    { type: "date", placeholder: "Current Scheduled Date", defaultValue:apiData?.ifcMakeReadyID>0?apiData.strOriginalScheduledDate:'' },
    { type: "textarea", placeholder: "Missed Dates & Reasons",defaultValue:apiData?.ifcMakeReadyID>0?apiData.missedDatesAndReasons:'' },
    { type: "date", placeholder: "Initial Issue Date" ,defaultValue:apiData?.ifcMakeReadyID>0?apiData.strInitialIssueDate:''},
    { type: "date", placeholder: "Final Issue Date",defaultValue:apiData?.ifcMakeReadyID>0?apiData.strFinalIssueDate:'' },
  ];


  return (
    <>
      {/* <h1>RealEstate</h1> */}
      {!loading && <Card
        data={data}
        disable={props.disableFields}
        cardTitle="IFC Make Ready"
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

export default IFCMakeReady;
