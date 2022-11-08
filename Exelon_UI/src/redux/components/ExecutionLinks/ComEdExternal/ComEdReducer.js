import { GET_ComEd_SUCCESS, UPDATE_ComEd_SUCCESS, CREATE_ComEd_SUCCESS,GET_LNLDROP_SUCCESS, GET_ComEdIDByLinkingID_SUCCESS } from "./ComEdExternalAction";

const initialState = {
  data: null,
  loading:true
};

function ComEdReducer(state = initialState, action) {
  switch (action.type) {
    case GET_ComEd_SUCCESS:
      return (state = {
        data: action.data,
        loading:false
      });
      case UPDATE_ComEd_SUCCESS:
        return (state = {
          data: action.data,
          loading:false
        });
        case CREATE_ComEd_SUCCESS:
          return (state = {
            data: action.data,
            loading:false
          });
          case GET_LNLDROP_SUCCESS:
            return (state = {
              data: action.data,
              loading:false
            });
            case GET_ComEdIDByLinkingID_SUCCESS:
              return (state = {
                data: action.data,
                loading:false
              });
    default:
      return state;
  }
}

export default ComEdReducer;
