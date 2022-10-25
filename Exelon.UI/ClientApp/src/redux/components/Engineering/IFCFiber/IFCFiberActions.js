export const GET_IFCFIBER_SUCCESS = "GET_IFCFIBER_SUCCESS";
export const UPDATE_IFCFIBER_SUCCESS = "UPDATE_IFCFIBER_SUCCESS";
export const CREATE_IFCFIBER_SUCCESS = "CREATE_IFCFIBER_SUCCESS";


export function getApi() {
return (dispatch)=>{
    return new Promise((resolve, reject) => {  
        fetch(
          `http://localhost:63006/api/engineering/getIFCFiber`
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
    type: GET_IFCFIBER_SUCCESS,
    data: value
  };
};

export function updateApi(id,data,apiData) {
    return new Promise((resolve, reject) => {  
        
        fetch(`http://localhost:63006/api/engineering/updateifcfiber/${id}`,
        {
        method:'PUT',
        body: JSON.stringify({
            'originalScheduledDate': data[0].value,
            'currentScheduledDate':data[1].value,
            'missedDates':data[2].value,
            'initialIssueDate':data[3].value,
            'finalIssueDate':data[4].value,
            'missedReason':data[5].value
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
        type: UPDATE_IFCFIBER_SUCCESS,
        data: value
      };
    };


    export function createApi(data,linkID,stepID) {
        
        return new Promise((resolve, reject) => {  
            fetch(`http://localhost:63006/api/engineering/createIFCFiber`,
            {
              method:'POST',
              body: JSON.stringify({
                'FK_LinkingID':linkID,
                'StepId':stepID,
                'originalScheduledDate': data[0].value,
                'currentScheduledDate':data[1].value,
                'missedReason':data[2].value,
                'initialIssueDate':data[3].value,
                'finalIssueDate':data[4].value,
                'missedDates':data[5].value
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
            type: CREATE_IFCFIBER_SUCCESS,
            data: value
          };
        };


