import { BASE_URL } from "../../../../ApiConstant";
export const GET_CIVIL_SUCCESS = "GET_CIVIL_SUCCESS";
export const UPDATE_CIVIL_SUCCESS = "UPDATE_CIVIL_SUCCESS";
export const CREATE_CIVIL_SUCCESS = "CREATE_CIVIL_SUCCESS";

export function getApi() {
  return (dispatch) => {
    return new Promise((resolve, reject) => {
      fetch(`${BASE_URL}/api/executionlinks/GetCIVIL`)
        .then((res) => {
          const data = res.json().then((res) => {
            dispatch(getApiSuccess(res));
            resolve(res);
          });
          return data;
        })
        .catch((error) => reject(error));
    });
  };
}

const getApiSuccess = (value) => {
  return {
    type: GET_CIVIL_SUCCESS,
    data: value,
  };
};

export function updateApi(id, data, dropData, linkID) {
  return id===0? createApi(data,dropData,linkID): new Promise((resolve, reject) => {
    fetch(`${BASE_URL}/api/executionlinks/UpdateCIVIL/${id}`, {
      method: "PUT",
      body: JSON.stringify({
        fK_CivilCOCID: dropData[0].value == 0 ? null : dropData[0].value,
        startDate: data[1].value,
        endDate: data[2].value,
        issuesOrComments: data[3].value,
        weeklyFTECount: data[4].value,
      }),
      headers: {
        "Content-Type": "application/json; charset=utf-8",
      },
    })
      .then((res) => {
        const data = res.json().then((res) => {
          updateApiSuccess(res);
          resolve(res);
        });
        return data;
      })
      .catch((error) => reject(error));
  });
}

const updateApiSuccess = (value) => {
  return {
    type: UPDATE_CIVIL_SUCCESS,
    data: value,
  };
};

export function createApi(data, dropData, linkID) {
  return new Promise((resolve, reject) => {
    fetch(`${BASE_URL}/api/executionlinks/CreateCIVIL`, {
      method: "POST",
      body: JSON.stringify({
        fK_LinkingID: linkID,
        fK_CivilCOCID: dropData[0].value === 0 ? null : dropData[0].value,
        startDate: data[1].value,
        endDate: data[2].value,
        issuesOrComments: data[3].value,
        weeklyFTECount: data[4].value,
      }),
      headers: {
        "Content-Type": "application/json; charset=utf-8",
      },
    })
      .then((response) => {
        response.json().then((res) => {
          createApiSuccess(res);
          resolve(res);
        });
      })
      .catch((error) => reject(error));
  });
}

const createApiSuccess = (value) => {
  return {
    type: CREATE_CIVIL_SUCCESS,
    data: value,
  };
};
