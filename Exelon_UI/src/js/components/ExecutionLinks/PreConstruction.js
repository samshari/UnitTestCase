// Redux and Component Imports
import React from "react";
import Card from "../../utils/Card";
import { useEffect, useState } from "react";
import { useDispatch, useSelector } from "react-redux";
import { getApi, updateApi, createApi } from "../../../redux/components/ExecutionLinks/PreConstruction/PreConstructionAction"
import { getPreConstructionApi } from '../../../redux/components/ExecutionLinks/PreConstruction/PreConstructionCocAction'
import CustomSnackBar from "../../utils/Snackbar";

//Static State Data
// let id = 3;
const YNOval = [
  { "id": 0, "name": "No" },
  { "id": 1, "name": "Yes" },
  { "id": 2, "name": "Complete" }
]

//Compnent RAFCE CODE
const PreConstruction = (props) => {
  let fK_PRECONSTRUCTIONCOCID = 0;
  let preConstructionName = 'COC_USER';
  const datatest = useSelector((state) => state.hideExecutionLinksFormReducer?.data);
  //UseState Declarations
  const [apiData, setapiData] = useState([]);
  const [loading, setLoading] = useState(true);
  const [loading1, setLoading1] = useState(true);
  const [ID, setID] = useState(0);
  const [COCID, setCocID] = useState(0);
  let count = 0;

  const [isDataUpdated,setDataUpdated]=useState(false);
  const createLink = useSelector((state)=>state.hideExecutionLinksFormReducer?.globallinkID);
  //Selector and Dispatcher
  const data2 = useSelector((state) => {
    return state;
  })
  const dispatch = useDispatch();
  const [open, setOpen] = React.useState(false);
  const [message, setMessage] = useState("");
  const handleToClose = (event, reason) => {
    if ("clickaway" == reason) return;
    setOpen(false);
  };


  // Update PreConstruction through API CALL
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
    })
  }

  // Create PreConstruction through API CALL
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
    })
  }

  //Loading Conditions
  useEffect(() => {
    if(datatest?.executionLinkingID!==undefined ) {dispatch(getApi()).then((res) => {
      res?.status !== 404 && res.map((data) => {
        if (data.fK_LinkingID === datatest?.executionLinkingID) {
          setID(data.preContructionID);
          setCocID(data.fK_EnvironmentalCOCID)
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
    })
  }
  else{
    setLoading(false);
    setapiData([]);
  }
    dispatch(getPreConstructionApi()).then((res) => {
      setLoading1(false);
    })
  }, [dispatch,datatest?.executionLinkingID,ID>0,isDataUpdated])


  //Set Coc credentials
  let item = data2?.PreConstructionCOCReducer?.data;
  item?.status !=404 && item?.map((value) => {
    let preConstruction_id = 0;
    if (data2?.PreConstructionReducer?.data && data2?.PreConstructionReducer?.data?.status!=404) {
      data2?.PreConstructionReducer?.data.filter((res) => {
        if (res.fK_LinkingID === datatest?.executionLinkingID)
          preConstruction_id = res.fK_EnvironmentalCOCID;
      })
    }
    if (value.id === preConstruction_id) {
      fK_PRECONSTRUCTIONCOCID = preConstruction_id
      preConstructionName = value.name
    }
  })

  //Data Prop for PreConstruction Card
  const data = [
    {
      type: "dropdown", placeholder: "Environmental COC", dropDownValues: data2?.PreConstructionCOCReducer?.data===undefined || data2?.PreConstructionCOCReducer?.data === null ? [] : data2?.PreConstructionCOCReducer?.data, defaultDrop: COCID,
      defaultValue: preConstructionName
    },
    {
      type: "dropdown", placeholder: "Veg. Required?", dropDownValues: YNOval,
      defaultDrop: apiData?.fK_VegRequired,
      defaultValue: YNOval[apiData?.fK_VegRequired]?.name
    },
    {
      type: "dropdown", placeholder: "Staking Required?", dropDownValues: YNOval,
      defaultDrop: apiData?.fK_StackingRequired,
      defaultValue: YNOval[apiData?.fK_StackingRequired]?.name
    },
    {
      type: "dropdown", placeholder: "Matting Required?", dropDownValues: YNOval,
      defaultDrop: apiData?.fK_MattingRequired,
      defaultValue: YNOval[apiData?.fK_MattingRequired]?.name
    },
  ];

  //Return Card if both loading complete
  return (
    <>
      {!loading && !loading1 &&
        <Card
          data={data}
          disable={props.disableFields}
          cardTitle="Pre Construction"
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


//Default Export
export default PreConstruction;