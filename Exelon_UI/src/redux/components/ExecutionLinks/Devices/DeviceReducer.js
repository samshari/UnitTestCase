import { GET_DEVICES_SUCCESS ,CREATE_DEVICES_SUCCESS, UPDATE_DEVICES_SUCCESS } from "./DeviceAction";
const initialState = {
    loading: true,
    data: null,
};

function ExDeviceReducer(state = initialState, action) {

    switch (action.type) {
        case GET_DEVICES_SUCCESS:
            return (state = {
                data: action.data,
                loading: false
            });
        case UPDATE_DEVICES_SUCCESS:
            return (state = {
                data: action.data,
                loading: false
            });
        case CREATE_DEVICES_SUCCESS:
            return (state = {
                data: action.data,
                loading: false
            });
        default:
            return state;
    }
}

export default ExDeviceReducer;
