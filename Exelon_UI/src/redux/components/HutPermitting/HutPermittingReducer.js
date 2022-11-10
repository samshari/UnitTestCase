import { GET_SUBSTATE_SUCCESS,GET_HUT_SUCCESS,GET_HUT_LABEL,GET_SUB_SUCCESS,HIDE_PERMITTING_FORM,SHOW_UPDATE_BUTTON, UPDATE_HUT_SUCCESS, CREATE_HUT_SUCCESS} from "./HutPermittingAction";

const initialState = {
  hideForm: false,
  showUpdateButton:false,
  clearSelectedTableRow: false,
  data:null,
  sub:[],
  hutLabel:[],
  subState:[]
};

function hutPermittingFormReducer(state = initialState, action) {
  switch (action.type) {
    case HIDE_PERMITTING_FORM:
      return (state = {
        ...state,
        hideForm: action.hideForm,
        showUpdateButton: false,
        clearSelectedTableRow:action.function.data
      });
      case SHOW_UPDATE_BUTTON:
        return (state = {
          ...state,
          hideForm:true,
          showUpdateButton: action.showUpdateButton,
      });
      case GET_HUT_SUCCESS:
        return (state = {
          ...state,
          data: action.data,
      });
      case UPDATE_HUT_SUCCESS:
        return (state = {
          ...state,
          data: action.data,
      });
      case CREATE_HUT_SUCCESS:
        return (state = {
          ...state,
          data: action.data,
      });
      case GET_SUB_SUCCESS:
        return (state = {
          ...state,
          sub: action.data,
      });
      case GET_HUT_LABEL:
        return (state = {
          ...state,
          hutLabel: action.data,
      });
      case GET_SUBSTATE_SUCCESS:
        return (state = {
          ...state,
          subState: action.data,
      });
    default:
      return state;
  }
}

export default hutPermittingFormReducer;
