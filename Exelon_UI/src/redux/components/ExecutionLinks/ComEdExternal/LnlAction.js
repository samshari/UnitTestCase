import { BASE_URL } from "../../../../ApiConstant";
export const  GET_LNL_DATA="GET_LNL_DATA";

export function getLnLApi() {
    return (dispatch)=>{
      return new Promise((resolve, reject) => {  
        fetch(
          `${BASE_URL}/api/Common/GetLNL/${7}`
        )
          .then((res) => {
              const data = res.json().then((res)=> {
                  dispatch(getLnLApiSuccess(res));
                  resolve(res);
              })
              return data;
            
          })
          .catch((error) => reject(error));
          })
    }
  
  }
  const getLnLApiSuccess = (value) => {
    return {
      type: GET_LNL_DATA,
      data: value
    };
  };
