import React, { useState } from "react";
import {
  Select,
  MenuItem,
  FormControl,
  InputLabel,
  TextField,
} from "@mui/material";

const DropDown = (props) => {
  const [value, setValue] = useState("");
  return (
    <>
      <FormControl size="small" style={{ marginBottom: "4px" }}>
        <InputLabel
          id="id"
          style={{
            fontSize: "12.8px",
            marginTop: "5px",
            color: "gray",
          }}
        >
          {props.placeholder}
        </InputLabel>
        <Select
          disabled={props.disable}
          class="dropdown"
          labelId="id"
        value={props.value}
          label={props.placeholder}
          style={{
            borderColor: "lightgray",
            margin: "5px",
            minWidth: "16.63rem",
            fontSize: "13px",
            borderRadius: "5px",
            height: "2.4rem",
            marginBottom:"1px"
          }}
          onChange={props.onChange}
        >
          {props.dropDownValues.map((value) => {
            return (
              <MenuItem value={value} class="MenuItem">
                {value}
              </MenuItem>
            );
          })}
        </Select>
      </FormControl>
      {value === "Other" && (
        <TextField
          type="text"
          id="outlined-basic"
          label={`${props.placeholder}` + " Other's value"}
          variant="outlined"
          style={{ margin: "4.5px", paddingBottom: "4px" }}
          size="small"
          inputProps={{ style: { fontSize: 15.5 } }} // font size of input text
          InputLabelProps={{ style: { fontSize: 13 } }} // font size of input label
        />
      )}
    </>
  );
};

export default DropDown;
