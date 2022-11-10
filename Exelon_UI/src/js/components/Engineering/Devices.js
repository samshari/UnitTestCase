import React from "react";
import Card from "../../utils/Card";
import { useState,useEffect } from "react";
import { useDispatch, useSelector } from "react-redux";
import {getApi,updateApi,createApi} from '../../../redux/components/Engineering/Device/DeviceAction';
import CustomSnackBar from "../../utils/Snackbar";

let stepID=1;
const Devices = (props) => {
  const [apiData,setapiData]=useState([]);  
  const [loading,setLoading]=useState(true);
  const [ID,setID]=useState(0);
  const [isDataUpdated,setDataUpdated]=useState(false);
  const dispatch = useDispatch();
  const [open, setOpen] = React.useState(false);
  let count =0;

  const [message, setMessage] = useState("");
  const handleToClose = (event, reason) => {
    if ("clickaway" == reason) return;
    setOpen(false);
  };

  
    

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
  const datatest = useSelector((state)=>state.engineeringFormReducer?.data)
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
  {datatest?.linkingId!==undefined ? dispatch(getApi()).then((res)=> {
    res?.status!==404 && res.map((data)=>{
      if(data.linkingId === datatest.linkingId){
        setID(data.deviceId);
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
  }): setLoading(false)
    setapiData([])
}
  
},[dispatch,datatest?.linkingId,ID,isDataUpdated])



  const data = [
    { type: "number", placeholder: "Device Count" ,defaultValue:apiData?.deviceId>0? apiData.totalDevices:''  },
    { placeholder: "Device Type",defaultValue: apiData?.deviceId>0?apiData.deviceType:'' },
  ];
  
  return (
    <>
      {/* <h1>RealEstate</h1> */}
      {!loading &&
      <Card
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
