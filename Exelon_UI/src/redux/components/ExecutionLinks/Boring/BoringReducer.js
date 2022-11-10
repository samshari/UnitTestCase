import { GET_BORING_SUCCESS, UPDATE_BORING_SUCCESS, CREATE_BORING_SUCCESS } from "./BoringAction";
const initialState = {
  data: null,
  loading: true
};

function BoringReducer(state = initialState, action) {

  switch (action.type) {
    case GET_BORING_SUCCESS:
      return (state = {
        data: action.data,
        loading: false
      });
    case UPDATE_BORING_SUCCESS:
      return (state = {
        data: action.data,
        loading: false
      });
    case CREATE_BORING_SUCCESS:
      return (state = {
        data: action.data,
        loading: false
      });
    default:
      return state;
  }
}

export default BoringReducer;
