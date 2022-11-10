import { BASE_URL } from "../../../../ApiConstant";
export const GET_PM_REQUEST = "GET_PM_REQUEST";

export function getPMApi() {
return(dispatch) =>{
  return new Promise((resolve, reject) => {  
    fetch(
      `${BASE_URL}/api/common/GetMPM`
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
    type: GET_PM_REQUEST,
    data: value
  };
};


