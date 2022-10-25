import React, { useState } from "react";
import "../../styles/views/Header.css";
import { useDispatch } from "react-redux";
import {
  selectPD,
} from "../../redux/views/Header/HeaderAction";

const Header = (props) => {
  const dispatch = useDispatch();
  const [selectedValue, setSelectedValue] = useState("");
  const PDValues = [
    {
      value: "1C224300 Backbone Ring 24",
      data: [
        {
          primaryKey: "BF-TSS67-TDC714",
          linkDescription: "BF-TSS67-TDC714",
          linkNickname: "1",
        },
        {
          primaryKey: "BF-TDC714-SS798",
          linkDescription: "BF-TDC714-SS798",
          linkNickname: "2",
        },
      ],
    },
    {
      value: "1C224302 - TSS30 COLUMBUS PARK",
      data: [
        {
          primaryKey: "DF-TSS30-TSS30-01",
          linkDescription: "DF-TSS30-TSS30-01",
          linkNickname: "1",
        },
        {
          primaryKey: "DF-TSS30-TSS38-01",
          linkDescription: "DF-TSS30-TSS38-01",
          linkNickname: "2",
        },
      ],
    },
    {
      value: "1C224302 - DCY310 Austin",
      data: [
        {
          primaryKey: "DF-DCY310-DCY310-01",
          linkDescription: "DF-DCY310-DCY310-01",
          linkNickname: "12",
        },
        {
          primaryKey: "DF-DCY310-DCY310-02",
          linkDescription: "DF-DCY310-DCY310-02",
          linkNickname: "13",
        },
      ],
    },
  ];
  return (
    <>
      <div class="Header">
        {props.userRole==="Admin" ?
        <div>Admin Header</div>:
        <>
        {/* <select
          class="pdDropdown"
          onChange={(value) => {
            setSelectedValue(value.target.value);
            dispatch(selectPD(value.target.value, true));
          }}
        >
          <option>--Select PD--</option>
          {PDValues.map((item) => {
            return <option>{item.value}</option>;
          })}
        </select> */}
        <div>Header</div>
        </>
        }
      </div>
    </>
  );
};

export default Header;
