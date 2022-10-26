import { HIDE_HUTS_FORM, SHOW_UPDATE_BUTTON } from "./HutsAction";

const initialState = {
  hideForm: false,
  showUpdateButton:false,
  clearSelectedTableRow: false,
};

function hutsFormReducer(state = initialState, action) {
  switch (action.type) {
    case HIDE_HUTS_FORM:
      return (state = {
        hideForm: action.hideForm,
        showUpdateButton: false,
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

export default hutsFormReducer;
