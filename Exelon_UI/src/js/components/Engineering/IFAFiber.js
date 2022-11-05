import React from "react";
import Card from "../../utils/Card";
import { useState,useEffect } from "react";
import { useSelector,useDispatch } from "react-redux";
import { getApi,updateApi,createApi } from "../../../redux/components/Engineering/IFAFiber/IFAFiberActions";
import {Circles} from 'react-loader-spinner';
import CustomSnackBar from "../../utils/Snackbar";
import { disableTabs } from "../../../redux/utils/Tabs/TabsAction";


let stepID =1;
const IFAFiber = (props) => {


  const [apiData,setapiData]=useState([]);  
  const [loading,setLoading]=useState(true) 
  const [ID,setID]= useState(0);
  const dispatch = useDispatch();
  const [open, setOpen] = React.useState(false);
  const [isDataUpdated,setDataUpdated]=useState(false);
  const [availableID,setavailableID]=useState(false);

  const [message, setMessage] = useState("");
  const handleToClose = (event, reason) => {
    if ("clickaway" == reason) return;
    setOpen(false);
  };


  const updateData=(data,dropdata)=>{
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

  const datatest=useSelector((state)=>state.engineeringFormReducer?.data);
  const datatest1=useSelector((state)=>state.engineeringFormReducer?.linkId);

  const createData=(data,dropData,multiDrop)=>{
    createApi(data,datatest1,stepID).then((res)=>{
      if(res.id>0){
        setOpen(true);
        setMessage(`Data Created SuccessFully!`);
      }
      else{
        setOpen(true);
        setMessage(res.message);
      }
    })
  }
useEffect(()=>{
  setID(0);
  console.log('mainid',ID);
  console.log('mainidlink',datatest.linkingId);
  if(datatest?.linkingId!==undefined) { dispatch(getApi()).then((res)=>{
    res?.status!==404 && res.map((data)=>{
      if(data.fK_LinkingID === datatest.linkingId){
        console.log('mainiddata',data);
        setID(data.ifaFiberID);
        setapiData(data);
      }
      return data;
    })
    setLoading(false)
  })}else{
    setID(0);
    setLoading(false)
    setapiData([])
  }
},[dispatch,datatest?.linkingId,ID>0,isDataUpdated])

const selectedPD = useSelector((state) => state.headerReducer.selectedPD);
selectedPD===[] && dispatch(disableTabs(false));

  const data = [
    { type: "date", placeholder: "Original Scheduled Date",defaultValue: apiData?.ifaFiberID>0? apiData.strOriginalScheduledDate:''   },
    { type: "date", placeholder: "Current Scheduled Date",defaultValue: apiData?.ifaFiberID>0?apiData.strCurrentScheduledDate:'' },
    { type: "textarea", placeholder: "Missed Dates & Reasons",defaultValue: apiData?.ifaFiberID>0?apiData.missedDatesAndReasons:'' },
    { type: "date", placeholder: "Initial Issue Date",defaultValue:apiData?.ifaFiberID>0? apiData.strInitialIssueDate:'' },
    { type: "date", placeholder: "Final Issue Date",defaultValue: apiData?.ifaFiberID>0?apiData.strFinalIssueDate:'' },
  ];
  return (
    <>
      {/* <h1>RealEstate</h1> */}
      {!loading && <Card
        data={data}
        disable={props.disableFields}
        cardTitle="IFA Fiber"
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

export default IFAFiber;
