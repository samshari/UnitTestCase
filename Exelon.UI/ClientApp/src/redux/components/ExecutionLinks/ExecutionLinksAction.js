export const  HIDE_EXECUTION_LINKS_FORM = "HIDE_EXECUTION_LINKS_FORM"; // action types

export function hideExecutionLinksForm(value ) {
  return {
    type: HIDE_EXECUTION_LINKS_FORM,
    data:value, // action payload,
  }
}