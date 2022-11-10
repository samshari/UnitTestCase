import { BASE_URL } from "../../../../ApiConstant";
export const GET_REGION_REQUEST = "GET_REGION_REQUEST";

export function getRegionApi() {
return(dispatch) =>{
  return new Promise((resolve, reject) => {  
    fetch(
      `${BASE_URL}/api/common/GetMREGION`
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
    type: GET_REGION_REQUEST,
    data: value
  };
};


