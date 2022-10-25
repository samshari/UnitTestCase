export const GET_ENGG_SUCCESS = "GET_ENGG_SUCCESS";
export const UPDATE_ENGG_SUCCESS = "UPDATE_ENGG_SUCCESS";
export const CREATE_ENGG_SUCCESS = "CREATE_ENGG_SUCCESS";

export function getApi() {
return (dispatch)=>{
    return new Promise((resolve, reject) => {  
        fetch(
          `http://localhost:63006/api/executionlinks/Getenginvest`
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
    type: GET_ENGG_SUCCESS,
    data: value
  };
};

export function updateApi(id,data,dropData,apiData) {
    
    return new Promise((resolve, reject) => {  
        
        fetch(`http://localhost:63006/api/executionlinks/Updateenginvest/${id}`,
        {
        method:'PUT',
        body: JSON.stringify({
            'fK_InnerductCOC':dropData[0].value,
            'comments':data[1].value

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
        type: UPDATE_ENGG_SUCCESS,
        data: value
      };
    };


    export function createApi(data,dropData,linkID,stepID) {
        return new Promise((resolve, reject) => {  
            fetch(`http://localhost:63006/api/engineering/Createenginvest`,
            {
              method:'POST',
              body: JSON.stringify({
                'FK_LinkingID':linkID,
                'StepId':stepID,
                'fK_InnerductCOC':dropData[0].value,
                'comments':data[1].value
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
            type: CREATE_ENGG_SUCCESS,
            data: value
          };
        };


