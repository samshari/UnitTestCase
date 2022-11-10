import React from "react";
import Card from "../../utils/Card";
import { useDispatch, useSelector } from "react-redux";
import { getApi, updateApi, createApi } from "../../../redux/components/Engineering/COCBidComplete/COCBidCompleteAction";
import { useState, useEffect } from "react";
import { getMkApi } from '../../../redux/components/Engineering/COCBidComplete/COCBIDMkReadyAction';
import { getFiberApi } from '../../../redux/components/Engineering/COCBidComplete/COCBIDFiberAction'
import CustomSnackBar from "../../utils/Snackbar";
import { Circles } from 'react-loader-spinner';


const COCBidComplete = (props) => {
  let mkID = 0
  let fiberId = 0
  let mkName = ''
  let fiberName = ''
  let stepID = 1;
  const [apiData, setapiData] = useState([]);
  const [loading, setLoading] = useState(true)
  const [loading1, setLoading1] = useState(true);
  const [loading2, setLoading2] = useState(true);
  const [ID, setID] = useState(0);
  const [Mk, setMk] = useState([]);
  const [Fiber, setFiber] = useState([]);
  const [isDataUpdated,setDataUpdated]=useState(false);
  let count =0;
  const dispatch = useDispatch();

  const [open, setOpen] = React.useState(false);

  const [message, setMessage] = useState("");
  const handleToClose = (event, reason) => {
    if ("clickaway" == reason) return;
    setOpen(false);
  };

  const updateData = (data, dropData) => {
    updateApi(ID, data, dropData, datatest.linkingId).then((res) => {
      if (res.status === 200) {
        setOpen(true);
        setMessage(`Data Updated SuccessFully!`);
        setDataUpdated(!isDataUpdated);
      }
      else if (res.id > 0) {
        setID(res.id);
        setOpen(true);
        setMessage(`Data Created SuccessFully!`);
      }
      else {
        setOpen(true);
        setMessage(res.message);
      }
    })
  }

  const datatest = useSelector((state) => state.engineeringFormReducer?.data)
  const datatest1 = useSelector((state) => state.engineeringFormReducer?.linkId)


  const createData = (data, dropData, multiDrop) => {
    createApi(data, dropData, datatest1, stepID).then(res => {
      if (res.id > 0) {
        setOpen(true);
        setMessage(`Data Created SuccessFully!`);
      }
      else {
        setOpen(true);
        setMessage(res.message);
      }
    });
  }



  const data2 = useSelector((state) => {
    return state
  })



  useEffect(() => {
    {
      datatest?.linkingId!==undefined ? dispatch(getApi()).then((res) => {
        res?.status !== 404 && res.map((data) => {
          if (data.fK_LinkingID === datatest.linkingId) {
            setID(data.cocBidCompleteID);
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
      }) : setLoading(false)
      setapiData([])
    }
    dispatch(getMkApi()).then((res) => {
      res?.status != 404 && setMk(res);
      setLoading1(false)
    })
    dispatch(getFiberApi()).then((res) => {
      res?.status != 404 && setFiber(res);
      setLoading2(false)
    })
  }, [dispatch, datatest?.linkingId,ID,isDataUpdated])


  let item1 = data2?.COCBIDMkReducer?.data;
  let item2 = data2?.COCBIDFiberReducer?.data;


  if (data2?.COCBIDReducer?.data && data2?.COCBIDReducer?.data.status === undefined) {
    item1?.map((value) => {
      let id = 0;
      data2?.COCBIDReducer?.data.filter((res) => {
        if (res.fK_LinkingID === datatest?.linkingId)
          id = res.fK_COCBidCompMkReadyID
      })
      if (value.id === id) {
        mkID = value.id
        mkName = value.name
      }

    })


    item2?.map((value) => {
      let id = 0;
      data2?.COCBIDReducer?.data.filter((res) => {
        if (res.fK_LinkingID === datatest?.linkingId)
          id = res.fK_COCBidCompFiberID
      })
      if (value.id === id) {
        fiberId = value.id
        fiberName = value.name
      }
    })
  }


  const data = [
    { type: "dropdown", placeholder: "COC Bid Complete Make Ready", dropDownValues: Mk, defaultValue: apiData?.cocBidCompleteID > 0 ? mkName : '', defaultDrop: mkID },
    { type: "dropdown", placeholder: "COC Bid Complete Fiber", dropDownValues: Fiber, defaultValue: apiData?.cocBidCompleteID > 0 ? fiberName : '', defaultDrop: fiberId },
  ];


  return (
    <>
      {/* <h1>RealEstate</h1> */}
      {!loading && !loading1 && !loading2 && <Card
        data={data}
        disable={props.disableFields}
        cardTitle="COC Bid Complete"
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

export default COCBidComplete;
