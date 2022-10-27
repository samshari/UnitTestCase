import { GET_OVHDCOC_REQUEST } from "./OvhdCocAction";

const initialState = {
  loading : true,
  data: null,
};

function OvhdCOCReducer(state = initialState, action) {

  switch (action.type) {
    case GET_OVHDCOC_REQUEST:
      return (state = {
        data: action.data,
        loading : false
      });
    default:
      return state;
  }
}

export default OvhdCOCReducer;
