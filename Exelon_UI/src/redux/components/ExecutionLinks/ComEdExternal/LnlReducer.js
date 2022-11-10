import { GET_LNL_DATA } from "./LnlAction";

const initialState = {
  loading: true,
  data: null,
};

function LnlReducer(state = initialState, action) {
  switch (action.type) {
    case GET_LNL_DATA:
      return (state = {
        data: action.data,
        loading: false,
      });
    default:
      return state;
  }
}

export default LnlReducer;
