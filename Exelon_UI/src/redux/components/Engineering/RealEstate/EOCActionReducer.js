import { GET_EOC_REQUEST } from "./EOCAction";
const initialState = {
  loading : true,
  data: null,
};

function EOCReducer(state = initialState, action) {

  switch (action.type) {
    case GET_EOC_REQUEST:
      return (state = {
        data: action.data,
        loading : false
      });
    default:
      return state;
  }
}

export default EOCReducer;
