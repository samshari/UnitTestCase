import { BASE_URL } from "../../../../ApiConstant";
export const GET_COMPLETEDFIBERMILES_SUCCESS = "GET_COMPLETEDFIBERMILES_SUCCESS";
export const UPDATE_COMPLETEDFIBERMILES_SUCCESS = "UPDATE_COMPLETEDFIBERMILES_SUCCESS";
export const CREATE_COMPLETEDFIBERMILES_SUCCESS = "CREATE_COMPLETEDFIBERMILES_SUCCESS";

export function getApi(id) {
return (dispatch)=>{
    return new Promise((resolve, reject) => {  
        fetch(
          `${BASE_URL}/api/executionlinks/GetCompletedFiberMileByLinkId/${id}`
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
    type: GET_COMPLETEDFIBERMILES_SUCCESS,
    data: value
  };
};

export function updateApi(id,data,dropData,linkId) {

    return id===0?createApi(data,dropData,linkId) : new Promise((resolve, reject) => {  
        
        fetch(`${BASE_URL}/api/executionlinks/UpdateCompletedFiberMile/${id}`,
        {
        method:'PUT',
        body: JSON.stringify({
            'fiberMilesInstalled': data[0].value,
            'fiberMilesCompleted': data[1].value
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
        type: UPDATE_COMPLETEDFIBERMILES_SUCCESS,
        data: value
      };
    };


    export function createApi(data,dropData,linkID) {
        return new Promise((resolve, reject) => {  
            fetch(`${BASE_URL}/api/executionlinks/SaveCompletedFiberMile`,
            {
              method:'POST',
              body: JSON.stringify({
                'executionLinkingId':linkID,
                'fiberMilesInstalled': data[0].value,
                'fiberMilesCompleted': data[1].value
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
            type: CREATE_COMPLETEDFIBERMILES_SUCCESS,
            data: value
          };
        };