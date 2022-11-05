export const GET_COMPLETEDFIBERMILES_SUCCESS = "GET_COMPLETEDFIBERMILES_SUCCESS";
export const UPDATE_COMPLETEDFIBERMILES_SUCCESS = "UPDATE_COMPLETEDFIBERMILES_SUCCESS";
export const CREATE_COMPLETEDFIBERMILES_SUCCESS = "CREATE_COMPLETEDFIBERMILES_SUCCESS";

export function getApi(id) {
return (dispatch)=>{
    return new Promise((resolve, reject) => {  
        fetch(
          `http://localhost:63006/api/executionlinks/GetCompletedFiberMile/${id}`
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

export function updateApi(id,data,dropData,apiData) {
    console.log(JSON.stringify({
      'ExecutionLinkingID':dropData[0].value==0? null :dropData[0].value,
      'FiberMilesInstalled': data[1].value,
      'FiberMilesCompleted': data[2].value
      
  }))
    return new Promise((resolve, reject) => {  
        
        fetch(`http://localhost:63006/api/executionlinks/UpdateCompletedFiberMile/${id}`,
        {
        method:'PUT',
        body: JSON.stringify({
            'ExecutionLinkingID':dropData[0].value==0? null :dropData[0].value,
      'FiberMilesInstalled': data[1].value,
      'FiberMilesCompleted': data[2].value
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
            fetch(`http://localhost:63006/api/executionlinks/SaveCompletedFiberMile`,
            {
              method:'POST',
              body: JSON.stringify({
                'ExecutionLinkingID':dropData[0].value,
                'FiberMilesInstalled': data[1].value,
                'FiberMilesCompleted': data[2].value
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