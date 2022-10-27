import { GET_TECH_REQUEST } from "./TechAction";
const initialState = {
  loading : true,
  data: null,
};

function TechReducer(state = initialState, action) {

  switch (action.type) {
    case GET_TECH_REQUEST:
      return (state = {
        data: action.data,
        loading : false
      });
    default:
      return state;
  }
}

export default TechReducer;
