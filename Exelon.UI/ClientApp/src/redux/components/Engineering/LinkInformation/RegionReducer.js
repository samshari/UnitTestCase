import { GET_REGION_REQUEST } from "./RegionAction";
const initialState = {
  loading : true,
  data: null,
};

function RegionReducer(state = initialState, action) {

  switch (action.type) {
    case GET_REGION_REQUEST:
      return (state = {
        data: action.data,
        loading : false
      });
    default:
      return state;
  }
}

export default RegionReducer;
