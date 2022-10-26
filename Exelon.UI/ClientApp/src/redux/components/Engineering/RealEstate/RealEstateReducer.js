import { GET_REAL_SUCCESS,UPDATE_REAL_SUCCESS,CREATE_REAL_SUCCESS} from "./RealEstateAction";
const initialState = {
  data: null,
  loading:true
};

function RealEstateReducer(state = initialState, action) {
  
  switch (action.type) {
    case GET_REAL_SUCCESS:
      return (state = {
        data: action.data,
        loading: false
      });
      case UPDATE_REAL_SUCCESS:
        return (state = {
          data: action.data,
          loading: false
        });
        case CREATE_REAL_SUCCESS:
      return (state = {
        data: action.data,
        loading: false
      });
    default:
      return state;
  }
}

export default RealEstateReducer;