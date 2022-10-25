import React from "react";
import Card from "../../utils/Card";
import { useEffect,useState } from "react";
import { useDispatch } from "react-redux";
import { getApi,updateApi,createApi } from "../../../redux/components/ExecutionLinks/Fiber/FiberAction";

let id =2;
let stepID =1;

const Fiber = (props) => {
  const [apiData,setapiData]=useState([]);  
  const [loading,setLoading]=useState(true) 
  const [ID,setID]= useState(0);

  const dispatch = useDispatch();
  const updateData=(data)=>{
    updateApi(ID,data,apiData).then((res)=>{
      if(res.status === 200)
        alert(`Data Updated SuccessFully!`);
      else 
        alert(res.message);
      })
  }

  const createData=(data)=>{
    createApi(data,id,stepID).then((res)=>{
      if(res.id>0)
        alert(`Data Created SuccessFully!`);
      else 
        alert(res.message);
    })
  }

useEffect(()=>{
  dispatch(getApi()).then((res)=>{
    res.map((data)=>{
      if(data.fK_LinkingID === id){
        setID(data.fiberID);
        setapiData(data);
      }
      return data;
    })
    setLoading(false)
  })
},[dispatch])
  const data = [
    { placeholder: "Fiber COC" },
    { type: "date", placeholder: "Fiber Start",defaultValue:apiData.strStartDate },
    { type: "date", placeholder: "Target Fiber Install Finish", defaultValue: apiData.strEndDate },
    { type: "textarea", placeholder: "Fiber Weekly FTE Count", defaultValue: apiData.weeklyFTECount   },
    { type: "textarea", placeholder: "Fiber Issues/Comments",defaultValue: apiData.issuesOrComments  },
    { type: "date", placeholder: "Actual OTDR Completion Date (In Service)", defaultValue: apiData.strOTDRCompletionDate },
  ];
  return (
    <>
      {!loading && <Card
        data={data}
        disable={props.disableFields}
        cardTitle="Fiber"
        tabColor={props.tabColor}
        onClick={updateData}
        onSubmit={createData}
      />}
    </>
  );
};

export default Fiber;
