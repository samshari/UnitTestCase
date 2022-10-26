import React, { useEffect, useState } from "react";
import { useSelector } from "react-redux";
import { Tab, Tabs, TabList, TabPanel } from "react-tabs";

import "react-tabs/style/react-tabs.css";
import "../../styles/utils/Tabs.css";

const CustomTabs = (props) => {
  const disableTabs = useSelector((state) => state.TabsReducer.disableTabs);
  const undisableTabs = useSelector(
    (state) => state.headerReducer.selectedPrimaryKey || 
    state.headerReducer.selectedProjectId
  );
  const [tabBorderColor, setTabBorderColor] = useState("lightgray");
  const [notFirstTimeUser, setFirstTimeUser] = useState(true);
  useEffect(() => {
    props.data.map((item) => {
      return setTabBorderColor(item.tabColor);
    });
    undisableTabs!==null && setFirstTimeUser(false);
    undisableTabs===null && setFirstTimeUser(true)
  }, [props.disable, props.data, undisableTabs]);
  return (
    <div class="Scrolbar">
      <Tabs defaultIndex={props.moveToTab}>
        <TabList>
          {props.data.map((item) => {
            return (
              <Tab
                disabled={(disableTabs && item.disable) && notFirstTimeUser}
                style={{
                  borderColor:
                    (disableTabs && item.disable) && notFirstTimeUser
                      ? "lightgray"
                      : `${item.tabColor}`,
                }}
              >
                {item.tabName}
              </Tab>
            );
          })}
        </TabList>
        {props.data.map((item) => {
          return <TabPanel>{item.component}</TabPanel>;
        })}
      </Tabs>
    </div>
  );
};

export default CustomTabs;
