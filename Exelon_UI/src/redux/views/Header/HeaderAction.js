export const  SELECT_PD = "SELECT_PD"; // action types
export const SELECT_PRIMARYKEY="SELECT_PRIMARYKEY";
export const SELECT_PROJECTID="SELECT_PROJECTID";
export const SELECT_SUBSTATION="SELECT_SUBSTATION";
export const SELECT_LOCATION="SELECT_LOCATION";
export const SELECT_HUTS_EXECUTION_LOCATION="SELECT_HUTS_EXECUTION_LOCATION";

export function selectPD(value1, value2 ) {
  return {
    type: SELECT_PD,
    data:value1, // action payload,
    function:clearSelectedRow(value2)
  }
}

export function clearSelectedRow(value){
  return{
    data:value
  }
}

export function selectPrimaryKey(value ) {
  return {
    type: SELECT_PRIMARYKEY,
    data:value, // action payload,
  }
}

export function selectProjectID(value ) {
  return {
    type: SELECT_PROJECTID,
    data:value, // action payload,
  }
}
export function selectSubstation(value ) {
  return {
    type: SELECT_SUBSTATION,
    data:value, // action payload,
  }
}
export function selectLocation(value ) {
  return {
    type: SELECT_LOCATION,
    data:value, // action payload,
  }
}
export function selectHutsExecutionLocation(value ) {
  return {
    type: SELECT_HUTS_EXECUTION_LOCATION,
    data:value, // action payload,
  }
}