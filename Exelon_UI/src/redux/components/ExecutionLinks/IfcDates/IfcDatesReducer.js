import { GET_IFCDATES_SUCCESS,CREATE_IFCDATES_SUCCESS,UPDATE_IFCDATES_SUCCESS } from "./IfcDatesAction";
const initialState = {
data: null,
  loading:true
};

function IfcDatesReducer(state = initialState, action) {
  
  switch (action.type) {
    case GET_IFCDATES_SUCCESS:
      return (state = {
        data: action.data,
        loading:false
      });
      case UPDATE_IFCDATES_SUCCESS:
        return (state = {
          data: action.data,
          loading:false
        });
        case CREATE_IFCDATES_SUCCESS:
          return (state = {
            data: action.data,
            loading:false
          });
    default:
      return state;
  }
}

export default IfcDatesReducer;
