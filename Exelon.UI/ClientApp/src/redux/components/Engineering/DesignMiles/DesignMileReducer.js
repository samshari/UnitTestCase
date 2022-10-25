import { GET_DESIGN_REQUEST,UPDATE_DESIGN_REQUEST, CREATE_DESIGN_REQUEST } from "./DesignMileAction";

const initialState = {
  loading : true,
  data: null,
};

function DesignReducer(state = initialState, action) {

  switch (action.type) {
    case GET_DESIGN_REQUEST:
      return (state = {
        data: action.data,
        loading : false
      });
    case UPDATE_DESIGN_REQUEST:
        return (state = {
          data: action.data,
          loading : false
        });
    case CREATE_DESIGN_REQUEST:
          return (state = {
            data: action.data,
            loading : false
      });
    default:
      return state;
  }
}

export default DesignReducer;
