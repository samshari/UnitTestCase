import React from "react";
import Card from "../../utils/Card";
import { useEffect,useState } from "react";
import { useSelector,useDispatch } from "react-redux";
import { getApi,createApi,updateApi } from "../../../redux/components/ExecutionLinks/PostCreation/PostCreationAction";

let id =1;
let stepID = 1;

const PostCompletion = (props) => {
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
        setID(data.postCompletionID);
        setapiData(data);
      }
      return data;
    })
    setLoading(false)
  })
},[dispatch])


  const data = [
    { type: "textarea", placeholder: "As-Builts Received",defaultValue: apiData.asBuiltsReceived },
    { type: "textarea", placeholder: "Locations Ready To Inspect", defaultValue: apiData.locationsReadyToInspect },
    { type: "textarea", placeholder: "Locations Inspected ", defaultValue: apiData.locationsInspected },
    { type: "textarea", placeholder: "TED updated", defaultValue: apiData.tedUpdated },
    { type: "textarea", placeholder: "PNI updated IS+60 days", defaultValue: apiData.pniUpdatedIS },
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