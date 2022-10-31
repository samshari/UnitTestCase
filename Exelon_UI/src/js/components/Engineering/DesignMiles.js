import React from "react";
import Card from "../../utils/Card";
import { useState,useEffect } from "react";
import { useDispatch, useSelector } from "react-redux";
import {getApi,updateApi,createApi} from '../../../redux/components/Engineering/DesignMiles/DesignMileAction'
import {Circles} from 'react-loader-spinner'

let id =1;
let linkID = 2;
let stepID =2;
const DesignMiles = (props) => {

  const [apiData,setapiData]= useState([]);
  const [loading,setLoading] = useState(true);
  const [ID,setID]=useState(0);

  const dispatch= useDispatch();

  const updateData=(data)=>{
    updateApi(ID,data,apiData).then(res=>{
      
      if(res.status === 200)
        alert('Data Updated SuccessFully!');
      else 
        alert(res.message);
    });
  }

  const datatest=useSelector((state)=>state.engineeringFormReducer?.data)
  const datatest1=useSelector((state)=>state.engineeringFormReducer?.linkId)
  
  const createData=(data,dropData,multiDrop)=>{
    createApi(data,datatest1,stepID).then(res=>{
      if(res.id > 0)
        alert('Data Created SuccessFully!');
      else 
        alert(res.message);
    });
  }

  useEffect( ()=>{
    {datatest ? dispatch(getApi()).then((res)=>{
      res.map((data)=>{
        if(data.fK_LinkingID === datatest.linkingId){
          setID(data.designMilesID);
          setapiData(data);
        }
        return data;
      })
      setLoading(false)
    }):setLoading(false)
    setapiData([])
  }
    
 },[dispatch])


  const data = [
    {  placeholder: "UG Miles", defaultValue : apiData.ugMiles },
    {  placeholder: "OH Miles",defaultValue: apiData.ohMiles },
    {  placeholder: "Total Miles", defaultValue: apiData.totalMiles},
  ];

  return (
    <>
      {/* <h1>RealEstate</h1> */}
      {!loading ? <Card
        data={data}
        disable={props.disableFields}
        cardTitle="Design Miles"
        tabColor={props.tabColor}
        onClick={updateData}
        onSubmit = {createData}
      />: <div className="loader">
      <Circles type="Circles" color="#4d841d" height={60} width={60} />
      </div>}
    </>
  );
};

export default DesignMiles;
