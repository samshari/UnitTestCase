import React, { useEffect, useState } from "react";
import { useDispatch } from "react-redux";
import { getEOCApi } from "../../../redux/components/Engineering/RealEstate/EOCAction";
import { getApi,updateApi,createApi, getsubStation, gethutPermitLabelData, getallDataBysubstation } from "../../../redux/components/HutPermitting/HutPermittingAction";
import Card from "../../utils/Card";
import { useSelector } from "react-redux";
import { getSizeApi } from "../../../redux/components/HutPermitting/Size/SizeAction";
import { FaCreativeCommonsPd } from "react-icons/fa";
import CustomSnackBar from "../../utils/Snackbar";
import {selectSubstation} from "../../../redux/views/Header/HeaderAction"

const YNOval = [
  { "id": 1, "name": "Yes" },
  { "id": 2, "name": "No" }
]

const Form = (props) => {
  const [apiData,setapiData]=useState([]);
  const [loading,setLoading]=useState(true);
  const [loading1,setLoading1]=useState(true);
  const [loading2,setLoading2]=useState(true);
  const [ID,setID]=useState(0);
  const [isDataUpdated,setDataUpdated]=useState(true);
  let fK_EOCID=0;
  let eocName = '';
  let fK_SizeID = 0;
  let sizeName = '';
  const dispatch = useDispatch();
  const data2 = useSelector((state)=>{
    return state
  })
  const [open, setOpen] = React.useState(false);
  const [message, setMessage] = useState("");
  const handleToClose = (event, reason) => {
    if ("clickaway" == reason) return;
    setOpen(false);
  };
  
  const substation = data2.headerReducer;
  const updateData=(data,dropData)=>{
    updateApi(ID,data,dropData).then((res)=>{
      if (res.status === 200){
        dispatch(selectSubstation(data[0].value));
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
    createApi(data,dropData).then((res)=>{
      if (res.id > 0){
        setID(res.id);
        setOpen(true)
        setMessage(`Data Created SuccessFully!`);
        dispatch(getApi()).then((res)=>{
          if(res.status!== 404) {
            dispatch(getsubStation(res.map((data)=>{
              return data.substation
          }))) 
        }})
      }
      else{
      setOpen(true)
      setMessage(res.message);
      }
    })
  }
  useEffect(()=>{
    if(substation?.selectedSubstation!==undefined){
      dispatch(getApi()).then((res)=>{
      if(res.status!==404){
        res.map((data)=>{
          if(data.substation===substation?.selectedSubstation){
            dispatch(getallDataBysubstation(data.substation)).then((res)=>{
              dispatch(gethutPermitLabelData(res));
            });
            setID(data.hutPermittingID);
            setapiData(data);
          }
        })
      }
      else{
        setapiData([]);
      }
      setLoading(false);
    })
  }
  else{
    setapiData([]);
    setID(0);
  }
    dispatch(getEOCApi()).then((res)=>setLoading1(false));
    dispatch(getSizeApi()).then((res)=>setLoading2(false));
  },[dispatch,substation?.selectedSubstation,isDataUpdated]);


  let item1 = data2?.EOCReducer?.data;
  item1?.status !==404 && item1?.map((value)=>{
    let id = 0; 
    if(data2?.hutPermittingFormReducer?.data && data2?.hutPermittingFormReducer?.data?.status!=404   ){
      data2?.hutPermittingFormReducer?.data?.filter((res)=>{
        if(res.substation === substation?.selectedSubstation)
          id = res.fK_EOCID;
      })
    }
    if(value.id === id){
      fK_EOCID = value.id
      eocName = value.name
    }
  
  })

  let item2 = data2?.SizeReducer?.data;
  item2?.status !==404 && item2?.map((value)=>{
    let id = 0; 
    if(data2?.hutPermittingFormReducer?.data && data2?.hutPermittingFormReducer?.data?.status!=404   ){
      data2?.hutPermittingFormReducer?.data?.filter((res)=>{
        if(res.substation === substation?.selectedSubstation)
          id = res.fK_SizeID;
      })
    }
    if(value.id === id){
      fK_SizeID = value.id
      sizeName = value.name
    }
  
  })

  const data = [
    { placeholder: "Substation",defaultValue:apiData?.hutPermittingID>0? apiData?.substation:''},
    {
      type: "dropdown",
      placeholder: "EOC",
      dropDownValues:data2?.EOCReducer?.data === null || data2?.EOCReducer?.data?.status === 404 ? []:data2?.EOCReducer?.data,
       defaultValue :apiData?.hutPermittingID>0?eocName:'', 
      defaultDrop: fK_EOCID
    },
    { type:"year", placeholder: "Install Year" ,defaultValue:apiData?.hutPermittingID>0?apiData?.installYear:''},
    {
      type: "dropdown",
      placeholder: "Size",
      dropDownValues: data2?.SizeReducer?.data === null || data2?.SizeReducer?.data.status === 404 ? []:data2?.SizeReducer?.data,
      defaultValue:apiData?.hutPermittingID>0?sizeName:'',
      defaultDrop:fK_SizeID
    },
    {
      placeholder: "Municipality",
      defaultValue:apiData?.hutPermittingID>0?apiData?.location_Municipality:'',
      
    },
    {
      placeholder: "County",
      defaultValue:apiData?.hutPermittingID>0?apiData?.location_County:'',
    },
    // {
    //   type: "radiobutton",
    //   fields: [
    //     {id:0,val:"County Stormwater Permit or MWRD Required?"},
    //     {id:1,val:"Army Corps Permit Required?"},
    //     {id:2,val:"TROW Permit Required?"},
    //     {id:3,val:"Site Development Permit Required?"},
    //     {id:4,val:"Hwy/IDOT Permit"}
    //   ]
    // },
    {
      type: "dropdown",
      placeholder: "County Stormwater Permit Required?",
      dropDownValues: YNOval,
      defaultValue:apiData?.hutPermittingID>0?YNOval[apiData.fK_RequiredCountyStormwater-1]?.name:'',
      defaultDrop:apiData.fK_RequiredCountyStormwater
    },
    {
      type: "dropdown",
      placeholder: "Army Corps Permit Required?",
      dropDownValues: YNOval,
      defaultValue:apiData?.hutPermittingID>0?YNOval[apiData.fK_ArmyCorpsPermitRequired-1]?.name:'',
      defaultDrop:apiData.fK_ArmyCorpsPermitRequired
    },
    {
      type: "dropdown",
      placeholder: "TROW Permit Required?",
      dropDownValues: YNOval,
      defaultValue:apiData?.hutPermittingID>0?YNOval[apiData.fK_TROWPermitRequired-1]?.name:'',
      defaultDrop:apiData?.fK_TROWPermitRequired
    },
    {
      type: "dropdown",
      placeholder: "Site Development Permit Required?",
      dropDownValues: YNOval,
      defaultValue:apiData?.hutPermittingID>0?YNOval[apiData.fK_SiteDevelopmentPermitRequired-1]?.name:'',
      defaultDrop:apiData?.fK_SiteDevelopmentPermitRequired
    },
    {
      type: "dropdown",
      placeholder: "Hwy/IDOT Permit",
      dropDownValues: YNOval,
      defaultValue:apiData?.hutPermittingID>0?YNOval[apiData.fK_HwyOrIDOTPermit-1]?.name:'',
      defaultDrop:apiData?.fK_HwyOrIDOTPermit
    },
    {
      type: "dropdown",
      placeholder: "Building Permit Required",
      dropDownValues: YNOval,
      defaultValue:apiData?.hutPermittingID>0?YNOval[apiData.fK_BuildingOrOtherPermitRequired-1]?.name:'',
      defaultDrop:apiData?.fK_BuildingOrOtherPermitRequired
    },
    { type:"date",placeholder: "Civil IFA Date",defaultValue:apiData?.hutPermittingID>0?apiData?.strCivilIFADate:'' },
    { type:"date",placeholder: "Civil IFC Date",defaultValue:apiData?.hutPermittingID>0?apiData?.strCivilIFCDate:'' },

    { type: "date", placeholder: "Permit Submission Date",defaultValue:apiData?.hutPermittingID>0?apiData?.strPermitSubmissionDate:'' },

    { type:"date", placeholder: " Permit Ready Date",defaultValue:apiData?.hutPermittingID>0?apiData?.strPermitReadyDate:''},
    {
      placeholder:
        "Permit Expiration",
        defaultValue:apiData?.hutPermittingID>0?apiData?.permitExpiration:''
    },
    // {
    //   type: "textarea",
    //   placeholder: "Permit Processing Duration/Including Comments",
    //   defaultValue:''
    // },
    { placeholder: "Status",defaultValue:apiData?.hutPermittingID>0?apiData?.status:''},
    { type: "textarea", placeholder: "Notes",defaultValue:apiData?.hutPermittingID>0?apiData?.notes:''  },
  ];
  return (
    <>
    {  
    !loading && !loading1 && !loading2 && <Card
      data={data}
      moveToTab={props.moveToTab}
      disable={props.disableFields}
      cardTitle="Hut Permitting"
      tabColor="green"
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

export default Form;
