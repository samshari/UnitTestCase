import { GET_PPReplace_SUCCESS,UPDATE_PPReplace_SUCCESS, CREATE_PPReplace_SUCCESS } from "./PlannedPoleReplacementAction";

const initialState = {
  data: null,
  loading : true
};

function PlannedPoleReducer(state = initialState, action) {
  
  switch (action.type) {
    case GET_PPReplace_SUCCESS:
      return (state = {
        data: action.data,
        loading : false
      });
    case UPDATE_PPReplace_SUCCESS:
        return (state = {
          data: action.data,
          loading : false
        });
    case CREATE_PPReplace_SUCCESS:
      return (state = {
        data: action.data,
        loading : false
      });
    default:
      return state;
  }
}

export default PlannedPoleReducer;