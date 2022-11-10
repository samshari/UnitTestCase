import { GET_PRECONSTRUCTIONCOC_REQUEST } from "./PreConstructionCocAction";

const initialState = {
  loading: true,
  data: null,
};

function PreConstructionCOCReducer(state = initialState, action) {

  switch (action.type) {
    case GET_PRECONSTRUCTIONCOC_REQUEST:
      return (state = {
        data: action.data,
        loading: false
      });
    default:
      return state;
  }
}

export default PreConstructionCOCReducer;
