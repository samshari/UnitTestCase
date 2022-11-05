import { HIDE_ENGINEERING_FORM,GET_LINKID_SUCCESS,GET_LINK_ID ,GET_ALLPK_KEY,GET_ALLPRIMARY_KEY ,SHOW_UPDATE_BUTTON, GET_PD_ID, GET_LABEL_KEY, GET_PRIMARY_KEY, GET_LINK_INFO_PRIMARY_KEY, GET_LINK_DATA, CREATE_LINK_DATA } from "./EngineeringAction";

const initialState = {
  id: null,
  hideForm: false,
  showUpdateButton: false,
  clearSelectedTableRow: false,
  primaryKey: [],
  linkInfoByPrimaryKey: null,
  data: [],
  linkId: 0,
  labelData: [],
  allPk: [],
  linkingID:0,
  allPrimaryKey:[],
  globalLinkID:0
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
    case GET_LABEL_KEY:
      return (state = {
        ...state,
        labelData: action.data
      })
    case GET_ALLPK_KEY:
      return (state = {
        ...state,
        allPk: action.data
      })
      case GET_LINK_ID:
      return (state = {
        ...state,
        linkingID: action.data
      })
      case GET_ALLPRIMARY_KEY:
      return (state = {
        ...state,
        allPrimaryKey: action.data
      })
      case GET_LINKID_SUCCESS:
      return (state = {
        ...state,
        globalLinkID: action.data
      })
    default:
      return state;
  }
}

export default engineeringFormReducer;
