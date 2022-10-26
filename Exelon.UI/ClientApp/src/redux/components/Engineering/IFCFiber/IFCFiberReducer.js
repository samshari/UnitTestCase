import { GET_IFCFIBER_SUCCESS,UPDATE_IFCFIBER_SUCCESS,CREATE_IFCFIBER_SUCCESS } from "./IFCFiberActions";

const initialState = {
  data: null,
  loading :true
};

function IFCFiberReducer(state = initialState, action) {
  
  switch (action.type) {
    case GET_IFCFIBER_SUCCESS:
      return (state = {
        data: action.data,
        loading:false
      });
      case UPDATE_IFCFIBER_SUCCESS:
        return (state = {
          data: action.data,
          loading:false
        });
        case CREATE_IFCFIBER_SUCCESS:
          return (state = {
            data: action.data,
            loading:false
          });
    default:
      return state;
  }
}

export default IFCFiberReducer;
