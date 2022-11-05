import React from "react";
import Card from "../../utils/Card";
import { useEffect,useState } from "react";
import { useDispatch , useSelector} from "react-redux";
import {getApi,updateApi,createApi} from "../../../redux/components/ExecutionLinks/CompletedFiber/CompletedFiberMilesAction";

let id =1;
let name="";
const CompletedFiberMiles = (props) => {

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
    dispatch(getApi(1)).then((res)=>{
      if(res?.status !== 404){
       setID(res[0].completedPolesID);
       setapiData(res[0]);
      }
      setLoading(false)
    })
   
  },[dispatch])
  

  const data = [
    { type:"number", placeholder: "Fiber Miles Installed",defaultValue: apiData?.CompletedFiberMileID>0? apiData.fibermilesinstalled:''},
    { type:"number", placeholder: "Fiber Miles Complete (OTDR Tested)",defaultValue: apiData?.CompletedFiberMileID>0? apiData.fibermilescompleted:'' }
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
    </>
  );
};

export default CompletedFiberMiles;
