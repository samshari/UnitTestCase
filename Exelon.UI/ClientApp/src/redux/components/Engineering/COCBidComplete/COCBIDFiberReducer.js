import { GET_COCBIDFiber_REQUEST } from "./COCBIDFiberAction";

const initialState = {
  loading : true,
  data: null,
};

function COCBIDFiberReducer(state = initialState, action) {

  switch (action.type) {
    case GET_COCBIDFiber_REQUEST:
      return (state = {
        data: action.data,
        loading : false
      });
    default:
      return state;
  }
}

export default COCBIDFiberReducer;
