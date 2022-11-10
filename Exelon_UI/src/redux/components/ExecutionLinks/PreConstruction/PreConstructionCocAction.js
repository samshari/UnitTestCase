import { BASE_URL } from "../../../../ApiConstant";
export const GET_PRECONSTRUCTIONCOC_REQUEST = "GET_PRECONSTRUCTIONCOC_REQUEST";

export function getPreConstructionApi() {
  return (dispatch) => {
    return new Promise((resolve, reject) => {
      fetch(
        `${BASE_URL}/api/common/GetMENVCOC`
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
    type: GET_PRECONSTRUCTIONCOC_REQUEST,
    data: value
  };
};


