import React from "react";
import Card from "../../utils/Card";
import { useEffect,useState } from "react";
import { useDispatch,useSelector } from "react-redux";
import { getApi,updateApi,createApi } from "../../../redux/components/ExecutionLinks/Fiber/FiberAction";
import {getOvhdApi} from '../../../redux/components/ExecutionLinks/Ovhd/OvhdCocAction';
import CustomSnackBar from "../../utils/Snackbar";


const Fiber = (props) => {
  // let id =3;
  let fK_FiberCOCID = 0;
  let fiberCocName='';
  let count = 0;
  const datatest = useSelector((state) => state.hideExecutionLinksFormReducer?.data);
  const selectLinkByPk = useSelector((state) => state.hideExecutionLinksFormReducer?.data?.executionLinkingID);
  const [apiData,setapiData]=useState([]);  
  const [loading,setLoading]=useState(true) 
  const [loading1,setLoading1]=useState(true) 
  const [ID,setID]= useState(0);
  const [isDataUpdated,setDataUpdated]=useState(false);
  const [check,setCheck]=useState(false);

  const [open, setOpen] = React.useState(false);
  const [message, setMessage] = useState("");
  const handleToClose = (event, reason) => {
    if ("clickaway" == reason) return;
    setOpen(false);
  };

  const data2=useSelector((state)=>{
    return state;
  })
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

  const createData=(data,dropData,multiDrop)=>{
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
  if(datatest?.executionLinkingID!==undefined) { dispatch(getApi()).then((res)=>{
    res?.status!==404 && res.map((data)=>{
      if(data.fK_LinkingID === datatest?.executionLinkingID){
        setID(data.fiberID);
        setapiData(data);
        count = count + 1;
      }
      return data;
    })
    if(count === 0){
      setID(0);
      setapiData([]);
    }
    setLoading(false)
  })
}
else{
  setID(0);
  setLoading(false);
  setapiData([]);
}

  dispatch(getOvhdApi()).then((res)=>{
    setLoading1(false);
  })
},[dispatch,selectLinkByPk,ID>0,isDataUpdated])

let item = data2?.OvhdCOCReducer?.data;

item?.status !==404 && item?.map((value)=>{
  let fiberCoc_id = 0; 
  if(data2?.ExFiberReducer?.data && data2?.ExFiberReducer?.data?.status!=404 ){
    data2?.ExFiberReducer?.data.filter((res)=>{
      if(res.fK_LinkingID === datatest?.executionLinkingID)
      fiberCoc_id = res.fK_FiberCOCID;
    })
  }
  if(value.cocid === fiberCoc_id){
    fK_FiberCOCID = fiberCoc_id
    fiberCocName = value.name
  }
})

  const data = [
    { type:"dropdown", placeholder: "Fiber COC",dropDownValues:data2?.OvhdCOCReducer?.data ===null || data2?.OvhdCOCReducer?.data ===undefined? []:data2?.OvhdCOCReducer?.data,defaultDrop: fK_FiberCOCID, defaultValue: fiberCocName },
    { type: "date", placeholder: "Fiber Start",defaultValue: apiData?.fiberID>0?apiData.strStartDate:''},
    { type: "date", placeholder: "Target Fiber Install Finish", defaultValue: apiData?.fiberID>0? apiData.strEndDate:'' },
    { type: "textarea", placeholder: "Fiber Weekly FTE Count", defaultValue: apiData?.fiberID>0? apiData.weeklyFTECount:''   },
    { type: "textarea", placeholder: "Fiber Issues/Comments",defaultValue: apiData?.fiberID>0? apiData.issuesOrComments:''  },
    { type: "date", placeholder: "Actual OTDR Completion Date (In Service)",  defaultValue:apiData?.fiberID>0? apiData.strOTDRCompletionDate:'' },
  ];
  return (
    <>
      {!loading && !loading1 && <Card
        data={data}
        disable={props.disableFields}
        cardTitle="Fiber"
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

export default Fiber;
