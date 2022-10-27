import React from "react";
import Card from "../../utils/Card";
import { useEffect,useState } from "react";
import { useDispatch , useSelector} from "react-redux";
import {getApi,updateApi,createApi} from "../../../redux/components/ExecutionLinks/Ovhd/OvhdAction"
import {getOvhdApi} from '../../../redux/components/ExecutionLinks/Ovhd/OvhdCocAction'

let id =1;
let stepID=1;
let fK_OVHDCOCID=0;
let ovhdName='';

const OvhdMakeReady = (props) => {
  const [apiData,setapiData]=useState([]);  
  const [loading,setLoading]=useState(true);
  const [loading1,setLoading1]=useState(true); 
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
        setID(data.ovhdMakeReadyID);
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
  let ovhd_id = 0; 
  if(data2?.OVHDReducer?.data ){
    ovhd_id = data2?.OVHDReducer?.data[0].fK_OVHDCOCID

  }
  if(value.cocid === ovhd_id){
    fK_OVHDCOCID = ovhd_id
    ovhdName = value.name
  }
})

  const data = [
    { type:"dropdown", placeholder: "OVHD COC",dropDownValues: data2?.OvhdCOCReducer?.data === null ? []: data2?.OvhdCOCReducer?.data,defaultDrop: fK_OVHDCOCID, defaultValue: ovhdName },
    { type:"date",placeholder: "OVHD Start",defaultValue:apiData.strStartDate },
    { type:"date",placeholder:"OVHD Finish",defaultValue:apiData.strEndDate},
    { type:"textarea",placeholder: "Make-Ready Issues/ Comments",defaultValue:apiData.issuesOrComments },
    { type:"textarea",placeholder:"OVHD Weekly FTE Count",defaultValue:apiData.weeklyFTECount   }
  ];
  return (
    <>
      {/* <h1>RealEstate</h1> */}
      {!loading && !loading1 && <Card
        data={data}
        disable={props.disableFields}
        cardTitle="OVHD Make Ready"
        tabColor={props.tabColor}
        onClick={updateData}
        onSubmit={createData}
      />}
    </>
  );
};

export default OvhdMakeReady;