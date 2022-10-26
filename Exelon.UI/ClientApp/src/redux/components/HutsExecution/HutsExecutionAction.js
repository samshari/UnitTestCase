export const  HIDE_HUTS_EXECUTION_FORM = "HIDE_HUTS_EXECUTION_FORM"; // action types
export const SHOW_UPDATE_BUTTON= "SHOW_UPDATE_BUTTON";

export function hideHutsExecutionForm(value1, value2 ) {
  return {
    type: HIDE_HUTS_EXECUTION_FORM,
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