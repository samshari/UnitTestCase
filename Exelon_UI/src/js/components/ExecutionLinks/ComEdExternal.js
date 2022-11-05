import React from "react";
import Card from "../../utils/Card";
import { useState, useEffect } from 'react'
import { useDispatch, useSelector } from "react-redux";
import { getApi, getLnLApi, createApi, updateApi, getComEdIdByLinkingIdApi } from '../../../redux/components/ExecutionLinks/ComEdExternal/ComEdExternalAction'
import { Circles } from 'react-loader-spinner'

const ComEdExternal = (props) => {
  const [loading, setLoading] = useState(true);
  const [apiData, setapiData] = useState([]);
  const [lnlNm, setlnlName] = useState('');
  const [lnlPKId, setlnlPKId] = useState('');
  const [comEdId, setComEdId] = useState('');
  var model = {
    ComEdId: '',
    LNLId: '',
    LinkingId: ''
  }
  const dispatch = useDispatch();
  let linkingId = 3;
  useEffect(() => {
    dispatch(getLnLApi()).then((res) => {
      setLoading(false);
    });
    dispatch(getComEdIdByLinkingIdApi(linkingId)).then((comEdId) => {
      if (comEdId !== undefined) {
        dispatch(getApi(comEdId)).then((res) => {
          if (res.status !== 404) {
            setlnlName(res[0].name);
            setlnlPKId(res[0].lnlId);
            setapiData(res[0]);
          }
          setComEdId(comEdId);
        });
      }
    })
  }, [dispatch])
  const updateData = (data, dropData) => {
    model.LNLId = lnlPKId;
    model.LinkingId = linkingId;
    model.ComEdId = comEdId;
    updateApi(comEdId, dropData, model).then((res) => {
      if (res.status === 200)
        alert(`Data Updated SuccessFully!`);
      else
        alert(res.message);
    })
  }
  const createData = (data, dropData) => {
    createApi(data, dropData, linkingId).then(res => {
      if (res.id > 0)
        alert(`Data Created SuccessFully!`);
      else
        alert(res.message);
    });
  }

  const LnlReducer = useSelector((state) => {
    return state;
  })

  const data = [
    { type: "dropdown", placeholder: "LNL/Labor for OH make ready", dropDownValues: LnlReducer?.ComEdReducer?.data?.result, defaultDrop: lnlPKId, defaultValue: lnlNm },
  ];

  return (
    <>
      {!loading && <Card
        data={data}
        disable={props.disableFields}
        cardTitle="ComEd/External"
        tabColor={props.tabColor}
        onSubmit={createData}
        onClick={updateData}
      />}
    </>
  );
};

export default ComEdExternal;
