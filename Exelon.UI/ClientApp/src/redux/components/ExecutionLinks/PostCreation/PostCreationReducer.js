import { GET_POSTCOMPLETION_SUCCESS,UPDATE_POSTCOMPLETION_SUCCESS,CREATE_POSTCOMPLETION_SUCCESS } from "./PostCreationAction";

const initialState = {
  data: null,
  loading:true
};

function PostCompletionReducer(state = initialState, action) {
  
  switch (action.type) {
    case GET_POSTCOMPLETION_SUCCESS:
      return (state = {
        data: action.data,
        loading:false
      });
      case UPDATE_POSTCOMPLETION_SUCCESS:
        return (state = {
          data: action.data,
          loading:false
        });
        case CREATE_POSTCOMPLETION_SUCCESS:
          return (state = {
            data: action.data,
            loading:false
          });
    default:
      return state;
  }
}

export default PostCompletionReducer;
