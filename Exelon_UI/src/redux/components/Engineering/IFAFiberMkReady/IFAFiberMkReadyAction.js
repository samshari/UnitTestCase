import { BASE_URL } from "../../../../ApiConstant";
export const GET_IFAMAKE_SUCCESS = "GET_IFAMAKE_SUCCESS";
export const UPDATE_IFAMAKE_SUCCESS = "UPDATE_IFAMAKE_SUCCESS";
export const CREATE_IFAMAKE_SUCCESS = "CREATE_IFAMAKE_SUCCESS";

export function getApi() {
return (dispatch)=>{
  return new Promise((resolve, reject) => {  
    fetch(
      `${BASE_URL}/api/engineering/getIFA`
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

export function updateApi(id,data,linkID) {
    
    return  id===0?createApi(data,linkID,1):new Promise((resolve, reject) => {  
        
      fetch(`${BASE_URL}/api/engineering/updateIFA/${id}`,
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
            fetch(`${BASE_URL}/api/engineering/createIFA`,
            {
              method:'POST',
              body: JSON.stringify({
                'FK_LinkingID':linkID,
                'StepId':stepID,
                'currentScheduledDate': data[1].value?data[1].value:null,
                'originalScheduledDate':data[0].value?data[0].value:null,
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
            type: CREATE_IFAMAKE_SUCCESS,
            data: value
          };
        };


