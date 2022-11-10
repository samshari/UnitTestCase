import React, { useEffect, useState } from "react";
import { Button, TextareaAutosize, TextField } from "@material-ui/core";
import { Select, MenuItem, FormControl, InputLabel } from "@mui/material";
import BasicDatePicker from "./DatePicker";
import "../../styles/utils/Card.css";
import { useDispatch, useSelector } from "react-redux";
import MultipleSelect from "./MultiSelect";
import DropDown from "./DropDown";
import { disableTabs } from "../../redux/utils/Tabs/TabsAction";
import Box from '@mui/material/Box';

const Card = (props) => {
  const dispatch = useDispatch();
  const [data, setData] = useState(props.data);
  const [defaultData, setDefaultData] = useState([]);
  const [defaultDrop, setDefaultDrop] = useState([]);
  const [defaultCreate, setDefaultCreate] = useState([]);
  const [defaultCreateDrop, setdefaultCreateDrop] = useState([]);
  const [defaultmultiDrop, setdefaultmultiDrop] = useState([]);
  const [blankState, setblankState] = useState(null);

  const [selectedPhase1ButtonColor, setSelectedPhase1ButtonColor] =
    useState("");
  const [selectedPhase2ButtonColor, setSelectedPhase2ButtonColor] =
    useState("burlywood");
  const [selectedPhase3ButtonColor, setSelectedPhase3ButtonColor] =
    useState("");


  const updateData = (e) =>{
      props.onClick([...defaultData],[...defaultDrop]);
  }

  const createData = (e) =>{
    props.onSubmit([...defaultCreate],[...defaultCreateDrop],[...defaultmultiDrop]);
}
   

  const selectedPrimaryKey = useSelector(
    (state) => state.headerReducer.selectedPrimaryKey

  );

  
  useEffect(() => {
    !props.phase2 && setSelectedPhase3ButtonColor("burlywood");
    setSelectedPhase1ButtonColor("burlywood");
  }, [props.phase2]);


  useEffect(() => {
    selectedPrimaryKey === null && setblankState(null)
    const testData1 = props.data.map((item) => ({ value: item.defaultValue }));
    setDefaultData(testData1);
    const testData2 = props.data.map((item) => ({ value: item.defaultDrop }));
    setDefaultDrop(testData2);
    const testData3 = props.data.map((item) => ({ value: '' }));
    setDefaultCreate(testData3);
    const testData4 = props.data.map((item) => ({ value: 0 }));
    setdefaultCreateDrop(testData4);
    const testData5 = props.data.map((item) => ({ value: [] }));
    setdefaultmultiDrop(testData5);
  }, [props.data, selectedPrimaryKey]);
  const showHutsUpdateButton = useSelector(
    (state) => state.headerReducer.selectedLocation
  );
  const showEngineeringUpdateButton = useSelector(
    (state) => state.headerReducer.selectedPrimaryKey
  );
  const showEngineeringdataUpdateButton = useSelector(
    (state) => state.engineeringFormReducer.data?.length > 0
  );
  const showExecutionLinksUpdateButton = useSelector(
    (state) => state.headerReducer.selectedProjectId
  )
  const showPermittingUpdateButton = useSelector(
    (state) => state.headerReducer.selectedSubstation
  );
  const showHutsExecutionUpdateButton = useSelector(
    (state) => state.headerReducer.selectedHutsExecutionLocation
  );
  // const handleSaveClick = () => {
  //   console.log('idlink',linkingID);
  //     linkingID===0 || linkingID === undefined?dispatch(disableTabs(true)):
  // };
  return (
    <div class="Card">
      <div class="card_inputArea">
        <div
          class="cardTitle"
          style={{
            borderBottomStyle: "solid",
            borderBottomWidth: "2px",
            borderBottomColor: `${props.disable ? "gray" : props.tabColor}`,
            width: "97.5%",
          }}
        >
          <span class="cardTitleLabel">{props.cardTitle}</span>
          <div
            class="phasesButtonContainer"
            style={{ width: !props.phase2 ? "5rem" : "12.5rem" }}
          >
            {props.phase1 && (
              <Button
                variant="outlined"
                size="small"
                onClick={() => setSelectedPhase1ButtonColor("burlywood")}
                style={{
                  borderColor: "#967bb6",
                  borderWidth: "4px",
                  borderRadius: "5px",
                  width: "6rem",
                  height: "2rem",
                  cursor: "pointer",
                  backgroundColor: `${selectedPhase1ButtonColor}`,
                  fontWeight: selectedPhase1ButtonColor && "bold",
                }}
              >
                Phase1
              </Button>
            )}
            {props.phase2 && (
              <Button
                variant="outlined"
                onClick={() => {
                  setData(props.Phase2Data);
                  setSelectedPhase2ButtonColor("burlywood");
                  setSelectedPhase3ButtonColor("");
                }}
                size="small"
                style={{
                  borderColor: "#b94e48",
                  borderWidth: "4px",
                  borderRadius: "5px",
                  width: "6rem",
                  height: "2rem",
                  cursor: "pointer",
                  backgroundColor: `${selectedPhase2ButtonColor}`,
                  fontWeight: selectedPhase2ButtonColor && "bold",
                }}
              >
                Phase2
              </Button>
            )}
            {props.phase3 && (
              <Button
                variant="outlined"
                onClick={() => {
                  setData(props.Phase3Data);
                  setSelectedPhase2ButtonColor("");
                  setSelectedPhase3ButtonColor("burlywood");
                }}
                size="small"
                style={{
                  borderColor: "#66b032",
                  borderWidth: "4px",
                  borderRadius: "5px",
                  width: "6rem",
                  height: "2rem",
                  cursor: "pointer",
                  backgroundColor: `${selectedPhase3ButtonColor}`,
                  fontWeight: selectedPhase3ButtonColor && "bold",
                }}
              >
                Phase3
              </Button>
            )}
          </div>
        </div>
        <Box sx={{display:'grid',gridTemplateColumns: 'repeat(4, 2fr)'}}>
        {data.map((item, index) => {
          console.log(item.disable);
          if (
            item.type == null ||
            item.type === "number" ||
            item.type === "checkbox"
          ) {
            return item.type === "checkbox" ? (
              <div class="checkbox">
                <input
                  disabled={props.disable}
                  type={item.type}
                  placeholder={item.placeholder}
                  min="0"
                  id={item.placeholder}
                  name={item.placeholder}
                />
                <label class="checkboxLabel" for={item.placeholder}>
                  {item.checkboxLabel}
                </label>
              </div>
            ) : 
            (
              <TextField
                type={item.type === "number" && `number`}
                disabled={props.disable || item.disable}
                required={item.required}
                id="outlined-basic"
                label={item.placeholder}
                variant="outlined"
                style={{ margin: "5px" }}
                size="small"
                inputProps={{ style: { fontSize: 13 } }} // font size of input text
                InputLabelProps={{ style: { fontSize: 13 } }} // font size of input label
                value={defaultData.length > 0 ? (showEngineeringUpdateButton || showExecutionLinksUpdateButton || showPermittingUpdateButton ? defaultData[index]?.value : defaultCreate[index]?.value) : ''}
                onChange={(value) => {
                  if (showEngineeringUpdateButton || showExecutionLinksUpdateButton || showPermittingUpdateButton)
                    setDefaultData([...defaultData], (defaultData[index].value = value.target.value));
                  else
                    setDefaultCreate([...defaultCreate], (defaultCreate[index].value = value.target.value));
                }}
              />
            );
          } else if (item.type === "dropdown") {
            return (
              <FormControl size="small">
                <InputLabel
                  id="id"
                  style={{
                    fontSize: "12.8px",
                    color: "gray",
                  }}
                >
                  {item.placeholder}
                </InputLabel>
                <Select
                  disabled={props.disable}
                  required={item.required}
                  class="dropdown"
                  labelId="id"
                  label={item.placeholder}
                  style={{
                    borderColor: "lightgray",
                    margin: "5px",
                    minWidth: "16.63rem",
                    fontSize: "13px",
                    borderRadius: "5px",
                    height: "2.4rem",
                  }}
                  value = {defaultData.length>0? (showEngineeringUpdateButton || showExecutionLinksUpdateButton || showPermittingUpdateButton ?(defaultData[index]?.value !== undefined ?defaultData[index]?.value:''):(defaultCreate[index]?.value !== undefined ?defaultCreate[index]?.value:'')):''}
                  onChange ={(value)=>{
                    if(showEngineeringUpdateButton || showExecutionLinksUpdateButton || showPermittingUpdateButton){
                      setDefaultData([...defaultData], (defaultData[index].value = value.target.value ));
                    let id;
                    item.dropDownValues.map((values)=>{
                      if(values.name === value.target.value || values.regionName === value.target.value || values.barnName === value.target.value ){
                        if(item.placeholder === "PM")
                          id = values.pmid
                        else if(item.placeholder === "Region")
                          id = values.regionID
                        else if(item.placeholder === "Barn")
                          id = values.barnID
                        else if(item.placeholder === "Project Status")
                          id = values.statusID
                        else if(item.placeholder === "Eng Investigation/ innerduct coc")
                          id = values.innerductCOCID;
                        else if(item.placeholder === "OVHD COC" || item.placeholder === "Fiber COC" || item.placeholder === "Civil COC" || item.placeholder === "Boring COC")
                          id = values.cocid
                        else
                          id = values.id

                        }
                      })
                      setDefaultDrop([...defaultDrop], (defaultDrop[index].value = id));
                    }
                    else{
                      setDefaultCreate([...defaultCreate], (defaultCreate[index].value = value.target.value ));
                        let id;
                        item.dropDownValues.map((values)=>{
                          if(values.name === value.target.value || values.regionName === value.target.value || values.barnName === value.target.value ){
                            if(item.placeholder === "PM")
                              id = values.pmid
                            else if(item.placeholder === "Region")
                              id = values.regionID
                            else if(item.placeholder === "Barn")
                              id = values.barnID
                            else if(item.placeholder === "Project Status")
                              id = values.statusID
                            else if(item.placeholder === "Eng Investigation/ innerduct coc")
                              id = values.innerductCOCID;
                            else if(item.placeholder === "OVHD COC" || item.placeholder === "Fiber COC" || item.placeholder === "Civil COC" || item.placeholder === "Boring COC")
                              id = values.cocid
                            else
                              id = values.id

                        }
                      })
                      setDefaultDrop([...defaultCreateDrop], (defaultCreateDrop[index].value = id));
                    }

                  }}
                >
                  {item?.dropDownValues?.map((value) => {
                    return (
                      <MenuItem value={
                        item.placeholder === "Barn" ? value.barnName : (item.placeholder === "Region" ? value.regionName : value.name)
                      } class="MenuItem">
                        {item.placeholder === "Barn" ? value.barnName : (item.placeholder === "Region" ? value.regionName : value.name)}
                      </MenuItem>
                    );
                  })}
                </Select>
              </FormControl>
            );
          } else if (item.type === "date") {
            return (
              <div style={{ margin: "5px" }}>
                <BasicDatePicker
                  disable={props.disable}
                  placeholder={item.placeholder}
                  style={{ padding: "3rem" }}
                  value={defaultData.length > 0 ? (showEngineeringUpdateButton || showExecutionLinksUpdateButton || showPermittingUpdateButton ? defaultData[index]?.value : defaultCreate[index]?.value) : blankState}
                  onChange={(value) => {

                    if (showEngineeringUpdateButton || showExecutionLinksUpdateButton || showPermittingUpdateButton) {
                      setDefaultData([...defaultData], defaultData[index].value = value!==null?`${value.$d.getMonth() + 1
                      }/${value.$d.getDate()}/${value.$d.getFullYear()}`:'');
                    }
                    else {
                      setDefaultCreate([...defaultCreate], defaultCreate[index].value = value!==null?`${value.$d.getMonth() + 1
                      }/${value.$d.getDate()}/${value.$d.getFullYear()}`:'');
                    }
                  }
                  }
                />
              </div>
            );
          } else if (item.type === "YNOdropdown") {
            return (
              <DropDown
                placeholder={item.placeholder}
                dropDownValues={item.dropDownValues}
                value={showPermittingUpdateButton? item.defaultValue:''}
              />
            );
          } else if (item.type === "multiSelect") {
            return (
              <div class="multiSelect">
                <MultipleSelect
                  disable={props.disable}
                  placeholder={item.placeholder}
                  options={item.optionValues}
                  value={defaultData.length > 0 ? (showEngineeringUpdateButton || showExecutionLinksUpdateButton || showPermittingUpdateButton ? defaultData[index]?.value : defaultmultiDrop[index].value) : []}
                  onChange={(event) => {
                    if (showEngineeringUpdateButton || showExecutionLinksUpdateButton || showPermittingUpdateButton) {
                      const {
                        target: { value },
                      } = event;

                      setDefaultData([...defaultData], (defaultData[index].value = typeof value === "string" ? value.split(",") : value));
                    }
                    else {
                      const {
                        target: { value },
                      } = event;

                      setdefaultmultiDrop([...defaultmultiDrop], (defaultmultiDrop[index].value = typeof value === "string" ? value.split(",") : value));
                    }
                  }}
                />
              </div>
            );
          } else if (item.type === "button") {
            return (
              <Button variant="contained" class="Button centeredButton">
                Submit
              </Button>
            );
          } 
          else if (item.type==="year"){

            return(
              <div style={{margin:'5px'}} class="year">
              <BasicDatePicker
                  disable={props.disable}
                  placeholder={item.placeholder}

                  views={['year']}

                  style={{ padding: "3rem" }}

                  value={defaultData.length > 0 ? (showEngineeringUpdateButton || showExecutionLinksUpdateButton || showPermittingUpdateButton ? defaultData[index]?.value : defaultCreate[index]?.value) : blankState}

                  onChange={(value) => {



                    if (showEngineeringUpdateButton || showExecutionLinksUpdateButton || showPermittingUpdateButton) {

                      setDefaultData([...defaultData], defaultData[index].value = value!==null? `${value.$d.getMonth() + 1

                      }/${value.$d.getDate()}/${value.$d.getFullYear()}`:'');

                    }

                    else {

                      setDefaultCreate([...defaultCreate], defaultCreate[index].value = value!==null?`${value.$d.getMonth() + 1

                      }/${value.$d.getDate()}/${value.$d.getFullYear()}`:'');

                    }

                  }

                  }

                />
                </div>

            )

          }
          else {
            return (
              // <TextField
              //   id="outlined-basic"
              //   variant="outlined"
              //   multiline
              //   size="small"
              //   minRows={2}
              //   placeholder={item.placeholder}
              //   style={{
              //     width: 240,
              //     borderRadius: "5px",
              //     marginTop: "0.35rem",
              //     margin: "8px 5px 18px 5px",
              //     fontFamily: "sans-serif",
              //     fontSize: "0.85rem",
                  
              //   }}
              //   disabled={props.disable}
              //   value={defaultData.length > 0 ? (showEngineeringUpdateButton || showExecutionLinksUpdateButton || showPermittingUpdateButton ? defaultData[index]?.value : defaultCreate[index].value) : ''}
              //   onChange={(value) => {
              //     if (showEngineeringUpdateButton || showExecutionLinksUpdateButton || showPermittingUpdateButton)
              //       setDefaultData([...defaultData], (defaultData[index].value = value.target.value));
              //     else
              //       setDefaultCreate([...defaultCreate], (defaultCreate[index].value = value.target.value));
              //   }}
              // ></TextField>
              <div class="Textarea">
              <TextField

              id="outlined-basic"
              variant="outlined"

              multiline

              size="small"
              minRows={2}

                label={item.placeholder}

                style={{

                  width: 265,

                  height: "0px",

                  borderRadius: "5px",

                  marginTop: "0.35rem",

                  margin: "8px 5px 18px 5px",

                  border:"0",

                  fontFamily: "sans-serif",

                  fontSize: "13px",

                }}

                disabled={props.disable}
                value={defaultData.length > 0 ? (showEngineeringUpdateButton || showExecutionLinksUpdateButton || showPermittingUpdateButton ? defaultData[index]?.value : defaultCreate[index].value) : ''}
                onChange={(value) => {
                  if (showEngineeringUpdateButton || showExecutionLinksUpdateButton || showPermittingUpdateButton)
                    setDefaultData([...defaultData], (defaultData[index].value = value.target.value));
                  else
                    setDefaultCreate([...defaultCreate], (defaultCreate[index].value = value.target.value));
                }}

              ></TextField>
              </div>
            );
          }
        })}
        </Box>
      </div>
      <div class="buttonsContainer">
        { (showEngineeringUpdateButton) ||
          showExecutionLinksUpdateButton ||
          showPermittingUpdateButton ||
          showHutsUpdateButton ||
          showHutsExecutionUpdateButton ? (
          <Button variant="contained" class="Button" onClick={updateData} >
            Update
          </Button>
        ) : (
          <Button
            variant="contained"
            class="Button"
              style={{backgroundColor:props.disable?"gray": "#922c88",
              border: props.disable?"1px solid gray":"1px solid #922c88"
            }}
            onClick={() => {
              createData();
            }}
            disabled={props.disable}
          >
            Save
          </Button>
        )}
      </div>
    </div>
  );
};

export default Card;
