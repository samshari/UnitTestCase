import { BASE_URL } from "../../../../ApiConstant";
export const GET_EOC_REQUEST = "GET_EOC_REQUEST";

export function getEOCApi() {
return(dispatch) =>{
  return new Promise((resolve, reject) => {  
    fetch(
      `${BASE_URL}/api/common/GetEOC`
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
    type: GET_EOC_REQUEST,
    data: value
  };
};


