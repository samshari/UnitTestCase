import React from "react";
import Card from "../../utils/Card";
import { useEffect,useState } from "react";
import { useSelector,useDispatch } from "react-redux";
import { getApi,createApi,updateApi } from "../../../redux/components/ExecutionLinks/PostCreation/PostCreationAction";

let id =3;

const PostCompletion = (props) => {
  const datatest = useSelector((state) => state.hideExecutionLinksFormReducer?.data);
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
    createApi(data,id).then((res)=>{
      if(res.id>0)
        alert(`Data Created SuccessFully!`);
      else 
        alert(res.message);
    })
  }

useEffect(()=>{
  if(datatest?.executionLinkingID!==undefined){dispatch(getApi()).then((res)=>{
    res?.status!==400 && res.map((data)=>{
      if(data.fK_LinkingID === datatest?.executionLinkingID){
        setID(data.postCompletionID);
        setapiData(data);
      }
      return data;
    })
    setLoading(false)
  })}
},[dispatch])


const data = [
  { type: "textarea", placeholder: "As-Builts Received",defaultValue: apiData?.postCompletionID>0?apiData.asBuiltsReceived:'' },
  { type: "textarea", placeholder: "Locations Ready To Inspect", defaultValue: apiData?.postCompletionID>0? apiData.locationsReadyToInspect:'' },
  { type: "textarea", placeholder: "Locations Inspected ", defaultValue: apiData?.postCompletionID>0? apiData.locationsInspected:'' },
  { type: "textarea", placeholder: "TED updated", defaultValue: apiData?.postCompletionID>0?apiData.tedUpdated:'' },
  { type: "textarea", placeholder: "PNI updated IS+60 days", defaultValue: apiData?.postCompletionID>0?apiData.pniUpdatedIS:'' },
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
    </>
  );
};

export default PostCompletion;
