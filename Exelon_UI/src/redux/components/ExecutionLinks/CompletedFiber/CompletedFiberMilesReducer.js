import { GET_COMPLETEDFIBERMILES_SUCCESS,UPDATE_COMPLETEDFIBERMILES_SUCCESS,CREATE_COMPLETEDFIBERMILES_SUCCESS } from "./CompletedFiberMilesAction";
const initialState = {
  data: null,
  loading:true
};

function COMPLETEDFIBERMILESReducer(state = initialState, action) {
  
  switch (action.type) {
    case GET_COMPLETEDFIBERMILES_SUCCESS:
      return (state = {
        data: action.data,
        loading:false
      });
      case UPDATE_COMPLETEDFIBERMILES_SUCCESS:
        return (state = {
          data: action.data,
          loading:false
        });
        case CREATE_COMPLETEDFIBERMILES_SUCCESS:
          return (state = {
            data: action.data,
            loading:false
          });
    default:
      return state;
  }
}

export default COMPLETEDFIBERMILESReducer;


