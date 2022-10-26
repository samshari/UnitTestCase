export const GET_FIBER_SUCCESS = "GET_FIBER_SUCCESS";
export const UPDATE_FIBER_SUCCESS = "UPDATE_FIBER_SUCCESS";
export const CREATE_FIBER_SUCCESS = "CREATE_FIBER_SUCCESS";

export function getApi() {
return (dispatch)=>{
    return new Promise((resolve, reject) => {  
        fetch(
          `http://localhost:63006/api/executionlinks/GetFIBER`
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
    type: GET_FIBER_SUCCESS,
    data: value
  };
};

export function updateApi(id,data,dropData,apiData) {
    
    return new Promise((resolve, reject) => {  
        
        fetch(`http://localhost:63006/api/executionlinks/UpdateFIBER/${id}`,
        {
        method:'PUT',
        body: JSON.stringify({

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
        type: UPDATE_FIBER_SUCCESS,
        data: value
      };
    };


    export function createApi(data,dropData,linkID,stepID) {
        return new Promise((resolve, reject) => {  
            fetch(`http://localhost:63006/api/engineering/CreateFIBER`,
            {
              method:'POST',
              body: JSON.stringify({
                'FK_LinkingID':linkID,
                'StepId':stepID
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
            type: CREATE_FIBER_SUCCESS,
            data: value
          };
        };


