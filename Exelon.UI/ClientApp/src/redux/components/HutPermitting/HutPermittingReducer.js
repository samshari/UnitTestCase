import { HIDE_PERMITTING_FORM,SHOW_UPDATE_BUTTON} from "./HutPermittingAction";

const initialState = {
  hideForm: false,
  showUpdateButton:false,
  clearSelectedTableRow: false,
};

function hutPermittingFormReducer(state = initialState, action) {
  switch (action.type) {
    case HIDE_PERMITTING_FORM:
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

export default hutPermittingFormReducer;
