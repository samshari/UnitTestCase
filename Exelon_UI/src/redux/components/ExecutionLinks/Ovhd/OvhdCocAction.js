import { BASE_URL } from "../../../../ApiConstant";
export const GET_OVHDCOC_REQUEST = "GET_OVHDCOC_REQUEST";

export function getOvhdApi() {
return(dispatch) =>{
  return new Promise((resolve, reject) => {  
    fetch(
      `${BASE_URL}/api/common/GetCOCMaster`
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
    type: GET_OVHDCOC_REQUEST,
    data: value
  };
};


