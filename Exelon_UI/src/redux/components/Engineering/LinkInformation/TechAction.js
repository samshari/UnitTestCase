import { BASE_URL } from "../../../../ApiConstant";
export const GET_TECH_REQUEST = "GET_TECH_REQUEST";

export function getTechApi() {
return(dispatch) =>{
  return new Promise((resolve, reject) => {  
    fetch(
      `${BASE_URL}/api/common/GetMTECH`
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
    type: GET_TECH_REQUEST,
    data: value
  };
};


