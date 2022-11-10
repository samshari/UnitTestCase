import React from "react";
import Card from "../../utils/Card";
import { useState,useEffect } from "react";
import {useSelector,useDispatch} from 'react-redux'
import { getApi,updateApi,createApi } from "../../../redux/components/ExecutionLinks/InnerDuct/InnerDuctAction";
import CustomSnackBar from "../../utils/Snackbar";

// let id =3;
const Innerduct = (props) => {
  let count = 0;
  const datatest = useSelector((state) => state.hideExecutionLinksFormReducer?.data);
  const [apiData,setapiData]=useState([]);  
  const [loading,setLoading]=useState(true); 
  const [ID,setID]= useState(0);
  const [isDataUpdated,setDataUpdated]=useState(false);
  const [open, setOpen] = React.useState(false);
  const [message, setMessage] = useState("");
  const handleToClose = (event, reason) => {
    if ("clickaway" == reason) return;
    setOpen(false);
  };

  const createLink = useSelector((state)=>state.hideExecutionLinksFormReducer?.globallinkID);
  const data2 = useSelector((state)=>{
    return state
  })

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
  if(datatest?.executionLinkingID!==undefined){dispatch(getApi()).then((res)=>{
    res?.status !== 404 && res.map((data)=>{
      if(data.fK_LinkingID === datatest?.executionLinkingID){
        setID(data.rodAndRopeID);
        setapiData(data);
        count = count +1;
      }
      return data;
    })
    if(count === 0){
      setID(0);
      setapiData([]);
    }
    setLoading(false);
  })}
  else
    { 
      setLoading(false);
      setapiData([])
    }
},[dispatch,datatest?.executionLinkingID,ID,isDataUpdated])
  const data = [
    { type:"date",placeholder: "Innerduct Start", defaultValue: apiData?.rodAndRopeID>0? apiData.strInnerductStartDate:'' },
    { type:"date",placeholder: "Innerduct Finish", defaultValue: apiData?.rodAndRopeID>0?apiData.strInnerductEndDate:''},
    { type:"textarea",placeholder: "Innerduct Comments", defaultValue:apiData?.rodAndRopeID>0?apiData.comments:'' },
  ];
  return (
    <>
      {!loading && <Card
        data={data}
        disable={props.disableFields}
        cardTitle="Innerduct (Rod and Rope)"
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

export default Innerduct;
