import { SELECT_NAVBAR_ITEM } from "./NavbarAction";

const initialState = {
  selectedItem: 1,
};

function selectNavbarReducer(state = initialState, action) {
  switch (action.type) {
    case SELECT_NAVBAR_ITEM:
      return (state = {
        selectedItem: action.data,
      });
    default:
      return state;
  }
}

export default selectNavbarReducer;
