import { BASE_URL } from "../../../../ApiConstant";
export const GET_PROJECTSTATUS_REQUEST = "GET_PROJECTSTATUS_REQUEST";

export function getProjectStatusApi() {
return(dispatch) =>{
  return new Promise((resolve, reject) => {  
    fetch(
      `${BASE_URL}/api/common/GetMprojectstatus`
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
    type: GET_PROJECTSTATUS_REQUEST,
    data: value
  };
};


