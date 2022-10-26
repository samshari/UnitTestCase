import { HIDE_EXECUTION_LINKS_FORM } from "./ExecutionLinksAction";

const initialState = {
  hideForm: false,
};

function hideExecutionLinksFormReducer(state = initialState, action) {
  switch (action.type) {
    case HIDE_EXECUTION_LINKS_FORM:
      return (state = {
        hideForm: action.data
      });
    default:
      return state;
  }
}

export default hideExecutionLinksFormReducer;
