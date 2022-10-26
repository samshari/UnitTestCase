import React from "react";
import Card from "../../utils/Card";
import { useEffect, useState } from "react";
import { getApi,updateApi,createApi } from "../../../redux/components/Engineering/RealEstate/RealEstateAction";
import {useSelector, useDispatch} from 'react-redux';
import {getSupCOCApi} from '../../../redux/components/Engineering/RealEstate/SupportCOCAction'
import {getEOCApi} from '../../../redux/components/Engineering/RealEstate/EOCAction'
import {Circles} from 'react-loader-spinner'

let eocName ='';
let realSupName ='';
let fK_EOCID = 0;
let fK_RealEstateSupportCOCID = 0;
let id = 2;
let linkID =1;
let stepID =1;

const RealEstate = (props) => {

  const [apiData,setapiData]=useState([]); 
  const [loading,setLoading] = useState(true);
  const [loading1,setLoading1] = useState(true);
  const [loading2,setLoading2] = useState(true);
  const [ID,setID]=useState(0);

  const dispatch = useDispatch();
  const updateData=(data,dropData)=>{
    console.log(dropData);
    updateApi(ID,data,dropData,apiData).then((res)=>{
      if(res.status === 200)
        alert(`Data Updated SuccessFully!`);
      else 
        alert(res.message);
      })
  }

  const createData=(data,dropData)=>{
    createApi(data,dropData,linkID,stepID).then(res=>{
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
  dispatch(getApi()).then((res)=>{
    res.map((data)=>{
      if(data.fK_LinkingID === id){
        setID(data.eocRealEstateID);
        setapiData(data);
      }
      return data;
    })
    setLoading(false)
  });
  dispatch(getEOCApi()).then((res)=>setLoading1(false));
  dispatch(getSupCOCApi()).then((res)=>setLoading2(false));
},[dispatch])


let item1 = data2?.EOCReducer?.data;
let item2 = data2?.SupportCOCReducer?.data;

item1?.map((value)=>{
  let id = 0; 
  if(data2?.RealEstateReducer?.data){
    id = data2?.RealEstateReducer?.data[0].fK_EOCID
  }
  
  if(value.id === id){
    fK_EOCID = value.id
    eocName = value.name
  }

})



item2?.map((value)=>{
  let id = 0; 
  if(data2?.RealEstateReducer?.data ){
    id = data2?.RealEstateReducer?.data[0].fK_RealEstateSupportCOCID
  }
  
  if(value.id === id){
    fK_RealEstateSupportCOCID = id
    realSupName = value.name
  }

})


  const data = [
    { type: "dropdown", placeholder: "EOC",dropDownValues:data2?.EOCReducer?.data === null ? []:data2?.EOCReducer?.data, defaultValue : eocName, defaultDrop: fK_EOCID },
    { id: "1", type: "date", placeholder: "EOC release date",  defaultValue: apiData.strEOCReleaseDate },
    { id: "2", type: "date", placeholder: "EOC pole foreman complete", defaultValue: apiData.strEOCPoleForemanComplete },
    { placeholder: "REEF submittal", defaultValue: apiData.reefSubmittal },
    { placeholder: "REEF #", defaultValue: apiData.reef },
    { type: "dropdown", placeholder: "Real Estate support COC",dropDownValues: data2?.SupportCOCReducer?.data === null ? []:data2?.SupportCOCReducer?.data , defaultValue: realSupName, defaultDrop: fK_RealEstateSupportCOCID},
    { placeholder: "EOC UG C&C investigation", defaultValue: apiData.ugCnCInvestigation },
    { placeholder: "MH Defects", defaultValue: apiData.mhDefects },
    { type: "textarea", placeholder: "EOC UG C&C investigation comments", defaultValue:  apiData.investigationComments },
    { placeholder: "MR's", defaultValue: apiData.mRs },
  ];
  console.log("data",data);
  return (
    <>
      {/* <h1>RealEstate</h1> */}
      { !loading  && !loading1 && !loading2 ? <Card
        data={data}
        disable={props.disableFields}
        cardTitle="EOC/Real Estate"
        tabColor={props.tabColor}
        onClick = {updateData}
        onSubmit ={createData}
      />: <div className="loader">
      <Circles type="Circles" color="#4d841d" height={60} width={60} />
      </div>}
    </>
  );
};

export default RealEstate;
