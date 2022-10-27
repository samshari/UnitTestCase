import { GET_UCOM_REQUEST } from "./UcomSPOCAction";

const initialState = {
  loading : true,
  data: null,
};

function UcomSPOCReducer(state = initialState, action) {

  switch (action.type) {
    case GET_UCOM_REQUEST:
      return (state = {
        data: action.data,
        loading : false
      });
    default:
      return state;
  }
}

export default UcomSPOCReducer;
