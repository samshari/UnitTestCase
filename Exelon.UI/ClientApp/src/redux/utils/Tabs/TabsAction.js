export const DISABLE_TABS = "DISABLE_TABS"; // action types

export function disableTabs(value) {
  return {
    type: DISABLE_TABS,
    data:value, // action payload,
  }
}