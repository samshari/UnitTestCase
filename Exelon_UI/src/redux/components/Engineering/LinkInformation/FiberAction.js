import { BASE_URL } from "../../../../ApiConstant";
export const GET_FIBER_REQUEST = "GET_FIBER_REQUEST";

export function getFiberApi() {
return(dispatch) =>{
  return new Promise((resolve, reject) => {  
    fetch(
      `${BASE_URL}/api/common/Getfiber`
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
    type: GET_FIBER_REQUEST,
    data: value
  };
};


