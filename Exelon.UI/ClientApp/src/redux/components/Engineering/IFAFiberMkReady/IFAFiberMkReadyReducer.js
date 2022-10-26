import { GET_IFAMAKE_SUCCESS,UPDATE_IFAMAKE_SUCCESS,CREATE_IFAMAKE_SUCCESS } from "./IFAFiberMkReadyAction";
const initialState = {
  data: null,
  loading:true
};

function IFAMakeReadyReducer(state = initialState, action) {
  
  switch (action.type) {
    case GET_IFAMAKE_SUCCESS:
      return (state = {
        data: action.data,
        loading: false
      });
      case UPDATE_IFAMAKE_SUCCESS:
        return (state = {
          data: action.data,
          loading: false
        });
        case CREATE_IFAMAKE_SUCCESS:
            return (state = {
              data: action.data,
              loading: false
            });
    default:
      return state;
  }
}

export default IFAMakeReadyReducer;
