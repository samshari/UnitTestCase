import React from "react";
import Card from "../../utils/Card";
import { useEffect,useState } from "react";
import { useDispatch , useSelector} from "react-redux";
import {getApi,updateApi,createApi} from "../../../redux/components/ExecutionLinks/CompletedPoles/CompletedPolesAction";
import CustomSnackBar from "../../utils/Snackbar";

// let id =6;
const CompletedPoles = (props) => {

  const [apiData,setapiData]=useState([]);  
  const [loading,setLoading]=useState(true);

  const [ID,setID]= useState(0);

  const data2=useSelector((state)=>{
    return state;
  })

  const createLink = useSelector((state)=>state.hideExecutionLinksFormReducer?.globallinkID);
  const datatest = useSelector((state) => state.hideExecutionLinksFormReducer?.data);
  const [open, setOpen] = React.useState(false);

  const [message, setMessage] = useState("");
  const handleToClose = (event, reason) => {
    if ("clickaway" == reason) return;
    setOpen(false);
  };
  const [isDataUpdated,setDataUpdated]=useState(false);

  const dispatch = useDispatch();

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
    createApi(data,dropData,createLink).then((res)=>{
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
  if(datatest?.executionLinkingID!==undefined){dispatch(getApi(datatest?.executionLinkingID)).then((res)=>{
    if(res?.status !== 404){
     setID(res.completedPoleMileId);
     setapiData(res);
    }
    else{
        setID(0);
        setapiData([]);
    }
    setLoading(false);
  })
}
else{
  setLoading(false);
  setapiData([]);
}
},[dispatch,datatest?.executionLinkingID,ID,isDataUpdated])


  const data = [
    { type: "number", placeholder: "Total Number of Poles Needed", 
    defaultValue: apiData?.completedPoleMileId>0? apiData.totalNoOfPolesNeeded:'' },
    { type: "number", placeholder: "Poles Installed",
     defaultValue: apiData?.completedPoleMileId>0? apiData.poleInstalled:'' },
    { type: "number", placeholder: "OH miles Total",
    defaultValue: apiData?.completedPoleMileId>0? apiData.ohMilesTotal:'' },
    { type: "number", placeholder: "Make-Ready OH Miles Completed",
   defaultValue: apiData?.completedPoleMileId>0? apiData.makeReadyOHMilesCompleted:'' },
    {
      type: "number",
      placeholder: "UG miles (Innerduct, Boring + Civil) Total",
      defaultValue: apiData?.completedPoleMileId>0? apiData.ugMilesTotal:''},
    {
      type: "number",
      placeholder: "UG miles (Innerduct, Boring + Civil)",
      defaultValue: apiData?.completedPoleMileId>0? apiData.ugMilesCompleted:''},
  ];
  return (
    <>
      {!loading && <Card
        data={data}
        disable={props.disableFields}
        cardTitle="Completed Poles/Miles"
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

export default CompletedPoles;
