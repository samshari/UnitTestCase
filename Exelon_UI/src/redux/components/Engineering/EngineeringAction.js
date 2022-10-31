export const HIDE_ENGINEERING_FORM = "HIDE_ENGINEERING_FORM"; // action types
export const SHOW_UPDATE_BUTTON = "SHOW_UPDATE_BUTTON";
export const GET_PD_ID = "GET_PD_ID";
export const GET_PRIMARY_KEY = "GET_PRIMARY_KEY";
export const GET_LINK_INFO_PRIMARY_KEY = "GET_LINK_INFO_PRIMARY_KEY";
export const GET_LINK_DATA="GET_LINK_DATA;"
export const CREATE_LINK_DATA="CREATE_LINK_DATA;"

export function hideEngineeringForm(value1, value2) {

  return {
    type: HIDE_ENGINEERING_FORM,
    hideForm: value1, // action payload,
    function: clearSelectedRow(value2)
  }
}

export function showUpdateButton(value1) {
  return {
    type: SHOW_UPDATE_BUTTON,
    showUpdateButton: value1, // action payload,
  }
}
export function clearSelectedRow(value) {
  return {
    data: value
  }
}

export function getPDID(value) {
  return {
    type: GET_PD_ID,
    data: value
  }
}
export function getLinkData(value) {
  return {
    type: GET_LINK_DATA,
    data: value
  }
}
export function createLinkData(value) {
  return {
    type: CREATE_LINK_DATA,
    data: value
  }
}
export function getPrimaryKey(id) {
  return (dispatch) => {
    return new Promise((resolve, reject) => {
      fetch(
        `http://localhost:63006/api/engineering/GetPrimaryKeysByPDId/${id}`
      )
        .then((res) => {
          const data = res.json().then((res) => {
            dispatch(getApiSuccess(res));
            resolve(res)
          })
          return data;

        })
        .catch((error) => reject(error));
    })
  }
}
export function getLinkInfoByPrimaryKey(pk) {
  return (dispatch) => {
    return new Promise((resolve, reject) => {
      fetch(
        `http://localhost:63006/api/engineering/GetDetailsByLinkId/${pk}`
      )
        .then((res) => {
          const data = res.json().then((res) => {
            dispatch(getLinkInfoPKApiSuccess(res));
            resolve(res)
          })
          return data;

        })
        .catch((error) => reject(error));
    })
  }
}
const getApiSuccess = (value) => {
  return {
    type: GET_PRIMARY_KEY,
    data: value
  };
};
const getLinkInfoPKApiSuccess = (value) => {
  return {
    type: GET_LINK_INFO_PRIMARY_KEY,
    data: value
  };
};
