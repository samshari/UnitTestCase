import { BASE_URL } from "../../../../ApiConstant";
export const GET_UCOM_REQUEST = "GET_UCOM_REQUEST";

export function getUcomApi() {
return(dispatch) =>{
  return new Promise((resolve, reject) => {  
    fetch(
      `${BASE_URL}/api/common/GetMUCO`
    )
      .then((res) => {
          const data = res.json().then((res)=> {
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
    type: GET_UCOM_REQUEST,
    data: value
  };
};


