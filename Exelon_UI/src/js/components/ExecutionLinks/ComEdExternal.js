import React from "react";
import Card from "../../utils/Card";
import { useState, useEffect } from 'react'
import { useDispatch, useSelector } from "react-redux";
import { getApi, createApi, updateApi, getComEdIdByLinkingIdApi } from '../../../redux/components/ExecutionLinks/ComEdExternal/ComEdExternalAction'
import { Circles } from 'react-loader-spinner'
import { getLnLApi } from "../../../redux/components/ExecutionLinks/ComEdExternal/LnlAction";
import CustomSnackBar from "../../utils/Snackbar";

const ComEdExternal = (props) => {
  let lnlid=0;
  let lnlname ='';
  let count =0;
  const [loading, setLoading] = useState(true);
  const [loading1, setLoading1] = useState(true);
  const [apiData, setapiData] = useState([]);
  const [ID,setID]=useState(0);
  const [lnlNm, setlnlName] = useState('');
  const [lnlPKId, setlnlPKId] = useState(0);
  const [isDataUpdated,setDataUpdated]=useState(false);
  const datatest = useSelector((state) => state.hideExecutionLinksFormReducer?.data);
  const dispatch = useDispatch();

  const createLink = useSelector((state)=>state.hideExecutionLinksFormReducer?.globallinkID);
  const [open, setOpen] = React.useState(false);

  const [message, setMessage] = useState("");
  const handleToClose = (event, reason) => {
    if ("clickaway" == reason) return;
    setOpen(false);
  };
  
  useEffect(() => {
    dispatch(getLnLApi()).then((res) => {
      setLoading1(false);
    });
    if(datatest?.executionLinkingID!==undefined){dispatch(getApi()).then((res) => {
      res?.status !== 404 && res.map((data) => {
        if (data.linkingId === datatest?.executionLinkingID) {
          setID(data.comEdId);
          setapiData(data);
          setlnlPKId(data.LNLId);
          count = count +1;
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
  else
  { 
      setLoading(false);
      setapiData([])
  }
    
  }, [dispatch,ID>0,datatest,isDataUpdated])



  const updateData = (data, dropData) => {
    updateApi(ID, data,dropData,datatest?.executionLinkingID).then((res) => {
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

  const createData = (data, dropData) => {
    createApi(data, dropData, createLink).then(res => {
      if (res.id > 0){
        setID(res.id);
        setOpen(true)
        setMessage(`Data Created SuccessFully!`);
      }
      else{
      setOpen(true)
      setMessage(res.message);
      }
    });
  }

  const data2=useSelector((state)=>state);
  const item = data2?.LnlReducer?.data?.result;

  item?.status !==404 && item?.map((value) => {
    let lnl_id = 0;
    if (data2?.ComEdReducer?.data && data2?.ComEdReducer?.data.status!==404 ) {
      data2?.ComEdReducer?.data.filter((res) => {
        if (res.linkingId === datatest?.executionLinkingID)
          lnl_id = res.lnlId;
      })
    }
    if (value.id === lnl_id){
      lnlid = value.id;
      lnlname = value.name;
    }
  })

 

  const data = [
    { required:true, type: "dropdown", placeholder: "LNL/Labor for OH make ready *", dropDownValues: data2?.LnlReducer?.data?.result===undefined || data2?.LnlReducer?.data?.result===null ?[]:data2?.LnlReducer?.data?.result, defaultDrop: lnlid, defaultValue: lnlname },
  ];

  return (
    <>
      {!loading && !loading1 && <Card
        data={data}
        disable={props.disableFields}
        cardTitle="ComEd/External"
        tabColor={props.tabColor}
        onSubmit={createData}
        onClick={updateData}
      />}
      <CustomSnackBar
        open={open}
        onClose={() => handleToClose()}
        message={message}
      />
    </>
  );
};

export default ComEdExternal;
