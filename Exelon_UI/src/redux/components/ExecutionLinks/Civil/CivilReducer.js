import {
    GET_CIVIL_SUCCESS,
    UPDATE_CIVIL_SUCCESS,
    CREATE_CIVIL_SUCCESS,
  } from "./CivilAction";
  const initialState = {
    data: null,
    loading: true,
  };
  
  function CIVILReducer(state = initialState, action) {
    switch (action.type) {
      case GET_CIVIL_SUCCESS:
        return (state = {
          data: action.data,
          loading: false,
        });
      case UPDATE_CIVIL_SUCCESS:
        return (state = {
          data: action.data,
          loading: false,
        });
      case CREATE_CIVIL_SUCCESS:
        return (state = {
          data: action.data,
          loading: false,
        });
      default:
        return state;
    }
  }
  
  export default CIVILReducer;
  