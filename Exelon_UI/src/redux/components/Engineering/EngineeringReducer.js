import { HIDE_ENGINEERING_FORM, SHOW_UPDATE_BUTTON, GET_PD_ID, GET_PRIMARY_KEY, GET_LINK_INFO_PRIMARY_KEY, GET_LINK_DATA, CREATE_LINK_DATA } from "./EngineeringAction";

const initialState = {
  id: null,
  hideForm: false,
  showUpdateButton: false,
  clearSelectedTableRow: false,
  primaryKey: null,
  linkInfoByPrimaryKey: null,
  data: [],
  linkId:0
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
        id: action.data
      });
    case GET_PRIMARY_KEY:
      return (state = {
        ...state,
        primaryKey: action.data
      })
    case GET_LINK_INFO_PRIMARY_KEY:
      return (state = {
        ...state,
        linkInfoByPrimaryKey: action.data
      })
    case GET_LINK_DATA:
      return (state = {
        ...state,
        data: action.data
      })
    case CREATE_LINK_DATA:
      return (state = {
        ...state,
        linkId: action.data
      })
    default:
      return state;
  }
}

export default engineeringFormReducer;
