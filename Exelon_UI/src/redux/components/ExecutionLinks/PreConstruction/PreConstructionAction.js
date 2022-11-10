import { BASE_URL } from "../../../../ApiConstant";
export const GET_PRECONSTRUCTION_SUCCESS = "GET_PRECONSTRUCTION_SUCCESS";
export const UPDATE_PRECONSTRUCTION_SUCCESS = "UPDATE_PRECONSTRUCTION_SUCCESS";
export const CREATE_PRECONSTRUCTION_SUCCESS = "CREATE_PRECONSTRUCTION_SUCCESS";

export function getApi() {
  return (dispatch) => {
    return new Promise((resolve, reject) => {
      fetch(
        `${BASE_URL}/api/executionlinks/GetPreConstruction`
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
    type: GET_PRECONSTRUCTION_SUCCESS,
    data: value
  };
};

export function updateApi(id, data, dropData,linkID) {
  return id===0?createApi(data,dropData,linkID): new Promise((resolve, reject) => {
    fetch(`${BASE_URL}/api/executionlinks/UpdatePreConstruction/${id}`,
      {
        method: 'PUT',
        body: JSON.stringify({
          "fK_EnvironmentalCOCID": dropData[0].value === 0?null:dropData[0].value,
          "fK_VegRequired": dropData[1].value ,
          "fK_StackingRequired": dropData[2].value,
          "fK_MattingRequired": dropData[3].value
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
    type: UPDATE_PRECONSTRUCTION_SUCCESS,
    data: value
  };
};


export function createApi(data, dropData, linkID) {
  return new Promise((resolve, reject) => {
    fetch(`${BASE_URL}/api/executionlinks/CreatePreConstruction`,
      {
        method: 'POST',
        body: JSON.stringify({
          'fK_LinkingID': linkID,
          "fK_EnvironmentalCOCID": dropData[0].value === 0?null:dropData[0].value,
          "fK_VegRequired": dropData[1].value ,
          "fK_StackingRequired": dropData[2].value,
          "fK_MattingRequired": dropData[3].value
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
    type: CREATE_PRECONSTRUCTION_SUCCESS,
    data: value
  };
};


