export const  HIDE_EXECUTION_LINKS_FORM = "HIDE_EXECUTION_LINKS_FORM"; // action types
export const GET_PROJECTID_SUCCESS ="GET_PROJECTID_SUCCESS"
export const GET_LINK_INFO_PROJECT_ID="GET_LINK_INFO_PROJECT_ID"
export const GET_ExPD_ID = "GET_ExPD_ID";
export const GET_PROJECT_ID="GET_PROJECT_ID";
export const GET_ALL_PROJECT_ID="GET_ALL_PROJECT_ID";
export const GET_EXLINK_DATA="GET_EXLINK_DATA";
export const GET_EXLABEL_KEY="GET_EXLABEL_KEY";
export const GET_EXLINK_ID="GET_EXLINK_ID";
export const GET_EXLINKID_SUCCESS="GET_EXLINKID_SUCCESS";

export function hideExecutionLinksForm(value ) {
  return {
    type: HIDE_EXECUTION_LINKS_FORM,
    data:value, // action payload,
  }
}

export function getExLinkData(value) {
  return {
    type: GET_EXLINK_DATA,
    data: value
  }
}

export function getExLabelData(value) {
  return {
    type: GET_EXLABEL_KEY,
    data: value

  }

}

export function getExLinkingID(value) {
  return {
    type: GET_EXLINK_ID,
    data: value
  }
}

export function getExLinkID(value) {
  return {
    type: GET_EXLINKID_SUCCESS,
    data: value
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
export function GetLinkInfoIdByProjectId(projectID) {
  return (dispatch) => {
    return new Promise((resolve, reject) => {
      fetch(
        `http://localhost:63006/api/executionlinks/GetLinkInfoIdByProjectId/${projectID}`
      )
        .then((res) => {
          const data = res.json().then((res) => {
            dispatch(getLinkInfoIdByProjectIdSuccess(res));
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

export function getProjectIDByPD(value) {
  return {
    type: GET_PROJECT_ID,
    data: value
  }
}

export function getallProjectId(value) {
  return {
    type: GET_ALL_PROJECT_ID,
    data: value
  }
}

const getApiSuccess = (value) => {
  return {
    type: GET_PROJECTID_SUCCESS,
    data: value
  };
};
const getLinkInfoIdByProjectIdSuccess = (value) => {
  return {
    type: GET_LINK_INFO_PROJECT_ID,
    data: value
  };
};
