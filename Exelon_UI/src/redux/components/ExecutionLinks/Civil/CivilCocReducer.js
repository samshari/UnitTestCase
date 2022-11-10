import { GET_CIVILCOC_REQUEST } from "./CivilCocAction";

const initialState = {
  loading: true,
  data: null,
};

function CivilCOCReducer(state = initialState, action) {
  switch (action.type) {
    case GET_CIVILCOC_REQUEST:
      return (state = {
        data: action.data,
        loading: false,
      });
    default:
      return state;
  }
}

export default CivilCOCReducer;
