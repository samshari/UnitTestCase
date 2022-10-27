import { GET_IFCMAKE_SUCCESS,UPDATE_IFCMAKE_SUCCESS,CREATE_IFCMAKE_SUCCESS } from "./IFCMakeReadyAction";
const initialState = {
  data: null,
  loading:true
};

function IFCMakeReadyReducer(state = initialState, action) {
  
  switch (action.type) {
    case GET_IFCMAKE_SUCCESS:
      return (state = {
        data: action.data,
        loading: false
      });
      case UPDATE_IFCMAKE_SUCCESS:
        return (state = {
          data: action.data,
          loading: false
        });
        case CREATE_IFCMAKE_SUCCESS:
            return (state = {
              data: action.data,
              loading: false
            });
    default:
      return state;
  }
}

export default IFCMakeReadyReducer;
