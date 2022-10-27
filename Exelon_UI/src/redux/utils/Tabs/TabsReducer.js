import { DISABLE_TABS } from "./TabsAction";

const initialState = {
  disableTabs:true
};

function TabsReducer(state = initialState, action) {
  switch (action.type) {
    case DISABLE_TABS:
      return (state = {
        disableTabs:action.data
      });
    default:
      return state;
  }
}

export default TabsReducer;
