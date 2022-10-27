import { GET_LINK_SUCCESS,UPDATE_LINK_SUCCESS,CREATE_LINK_SUCCESS } from "./LinkInformationAction";

const initialState = {
  data: null,
};

function linkInformationReducer(state = initialState, action) {
  switch (action.type) {
    case GET_LINK_SUCCESS:
      return (state = {
        data: action.data,
      });
      case UPDATE_LINK_SUCCESS:
        return (state = {
          data: action.data,
        });
        case CREATE_LINK_SUCCESS:
          return (state = {
            data: action.data,
          });
    default:
      return state;
  }
}

export default linkInformationReducer;
