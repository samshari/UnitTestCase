import React from "react";
import Card from "../../utils/Card";
import { useEffect,useState } from "react";
import { useDispatch, useSelector } from "react-redux";
import { getApi,updateApi,createApi } from "../../../redux/components/Engineering/IFAFiberMkReady/IFAFiberMkReadyAction";
import { Circles } from "react-loader-spinner";
import CustomSnackBar from "../../utils/Snackbar";



let stepID = 1;
const IFAMakeReady = (props) => {
  const [apiData,setapiData]=useState([]);  
  const [loading,setLoading]=useState(true) 
  const [ID,setID]=useState(0);
  const dispatch = useDispatch();
  const [open, setOpen] = React.useState(false);
  const [isDataUpdated,setDataUpdated]=useState(false);

  const [message, setMessage] = useState("");
  const handleToClose = (event, reason) => {
    if ("clickaway" == reason) return;
    setOpen(false);
  };
    
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
  {datatest?.linkingId!=undefined ? dispatch(getApi()).then((res)=>{
    res?.status!==404 && res.map((data)=>{
      if(data.fK_LinkingID === datatest.linkingId){
        setID(data.ifaMakeReadyID);
        setapiData(data);
      }
      return data;
    })
    setLoading(false)
  }):setLoading(false)
    setapiData([])}
},[dispatch,datatest?.linkingId,ID,isDataUpdated])

  const data = [
    { type: "date", placeholder: "Original Scheduled Date",defaultValue: apiData.ifaMakeReadyID>0? apiData.strOriginalScheduledDate:'' },
    { type: "date", placeholder: "Current Scheduled Date",defaultValue: apiData.ifaMakeReadyID>0?apiData.strCurrentScheduledDate:'' },
    { type: "textarea", placeholder: "Missed Dates & Reasons",defaultValue: apiData.ifaMakeReadyID>0?apiData.missedDatesAndReasons:'' },
    { type: "date", placeholder: "Initial Issue Date",defaultValue: apiData.ifaMakeReadyID>0?apiData.strInitialIssueDate:'' },
    { type: "date", placeholder: "Final Issue Date",defaultValue: apiData.ifaMakeReadyID>0?apiData.strFinalIssueDate:'' },
  ];

  return (
    <>
      {/* <h1>RealEstate</h1> */}
      { !loading && <Card
        data={data}
        disable={props.disableFields}
        cardTitle="IFA Make Ready"
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

export default IFAMakeReady;
