import React, { useEffect } from "react";
import { useState } from "react";
import { useSelector, useDispatch } from "react-redux";
import { getApi, updateApi, createApi } from "../../../redux/components/Engineering/LinkInformation/LinkInformationAction";
import Card from "../../utils/Card";
import { Circles } from "react-loader-spinner";
import { getBarnApi } from '../../../redux/components/Engineering/LinkInformation/BarnAction'
import { getRegionApi } from '../../../redux/components/Engineering/LinkInformation/RegionAction'
import { getProjectStatusApi } from '../../../redux/components/Engineering/LinkInformation/ProjectStatusAction'
import { getTechApi } from '../../../redux/components/Engineering/LinkInformation/TechAction'
import { getFiberApi } from '../../../redux/components/Engineering/LinkInformation/FiberAction'
import CustomSnackBar from "../../utils/Snackbar";
import {getallPrimaryKey, getLinkData, getLinkingID} from "../../../redux/components/Engineering/EngineeringAction";
import { disableTabs } from "../../../redux/utils/Tabs/TabsAction";
import {
  getLinkInfoByPrimaryKey,
  getAllprimaryKeys,
  getLabelData,
  getPrimaryKey

} from "../../../redux/components/Engineering/EngineeringAction";
import { selectPrimaryKey } from "../../../redux/views/Header/HeaderAction";
import { createLinkData } from "../../../redux/components/Engineering/EngineeringAction"
import { getPDApi } from "../../../redux/components/Engineering/PD/PDAction";

