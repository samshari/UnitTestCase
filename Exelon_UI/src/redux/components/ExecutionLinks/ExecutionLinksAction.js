export const  HIDE_EXECUTION_LINKS_FORM = "HIDE_EXECUTION_LINKS_FORM"; // action types
export const GET_PROJECTID_SUCCESS ="GET_PROJECTID_SUCCESS"
export const GET_LINK_INFO_PROJECT_ID="GET_LINK_INFO_PROJECT_ID"
export const GET_ExPD_ID = "GET_ExPD_ID";

export function hideExecutionLinksForm(value ) {
  return {
    type: HIDE_EXECUTION_LINKS_FORM,
    data:value, // action payload,
  }
}

export function getProjectId(id) {
  return (dispatch) => {
    return new Promise((resolve, reject) => {
      fetch(
        `http://localhost:63006/api/executionlinks/GetProjectIdsByPDId/${id}`
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

export function getPDID(value) {
  return {
    type: GET_ExPD_ID,
    data: value
  }
}

const getApiSuccess = (value) => {
  return {
    type: GET_PROJECTID_SUCCESS,
    data: value
  };
};
const getLinkInfoPKApiSuccess = (value) => {
  return {
    type: GET_LINK_INFO_PROJECT_ID,
    data: value
  };
};