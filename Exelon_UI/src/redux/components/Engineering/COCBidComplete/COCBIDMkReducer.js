import { GET_COCBIDMk_REQUEST } from "./COCBIDMkReadyAction";

const initialState = {
  loading : true,
  data: null,
};

function COCBIDMkReducer(state = initialState, action) {

  switch (action.type) {
    case GET_COCBIDMk_REQUEST:
      return (state = {
        data: action.data,
        loading : false
      });
    default:
      return state;
  }
}

export default COCBIDMkReducer;
