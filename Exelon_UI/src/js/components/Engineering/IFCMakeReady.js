import React from "react";
import Card from "../../utils/Card";
import { useState,useEffect } from "react";
import {getApi,createApi,updateApi} from '../../../redux/components/Engineering/IFCMakeReady/IFCMakeReadyAction'
import { useDispatch, useSelector } from "react-redux";
import {Circles} from 'react-loader-spinner'



let stepID = 1;
const IFCMakeReady = (props) => {
  const [apiData,setapiData]=useState([]);  
  const [loading,setLoading]=useState(true) 
  const [ID,setID]=useState(0);

  const dispatch = useDispatch();
  const updateData=(data)=>{
    updateApi(ID,data,apiData).then((res)=>{
      if(res.status === 200)
        alert(`Data Updated SuccessFully!`);
      else 
        alert(res.message);
      })
  }
  const datatest=useSelector((state)=>state.engineeringFormReducer?.data)
  const datatest1=useSelector((state)=>state.engineeringFormReducer?.linkId)
  const createData=(data)=>{
    createApi(data,datatest1,stepID).then(res=>{
      if(res.id>0)
        alert(`Data Created SuccessFully!`);
      else 
        alert(res.message);
    });
  }



  
useEffect( ()=>{
  {datatest!==undefined ? dispatch(getApi()).then((res)=>{
    res.map((data)=>{
      if(data.fK_LinkingID === datatest.linkingId){
        setID(data.ifcMakeReadyID);
        setapiData(data);
      }
      return data;
    })
    setLoading(false);
  }):setLoading(false)
    setapiData([])}
},[dispatch])


  const data = [
    { type: "date", placeholder: "IFC Make Ready Original Scheduled Date" ,defaultValue: apiData.strCurrentScheduledDate },
    { type: "date", placeholder: "IFC Make Ready Current Scheduled Date", defaultValue:apiData.strOriginalScheduledDate },
    { type: "textarea", placeholder: "IFC Make Ready Missed Dates & Reasons",defaultValue:apiData.missedDatesAndReasons },
    { type: "date", placeholder: "IFC Make Ready Initial Issue Date" ,defaultValue:apiData.strInitialIssueDate},
    { type: "date", placeholder: "IFC Make Ready Final Issue Date",defaultValue:apiData.strFinalIssueDate },
  ];


  return (
    <>
      {/* <h1>RealEstate</h1> */}
      {!loading ? <Card
        data={data}
        disable={props.disableFields}
        cardTitle="IFC Make Ready"
        tabColor={props.tabColor}
        onClick={updateData}
        onSubmit={createData}
      />: <div className="loader">
      <Circles type="Circles" color="#4d841d" height={60} width={60} />
      </div>}
    </>
  );
};

export default IFCMakeReady;
