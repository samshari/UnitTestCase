import React from "react";
import Card from "../../utils/Card";
import { useEffect,useState } from "react";
import { useDispatch, useSelector } from "react-redux";
import { getApi,updateApi,createApi } from "../../../redux/components/ExecutionLinks/IfcDates/IfcDatesAction";

let id =3;
const IFCDates = (props) => {
  const [apiData,setapiData]=useState([]);  
  const [loading,setLoading]=useState(true);
  const [ID,setID]= useState(0);

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
    createApi(data,id).then((res)=>{
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
        setID(data.ifcDateID);
        setapiData(data);
      }
      return data;
    })
    setLoading(false)
  })
},[dispatch])
  
  const data = [
    { type:"date",placeholder: "IFC Make Ready Scheduled Issue Date", defaultValue:apiData?.ifcDateID>0?apiData.strIFCMkReadyScheduledIssueDate:'' },
    { type:"date",placeholder: "IFC Fiber current Scheduled Issue Date",defaultValue:apiData?.ifcDateID>0?apiData.strIFCFiberCurrentScheduledIssueDt:'' },
  ];
  return (
    <>
      {!loading && <Card
        data={data}
        disable={props.disableFields}
        cardTitle="IFC Dates"
        tabColor={props.tabColor}
        onClick={updateData}
        onSubmit={createData}
      />}
    </>
  );
};

export default IFCDates;
