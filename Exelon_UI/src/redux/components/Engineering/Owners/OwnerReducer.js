import { GET_OWNER_SUCCESS,UPDATE_OWNER_SUCCESS,CREATE_OWNER_SUCCESS } from "./OwnerAction";

const initialState = {
  data: null,
  loading:true
};

function OwnerReducer(state = initialState, action) {
  
  switch (action.type) {
    case GET_OWNER_SUCCESS:
      return (state = {
        data: action.data,
        loading:false
      });
      case UPDATE_OWNER_SUCCESS:
        return (state = {
          data: action.data,
          loading:false
        });
        case CREATE_OWNER_SUCCESS:
          return (state = {
            data: action.data,
            loading:false
          });
    default:
      return state;
  }
}

export default OwnerReducer;
