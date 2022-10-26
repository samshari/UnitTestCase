import { GET_COCBID_REQUEST,UPDATE_COCBID_REQUEST,CREATE_COCBID_REQUEST } from "./COCBidCompleteAction";

const initialState = {
  loading : true,
  data: null,
};

function COCBIDReducer(state = initialState, action) {

  switch (action.type) {
    case GET_COCBID_REQUEST:
      return (state = {
        data: action.data,
        loading : false
      });
    case UPDATE_COCBID_REQUEST:
        return (state = {
          data: action.data,
          loading : false
        });
    case CREATE_COCBID_REQUEST:
          return (state = {
            data: action.data,
            loading : false
      });
    default:
      return state;
  }
}

export default COCBIDReducer;
