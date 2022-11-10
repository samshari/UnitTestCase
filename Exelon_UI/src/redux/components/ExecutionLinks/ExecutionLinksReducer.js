import { HIDE_EXECUTION_LINKS_FORM,GET_EXLINKID_SUCCESS,GET_EXLINK_ID, GET_EXLABEL_KEY,GET_EXLINK_DATA,GET_PROJECT_ID,GET_ALL_PROJECT_ID ,GET_PROJECTID_SUCCESS, GET_LINK_INFO_PROJECT_ID,GET_ExPD_ID } from "./ExecutionLinksAction";

const initialState = {
  hideForm: false,
  projectID:[],
  allprojectId:[],
  labelData:[],
  data:[],
  linkid:0,
  globallinkID:0
};

function hideExecutionLinksFormReducer(state = initialState, action) {
  switch (action.type) {
    case HIDE_EXECUTION_LINKS_FORM:
      return (state = {
        hideForm: action.data
      });
    case GET_PROJECTID_SUCCESS:
      return (state = {
        ...state,
        primaryKey: action.data
      })
    case GET_LINK_INFO_PROJECT_ID:
      return (state = {
        ...state,
        linkInfoByPrimaryKey: action.data
      })
      case GET_ExPD_ID:
      return (state = {
        ...state,
        id: action.data
      });
      case GET_PROJECT_ID:
      return (state = {
        ...state,
        projectID: action.data
      });
      case GET_ALL_PROJECT_ID:
      return (state = {
        ...state,
        allprojectId: action.data
      });
      case GET_EXLABEL_KEY:
      return (state = {
        ...state,
        labelData: action.data
      });
      case GET_EXLINK_DATA:
      return (state = {
        ...state,
        data: action.data
      });
      case GET_EXLINK_ID:
      return (state = {
        ...state,
        linkid: action.data
      });
      case GET_EXLINKID_SUCCESS:
      return (state = {
        ...state,
        globallinkID: action.data
      });
    default:
      return state;
  }
}

export default hideExecutionLinksFormReducer;
