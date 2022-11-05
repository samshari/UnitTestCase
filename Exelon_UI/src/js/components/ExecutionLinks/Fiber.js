import React from "react";
import Card from "../../utils/Card";
import { useEffect,useState } from "react";
import { useDispatch,useSelector } from "react-redux";
import { getApi,updateApi,createApi } from "../../../redux/components/ExecutionLinks/Fiber/FiberAction";
import {getOvhdApi} from '../../../redux/components/ExecutionLinks/Ovhd/OvhdCocAction';

let id =3;
let fK_FiberCOCID = 0;
let fiberCocName='';
const Fiber = (props) => {
  const [apiData,setapiData]=useState([]);  
  const [loading,setLoading]=useState(true) 
  const [loading1,setLoading1]=useState(true) 
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
    res.map((data)=>{
      if(data.fK_LinkingID === id){
        setID(data.fiberID);
        setapiData(data);
      }
      return data;
    })
    setLoading(false)
  })
  dispatch(getOvhdApi()).then((res)=>{
    setLoading1(false);
  })
},[dispatch])

let item = data2?.OvhdCOCReducer?.data;

item?.map((value)=>{
  let fiberCoc_id = 0; 
  if(data2?.ExFiberReducer?.data ){
    fiberCoc_id = data2?.ExFiberReducer?.data[0].fK_FiberCOCID
  }
  if(value.cocid === fiberCoc_id){
    fK_FiberCOCID = fiberCoc_id
    fiberCocName = value.name
  }
})

  const data = [
    { type:"dropdown", placeholder: "Fiber COC",dropDownValues: [],defaultDrop: fK_FiberCOCID, defaultValue: fiberCocName },
    { type: "date", placeholder: "Fiber Start",defaultValue:apiData.strStartDate },
    { type: "date", placeholder: "Target Fiber Install Finish", defaultValue: apiData.strEndDate },
    { type: "textarea", placeholder: "Fiber Weekly FTE Count", defaultValue: apiData.weeklyFTECount   },
    { type: "textarea", placeholder: "Fiber Issues/Comments",defaultValue: apiData.issuesOrComments  },
    { type: "date", placeholder: "Actual OTDR Completion Date (In Service)", defaultValue: apiData.strOTDRCompletionDate },
  ];
  return (
    <>
      {!loading && !loading1 && <Card
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
