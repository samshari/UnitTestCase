import React, { useEffect, useState } from "react";
import Card from "../../utils/Card";
import { useSelector } from "react-redux";
import { useDispatch } from "react-redux";
import { getApi,updateApi,createApi} from "../../../redux/components/ExecutionLinks/Devices/DeviceAction";
import CustomSnackBar from "../../utils/Snackbar";

const Devices = (props) => {
  const [ID,setID]=useState(0);
  const [apiData,setapiData]=useState([]);
  const [loading,setLoading]=useState(true);
  const [isDataUpdated,setDataUpdated]=useState(false);
  const datatest = useSelector((state) => state.hideExecutionLinksFormReducer?.data);
  const dispatch = useDispatch();

  const [open, setOpen] = React.useState(false);
  const [message, setMessage] = useState("");
  const handleToClose = (event, reason) => {
    if ("clickaway" == reason) return;
    setOpen(false);
  };
  
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
      if(res?.status!=404)
      {
        setapiData(res);
        setID(res.executionDeviceId);
      }
      else{
        setID(0);
        setapiData([]);
      }
      setLoading(false);
    })
  }
  else{
    setLoading([]);
    setapiData([]);
  }
  },[dispatch,datatest,ID>0,isDataUpdated])

  const data = [
    { type:"number",placeholder: "No. of Devices Ready to be Cutover" ,defaultValue:apiData?.executionDeviceId>0?apiData?.installedDevice:''},
  ];
  return (
    <>
      {!loading && <Card
        data={data}
        disable={props.disableFields}
        cardTitle="Devices"
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

export default Devices;
