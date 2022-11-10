import React from "react";
import Card from "../../utils/Card";
import { useEffect,useState } from "react";
import { useDispatch, useSelector } from "react-redux";
import { getApi,updateApi,createApi } from "../../../redux/components/ExecutionLinks/IfcDates/IfcDatesAction";
import CustomSnackBar from "../../utils/Snackbar";

// let id =3;
const IFCDates = (props) => {
  let count = 0;
  const datatest = useSelector((state) => state.hideExecutionLinksFormReducer?.data);
  const [apiData,setapiData]=useState([]);  
  const [loading,setLoading]=useState(true);
  const [ID,setID]= useState(0);
  const [isDataUpdated,setDataUpdated]=useState(false);
  const [open, setOpen] = React.useState(false);
  const [message, setMessage] = useState("");
  const handleToClose = (event, reason) => {
    if ("clickaway" == reason) return;
    setOpen(false);
  };

  const dispatch = useDispatch();
  const createLink = useSelector((state)=>state.hideExecutionLinksFormReducer?.globallinkID);

  const updateData=(data,dropData)=>{
    updateApi(ID,data,dropData,datatest?.executionLinkingID).then((res)=>{
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

  const createData=(data,dropData,multiDrop)=>{
    createApi(data,createLink).then((res)=>{
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

useEffect(()=>{
  if(datatest?.executionLinkingID!==undefined){dispatch(getApi()).then((res)=>{
    res?.status!==404 &&  res.map((data)=>{
      if(data.fK_LinkingID === datatest?.executionLinkingID){
        setID(data.ifcDateID);
        setapiData(data);
        count = count + 1;
      }
      return data;
    })
    if(count === 0){
      setID(0);
      setapiData([]);
    }
    setLoading(false);
  })
  }
  else
    { 
      setLoading(false);
      setapiData([])
    }
},[dispatch,datatest?.executionLinkingID,ID>0,isDataUpdated])
  
  const data = [
    { type:"date",placeholder: "IFC Make Ready Scheduled Issue Date", defaultValue:apiData?.ifcDateID>0?apiData.strIFCMkReadyScheduledIssueDate:'' },
    { type:"date",placeholder: "IFC Fiber current Scheduled Issue Date",defaultValue:apiData?.ifcDateID>0?apiData.strIFCFiberCurrentScheduledIssueDt:'' },
  ];
  return (
    <>
      {!loading && <Card
        data={data}
        disable={props.disableFields}
        cardTitle="IFC Dates"
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

export default IFCDates;
