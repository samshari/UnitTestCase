import { GET_EXLINK_SUCCESS,UPDATE_EXLINK_SUCCESS,CREATE_EXLINK_SUCCESS } from "./LinkInfromationAction";

const initialState = {
  data: null,
};

function exlinkInformationReducer(state = initialState, action) {
  switch (action.type) {
    case GET_EXLINK_SUCCESS:
      return (state = {
        data: action.data,
      });
      case UPDATE_EXLINK_SUCCESS:
        return (state = {
          data: action.data,
        });
        case CREATE_EXLINK_SUCCESS:
          return (state = {
            data: action.data,
          });
    default:
      return state;
  }
}

export default exlinkInformationReducer;
