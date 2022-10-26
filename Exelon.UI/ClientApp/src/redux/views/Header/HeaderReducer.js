import { SELECT_LOCATION, SELECT_PD, SELECT_PRIMARYKEY, SELECT_PROJECTID, SELECT_SUBSTATION, SELECT_HUTS_EXECUTION_LOCATION } from "./HeaderAction";

const initialState = {
  selectedPD: [],
  clearSelectedTableRow: false,
  selectedPrimaryKey: null,
  selectedProjectId: null,
  selectedSubstation: null,
  selectedLocation: null,
  selectedHutsExecutionLocation: null,
  id: null
};

function headerReducer(state = initialState, action) {
  switch (action.type) {
    case SELECT_PD:
      return (state = {
        ...state,
        selectedPD: action.data,
        id: action.id,
        clearSelectedTableRow: action.function.data,
      });
    case SELECT_PRIMARYKEY:
      return (state = {
        ...state,
        selectedPrimaryKey: action.data
      });
    case SELECT_PROJECTID:
      return (state = {
        ...state,
        selectedProjectId: action.data
      });
    case SELECT_SUBSTATION:
      return (state = {
        ...state,
        selectedSubstation: action.data
      });
    case SELECT_LOCATION:
      return (state = {
        ...state,
        selectedLocation: action.data
      });
    case SELECT_HUTS_EXECUTION_LOCATION:
      return (state = {
        ...state,
        selectedHutsExecutionLocation: action.data
      });
    default:
      return state;
  }
}

export default headerReducer;
