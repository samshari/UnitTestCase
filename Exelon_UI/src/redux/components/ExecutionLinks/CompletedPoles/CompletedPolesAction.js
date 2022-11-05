export const GET_COMPLETEDPOLES_SUCCESS = "GET_COMPLETEDPOLES_SUCCESS";
export const UPDATE_COMPLETEDPOLES_SUCCESS = "UPDATE_COMPLETEDPOLES_SUCCESS";
export const CREATE_COMPLETEDPOLES_SUCCESS = "CREATE_COMPLETEDPOLES_SUCCESS";

export function getApi() {
return (dispatch)=>{
    return new Promise((resolve, reject) => {  
        fetch(
          `http://localhost:63006/api/executionlinks/GetCOMPLETEDPOLES`
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
    type: GET_COMPLETEDPOLES_SUCCESS,
    data: value
  };
};

export function updateApi(id,data,dropData,apiData) {
    console.log(JSON.stringify({
      'ExecutionLinkingID':dropData[0].value==0? null :dropData[0].value,
      'TotalNoOfPolesNeeded': data[1].value,
      'PoleInstalled': data[2].value,
      'OHMilesTotal':data[3].value,
      'MakeReadyOHMilesCompleted':data[4].value,
      'UGMilesTotal':data[5].value,
      'UGMilesCompleted':data[6].value
  }))
    return new Promise((resolve, reject) => {  
        
        fetch(`http://localhost:63006/api/executionlinks/UpdateCOMPLETEDPOLES/${id}`,
        {
        method:'PUT',
        body: JSON.stringify({
            'ExecutionLinkingID':dropData[0].value==0? null :dropData[0].value,
            'TotalNoOfPolesNeeded': data[1].value,
            'PoleInstalled': data[2].value,
            'OHMilesTotal':data[3].value,
            'MakeReadyOHMilesCompleted':data[4].value,
            'UGMilesTotal':data[5].value,
            'UGMilesCompleted':data[6].value
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
        type: UPDATE_COMPLETEDPOLES_SUCCESS,
        data: value
      };
    };


    export function createApi(data,dropData,linkID) {
        return new Promise((resolve, reject) => {  
            fetch(`http://localhost:63006/api/executionlinks/CreateCOMPLETEDPOLES`,
            {
              method:'POST',
              body: JSON.stringify({
            'ExecutionLinkingID':dropData[0],
            'TotalNoOfPolesNeeded': data[1].value,
            'PoleInstalled': data[2].value,
            'OHMilesTotal':data[3].value,
            'MakeReadyOHMilesCompleted':data[4].value,
            'UGMilesTotal':data[5].value,
            'UGMilesCompleted':data[6].value
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
            type: CREATE_COMPLETEDPOLES_SUCCESS,
            data: value
          };
        };


