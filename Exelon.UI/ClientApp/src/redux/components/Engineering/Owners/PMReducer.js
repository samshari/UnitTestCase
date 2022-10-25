import { GET_PM_REQUEST } from "./PMAction";
const initialState = {
  loading : true,
  data: null,
};

function PMReducer(state = initialState, action) {

  switch (action.type) {
    case GET_PM_REQUEST:
      return (state = {
        data: action.data,
        loading : false
      });
    default:
      return state;
  }
}

export default PMReducer;
