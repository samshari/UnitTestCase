import * as React from "react";
import {
  OutlinedInput,
  InputLabel,
  MenuItem,
  FormControl,
  ListItemText,
  Select,
  Checkbox,
} from "@material-ui/core";
import '../../styles/utils/MultiSelect.css'

const ITEM_HEIGHT = 48;
const ITEM_PADDING_TOP = 8;
const MenuProps = {
  PaperProps: {
    style: {
      maxHeight: ITEM_HEIGHT * 4.5 + ITEM_PADDING_TOP,
      width: 250,
    },
  },
};

export default function MultipleSelectCheckmarks(props) {
  const [dropDownValue, setDropDownValue] = React.useState(props.defaultValue?props.defaultValue:[]);

  // const handleChange = (event) => {
  //   const {
  //     target: { value },
  //   } = event;
  //   setDropDownValue(
  //     // On autofill we get a stringified value.
  //     typeof value === "string" ? value.split(",") : value
  //   );
  // };

  return (
    <div>
      <FormControl size="small">
        <InputLabel
          id="demo-multiple-checkbox-label"
          style={{
            marginTop: "-8px",
            marginLeft: "0.8rem",
            fontSize: "0.85rem",
          }}
        >
          Select {props.placeholder}
        </InputLabel>
        <Select
          labelId="demo-multiple-checkbox-label"
          id="demo-multiple-checkbox"
          multiple
          value={props.value}
          onChange={props.onChange}
          input={<OutlinedInput label="{props.placeholder}" />}
          renderValue={(selected) => selected.join(", ")}
          MenuProps={MenuProps}
          style={{ width: "16.45rem" }}
        >
          {props.options.map((element) => (
            <MenuItem key={element} value={element} style={{ padding: "1px" }}>
              <Checkbox
                size="small"
                checked={props.value.indexOf(element) > -1}
              />
              <ListItemText primary={element} />
            </MenuItem>
          ))}
        </Select>
      </FormControl>
    </div>
  );
}
