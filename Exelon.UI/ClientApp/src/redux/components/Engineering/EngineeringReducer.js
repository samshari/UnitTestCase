import { HIDE_ENGINEERING_FORM, SHOW_UPDATE_BUTTON, GET_PD_ID } from "./EngineeringAction";

const initialState = {
  id:null,
  hideForm: false,
  showUpdateButton: false,
  clearSelectedTableRow: false,
};

function engineeringFormReducer(state = initialState, action) {
  switch (action.type) {
    case HIDE_ENGINEERING_FORM:
      return (state = {
        hideForm: action.hideForm,
        showUpdateButton: false,
        clearSelectedTableRow: action.function.data
      });
    case SHOW_UPDATE_BUTTON:
      return (state = {
        hideForm: true,
        showUpdateButton: action.showUpdateButton
      });
    case GET_PD_ID:
      return (state = {
        ...state,
        id:action.data
      });
    default:
      return state;
  }
}

export default engineeringFormReducer;