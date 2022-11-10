import { BASE_URL } from "../../../../ApiConstant";
export const GET_PD_REQUEST = "GET_PD_REQUEST";

export function getPDApi() {
return(dispatch) =>{
  return new Promise((resolve, reject) => {  
    fetch(
      `${BASE_URL}/api/engineering/GetPD`
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
    type: GET_PD_REQUEST,
    data: value
  };
};


