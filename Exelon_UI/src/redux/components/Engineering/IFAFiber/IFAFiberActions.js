export const GET_IFAFIBER_SUCCESS = "GET_IFAFIBER_SUCCESS";
export const UPDATE_IFAFIBER_SUCCESS = "UPDATE_IFAFIBER_SUCCESS";
export const CREATE_IFAFIBER_SUCCESS = "CREATE_IFAFIBER_SUCCESS";


export function getApi() {
return (dispatch)=>{
    return new Promise((resolve, reject) => {  
        fetch(
          `http://localhost:63006/api/engineering/getIFAFiber`
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
    type: GET_IFAFIBER_SUCCESS,
    data: value
  };
};

export function updateApi(id,data,linkID) {
    return id ===0 ?createApi(data,linkID,1) : new Promise((resolve, reject) => {  
        
       fetch(`http://localhost:63006/api/engineering/updateifafiber/${id}`,
        {
        method:'PUT',
        body: JSON.stringify({
            'originalScheduledDate': data[0].value,
            'currentScheduledDate':data[1].value,
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
        type: UPDATE_IFAFIBER_SUCCESS,
        data: value
      };
    };


    export function createApi(data,linkID,stepID) {
        
        return new Promise((resolve, reject) => {  
            fetch(`http://localhost:63006/api/engineering/createIFAFiber`,
            {
              method:'POST',
              body: JSON.stringify({
                'FK_LinkingID':linkID,
                'StepId':stepID,
                'originalScheduledDate': data[0].value,
                'currentScheduledDate':data[1].value,
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
            type: CREATE_IFAFIBER_SUCCESS,
            data: value
          };
        };


