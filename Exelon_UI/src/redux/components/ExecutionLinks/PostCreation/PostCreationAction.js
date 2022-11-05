export const GET_POSTCOMPLETION_SUCCESS = "GET_POSTCOMPLETION_SUCCESS";
export const UPDATE_POSTCOMPLETION_SUCCESS = "UPDATE_POSTCOMPLETION_SUCCESS";
export const CREATE_POSTCOMPLETION_SUCCESS = "CREATE_POSTCOMPLETION_SUCCESS";

export function getApi() {
return (dispatch)=>{
    return new Promise((resolve, reject) => {  
        fetch(
          `http://localhost:63006/api/executionlinks/GetPostCompletion`
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
    type: GET_POSTCOMPLETION_SUCCESS,
    data: value
  };
};

export function updateApi(id,data,dropData,apiData) {
    
    return new Promise((resolve, reject) => {  
        
        fetch(`http://localhost:63006/api/executionlinks/UpdatePostCompletion/${id}`,
        {
        method:'PUT',
        body: JSON.stringify({
          'asBuiltsReceived':data[0].value,
          'locationsReadyToInspect':data[1].value,
          'locationsInspected':data[2].value,
          'tedUpdated':data[3].value,
          'pniUpdatedIS':data[4].value

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
        type: UPDATE_POSTCOMPLETION_SUCCESS,
        data: value
      };
    };


    export function createApi(data,dropData,linkID) {
        return new Promise((resolve, reject) => {  
            fetch(`http://localhost:63006/api/engineering/createowner`,
            {
              method:'POST',
              body: JSON.stringify({
                'FK_LinkingID':linkID,
                'asBuiltsReceived':data[0].value,
                'locationsReadyToInspect':data[1].value,
                'locationsInspected':data[2].value,
                'tedUpdated':data[3].value,
                'pniUpdatedIS':data[4].value
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
            type: CREATE_POSTCOMPLETION_SUCCESS,
            data: value
          };
        };


