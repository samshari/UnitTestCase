import { GET_ENGG_SUCCESS, CREATE_ENGG_SUCCESS, UPDATE_ENGG_SUCCESS } from "./EngginvestigationAction";
const initialState = {
    loading: true,
    data: null,
};

function EnggInvestReducer(state = initialState, action) {

    switch (action.type) {
        case GET_ENGG_SUCCESS:
            return (state = {
                data: action.data,
                loading: false
            });
        case UPDATE_ENGG_SUCCESS:
            return (state = {
                data: action.data,
                loading: false
            });
        case CREATE_ENGG_SUCCESS:
            return (state = {
                data: action.data,
                loading: false
            });
        default:
            return state;
    }
}

export default EnggInvestReducer;
