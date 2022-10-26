import React from "react";
import Card from "../../utils/Card";
import { useDispatch,useSelector } from "react-redux";
import { getApi,updateApi,createApi } from "../../../redux/components/Engineering/COCBidComplete/COCBidCompleteAction";
import { useState,useEffect } from "react";
import {getMkApi} from '../../../redux/components/Engineering/COCBidComplete/COCBIDMkReadyAction';
import {getFiberApi} from '../../../redux/components/Engineering/COCBidComplete/COCBIDFiberAction'
import {Circles} from 'react-loader-spinner';

let mkID = 0
let fiberId = 0
let mkName = ''
let fiberName = ''
let id =1 ;
let linkID = 2;
let stepID = 1;
const COCBidComplete = (props) => {
  const [apiData,setapiData]=useState([]); 
  const [loading,setLoading]=useState(true) 
  const [loading1,setLoading1]=useState(true) 
  const [loading2,setLoading2]=useState(true)
  const [ID,setID]=useState(0);
  const [Mk,setMk]=useState([]);
  const [Fiber,setFiber]=useState([]);

  const dispatch = useDispatch();

  const updateData=(data,dropData)=>{
    
   dispatch(updateApi(ID,data,dropData,apiData)).then((res)=>{
      if(res.status === 200)
        alert(`Data Updated SuccessFully!`);
      else 
        alert(res.message);
      })
  }

  const createData=(data,dropData)=>{
    console.log('drop',dropData);
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
        setID(data.cocBidCompleteID);
        setapiData(data);
      }
      return data;
    })
    setLoading(false)
  })
  dispatch(getMkApi()).then((res)=>{
    setMk(res);
    setLoading1(false)
  })
  dispatch(getFiberApi()).then((res)=>{
    setFiber(res);
    setLoading2(false)
  })
},[dispatch])
  

let item1 = data2?.COCBIDMkReducer?.data;
let item2 = data2?.COCBIDFiberReducer?.data;


if(data2?.COCBIDReducer?.data && data2?.COCBIDReducer?.data.status === undefined){
  item1?.map((value)=>{
    let id = data2?.COCBIDReducer?.data[0].fK_COCBidCompMkReadyID
    if(value.id === id){
      mkID = value.id
      mkName = value.name
    }
  
  })
  
  
  item2?.map((value)=>{
    let id = data2?.COCBIDReducer?.data[0].fK_COCBidCompFiberID
    if(value.id === id){
      fiberId = value.id
      fiberName = value.name
    }
  })
}


  const data = [
    { type:"dropdown", placeholder: "COC Bid Complete Make Ready",dropDownValues: Mk, defaultValue: mkName,defaultDrop: mkID },
    { type:"dropdown",placeholder: "COC Bid Complete Fiber",dropDownValues:Fiber,defaultValue: fiberName , defaultDrop: fiberId},
  ];

  console.log('data',data);

  return (
    <>
      {/* <h1>RealEstate</h1> */}
      {!loading && !loading1 && !loading2 ? <Card
        data={data}
        disable={props.disableFields}
        cardTitle="COC Bid Complete"
        tabColor={props.tabColor}
        onClick={updateData}
        onSubmit={createData}
      />: <div className="loader">
      <Circles type="Circles" color="#4d841d" height={60} width={60} />
      </div>}
    </>
  );
};

export default COCBidComplete;
