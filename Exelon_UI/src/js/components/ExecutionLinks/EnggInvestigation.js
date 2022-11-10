import React from "react";
import Card from "../../utils/Card";
import { useEffect,useState } from "react";
import { useDispatch , useSelector} from "react-redux";
import { getApi,updateApi,createApi } from "../../../redux/components/ExecutionLinks/Engginvestigation/EngginvestigationAction";
import {getInnerApi} from '../../../redux/components/ExecutionLinks/Engginvestigation/InnerDuctCOCAction'
import CustomSnackBar from "../../utils/Snackbar";


const EnggInvestigation = (props) => {
  // let id =3;
  let fK_InnerductCOC =0;
  let innerName = '';
  let count =0;
  const [apiData,setapiData]=useState([]);  
  const [loading,setLoading]=useState(true) 
  const [loading1,setLoading1]=useState(true);
  const [ID,setID]= useState(0);
  const [isDataUpdated,setDataUpdated]=useState(false);

  const datatest = useSelector((state) => state.hideExecutionLinksFormReducer?.data);
  const createLink = useSelector((state)=>state.hideExecutionLinksFormReducer?.globallinkID);
  const data2 = useSelector((state)=>{
    return state
  })

  const [open, setOpen] = React.useState(false);
  const [message, setMessage] = useState("");
  const handleToClose = (event, reason) => {
    if ("clickaway" == reason) return;
    setOpen(false);
  };

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
  
  if(datatest?.executionLinkingID!==undefined){
  dispatch(getApi()).then((res)=>{
    res?.status !== 404 && res.map((data)=>{
      if(data.fK_LinkingID === datatest?.executionLinkingID){
        setID(data.enggInvestigationID);
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
  else{
    setLoading(false);
    setapiData([]);
  }
  dispatch(getInnerApi()).then((res)=>setLoading1(false))
},[dispatch,datatest?.executionLinkingID,ID,isDataUpdated])

let item = data2?.InnerDuctCOCReducer?.data;

item?.status !==404 && item?.map((value)=>{
  let inner_id = 0; 
  if(data2?.EnggInvestReducer?.data && data2?.EnggInvestReducer?.data?.status!=404 ){
    data2?.EnggInvestReducer?.data?.filter((res)=>{
      if(res.fK_LinkingID === datatest?.executionLinkingID)
        inner_id = res.fK_InnerductCOC;
    })
  }
  if(value.innerductCOCID === inner_id){
    fK_InnerductCOC = inner_id
    innerName = value.name
  }

})



  const data = [
    { type:"dropdown",placeholder: "Eng Investigation/ innerduct coc",dropDownValues: data2?.InnerDuctCOCReducer?.data === null ? []:data2?.InnerDuctCOCReducer?.data ,defaultDrop: fK_InnerductCOC, defaultValue: innerName },
    { type:"textarea",placeholder: "Eng. Investigation Issues/Comments",defaultValue: apiData?.enggInvestigationID>0? apiData.comments:''}
  ];
  return (
    <>
      {!loading && !loading1 && <Card
        data={data}
        disable={props.disableFields}
        cardTitle="Engineering Investigation"
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

export default EnggInvestigation;
