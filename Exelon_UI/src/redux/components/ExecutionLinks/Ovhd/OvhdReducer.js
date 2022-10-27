import { GET_OVHD_SUCCESS,UPDATE_OVHD_SUCCESS,CREATE_OVHD_SUCCESS } from "./OvhdAction";
const initialState = {
  data: null,
  loading:true
};

function OVHDReducer(state = initialState, action) {
  
  switch (action.type) {
    case GET_OVHD_SUCCESS:
      return (state = {
        data: action.data,
        loading:false
      });
      case UPDATE_OVHD_SUCCESS:
        return (state = {
          data: action.data,
          loading:false
        });
        case CREATE_OVHD_SUCCESS:
          return (state = {
            data: action.data,
            loading:false
          });
    default:
      return state;
  }
}

export default OVHDReducer;
