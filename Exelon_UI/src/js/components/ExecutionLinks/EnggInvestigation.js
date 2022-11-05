import React from "react";
import Card from "../../utils/Card";
import { useEffect,useState } from "react";
import { useDispatch , useSelector} from "react-redux";
import { getApi,updateApi,createApi } from "../../../redux/components/ExecutionLinks/Engginvestigation/EngginvestigationAction";
import {getInnerApi} from '../../../redux/components/ExecutionLinks/Engginvestigation/InnerDuctCOCAction'


const EnggInvestigation = (props) => {
  let id =3;
  let fK_InnerductCOC =0;
  let innerName = '';
  const [apiData,setapiData]=useState([]);  
  const [loading,setLoading]=useState(true) 
  const [loading1,setLoading1]=useState(true);
  const [ID,setID]= useState(0);

  const datatest = useSelector((state) => state.hideExecutionLinksFormReducer?.data);
  const data2 = useSelector((state)=>{
    return state
  })

  const dispatch = useDispatch();
  const updateData=(data,dropData)=>{
    updateApi(ID,data,dropData,apiData).then((res)=>{
      if(res.status === 200)
        alert(`Data Updated SuccessFully!`);
      else 
        alert(res.message);
      })
  }

  const createData=(data,dropData,multiDrop)=>{
    createApi(data,dropData,id).then((res)=>{
      if(res.id>0)
        alert(`Data Created SuccessFully!`);
      else 
        alert(res.message);
    })
  }


useEffect(()=>{
  
  if(datatest?.executionLinkingID!==undefined){
  dispatch(getApi()).then((res)=>{
    res?.status !== 404 && res.map((data)=>{
      if(data.fK_LinkingID === datatest?.executionLinkingID){
        setID(data.enggInvestigationID);
        setapiData(data);
      }
      return data;
    })
    setLoading(false)
  })}
  else{
    setLoading(false);
    setapiData([]);
  }
  dispatch(getInnerApi()).then((res)=>setLoading1(false))
},[dispatch])

let item = data2?.InnerDuctCOCReducer?.data;

console.log('item',data2?.EnggInvestReducer?.data);
item?.map((value)=>{
  let inner_id = 0; 
  if(data2?.EnggInvestReducer?.data ){
    data2?.EnggInvestReducer?.data?.filter((res)=>{
      if(res.fK_LinkingID === id)
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
    </>
  );
};

export default EnggInvestigation;
