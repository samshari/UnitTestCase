import { GET_PRECONSTRUCTION_SUCCESS, UPDATE_PRECONSTRUCTION_SUCCESS, CREATE_PRECONSTRUCTION_SUCCESS } from "./PreConstructionAction";
const initialState = {
  data: null,
  loading: true
};

function PreConstructionReducer(state = initialState, action) {

  switch (action.type) {
    case GET_PRECONSTRUCTION_SUCCESS:
      return (state = {
        data: action.data,
        loading: false
      });
    case UPDATE_PRECONSTRUCTION_SUCCESS:
      return (state = {
        data: action.data,
        loading: false
      });
    case CREATE_PRECONSTRUCTION_SUCCESS:
      return (state = {
        data: action.data,
        loading: false
      });
    default:
      return state;
  }
}

export default PreConstructionReducer;
