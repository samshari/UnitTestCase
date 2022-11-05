import React from "react";
import Card from "../../utils/Card";
import { useState,useEffect } from "react";
import {useSelector,useDispatch} from 'react-redux'
import { getApi,updateApi,createApi } from "../../../redux/components/ExecutionLinks/InnerDuct/InnerDuctAction";

let id =3;
const Innerduct = (props) => {
  const datatest = useSelector((state) => state.hideExecutionLinksFormReducer?.data);
  const [apiData,setapiData]=useState([]);  
  const [loading,setLoading]=useState(true); 
  const [ID,setID]= useState(0);

  const data2 = useSelector((state)=>{
    return state
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
  if(datatest?.executionLinkingID!==undefined){dispatch(getApi()).then((res)=>{
    res?.status !== 404 && res.map((data)=>{
      if(data.fK_LinkingID === datatest?.executionLinkingID){
        setID(data.rodAndRopeID);
        setapiData(data);
      }
      return data;
    })
    setLoading(false)
  })}
},[dispatch])
  const data = [
    { type:"date",placeholder: "Innerduct Start", defaultValue: apiData?.rodAndRopeID>0? apiData.strInnerductStartDate:'' },
    { type:"date",placeholder: "Innerduct Finish", defaultValue: apiData?.rodAndRopeID>0?apiData.strInnerductEndDate:''},
    { type:"textarea",placeholder: "Innerduct Comments", defaultValue:apiData?.rodAndRopeID>0?apiData.comments:'' },
  ];
  return (
    <>
      {!loading && <Card
        data={data}
        disable={props.disableFields}
        cardTitle="Innerduct (Rod and Rope)"
        tabColor={props.tabColor}
        onClick={updateData}
        onSubmit={createData}
      />}
    </>
  );
};

export default Innerduct;
