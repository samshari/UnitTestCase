import React from "react";
import Card from "../../utils/Card";
import { useState, useEffect } from "react";
import {getApi,updateApi,createApi} from '../../../redux/components/Engineering/PlannedPoleReplacement/PlannedPoleReplacementAction';
import { useSelector,useDispatch } from "react-redux";
import {Circles} from 'react-loader-spinner'
import CustomSnackBar from "../../utils/Snackbar";


let stepID =1;
const PlannedPoleReplacements = (props) => {
  const [apiData,setapiData]=useState([]);  
  const [loading,setLoading]=useState(true);  
  const [ID,setID]=useState(0);
  const [isDataUpdated,setDataUpdated]=useState(false);

  const dispatch = useDispatch();
  const [open, setOpen] = React.useState(false);
  let count =0;
  const [message, setMessage] = useState("");
  const handleToClose = (event, reason) => {
    if ("clickaway" == reason) return;
    setOpen(false);
  };

  const updateData=(data,dropData)=>{
    updateApi(ID,data,datatest.linkingId).then((res)=>{
      if(res.status === 200){
        setOpen(true);
        setMessage(`Data Updated SuccessFully!`);
        setDataUpdated(!isDataUpdated);
      }
      else if(res.id>0){
        setID(res.id);
        setOpen(true);
        setMessage(`Data Created SuccessFully!`);
      }
      else{
        setOpen(true);
        setMessage(res.message);}
      })
  }
  const datatest=useSelector((state)=>state.engineeringFormReducer?.data)
  const datatest1=useSelector((state)=>state.engineeringFormReducer?.linkId)
  
  const createData=(data,dropData,multiDrop)=>{
    createApi(data,datatest1,stepID).then(res=>{
      if(res.id>0){
        setOpen(true);
        setMessage(`Data Created SuccessFully!`);
      }
      else{
        setOpen(true);
        setMessage(res.message);
      }
    });
  }


useEffect( ()=>{
  {datatest?.linkingId!==undefined ? dispatch(getApi()).then((res)=>{
    res?.status!==404 && res.map((data)=>{
      if(data.fK_LinkingID === datatest.linkingId){
        setID(data.polesRepacementID);
        setapiData(data);
        count = count +1;
      }
      return data;
    })
    if(count === 0){
      setID(0);
      setapiData([]);
    }
    setLoading(false);
  }): setLoading(false)
    setapiData([])}
},[dispatch,datatest?.linkingId,ID,isDataUpdated])


  const data = [
    { type: "number", placeholder: "Total # of Poles in Route" , defaultValue:apiData?.polesRepacementID>0? apiData.totalNoOfPolesInRoute:''},
    { type: "number", placeholder: "Replaced  Osmose",defaultValue: apiData?.polesRepacementID>0?apiData.replacedNoOfOsmos:'' },
    { type: "number", placeholder: "Replaced Loading",defaultValue: apiData?.polesRepacementID>0?apiData.replacedLoading:'' },
    { type: "number", placeholder: "Replaced Clearance",defaultValue: apiData?.polesRepacementID>0?apiData.replacedClearance:'' },
    { type: "number", placeholder: "Replaced Reliability",defaultValue: apiData?.polesRepacementID>0?apiData.replacedReliability:'' },
    { type: "number", placeholder: "New or Midspan Poles",defaultValue: apiData?.polesRepacementID>0?apiData.newOrMidspanPoles:'' },
    { type: "number", placeholder: "Poles Relocated",defaultValue: apiData?.polesRepacementID>0?apiData.totalRelocatedPoles:'' },
    { type: "number", placeholder: "Total Poles Needing Replaced/Set",defaultValue: apiData?.polesRepacementID>0?apiData.totalPolesNeedingReplaced:'' },
    { type: "number", placeholder: "New Guy/Anchor",defaultValue: apiData?.polesRepacementID>0?apiData.newAnchor:'' },
    { type: "number", placeholder: "Other Work on Pole",defaultValue: apiData?.polesRepacementID>0?apiData.otherWorkOnPole:'' },
    { disable:"true", type: "number", placeholder: "Pole replacement %" , defaultValue: apiData?.polesRepacementID>0?String(((apiData.totalPolesNeedingReplaced/apiData.totalNoOfPolesInRoute)*100).toFixed(2)):''},
  ];
  return (
    <>
      {/* <h1>RealEstate</h1> */}
      {!loading && <Card
        data={data}
        disable={props.disableFields}
        cardTitle="Planned Pole Replacement"
        tabColor={props.tabColor}
        onClick={updateData}
        onSubmit={createData}
      />}
      <CustomSnackBar
        open={open}
        onClose={() => handleToClose()}
        message={message}
      />
    </>
  );
};

export default PlannedPoleReplacements;