export const GET_IFCDATES_SUCCESS = "GET_IFCDATES_SUCCESS";
export const UPDATE_IFCDATES_SUCCESS = "UPDATE_IFCDATES_SUCCESS";
export const CREATE_IFCDATES_SUCCESS = "CREATE_IFCDATES_SUCCESS";

export function getApi() {
return (dispatch)=>{
    return new Promise((resolve, reject) => {  
        fetch(
          `http://localhost:63006/api/executionlinks/GetIFCDATES`
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
    type: GET_IFCDATES_SUCCESS,
    data: value
  };
};

export function updateApi(id,data,dropData,apiData) {
  
    return new Promise((resolve, reject) => {  
        
        fetch(`http://localhost:63006/api/executionlinks/UpdateIFCDATES/${id}`,
        {
        method:'PUT',
        body: JSON.stringify({
            'ifcMkReadyScheduledIssueDate':data[0].value,
            'ifcFiberCurrentScheduledIssueDt':data[1].value
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
        type: UPDATE_IFCDATES_SUCCESS,
        data: value
      };
    };


    export function createApi(data,dropData,linkID) {
        return new Promise((resolve, reject) => {  
            fetch(`http://localhost:63006/api/executionlinks/CreateIFCDATES`,
            {
              method:'POST',
              body: JSON.stringify({
                'FK_LinkingID':linkID,
                'ifcMkReadyScheduledIssueDate':data[0].value,
                'ifcFiberCurrentScheduledIssueDt':data[1].value
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
            type: CREATE_IFCDATES_SUCCESS,
            data: value
          };
        };


