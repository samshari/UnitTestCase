import React from "react";
import Card from "../../utils/Card";
import { useEffect,useState } from "react";
import { useDispatch, useSelector } from "react-redux";
import { getApi,updateApi,createApi } from "../../../redux/components/Engineering/IFAFiberMkReady/IFAFiberMkReadyAction";
import { Circles } from "react-loader-spinner";



let stepID = 1;
const IFAMakeReady = (props) => {
  const [apiData,setapiData]=useState([]);  
  const [loading,setLoading]=useState(true) 
  const [ID,setID]=useState(0);

  const dispatch = useDispatch();

    
  const updateData=(data)=>{
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
  {datatest!=undefined ? dispatch(getApi()).then((res)=>{
    res.map((data)=>{
      if(data.fK_LinkingID === datatest.linkingId){
        setID(data.ifaMakeReadyID);
        setapiData(data);
      }
      return data;
    })
    setLoading(false)
  }):setLoading(false)
    setapiData([])}
},[dispatch])

  const data = [
    { type: "date", placeholder: "IFA Make Ready Original Scheduled Date",defaultValue: apiData.strOriginalScheduledDate },
    { type: "date", placeholder: "IFA Make Ready Current Scheduled Date",defaultValue: apiData.strCurrentScheduledDate },
    { type: "textarea", placeholder: "IFA Make Ready Missed Dates & Reasons",defaultValue: apiData.missedDatesAndReasons },
    { type: "date", placeholder: "IFA Make Ready Initial Issue Date",defaultValue: apiData.strInitialIssueDate },
    { type: "date", placeholder: "IFA Make Ready Final Issue Date",defaultValue: apiData.strFinalIssueDate },
  ];

  return (
    <>
      {/* <h1>RealEstate</h1> */}
      { !loading ? <Card
        data={data}
        disable={props.disableFields}
        cardTitle="IFA Make Ready"
        tabColor={props.tabColor}
        onClick={updateData}
        onSubmit={createData}
      />: <div className="loader">
      <Circles type="Circles" color="#4d841d" height={60} width={60} />
      </div>}
    </>
  );
};

export default IFAMakeReady;
