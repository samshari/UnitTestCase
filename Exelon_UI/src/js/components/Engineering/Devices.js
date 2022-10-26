import React from "react";
import Card from "../../utils/Card";
import {Circles} from "react-loader-spinner";
import { useState,useEffect } from "react";
import { useDispatch, useSelector } from "react-redux";
import {getApi,updateApi,createApi} from '../../../redux/components/Engineering/Device/DeviceAction';

let linkID=2;
let stepID=1;
const Devices = (props) => {
  const [apiData,setapiData]=useState([]);  
  const [loading,setLoading]=useState(true);
  const [ID,setID]=useState(0);


  const dispatch = useDispatch();


  
    

  const updateData=(data,dropData)=>{
    console.log(data)
    dispatch(updateApi(ID,data,apiData)).then((res)=>{

      if(res.status === 200)
        alert(`Data Updated SuccessFully!`);
      else 
        alert(res.message);
      })
  }

  const createData=(data)=>{
    createApi(data,linkID,stepID).then(res=>{
      if(res.id>0)
        alert(`Data Created SuccessFully!`);
      else 
        alert(res.message);
    });
  }

  

useEffect( ()=>{
  dispatch(getApi()).then((res)=> {
    res.map((data)=>{
      if(data.linkingId === linkID){
        setID(data.deviceId);
        setapiData(data);
      }
      return data;
    })
    setLoading(false);
  })
  
},[dispatch])



  const data = [
    { type: "number", placeholder: "Total Devices" ,defaultValue: apiData.totalDevices  },
    { placeholder: "Device Type",defaultValue: apiData.deviceType },
  ];
  
  return (
    <>
      {/* <h1>RealEstate</h1> */}
      {!loading ? 
      <Card
        data={data}
        disable={props.disableFields}
        cardTitle="Devices"
        tabColor={props.tabColor}
        onClick={updateData}
        onSubmit={createData}
      />: <div className="loader">
      <Circles type="Circles" color="#4d841d" height={60} width={60} />
      </div>}
    </>
  );
};

export default Devices;
