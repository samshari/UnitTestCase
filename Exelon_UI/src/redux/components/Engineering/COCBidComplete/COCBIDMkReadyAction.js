import { BASE_URL } from "../../../../ApiConstant";
export const GET_COCBIDMk_REQUEST = "GET_COCBIDMk_REQUEST";

export function getMkApi() {
return(dispatch) =>{
  return new Promise((resolve, reject) => {  
    fetch(
      `${BASE_URL}/api/common/GetMCOCMK`
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
    type: GET_COCBIDMk_REQUEST,
    data: value
  };
};


