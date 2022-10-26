export const GET_IFAMAKE_SUCCESS = "GET_IFAMAKE_SUCCESS";
export const UPDATE_IFAMAKE_SUCCESS = "UPDATE_IFAMAKE_SUCCESS";
export const CREATE_IFAMAKE_SUCCESS = "CREATE_IFAMAKE_SUCCESS";

export function getApi() {
return (dispatch)=>{
  return new Promise((resolve, reject) => {  
    fetch(
      `http://localhost:63006/api/engineering/getIFA`
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
    type: GET_IFAMAKE_SUCCESS,
    data: value
  };
};

export function updateApi(id,data,apiData) {
    
    return new Promise((resolve, reject) => {  
        
        fetch(`http://localhost:63006/api/engineering/updateIFA/${id}`,
        {
        method:'PUT',
        body: JSON.stringify({
            'currentScheduledDate': data[1].value,
            'originalScheduledDate':data[0].value,
            'missedDatesAndReasons':data[2].value,
            'initialIssueDate':data[3].value,
            'finalIssueDate':data[4].value
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
        type: UPDATE_IFAMAKE_SUCCESS,
        data: value
      };
    };


    export function createApi(data,linkID,stepID) {
        return new Promise((resolve, reject) => {  
            fetch(`http://localhost:63006/api/engineering/createIFA`,
            {
              method:'POST',
              body: JSON.stringify({
                'FK_LinkingID':linkID,
                'StepId':stepID,
                'currentScheduledDate': data[1].value,
                'originalScheduledDate':data[0].value,
                'missedDatesAndReasons':data[2].value,
                'initialIssueDate':data[3].value,
                'finalIssueDate':data[4].value
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
            type: CREATE_IFAMAKE_SUCCESS,
            data: value
          };
        };


