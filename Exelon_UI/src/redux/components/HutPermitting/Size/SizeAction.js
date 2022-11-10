import { BASE_URL } from "../../../../ApiConstant";
export const GET_SIZE_REQUEST = "GET_SIZE_REQUEST";

export function getSizeApi() {
return(dispatch) =>{
  return new Promise((resolve, reject) => {  
    fetch(
      `${BASE_URL}/api/common/GetMSIZE`
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
    type: GET_SIZE_REQUEST,
    data: value
  };
};


