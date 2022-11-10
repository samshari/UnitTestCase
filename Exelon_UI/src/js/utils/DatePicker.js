import * as React from "react";
import "../../styles/utils/DatePicker.css";
import TextField from "@mui/material/TextField";
import { AdapterDayjs } from "@mui/x-date-pickers/AdapterDayjs";
import { LocalizationProvider } from "@mui/x-date-pickers/LocalizationProvider";
import { DatePicker } from "@mui/x-date-pickers/DatePicker";

export default function BasicDatePicker(props) {
  const [value, setValue] = React.useState(null);

  const date= new Date();
  return (
    <LocalizationProvider dateAdapter={AdapterDayjs}>
      <DatePicker style={{fontSize:'0.3rem',marginTop:'-7px'}}
        disabled={props.disable}
        label={props.placeholder}
        value={props.value?props.value:null}
        onChange={
          props.onChange
        }
        views={props.views}
        minDate={props.views && "2019"}
        maxDate={props.views && `${date.getFullYear()+10}`}

        renderInput={(params) => <TextField  {...params}  />}
      />
    </LocalizationProvider>
  );
}
