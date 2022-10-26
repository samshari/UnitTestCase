import { GET_FIBER_SUCCESS,UPDATE_FIBER_SUCCESS,CREATE_FIBER_SUCCESS } from "./FiberAction";

const initialState = {
  data: null,
  loading:true
};

function FiberReducer(state = initialState, action) {
  
  switch (action.type) {
    case GET_FIBER_SUCCESS:
      return (state = {
        data: action.data,
        loading:false
      });
      case UPDATE_FIBER_SUCCESS:
        return (state = {
          data: action.data,
          loading:false
        });
        case CREATE_FIBER_SUCCESS:
          return (state = {
            data: action.data,
            loading:false
          });
    default:
      return state;
  }
}

export default FiberReducer;
