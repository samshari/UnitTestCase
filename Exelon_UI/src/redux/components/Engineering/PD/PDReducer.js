import { GET_PD_REQUEST } from "./PDAction";
const initialState = {
  loading : true,
  data: null,
};

function PDReducer(state = initialState, action) {

  switch (action.type) {
    case GET_PD_REQUEST:
      return (state = {
        data: action.data,
        loading : false
      });
    default:
      return state;
  }
}

export default PDReducer;
