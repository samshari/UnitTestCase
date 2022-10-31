import React from "react";
import Card from "../../utils/Card";
import { useState, useEffect } from "react";
import {getApi,updateApi,createApi} from '../../../redux/components/Engineering/PlannedPoleReplacement/PlannedPoleReplacementAction';
import { useSelector,useDispatch } from "react-redux";
import {Circles} from 'react-loader-spinner'

let linkID =1;
let stepID =1;
const PlannedPoleReplacements = (props) => {
  const [apiData,setapiData]=useState([]);  
  const [loading,setLoading]=useState(true);  
  const [ID,setID]=useState(0);

  const dispatch = useDispatch();

  const updateData=(data,dropData)=>{
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
        setID(data.polesRepacementID);
        setapiData(data);
      }
      return data;
    })
    setLoading(false);
  }): setLoading(false)
    setapiData([])}
},[dispatch])


  const data = [
    { type: "number", placeholder: "Total # of Poles in Route" , defaultValue: apiData.totalNoOfPolesInRoute},
    { type: "number", placeholder: "Replaced  Osmose",defaultValue: apiData.replacedNoOfOsmos },
    { type: "number", placeholder: "Replaced Loading",defaultValue: apiData.replacedLoading },
    { type: "number", placeholder: "Replaced Clearance",defaultValue: apiData.replacedClearance },
    { type: "number", placeholder: "Replaced Reliability",defaultValue: apiData.replacedReliability },
    { type: "number", placeholder: "New or Midspan Poles",defaultValue: apiData.newOrMidspanPoles },
    { type: "number", placeholder: "Poles Relocated",defaultValue: apiData.totalRelocatedPoles },
    { type: "number", placeholder: "Total Poles Needing Replaced/Set",defaultValue: apiData.totalPolesNeedingReplaced },
    { type: "number", placeholder: "New Guy/Anchor",defaultValue: apiData.newAnchor },
    { type: "number", placeholder: "Other Work on Pole",defaultValue: apiData.otherWorkOnPole },
    { placeholder: "Pole replacement %" , defaultValue: String(apiData.poleReplacementPercentage)},
  ];
  return (
    <>
      {/* <h1>RealEstate</h1> */}
      {!loading ? <Card
        data={data}
        disable={props.disableFields}
        cardTitle="Planned Pole Replacement"
        tabColor={props.tabColor}
        onClick={updateData}
        onSubmit={createData}
      />: <div className="loader">
      <Circles type="Circles" color="#4d841d" height={60} width={60} />
      </div>}
    </>
  );
};

export default PlannedPoleReplacements;