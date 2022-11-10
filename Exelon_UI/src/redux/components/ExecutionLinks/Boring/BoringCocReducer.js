import { GET_BORINGCOC_REQUEST } from "./BoringCocAction";

const initialState = {
  loading: true,
  data: null,
};

function BoringCOCReducer(state = initialState, action) {

  switch (action.type) {
    case GET_BORINGCOC_REQUEST:
      return (state = {
        data: action.data,
        loading: false
      });
    default:
      return state;
  }
}

export default BoringCOCReducer;
