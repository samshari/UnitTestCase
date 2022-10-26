import React from "react";
import Card from "../../utils/Card";
import {useState,useEffect} from 'react'
import {getApi,updateApi,createApi} from '../../../redux/components/Engineering/Owners/OwnerAction';
import { useDispatch,useSelector } from "react-redux";
import {getReactApi} from '../../../redux/components/Engineering/Owners/ReactLREAction'
import {getUcomApi} from '../../../redux/components/Engineering/Owners/UcomSPOCAction'
import {getPMApi} from '../../../redux/components/Engineering/Owners/PMAction'
import {Circles} from 'react-loader-spinner'

let fK_ReactsLRE_ID = 0;
let fK_UCOMMSPOC_ID =0;
let fK_ProjectManagerID=0;
let lreName = '';
let ucomName = '';
let pmName = '';
let id =1;
let stepID=1;
const Owners = (props) => {
  
  const [apiData,setapiData]=useState([]); 
  const [loading,setLoading]=useState(true)  
  const [loading1,setLoading1]=useState(true)  
  const [loading2,setLoading2]=useState(true)  
  const [loading3,setLoading3]=useState(true)  
  const [ID,setID]=useState(0);
  

  const dispatch = useDispatch();
  const updateData=(data,dropData)=>{
    updateApi(ID,data,dropData,apiData).then((res)=>{
      if(res.status === 200)
        alert(`Data Updated SuccessFully!`);
      else 
        alert(res.message);
      })
  }

  const createData=(data,dropData)=>{
    createApi(data,dropData,id,stepID).then(res=>{
      if(res.id>0)
        alert(`Data Created SuccessFully!`);
      else 
        alert(res.message);
    });
  }


const data2 = useSelector((state)=>{
  return state
})



useEffect( ()=>{
  dispatch(getApi()).then((res)=> {
    res.map((data)=>{
      if(data.fK_LinkingID === id){
        setID(data.ownerID);
        setapiData(data);
      }
      return data;
    })
    setLoading(false)
  })

  dispatch(getReactApi()).then((res)=> setLoading1(false))
  dispatch(getUcomApi()).then((res)=> setLoading2(false))
  dispatch(getPMApi()).then((res)=> setLoading3(false))
},[dispatch])


let item1 = data2?.ReactLREReducer?.data;

item1?.map((value)=>{
  let id = 0; 
  if(data2?.OwnerReducer?.data ){
    id = data2?.OwnerReducer?.data[0].fK_ReactsLRE_ID
  }
  if(value.id === id){
    fK_ReactsLRE_ID = id
    lreName = value.name
  }
})

let item2 = data2?.UcomSPOCReducer?.data;

item2?.map((value)=>{
  let id = 0; 
  if(data2?.OwnerReducer?.data ){
    id = data2?.OwnerReducer?.data[0].fK_UCOMMSPOC_ID
  }
  if(value.id === id){
    fK_UCOMMSPOC_ID = id
    ucomName = value.name
  }
})

let item3 = data2?.PMReducer?.data;

item3?.map((value)=>{
  let id = 0; 
  if(data2?.OwnerReducer?.data ){
    id = data2?.OwnerReducer?.data[0].fK_ProjectManagerID

  }
  if(value.pmid === id){
    fK_ProjectManagerID = id
    pmName = value.name
  }

})

  const data = [
    { type:"dropdown", placeholder: "REACTS LRE", dropDownValues: data2?.ReactLREReducer?.data === null ? []:data2?.ReactLREReducer?.data,defaultDrop: fK_ReactsLRE_ID, defaultValue: lreName },
    { type:"dropdown",placeholder: "UCOMM SPOC",dropDownValues: data2?.UcomSPOCReducer?.data === null ? []:data2?.UcomSPOCReducer?.data,defaultDrop: fK_UCOMMSPOC_ID,defaultValue: ucomName },
    { type:"dropdown",placeholder: "PM", dropDownValues : data2?.PMReducer?.data === null ? []:data2?.PMReducer?.data,defaultDrop: fK_ProjectManagerID, defaultValue: pmName },
  ];

  return (
    <>
      {/* <h1>RealEstate</h1> */}
      {!loading && !loading1 && !loading2 && !loading3 ? <Card
        data={data}
        disable={props.disableFields}
        cardTitle="Owners"
        tabColor={props.tabColor}
        onClick = {updateData}
        onSubmit = {createData}
      />: <div className="loader">
      <Circles type="Circles" color="#4d841d" height={60} width={60} />
      </div>}
    </>
  );
};

export default Owners;
