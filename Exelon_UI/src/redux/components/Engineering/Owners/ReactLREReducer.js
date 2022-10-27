import { GET_REACTLRE_REQUEST } from "./ReactLREAction";

const initialState = {
  loading : true,
  data: null,
};

function ReactLREReducer(state = initialState, action) {

  switch (action.type) {
    case GET_REACTLRE_REQUEST:
      return (state = {
        data: action.data,
        loading : false
      });
    default:
      return state;
  }
}

export default ReactLREReducer;
