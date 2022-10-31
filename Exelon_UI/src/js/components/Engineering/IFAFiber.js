import React from "react";
import Card from "../../utils/Card";
import { useState,useEffect } from "react";
import { useSelector,useDispatch } from "react-redux";
import { getApi,updateApi,createApi } from "../../../redux/components/Engineering/IFAFiber/IFAFiberActions";
import {Circles} from 'react-loader-spinner';


let id = 1;
let linkID =1;
let stepID =1;
const IFAFiber = (props) => {


  const [apiData,setapiData]=useState([]);  
  const [loading,setLoading]=useState(true) 
  const [ID,setID]= useState(0);

  const dispatch = useDispatch();
  const updateData=(data,dropdata)=>{
    updateApi(ID,data,apiData).then((res)=>{
      if(res.status === 200)
        alert(`Data Updated SuccessFully!`);
      else 
        alert(res.message);
      })
  }

  const datatest=useSelector((state)=>state.engineeringFormReducer?.data)
  const datatest1=useSelector((state)=>state.engineeringFormReducer?.linkId)
  const createData=(data,dropData,multiDrop)=>{
    createApi(data,datatest1,stepID).then((res)=>{
      if(res.id>0)
        alert(`Data Created SuccessFully!`);
      else 
        alert(res.message);
    })
  }

useEffect(()=>{
  {datatest!==undefined ? dispatch(getApi()).then((res)=>{
    res.map((data)=>{
      if(data.fK_LinkingID === datatest.linkingId){
        setID(data.ifaFiberID);
        setapiData(data);
      }
      return data;
    })
    setLoading(false)
  }):setLoading(false)
    setapiData([])}
},[dispatch])

  const data = [
    { type: "date", placeholder: "IFA Fiber Original Scheduled Date",defaultValue: apiData.strOriginalScheduledDate   },
    { type: "date", placeholder: "IFA Fiber Current Scheduled Date",defaultValue: apiData.strCurrentScheduledDate },
    { type: "textarea", placeholder: "IFA Fiber Missed Dates & Reasons",defaultValue: apiData.missedDatesAndReasons },
    { type: "date", placeholder: "IFA Fiber Initial Issue Date",defaultValue: apiData.strInitialIssueDate },
    { type: "date", placeholder: "IFA Fiber Final Issue Date",defaultValue: apiData.strFinalIssueDate },
  ];
  return (
    <>
      {/* <h1>RealEstate</h1> */}
      {!loading ? <Card
        data={data}
        disable={props.disableFields}
        cardTitle="IFA Fiber"
        tabColor={props.tabColor}
        onClick={updateData}
        onSubmit={createData}
      />: <div className="loader">
      <Circles type="Circles" color="#4d841d" height={60} width={60} />
      </div>}
    </>
  );
};

export default IFAFiber;
