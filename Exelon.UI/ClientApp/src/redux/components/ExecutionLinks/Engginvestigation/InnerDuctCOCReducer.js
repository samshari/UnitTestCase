import { GET_INNER_REQUEST } from "./InnerDuctCOCAction";

const initialState = {
  loading : true,
  data: null,
};

function InnerDuctReducer(state = initialState, action) {

  switch (action.type) {
    case GET_INNER_REQUEST:
      return (state = {
        data: action.data,
        loading : false
      });
    default:
      return state;
  }
}

export default InnerDuctReducer;
