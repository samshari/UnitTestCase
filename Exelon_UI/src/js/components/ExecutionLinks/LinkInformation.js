import React from "react";
import Card from "../../utils/Card";
import { useSelector,useDispatch } from "react-redux";
import { useState, useEffect } from "react";
import { getExLinkApi,updateExLinkApi,createExLinkApi } from "../../../redux/components/ExecutionLinks/Linkinformation/LinkInfromationAction";
import {getBarnApi} from '../../../redux/components/Engineering/LinkInformation/BarnAction'
import {getRegionApi} from '../../../redux/components/Engineering/LinkInformation/RegionAction'
import {getProjectStatusApi} from '../../../redux/components/Engineering/LinkInformation/ProjectStatusAction'
import {getTechApi} from '../../../redux/components/Engineering/LinkInformation/TechAction'
import {getFiberApi} from '../../../redux/components/Engineering/LinkInformation/FiberAction'
import { selectProjectID } from "../../../redux/views/Header/HeaderAction";
import { getallProjectId, getExLabelData, getExLinkID, getProjectId, getProjectIDByPD } from "../../../redux/components/ExecutionLinks/ExecutionLinksAction";
import { disableTabs } from "../../../redux/utils/Tabs/TabsAction";
import { getPDApi } from "../../../redux/components/Engineering/PD/PDAction";
import CustomSnackBar from "../../utils/Snackbar";



