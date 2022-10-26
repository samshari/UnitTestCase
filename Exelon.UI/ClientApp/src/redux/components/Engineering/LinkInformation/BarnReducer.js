import { GET_BARN_REQUEST } from "./BarnAction";
const initialState = {
  loading : true,
  data: null,
};

function BarnReducer(state = initialState, action) {

  switch (action.type) {
    case GET_BARN_REQUEST:
      return (state = {
        data: action.data,
        loading : false
      });
    default:
      return state;
  }
}

export default BarnReducer;
