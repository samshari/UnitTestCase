export const  HIDE_ENGINEERING_FORM = "HIDE_ENGINEERING_FORM"; // action types
export const SHOW_UPDATE_BUTTON= "SHOW_UPDATE_BUTTON";
export const GET_PD_ID="GET_PD_ID"

export function hideEngineeringForm(value1, value2 ) {
  
  return {
    type: HIDE_ENGINEERING_FORM,
    hideForm:value1, // action payload,
    function:clearSelectedRow(value2)
  }
}

export function showUpdateButton(value1) {
  return {
    type: SHOW_UPDATE_BUTTON,
    showUpdateButton:value1, // action payload,
  }
}
export function clearSelectedRow(value){
  return{
    data:value
  }
}

export function getPDID(value){
  return {
    type: GET_PD_ID,
    data:value
  }
}