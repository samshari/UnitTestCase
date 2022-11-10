import React from "react";
import Card from "../../utils/Card";
import { useEffect,useState } from "react";
import { useDispatch , useSelector} from "react-redux";
import {getApi,updateApi,createApi} from "../../../redux/components/ExecutionLinks/CompletedFiber/CompletedFiberMilesAction";
import CustomSnackBar from "../../utils/Snackbar";

const CompletedFiberMiles = (props) => {

  let count = 0;
  const [apiData,setapiData]=useState([]);  
  const [loading,setLoading]=useState(true);

  const [ID,setID]= useState(0);

  const data2=useSelector((state)=>{
    return state;
  })
  const [open, setOpen] = React.useState(false);

  const [message, setMessage] = useState("");
  const handleToClose = (event, reason) => {
    if ("clickaway" == reason) return;
    setOpen(false);
  };
  const [isDataUpdated,setDataUpdated]=useState(false);
  const createLink = useSelector((state)=>state.hideExecutionLinksFormReducer?.globallinkID);
  const datatest = useSelector((state) => state.hideExecutionLinksFormReducer?.data);
  
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
       setID(res.completedFiberMileId);
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
    { type:"number", placeholder: "Fiber Miles Installed",defaultValue: apiData?.completedFiberMileId>0? apiData.fiberMilesInstalled:''},
    { type:"number", placeholder: "Fiber Miles Complete (OTDR Tested)",defaultValue: apiData?.completedFiberMileId>0? apiData.fiberMilesCompleted:'' }
  ];
  return (
    <>
      {!loading && <Card
        data={data}
        disable={props.disableFields}
        cardTitle="Completed Fiber Miles"
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

export default CompletedFiberMiles;
