import { GET_SIZE_REQUEST } from "./SizeAction";
const initialState = {
  loading : true,
  data: null,
};

function SizeReducer(state = initialState, action) {

  switch (action.type) {
    case GET_SIZE_REQUEST:
      return (state = {
        data: action.data,
        loading : false
      });
    default:
      return state;
  }
}

export default SizeReducer;
