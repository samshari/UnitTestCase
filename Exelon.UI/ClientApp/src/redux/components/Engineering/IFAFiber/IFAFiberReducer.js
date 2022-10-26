import { GET_IFAFIBER_SUCCESS,UPDATE_IFAFIBER_SUCCESS,CREATE_IFAFIBER_SUCCESS } from "./IFAFiberActions";
const initialState = {
  data: null,
  loading :true
};

function IFAFiberReducer(state = initialState, action) {
  
  switch (action.type) {
    case GET_IFAFIBER_SUCCESS:
      return (state = {
        data: action.data,
        loading:false
      });
      case UPDATE_IFAFIBER_SUCCESS:
        return (state = {
          data: action.data,
          loading:false
        });
        case CREATE_IFAFIBER_SUCCESS:
          return (state = {
            data: action.data,
            loading:false
          });
    default:
      return state;
  }
}

export default IFAFiberReducer;
