import React from "react";
import Card from "../../utils/Card";
import { useEffect,useState } from "react";
import { useSelector,useDispatch } from "react-redux";
import { getApi,createApi,updateApi } from "../../../redux/components/ExecutionLinks/PostCreation/PostCreationAction";
import CustomSnackBar from "../../utils/Snackbar";



const PostCompletion = (props) => {
  let count = 0;
  const datatest = useSelector((state) => state.hideExecutionLinksFormReducer?.data);
  const [apiData,setapiData]=useState([]);  
  const [loading,setLoading]=useState(true) 
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
  const updateData=(data)=>{
    updateApi(ID,data,datatest?.executionLinkingID).then((res)=>{
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

  const createData=(data)=>{
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
    res?.status!==404 && res?.map((data)=>{
      if(data.fK_LinkingID === datatest?.executionLinkingID){
        setID(data.postCompletionID);
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
  })}
  else{
    setLoading(false);
    setapiData([]);
  }
},[dispatch,ID>0,datatest?.executionLinkingID,isDataUpdated])


const data = [
  {  placeholder: "As-Builts Received",defaultValue: apiData?.postCompletionID>0?apiData.asBuiltsReceived:'' },
  {  placeholder: "Locations Ready To Inspect", defaultValue: apiData?.postCompletionID>0? apiData.locationsReadyToInspect:'' },
  {  placeholder: "Locations Inspected ", defaultValue: apiData?.postCompletionID>0? apiData.locationsInspected:'' },
  {  placeholder: "TED updated", defaultValue: apiData?.postCompletionID>0?apiData.tedUpdated:'' },
  {  placeholder: "PNI updated IS+60 days", defaultValue: apiData?.postCompletionID>0?apiData.pniUpdatedIS:'' },
];
  return (
    <>
      {!loading && <Card
        data={data}
        disable={props.disableFields}
        cardTitle="Post-Completion"
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

export default PostCompletion;
