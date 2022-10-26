import { HIDE_HUTS_EXECUTION_FORM, SHOW_UPDATE_BUTTON } from "./HutsExecutionAction";

const initialState = {
  hideForm: false,
  showUpdateButton:false,
  clearSelectedTableRow: false,
};

function hutsExecutionFormReducer(state = initialState, action) {
  switch (action.type) {
    case HIDE_HUTS_EXECUTION_FORM:
      return (state = {
        hideForm: action.hideForm,
        showUpdateButton:false,
        clearSelectedTableRow:action.function.data
      });
      case SHOW_UPDATE_BUTTON:
        return (state = {
          hideForm:true,
          showUpdateButton: action.showUpdateButton,
      });
    default:
      return state;
  }
}

export default hutsExecutionFormReducer;
