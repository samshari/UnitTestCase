import { GET_INNERDUCT_SUCCESS,UPDATE_INNERDUCT_SUCCESS,CREATE_INNERDUCT_SUCCESS } from "./InnerDuctAction";
const initialState = {
  data: null,
  loading:true
};

function InnerDuctReducer(state = initialState, action) {
  
  switch (action.type) {
    case GET_INNERDUCT_SUCCESS:
      return (state = {
        data: action.data,
        loading:false
      });
      case UPDATE_INNERDUCT_SUCCESS:
        return (state = {
          data: action.data,
          loading:false
        });
        case CREATE_INNERDUCT_SUCCESS:
          return (state = {
            data: action.data,
            loading:false
          });
    default:
      return state;
  }
}

export default InnerDuctReducer;
