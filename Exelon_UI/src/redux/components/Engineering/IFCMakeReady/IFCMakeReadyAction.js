export const GET_IFCMAKE_SUCCESS = "GET_IFCMAKE_SUCCESS";
export const UPDATE_IFCMAKE_SUCCESS = "UPDATE_IFCMAKE_SUCCESS";
export const CREATE_IFCMAKE_SUCCESS = "CREATE_IFCMAKE_SUCCESS";

export function getApi() {
return (dispatch)=>{
  return new Promise((resolve, reject) => {  
    fetch(
      `http://localhost:63006/api/engineering/getIFC`
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
    type: GET_IFCMAKE_SUCCESS,
    data: value
  };
};

export function updateApi(id,data,linkID) {
    
    return id===0?createApi(data,linkID,0):new Promise((resolve, reject) => {  
        
      fetch(`http://localhost:63006/api/engineering/updateIFC/${id}`,
        {
        method:'PUT',
        body: JSON.stringify({
            'originalScheduledDate': data[1].value,
            'currentScheduledDate':data[0].value,
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
        type: UPDATE_IFCMAKE_SUCCESS,
        data: value
      };
    };


    export function createApi(data,linkID,stepID) {
        return new Promise((resolve, reject) => {  
            fetch(`http://localhost:63006/api/engineering/createIFC`,
            {
              method:'POST',
              body: JSON.stringify({
                'FK_LinkingID':linkID,
                'StepId':stepID,
                'originalScheduledDate': data[1].value?data[1].value:null,
                'currentScheduledDate':data[0].value?data[0].value:null,
                'missedDatesAndReasons':data[2].value?data[2].value:null,
                'initialIssueDate':data[3].value?data[3].value:null,
                'finalIssueDate':data[4].value?data[4].value:null
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
            type: CREATE_IFCMAKE_SUCCESS,
            data: value
          };
        };


