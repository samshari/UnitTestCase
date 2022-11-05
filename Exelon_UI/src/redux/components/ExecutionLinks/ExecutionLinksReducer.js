import { HIDE_EXECUTION_LINKS_FORM, GET_PROJECTID_SUCCESS, GET_LINK_INFO_PROJECT_ID,GET_ExPD_ID } from "./ExecutionLinksAction";

const initialState = {
  hideForm: false,
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
    default:
      return state;
  }
}

export default hideExecutionLinksFormReducer;
