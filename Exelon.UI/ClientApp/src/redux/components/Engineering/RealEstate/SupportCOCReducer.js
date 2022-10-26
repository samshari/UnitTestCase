import { GET_SUPCOC_REQUEST } from "./SupportCOCAction";
const initialState = {
  loading : true,
  data: null,
};

function SupportCOCReducer(state = initialState, action) {

  switch (action.type) {
    case GET_SUPCOC_REQUEST:
      return (state = {
        data: action.data,
        loading : false
      });
    default:
      return state;
  }
}

export default SupportCOCReducer;
