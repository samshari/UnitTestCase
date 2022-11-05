import * as React from "react";
import "../../styles/utils/DatePicker.css";
import TextField from "@mui/material/TextField";
import { AdapterDayjs } from "@mui/x-date-pickers/AdapterDayjs";
import { LocalizationProvider } from "@mui/x-date-pickers/LocalizationProvider";
import { DatePicker } from "@mui/x-date-pickers/DatePicker";

export default function BasicDatePicker(props) {
  const [value, setValue] = React.useState(null);

  return (
    <LocalizationProvider dateAdapter={AdapterDayjs}>
      <DatePicker
        disabled={props.disable}
        label={props.placeholder}
        value={props.value?props.value:null}
        onChange={
          props.onChange
        }
        renderInput={(params) => <TextField {...params} />}
      />
    </LocalizationProvider>
  );
}
