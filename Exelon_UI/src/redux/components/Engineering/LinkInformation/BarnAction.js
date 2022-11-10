import { BASE_URL } from "../../../../ApiConstant";
export const GET_BARN_REQUEST = "GET_BARN_REQUEST";

export function getBarnApi() {
return(dispatch) =>{
  return new Promise((resolve, reject) => {  
    fetch(
      `${BASE_URL}/api/common/GetAllBarn`
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
    type: GET_BARN_REQUEST,
    data: value
  };
};


