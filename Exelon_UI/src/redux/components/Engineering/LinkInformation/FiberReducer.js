import { GET_FIBER_REQUEST } from "./FiberAction";
const initialState = {
  loading : true,
  data: null,
};

function FiberReducer(state = initialState, action) {

  switch (action.type) {
    case GET_FIBER_REQUEST:
      return (state = {
        data: action.data,
        loading : false
      });
    default:
      return state;
  }
}

export default FiberReducer;
