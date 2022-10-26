import { GET_DEVICE_REQUEST,UPDATE_DEVICE_REQUEST,CREATE_DEVICE_REQUEST } from "../Device/DeviceAction";

const initialState = {
  loading : true,
  data: null,
};

function DeviceReducer(state = initialState, action) {
  
  switch (action.type) {
    case GET_DEVICE_REQUEST:
      return (state = {
        data: action.data,
        loading: false
      });
    case UPDATE_DEVICE_REQUEST:
        return (state = {
          data: action.data,
          loading: false
        });
    case CREATE_DEVICE_REQUEST:
          return (state = {
            data: action.data,
            loading: false
          });
    default:
      return state;
  }
}

export default DeviceReducer;
