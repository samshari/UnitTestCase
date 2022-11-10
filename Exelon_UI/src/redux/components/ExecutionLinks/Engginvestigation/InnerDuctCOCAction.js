import { BASE_URL } from "../../../../ApiConstant";
export const GET_INNER_REQUEST = "GET_INNER_REQUEST";

export function getInnerApi() {
return(dispatch) =>{
  return new Promise((resolve, reject) => {  
    fetch(
      `${BASE_URL}/api/common/Getinnerduct`
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
    type: GET_INNER_REQUEST,
    data: value
  };
};


