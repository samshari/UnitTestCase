export const SELECT_NAVBAR_ITEM = "SELECT_NAVBAR_ITEM"; // action types

export function selectNavbarItem(value) {
  return {
    type: SELECT_NAVBAR_ITEM,
    data: value, // action payload,
  };
}
