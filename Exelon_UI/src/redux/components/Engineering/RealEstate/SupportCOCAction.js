import { BASE_URL } from "../../../../ApiConstant";
export const GET_SUPCOC_REQUEST = "GET_SUPCOC_REQUEST";

export function getSupCOCApi() {
return(dispatch) =>{
  return new Promise((resolve, reject) => {  
    fetch(
      `${BASE_URL}/api/common/GetMREALEOC`
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
    type: GET_SUPCOC_REQUEST,
    data: value
  };
};


