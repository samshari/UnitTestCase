export const  HIDE_PERMITTING_FORM = "HIDE_PERMITTING_FORM"; // action types
export const SHOW_UPDATE_BUTTON= "SHOW_UPDATE_BUTTON";

export function hidePermittingForm(value1, value2 ) {
  return {
    type: HIDE_PERMITTING_FORM,
    hideForm:value1, // action payload,
    function:clearSelectedRow(value2)
  }
}

export function showUpdateButton(value ) {
  return {
    type: SHOW_UPDATE_BUTTON,
    showUpdateButton:value, // action payload,
  }
}
export function clearSelectedRow(value){
  return{
    data:value
  }
}