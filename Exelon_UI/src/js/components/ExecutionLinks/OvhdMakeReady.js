import React from "react";
import Card from "../../utils/Card";
import { useEffect,useState } from "react";
import { useDispatch , useSelector} from "react-redux";
import {getApi,updateApi,createApi} from "../../../redux/components/ExecutionLinks/Ovhd/OvhdAction"
import {getOvhdApi} from '../../../redux/components/ExecutionLinks/Ovhd/OvhdCocAction'
import CustomSnackBar from "../../utils/Snackbar";


const OvhdMakeReady = (props) => {
  const datatest = useSelector((state) => state.hideExecutionLinksFormReducer?.data);
  // let id =3;
  let fK_OVHDCOCID=0;
  let count = 0;
  let ovhdName='';
  const [apiData,setapiData]=useState([]);  
  const [loading,setLoading]=useState(true);
  const [loading1,setLoading1]=useState(true); 
  const [ID,setID]= useState(0);
  const [isDataUpdated,setDataUpdated]=useState(false);

  const data2=useSelector((state)=>{
    return state;
  })
  const [open, setOpen] = React.useState(false);
  const [message, setMessage] = useState("");
  const handleToClose = (event, reason) => {
    if ("clickaway" == reason) return;
    setOpen(false);
  };
  const createLink = useSelector((state)=>state.hideExecutionLinksFormReducer?.globallinkID);
  const dispatch = useDispatch();
  const updateData=(data,dropData)=>{
    updateApi(ID,data,dropData,datatest?.executionLinkingID).then((res)=>{
      if (res.status === 200){
        setDataUpdated(!isDataUpdated);
        setOpen(true);
        setMessage(`Data Updated SuccessFully!`);
      }
      else if(res.id>0){
        setID(res.id);
        setOpen(true);
        setMessage(`Data Created SuccessFully`);
      }
      else{
        setOpen(true);
        setMessage(res.message);
	    }
      })
  }

  const createData=(data,dropData)=>{
    createApi(data,dropData,createLink).then((res)=>{
      if (res.id > 0){
        setID(res.id);
        setOpen(true)
        setMessage(`Data Created SuccessFully!`);
      }
      else{
      setOpen(true)
      setMessage(res.message);
      }
    })
  }

useEffect(()=>{
  if(datatest?.executionLinkingID!==undefined){dispatch(getApi()).then((res)=>{
    res?.status !== 404 && res.map((data)=>{
      if(data.fK_LinkingID === datatest?.executionLinkingID){
        setID(data.ovhdMakeReadyID);
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
  })}
  else
  { 
      setLoading(false);
      setapiData([])
  }
  dispatch(getOvhdApi()).then((res)=>{
    setLoading1(false);
  })
},[dispatch,ID,datatest?.executionLinkingID,isDataUpdated])

let item = data2?.OvhdCOCReducer?.data;

item?.status !==404 && item?.map((value)=>{
  let ovhd_id = 0; 
  if(data2?.OVHDReducer?.data && data2?.OVHDReducer?.data?.status!==404 ){
    data2?.OVHDReducer?.data.filter((res)=>{
      if(res.fK_LinkingID === datatest?.executionLinkingID)
        ovhd_id = res.fK_OVHDCOCID;
    })
  }
  if(value.cocid === ovhd_id){
    fK_OVHDCOCID = ovhd_id
    ovhdName = value.name
  }
})

  const data = [
    { type:"dropdown", placeholder: "OVHD COC",dropDownValues: data2?.OvhdCOCReducer?.data===null || data2?.OvhdCOCReducer?.data ===undefined?[]:data2?.OvhdCOCReducer?.data ,defaultDrop: fK_OVHDCOCID, defaultValue: ovhdName },
    { type:"date",placeholder: "OVHD Start",defaultValue: apiData?.ovhdMakeReadyID>0? apiData.strStartDate:'' },
    { type:"date",placeholder:"OVHD Finish",defaultValue: apiData?.ovhdMakeReadyID>0?apiData.strEndDate:''},
    { type:"textarea",placeholder: "Make-Ready Issues/ Comments",defaultValue:apiData?.ovhdMakeReadyID>0?apiData.issuesOrComments:'' },
    { type:"textarea",placeholder:"OVHD Weekly FTE Count",defaultValue:apiData?.ovhdMakeReadyID>0?apiData.weeklyFTECount:''   }
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
      <CustomSnackBar
        open={open}
        onClose={() => handleToClose()}
        message={message}
      />
    </>
  );
};

export default OvhdMakeReady;
