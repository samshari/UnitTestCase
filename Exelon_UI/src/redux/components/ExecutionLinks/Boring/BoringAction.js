import { create } from "@mui/material/styles/createTransitions";
import { BASE_URL } from "../../../../ApiConstant";
export const GET_BORING_SUCCESS = "GET_BORING_SUCCESS";
export const UPDATE_BORING_SUCCESS = "UPDATE_BORING_SUCCESS";
export const CREATE_BORING_SUCCESS = "CREATE_BORING_SUCCESS";

export function getApi() {
  return (dispatch) => {
    return new Promise((resolve, reject) => {
      fetch(
        `${BASE_URL}/api/executionlinks/GetBORE`
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


const getApiSuccess = (value) => {

  return {
    type: GET_BORING_SUCCESS,
    data: value
  };
};

export function updateApi(id, data, dropData,linkID) {
  return id===0? createApi(data,dropData,linkID): new Promise((resolve, reject) => {

    fetch(`${BASE_URL}/api/executionlinks/UpdateBORE/${id}`,
      {
        method: 'PUT',
        body: JSON.stringify({
          'fK_BoringCOCID': dropData[0].value == 0 ? null : dropData[0].value,
          'startDate': data[1].value,
          'endDate': data[2].value,
          'issuesOrComments': data[4].value,
          'weeklyFTECount': data[3].value
        }),
        headers: {
          'Content-Type': 'application/json; charset=utf-8'
        }
      }
    ).then((res) => {
      const data = res.json().then(res => {
        updateApiSuccess(res);
        resolve(res);
      });
      return data;
    })
      .catch((error) => reject(error));
  })
}


const updateApiSuccess = (value) => {

  return {
    type: UPDATE_BORING_SUCCESS,
    data: value
  };
};


export function createApi(data, dropData, linkID) {
  return new Promise((resolve, reject) => {
    fetch(`${BASE_URL}/api/executionlinks/CreateBORE`,
      {
        method: 'POST',
        body: JSON.stringify({
          'fK_LinkingID': linkID,
          'fK_BoringCOCID': dropData[0].value == 0 ? null : dropData[0].value,
          'startDate': data[1].value,
          'endDate': data[2].value,
          'issuesOrComments': data[4].value,
          'weeklyFTECount': data[3].value
        }),
        headers: {
          'Content-Type': 'application/json; charset=utf-8'
        }
      }
    ).then((response) => {
      response.json().then(res => {
        createApiSuccess(res);
        resolve(res);
      });

    })
      .catch((error) => reject(error));
  })
}


const createApiSuccess = (value) => {

  return {
    type: CREATE_BORING_SUCCESS,
    data: value
  };
};


