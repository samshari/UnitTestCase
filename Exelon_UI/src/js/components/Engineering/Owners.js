import React from "react";
import Card from "../../utils/Card";
import {useState,useEffect} from 'react'
import {getApi,updateApi,createApi} from '../../../redux/components/Engineering/Owners/OwnerAction';
import { useDispatch,useSelector } from "react-redux";
import {getReactApi} from '../../../redux/components/Engineering/Owners/ReactLREAction'
import {getUcomApi} from '../../../redux/components/Engineering/Owners/UcomSPOCAction'
import {getPMApi} from '../../../redux/components/Engineering/Owners/PMAction'
import {Circles} from 'react-loader-spinner'
import CustomSnackBar from "../../utils/Snackbar";

const Owners = (props) => {
  let fK_ReactsLRE_ID = 0;
  let fK_UCOMMSPOC_ID =0;
  let fK_ProjectManagerID=0;
  let lreName = '';
  let ucomName = '';
  let pmName = '';
  let stepID=1; 
  let count = 0;
  const [apiData,setapiData]=useState([]); 
  const [loading,setLoading]=useState(true);
  const [loading1,setLoading1]=useState(true);  
  const [loading2,setLoading2]=useState(true); 
  const [loading3,setLoading3]=useState(true);  
  const [ID,setID]=useState(0);
  const [open, setOpen] = React.useState(false);
  const [isDataUpdated,setDataUpdated]=useState(false);
  const [message, setMessage] = useState("");
  const handleToClose = (event, reason) => {
    if ("clickaway" == reason) return;
    setOpen(false);
  };
  

  const dispatch = useDispatch();
  const updateData=(data,dropData)=>{
    updateApi(ID,data,dropData,datatest.linkingId).then((res)=>{
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
  
  const createData=(data,dropData)=>{
    createApi(data,dropData,datatest1,stepID).then(res=>{
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


const data2 = useSelector((state)=>{
  return state
})



useEffect( ()=>{
  {datatest?.linkingId!==undefined ? dispatch(getApi()).then((res)=> {
    res?.status!==404 && res.map((data)=>{
      if(data.fK_LinkingID === datatest.linkingId){
        setID(data.ownerID);
        setapiData(data);
        count = count +1;
      }
      return data;
    })
    if(count === 0){
      setID(0);
      setapiData([]);
    }
    setLoading(false)
  }):setLoading(false)
  setapiData([])}

  dispatch(getReactApi()).then((res)=> setLoading1(false))
  dispatch(getUcomApi()).then((res)=> setLoading2(false))
  dispatch(getPMApi()).then((res)=> setLoading3(false))
},[dispatch,datatest?.linkingId,ID,isDataUpdated])


let item1 = data2?.ReactLREReducer?.data;

item1?.status !==404 && item1?.map((value)=>{
  let id = 0; 
  if(data2?.OwnerReducer?.data && data2?.OwnerReducer?.data?.status!=404 ){
    data2?.OwnerReducer?.data?.filter((res)=>{
      if(res.fK_LinkingID === datatest?.linkingId)
        id = res.fK_ReactsLRE_ID;
    })
  }
  if(value.id === id){
    fK_ReactsLRE_ID = id
    lreName = value.name
  }
})

let item2 = data2?.UcomSPOCReducer?.data;

item2?.status !==404 && item2?.map((value)=>{
  let id = 0; 
  if(data2?.OwnerReducer?.data && data2?.OwnerReducer?.data?.status!=404){
    data2?.OwnerReducer?.data.filter((res)=>{
      if(res.fK_LinkingID === datatest?.linkingId)
        id = res.fK_UCOMMSPOC_ID;
    })
  }
  if(value.id === id){
    fK_UCOMMSPOC_ID = id
    ucomName = value.name
  }
})

let item3 = data2?.PMReducer?.data;

item3?.status !==404 && item3?.map((value)=>{
  
  let id = 0; 
  if(data2?.OwnerReducer?.data && data2?.OwnerReducer?.data?.status!=404){
    data2?.OwnerReducer?.data.filter((res)=>{
      if(res.fK_LinkingID === datatest?.linkingId)
        id = res.fK_ProjectManagerID;
    })
  }
  if(value.pmid === id){
    fK_ProjectManagerID = id
    pmName = value.name
  }

})

  const data = [
    { type:"dropdown", placeholder: "REACTS LRE", dropDownValues: data2?.ReactLREReducer?.data === null || data2?.ReactLREReducer?.data?.status ===404 ? []:data2?.ReactLREReducer?.data,defaultDrop: fK_ReactsLRE_ID, defaultValue: apiData?.ownerID>0? lreName:'' },
    { type:"dropdown",placeholder: "UCOMM SPOC",dropDownValues: data2?.UcomSPOCReducer?.data === null || data2?.ReactLREReducer?.data?.status ===404? []:data2?.UcomSPOCReducer?.data,defaultDrop: fK_UCOMMSPOC_ID,defaultValue:apiData?.ownerID>0? ucomName:'' },
    { type:"dropdown",placeholder: "PM", dropDownValues : data2?.PMReducer?.data === null || data2?.ReactLREReducer?.data?.status ===404? []:data2?.PMReducer?.data,defaultDrop: fK_ProjectManagerID, defaultValue: apiData?.ownerID>0?pmName:'' },
  ];

  return (
    <>
      {/* <h1>RealEstate</h1> */}
      {!loading && !loading1 && !loading2 && !loading3 && <Card
        data={data}
        disable={props.disableFields}
        cardTitle="Owners"
        tabColor={props.tabColor}
        onClick = {updateData}
        onSubmit = {createData}
      />}
      <CustomSnackBar
        open={open}
        onClose={() => handleToClose()}
        message={message}
      />
    </>
  );
};

export default Owners;
