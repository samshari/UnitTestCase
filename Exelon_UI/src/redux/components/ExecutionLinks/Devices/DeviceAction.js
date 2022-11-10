import { BASE_URL } from "../../../../ApiConstant";
export const GET_DEVICES_SUCCESS = "GET_DEVICES_SUCCESS";
export const UPDATE_DEVICES_SUCCESS = "UPDATE_DEVICES_SUCCESS";
export const CREATE_DEVICES_SUCCESS = "CREATE_DEVICES_SUCCESS";

export function getApi(id) {
return (dispatch)=>{
    return new Promise((resolve, reject) => {  
        fetch(
          `${BASE_URL}/api/executionlinks/GetExecutionDeviceBYLinkId/${id}`
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
    type: GET_DEVICES_SUCCESS,
    data: value
  };
};

export function updateApi(id,data,dropData,linkID) {
   
    return id===0?createApi(data,dropData,linkID): new Promise((resolve, reject) => {  
        
        fetch(`${BASE_URL}/api/executionlinks/UpdateExecutionDevice/${id}`,
        {
        method:'PUT',
        body: JSON.stringify({
            'installedDevice':data[0].value?parseInt(data[0].value):null
        }),
        headers: {
            'Content-Type': 'application/json; charset=utf-8'
        }
        }
        ).then((res)=>{
            const data  = res.json().then(res=> {
                updateApiSuccess(res);
                resolve(res);
              }); 
            return data;   
        })
        .catch((error) => reject(error));
        })
    }
    
    
    const updateApiSuccess = (value) => {
     
      return {
        type: UPDATE_DEVICES_SUCCESS,
        data: value
      };
    };


    export function createApi(data,dropData,linkID) {
        return new Promise((resolve, reject) => {  
            fetch(`${BASE_URL}/api/executionlinks/SaveExecutionDevice`,
            {
              method:'POST',
              body: JSON.stringify({
                'executionLinkidId':linkID,
                'installedDevice':data[0].value?parseInt(data[0].value):null
              }),
              headers: {
                'Content-Type': 'application/json; charset=utf-8'
              }
            }
            ).then((response)=>{
                response.json().then(res=> {
                    createApiSuccess(res);
                    resolve(res);
                });
                
            })
            .catch((error) => reject(error));
            })
        }
        
        
        const createApiSuccess = (value) => {
         
          return {
            type: CREATE_DEVICES_SUCCESS,
            data: value
          };
        };


