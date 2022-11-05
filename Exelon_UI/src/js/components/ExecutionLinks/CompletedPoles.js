import React from "react";
import Card from "../../utils/Card";
import { useEffect,useState } from "react";
import { useDispatch , useSelector} from "react-redux";
import {getApi,updateApi,createApi} from "../../../redux/components/ExecutionLinks/CompletedPoles/CompletedPolesAction";

let id =6;
const CompletedPoles = (props) => {

  const [apiData,setapiData]=useState([]);  
  const [loading,setLoading]=useState(true);

  const [ID,setID]= useState(0);

  const data2=useSelector((state)=>{
    return state;
  })


  const dispatch = useDispatch();

  const updateData=(data,dropData)=>{
    updateApi(ID,data,dropData,apiData).then((res)=>{
      if(res.status === 200)
        alert(`Data Updated SuccessFully!`);
      else 
        alert(res.message);
      })
  }

  const createData=(data,dropData,multiDrop)=>{
    createApi(data,dropData,id).then((res)=>{
      if(res.id>0)
        alert(`Data Created SuccessFully!`);
      else 
        alert(res.message);
    })
  }



  
useEffect(()=>{
  dispatch(getApi()).then((res)=>{
    res?.status !== 404 && res.map((data)=>{
      if(data.ExecutionLinkingID === id){
        setID(data.completedPolesID);
        setapiData(data);
      }
      return data;
    })
    setLoading(false)
  })
 
},[dispatch])


  const data = [
    { type: "number", placeholder: "Total Number of Poles Needed", 
    defaultValue: apiData?.completedPolesID>0? apiData.totalpoles:'' },
    { type: "number", placeholder: "Poles Installed",
     defaultValue: apiData?.completedPolesID>0? apiData.polesinstalled:'' },
    { type: "number", placeholder: "OH miles Total",
    defaultValue: apiData?.completedPolesID>0? apiData.ohmilestotal:'' },
    { type: "number", placeholder: "Make-Ready OH Miles Completed",
   defaultValue: apiData?.completedPolesID>0? apiData.ohmilescompleted:'' },
    {
      type: "number",
      placeholder: "UG miles (Innerduct, Boring + Civil) Total",
      defaultValue: apiData?.completedPolesID>0? apiData.ugmilestotal:''},
    {
      type: "number",
      placeholder: "UG miles (Innerduct, Boring + Civil)",
      defaultValue: apiData?.completedPolesID>0? apiData.ugmiles:''},
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
    </>
  );
};

export default CompletedPoles;
