import React from "react";
import Card from "../../utils/Card";
import { useEffect, useState } from "react";
import { useDispatch, useSelector } from "react-redux";
import {
  getApi,
  updateApi,
  createApi,
} from "../../../redux/components/ExecutionLinks/Civil/CivilAction";
import { getCivilApi } from "../../../redux/components/ExecutionLinks/Civil/CivilCocAction";
import CustomSnackBar from "../../utils/Snackbar";


const Civil = (props) => {
  // let id = 3;
  let fK_CIVILCOCID = 0;
  let civilName = "";
  let count = 0;
  const datatest = useSelector((state) => state.hideExecutionLinksFormReducer?.data);
  const [apiData, setapiData] = useState([]);
  const [loading, setLoading] = useState(true);
  const [loading1, setLoading1] = useState(true);
  const [ID, setID] = useState(0);
  const [isDataUpdated,setDataUpdated]=useState(false);
  const [open, setOpen] = React.useState(false);

  const [message, setMessage] = useState("");
  const handleToClose = (event, reason) => {
    if ("clickaway" == reason) return;
    setOpen(false);
  };

  const data2 = useSelector((state) => {
    return state;
  });
  const createLink = useSelector((state)=>state.hideExecutionLinksFormReducer?.globallinkID);
  const dispatch = useDispatch();
  const updateData = (data, dropData) => {
    updateApi(ID, data, dropData, datatest?.executionLinkingID).then((res) => {
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
    });
  };

  const createData = (data,dropData) => {
    createApi(data,dropData,createLink).then((res) => {
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
  };

  useEffect(() => {
    if(datatest?.executionLinkingID!==undefined){dispatch(getApi()).then((res) => {
      res?.status !== 404 &&
        res.map((data) => {
          if (data.fK_LinkingID === datatest?.executionLinkingID) {
            setID(data.civilID);
            setapiData(data);
            count = count +1;
          }
          return data;
        });
        if(count === 0){
          setID(0);
          setapiData([]);
        }
      setLoading(false);
    });
  }
  else
  { 
      setLoading(false);
      setapiData([])
  }

    dispatch(getCivilApi()).then((res) => {
      setLoading1(false);
    });
  }, [dispatch,datatest?.executionLinkingID,ID>0,isDataUpdated]);

  let item = data2?.CivilCOCReducer?.data;

  item?.status !==404 && item?.map((value) => {
    let civil_id = 0;
    if (data2?.CIVILReducer?.data  && data2?.CIVILReducer?.data?.status!=404) {
      data2?.CIVILReducer?.data?.filter((res) => {
        if (res.fK_LinkingID === datatest?.executionLinkingID) 
          civil_id = res.fK_CivilCOCID;
      });
    }
    if (value.cocid === civil_id) {
      fK_CIVILCOCID = value.cocid;
      civilName = value.name;
    }
  });
  
  const data = [
    { type:"dropdown", placeholder: "Civil COC", dropDownValues: data2?.CivilCOCReducer?.data === null ? []: data2?.CivilCOCReducer?.data,defaultDrop: fK_CIVILCOCID, defaultValue: civilName  },
    { type: "date", placeholder: "Civil Start", defaultValue:apiData?.civilID>0? apiData.strStartDate:'' },
    { type: "date", placeholder: "Civil Finish", defaultValue:apiData?.civilID>0? apiData.strEndDate:'' },
    { type: "textarea", placeholder: "Civil Issues/Comments", defaultValue:apiData?.civilID>0? apiData.issuesOrComments:'' },
    { type: "textarea", placeholder: "Civil Weekly FTE Count", defaultValue:apiData?.civilID>0? apiData.weeklyFTECount:'' },
  ];

  return (
    <>
      {!loading && !loading1 && <Card
        data={data}
        disable={props.disableFields}
        cardTitle="Civil"
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

export default Civil;
