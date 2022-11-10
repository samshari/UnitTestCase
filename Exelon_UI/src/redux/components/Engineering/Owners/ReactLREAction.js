import { BASE_URL } from "../../../../ApiConstant";
export const GET_REACTLRE_REQUEST = "GET_REACTLRE_REQUEST";

export function getReactApi() {
return(dispatch) =>{
  return new Promise((resolve, reject) => {  
    fetch(
      `${BASE_URL}/api/common/GetMREACT`
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
    type: GET_REACTLRE_REQUEST,
    data: value
  };
};


