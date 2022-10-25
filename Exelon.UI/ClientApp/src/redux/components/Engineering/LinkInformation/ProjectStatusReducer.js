import { GET_PROJECTSTATUS_REQUEST } from "./ProjectStatusAction";
const initialState = {
  loading : true,
  data: null,
};

function ProjectStatusReducer(state = initialState, action) {

  switch (action.type) {
    case GET_PROJECTSTATUS_REQUEST:
      return (state = {
        data: action.data,
        loading : false
      });
    default:
      return state;
  }
}

export default ProjectStatusReducer;