const LinkInformation = (props) => {
  let fK_TechnologyID = 0;
  let fK_RegionID = 0;
  let fK_BarnID = 0;
  let fK_ProjectStatusID = 0;
  let techName = '';
  let regionName = '';
  let barnName = '';
  let projectName = '';
  let stepID = 1;
  const [ID, setID] = useState(0);
  const pdID = useSelector((state) => state.engineeringFormReducer.id);

  const [apiData, setApiData] = useState([]);
  const [loading, setLoading] = useState(true);
  const [loading1, setLoading1] = useState(true);
  const [loading2, setLoading2] = useState(true);
  const [loading3, setLoading3] = useState(true);
  const [loading4, setLoading4] = useState(true);
  const [loading5, setLoading5] = useState(true);
  const dispatch = useDispatch();
  const [isDataUpdated,setDataUpdated]=useState(false);

  const [open, setOpen] = React.useState(false);

  const [message, setMessage] = useState("");
  const handleToClose = (event, reason) => {
    if ("clickaway" == reason) return;
    setOpen(false);
  };

  const updateData = (data, dropData) => {
    let fiberCount = '';
    data[14].value.map((val) => {
      item5.map((value) => {
        if (val === value.fiberCountValue)
          fiberCount += String(val);
        return value;
      })
      fiberCount += ',';
    })
    updateApi(ID, data, dropData, fiberCount, apiData).then((res) => {
      if (res.status === 200) {
        setOpen(true);
        setMessage(`Data Updated SuccessFully!`);
        setDataUpdated(!isDataUpdated);
      }
      else{
        setOpen(true)
        setMessage(res.message);
      }
    })
  }

  const createData = (data, dropData, multiDrop) => {
    let fiberCount = '';
    multiDrop[14].value.map((val) => {
      item5.map((value) => {
        if (val === value.fiberCountValue)
          fiberCount += String(val);
        return value;
      })
      fiberCount += ',';
    })
    createApi(data, dropData, fiberCount, stepID, pdID).then(res => {
      dispatch(getLinkingID(res.id));
      if (res.id > 0) {
      {
          dispatch(getPDApi());
          dispatch(getPrimaryKey(0)).then((res)=> { res?.status!==404 && dispatch(getAllprimaryKeys(res.map((item)=>{
            return item.primaryKey;
          })))})
          dispatch(getPrimaryKey(pdID)).then((res) => {
            dispatch(getallPrimaryKey(res));
          })
          dispatch(disableTabs(false));
          setOpen(true)
          setMessage(`Data Created SuccessFully!`);
      }
        dispatch(createLinkData(res.id))
      }
      else
      {
        setOpen(true)
        setMessage(res.message);
      }
    });
  }

  const data2 = useSelector((state) => {
    return state
  })

  const datatest = useSelector((state) => state.engineeringFormReducer?.data)

  useEffect(() => {
      if(datatest?.linkingId !== undefined){dispatch(getApi(datatest?.linkingId)).then((res) => {
        if(res?.status !== 404) {
          setID(res[0]?.linkingId);
          setApiData(res[0]); 
          dispatch(selectPrimaryKey(res[0].primaryKey));
          dispatch(getLabelData(res));
        }
        setLoading(false);
      })}else{ setLoading(false);
          setApiData([])
      }
    dispatch(getBarnApi()).then((res) => setLoading1(false));
    dispatch(getRegionApi()).then((res) => setLoading2(false));
    dispatch(getTechApi()).then((res) => setLoading3(false));
    dispatch(getProjectStatusApi()).then((res) => setLoading4(false));
    dispatch(getFiberApi()).then((res) => setLoading5(false));
  }, [dispatch, datatest,isDataUpdated]);



  let item5 = data2?.FiberReducer?.data;
  const optionsID = apiData?.fiberCount?.split(",");

  let options = []
  item5?.status !== 404 && item5?.map((val) => {
    options.push(val.fiberCountValue);
    return val;
  })

  let option = []
  optionsID?.map((val) => {
    item5?.map((value) => {
      if (value.fiberCountID === parseInt(val)) {
        option.push(value.fiberCountValue);
      }
      return value;
    })
  })


  let item1 = data2?.TechReducer?.data;

  item1?.status !== 404 && item1?.map((value) => {
    let id = 0;
    if (data2?.linkInformationReducer?.data) {
      id = data2?.linkInformationReducer?.data[0]?.technologyId
    }
    if (value.id === id) {
      fK_TechnologyID = value.id
      techName = value.name
    }
  })

  let item2 = data2?.RegionReducer?.data;

  item2?.status !== 404 && item2?.map((value) => {
    let id = 0;
    if (data2?.linkInformationReducer?.data) {
      id = data2?.linkInformationReducer?.data[0]?.regionId
    }
    if (value.regionID === id) {
      fK_RegionID = value.regionID
      regionName = value.regionName
    }
  })

  let item3 = data2?.BarnReducer?.data;

  item3?.status !== 404 && item3?.map((value) => {
    let id = 0;
    if (data2?.linkInformationReducer?.data) {
      id = data2?.linkInformationReducer?.data[0]?.barnId
    }
    if (value.barnID === id) {
      fK_BarnID = value.barnId
      barnName = value.barnName
    }

  })

  let item4 = data2?.ProjectStatusReducer?.data;

  item4?.status !== 404 && item4?.map((value) => {
    let id = 0;
    if (data2?.linkInformationReducer?.data) {
      id = data2?.linkInformationReducer?.data[0]?.projectStatusId
    }
    if (value.statusID === id) {
      fK_ProjectStatusID = value.statusID
      projectName = value.name
    }

  })

  const data = [
    { required:true,placeholder: "Primary Key", defaultValue: apiData?.linkingId > 0 ? apiData.primaryKey : '' },
    { placeholder: "Link Nickname", defaultValue: apiData?.linkingId > 0 ? apiData.nickname : '' },
    { type:"year",placeholder: "Engineering Year", defaultValue: apiData?.linkingId > 0 ? apiData.engineeringYear : '' },
    { type:"year",placeholder: "Execution Year", defaultValue: apiData?.linkingId > 0 ? apiData.executionYear : '' },
    {
      type: "dropdown",
      placeholder: "Technology",
      dropDownValues: data2?.TechReducer?.data === null || data2?.TechReducer?.data?.status === 404 ? [] : data2?.TechReducer?.data,
      defaultDrop: fK_TechnologyID,
      defaultValue: apiData?.linkingId > 0 ? techName : ''
    },
    {
      type: "dropdown",
      placeholder: "Region",
      dropDownValues: data2?.RegionReducer?.data === null || data2?.TechReducer?.data?.status === 404 ? [] : data2?.RegionReducer?.data,
      defaultDrop: fK_RegionID,
      defaultValue: apiData?.linkingId > 0 ? regionName : ''
    },
    {
      type: "dropdown",
      placeholder: "Barn",
      dropDownValues: data2?.BarnReducer?.data === null || data2?.TechReducer?.data?.status === 404 ? [] : data2?.BarnReducer?.data,
      defaultDrop: fK_BarnID,
      defaultValue: apiData?.linkingId > 0 ? barnName : ''
    },
    { placeholder: "Work Order", defaultValue: apiData?.linkingId > 0 ? apiData.workOrder : '' },
    { placeholder: "Project Id", defaultValue: apiData?.linkingId > 0 ? apiData.projectId : '' },
    { placeholder: "Link Information Comments", defaultValue: apiData?.linkingId > 0 ? apiData.comments : '' },
    { placeholder: "ITN", defaultValue: apiData?.linkingId > 0 ? apiData.itn : '' },
    {
      type: "dropdown",
      placeholder: "Project Status",
      dropDownValues: data2?.ProjectStatusReducer?.data === null || data2?.TechReducer?.data?.status === 404 ? [] : data2?.ProjectStatusReducer?.data,
      defaultDrop: fK_ProjectStatusID,
      defaultValue: apiData?.linkingId > 0 ? projectName : ''
    },
    { type: "textarea", placeholder: "Link Description", defaultValue: apiData?.linkingId > 0 ? apiData.description : '' },
    { type: "textarea", placeholder: "Scope Comments", defaultValue: apiData?.linkingId > 0 ? apiData.scopeComments : '' },
    {
      type: "multiSelect",
      placeholder: "Fiber Count",
      optionValues: options,
      defaultValue: option
    },
  ];


  return (
    <>

      {!loading && !loading1 && !loading2 && !loading3 && !loading4 && !loading5 &&
        <Card
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
