import { GET_COMPLETEDPOLES_SUCCESS,UPDATE_COMPLETEDPOLES_SUCCESS,CREATE_COMPLETEDPOLES_SUCCESS } from "./CompletedPolesAction";
const initialState = {
  data: null,
  loading:true
};

function COMPLETEDPOLESReducer(state = initialState, action) {
  
  switch (action.type) {
    case GET_COMPLETEDPOLES_SUCCESS:
      return (state = {
        data: action.data,
        loading:false
      });
      case UPDATE_COMPLETEDPOLES_SUCCESS:
        return (state = {
          data: action.data,
          loading:false
        });
        case CREATE_COMPLETEDPOLES_SUCCESS:
          return (state = {
            data: action.data,
            loading:false
          });
    default:
      return state;
  }
}

export default COMPLETEDPOLESReducer;