const LinkInformation = (props) => {
  let fK_TechnologyID = 0;
  let fK_RegionID =0;
  let fK_BarnID=0;
  let fK_ProjectStatusID=0;
  let techName = '';
  let regionName = '';
  let barnName = '';
  let projectName ='';

  const pdID =useSelector((state)=> state.engineeringFormReducer.id); 
  const [apiData,setApiData]=useState([]); 
  const [ID,setID]=useState(0);
  const [loading,setLoading]=useState(true);
  const [loading1,setLoading1]=useState(true);
  const [loading2,setLoading2]=useState(true);
  const [loading3,setLoading3]=useState(true);
  const [loading4,setLoading4]=useState(true);
  const [loading5,setLoading5]=useState(true);
  const [isDataUpdated,setDataUpdated]=useState(false);
  const dispatch= useDispatch();
  const [open, setOpen] = React.useState(false);
  const [message, setMessage] = useState("");
  const handleToClose = (event, reason) => {
    if ("clickaway" == reason) return;
    setOpen(false);
  };
  const datatest = useSelector((state) => state.hideExecutionLinksFormReducer?.data);

  const updateData=(data,dropData)=>{
    let fiberCount='';
    data[7]?.value?.map((val)=>{
      item5.map((value)=>{
        if(val === value.fiberCountValue)
          fiberCount += String(val);
        return value;
      })
      fiberCount+=',';
    })
    updateExLinkApi(ID,data,dropData,fiberCount,apiData).then((res)=>{
      setDataUpdated(!isDataUpdated);
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
    let fiberCount='';
    multiDrop[7]?.value?.map((val)=>{
      item5.map((value)=>{
        if(val === value.fiberCountValue)
          fiberCount += String(val);
        return value;
      })
      fiberCount+= ',';
    })
    createExLinkApi(data,dropData,fiberCount,pdID).then(res=>{
      if(res.id>0){
        dispatch(getPDApi());
        dispatch(getProjectId(0)).then((res) => {
          res?.status !== 404 && dispatch(getallProjectId(res.map((item) => {
            return item.projectId;
          })))
        })
        dispatch(getProjectId(pdID)).then((res) => {
          dispatch(getProjectIDByPD(res));
        })
        dispatch(getExLinkID(res.id));
        dispatch(disableTabs(false));
        setOpen(true);
        setMessage(`Data Created SuccessFully!`);
      }
      else{
        setOpen(true);
        setMessage(res.message);
      }
    });
  }

  const data2 = useSelector((state)=>{
    return state
  })

  useEffect(() => {

    if(datatest?.executionLinkingID!==undefined) { 
      dispatch(getExLinkApi(datatest?.executionLinkingID)).then((res)=> {
      if(res?.status !== 404) {
        setID(res[0]?.executionLinkingID);
        setApiData(res[0]);
        dispatch(selectProjectID(res[0].projectId));
        dispatch(getExLabelData(res));
      }
      setLoading(false);
    })}
    else
    { 
      setLoading(false);
      setApiData([])
    }
    dispatch(getBarnApi()).then((res)=>setLoading1(false));
    dispatch(getRegionApi()).then((res)=>setLoading2(false));
    dispatch(getTechApi()).then((res)=>setLoading3(false));
    dispatch(getProjectStatusApi()).then((res)=>setLoading4(false));
    dispatch(getFiberApi()).then((res)=>setLoading5(false));
  }, [dispatch,datatest?.executionLinkingID,isDataUpdated]);


let item5 = data2?.FiberReducer?.data;
const optionsID = apiData?.fiberCount?.split(",");
let options=[]

item5?.status!==404 && item5?.map((val)=>{
  options.push(val.fiberCountValue);
  return val;
})
let option = []
optionsID?.map((val)=>{
  item5?.map((value)=>{
      if(value.fiberCountID === parseInt(val)){
        option.push(value.fiberCountValue);  
      }   
      return value;
  })
})


let item1 = data2?.TechReducer?.data;

item1?.status !==404 && item1?.status!==404 && item1?.map((value)=>{
  let id = 0; 
  if(data2?.exlinkInformationReducer?.data ){
    id = data2?.exlinkInformationReducer?.data[0].technologyId
  }
  if(value.id === id){
    fK_TechnologyID = value.id
    techName = value.name
  }
})

let item2 = data2?.RegionReducer?.data;

item2?.status !==404 && item2?.status!==404 && item2?.map((value)=>{
  let id = 0; 
  if(data2?.exlinkInformationReducer?.data ){
    id = data2?.exlinkInformationReducer?.data[0].regionId
  }
  if(value.regionID === id){
    fK_RegionID = value.regionID
    regionName = value.regionName
  }
})

let item3 = data2?.BarnReducer?.data;

item3?.status !==404 && item3?.status!==404 && item3?.map((value)=>{
  let id = 0; 
  if(data2?.exlinkInformationReducer?.data ){
    id = data2?.exlinkInformationReducer?.data[0].barnId
  }
  if(value.barnID === id){
    fK_BarnID = value.barnID
    barnName = value.barnName
  }

})

let item4 = data2?.ProjectStatusReducer?.data;

item4?.status !==404 && item4?.status!==404 && item4?.map((value)=>{
  let id = 0; 
  if(data2?.exlinkInformationReducer?.data ){
    id = data2?.exlinkInformationReducer?.data[0].projectStatusId
  }
  if(value.statusID === id){
    fK_ProjectStatusID = value.statusID
    projectName = value.name
  }

})

  const data = [
    { type:"year", placeholder: "Engineering Year",defaultValue: apiData?.executionLinkingID>0?apiData?.engineeringYear:"" },
    { type:"year",placeholder: "Execution Year",defaultValue: apiData?.executionLinkingID>0?apiData?.executionYear:'' },
    { 
      type: "dropdown",
      placeholder: "Technology",
      dropDownValues: data2?.TechReducer?.data === null  || data2?.TechReducer?.data?.status===404? []: data2?.TechReducer?.data,
      defaultDrop: fK_TechnologyID,
      defaultValue: techName
    },
    { 
      type: "dropdown",
      placeholder: "Region",
      dropDownValues: data2?.RegionReducer?.data === null || data2?.RegionReducer?.data?.status===404 ? []:data2?.RegionReducer?.data,
      defaultDrop: fK_RegionID,
      defaultValue: regionName
    },
    { 
      type: "dropdown",
      placeholder: "Barn",
      dropDownValues: data2?.BarnReducer?.data === null || data2?.BarnReducer?.data?.status === 404 ? []:data2?.BarnReducer?.data,
      defaultDrop: fK_BarnID,
      defaultValue: barnName
    },
    { placeholder: "Work Order",defaultValue:apiData?.executionLinkingID>0? apiData?.workOrder:'' },
    { required:true,placeholder: "Project Id", defaultValue: apiData?.executionLinkingID>0? apiData?.projectId:'' },
    // {placeholder:"Fiber PID Split",defaultValue:''},
    { 
      type: "multiSelect",
      placeholder: "Fiber Count",
      optionValues: options,
      defaultValue:option
    },
    { placeholder: "Link Information Comments" ,defaultValue: apiData.executionLinkingID>0?apiData?.comments:''},
    { placeholder: "ITN",defaultValue: apiData.executionLinkingID>0?apiData?.itn :''},
    {
      type: "dropdown",
      placeholder: "Project Status",
      dropDownValues: data2?.ProjectStatusReducer?.data === null || data2?.ProjectStatusReducer?.data?.status ===404 ? []:data2?.ProjectStatusReducer?.data,
      defaultDrop: fK_ProjectStatusID,
      defaultValue: projectName
    },
    { type: "textarea", placeholder: "Scope Comments",defaultValue: apiData.executionLinkingID>0?apiData?.scopeComments:'' },
  ];
  return (
    <>
    {!loading && !loading1 && !loading2 && !loading3 && !loading4 && !loading5 && <Card
        data={data}
        moveToTab={props.moveToTab}
        disable={props.disableFields}
        cardTitle="Link Information"
        tabColor={props.tabColor}
        onClick={updateData}
        onSubmit={createData}
      />
    }
    <CustomSnackBar
        open={open}
        onClose={() => handleToClose()}
        message={message}
      />
    </>
  );
};

export default LinkInformation;
