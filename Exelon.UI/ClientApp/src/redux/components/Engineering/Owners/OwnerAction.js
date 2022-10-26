export const GET_OWNER_SUCCESS = "GET_OWNER_SUCCESS";
export const UPDATE_OWNER_SUCCESS = "UPDATE_OWNER_SUCCESS";
export const CREATE_OWNER_SUCCESS = "CREATE_OWNER_SUCCESS";



export function getApi() {
return (dispatch)=>{
    return new Promise((resolve, reject) => {  
        fetch(
          `http://localhost:63006/api/engineering/getowner`
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
    type: GET_OWNER_SUCCESS,
    data: value
  };
};

export function updateApi(id,data,dropData,apiData) {
    
    return new Promise((resolve, reject) => {  
        
        fetch(`http://localhost:63006/api/engineering/updateowner/${id}`,
        {
        method:'PUT',
        body: JSON.stringify({
            'fK_ReactsLRE_ID' : dropData[0].value.length===0?apiData.fK_ReactsLRE_ID:parseInt(dropData[0].value),
            'fK_UCOMMSPOC_ID' : dropData[1].value.length ===0?apiData.fK_UCOMMSPOC_ID:parseInt(dropData[1].value),
            'fK_ProjectManagerID':dropData[2].value.length===0?apiData.fK_ProjectManagerID: parseInt(dropData[2].value)
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
        type: UPDATE_OWNER_SUCCESS,
        data: value
      };
    };


    export function createApi(data,dropData,linkID,stepID) {
        return new Promise((resolve, reject) => {  
            fetch(`http://localhost:63006/api/engineering/createowner`,
            {
              method:'POST',
              body: JSON.stringify({
                'FK_LinkingID':linkID,
                'StepId':stepID,
                'fK_ReactsLRE_ID' : dropData[0].value.length===0?null:parseInt(dropData[0].value),
                'fK_UCOMMSPOC_ID' : dropData[1].value.length ===0?null:parseInt(dropData[1].value),
                'fK_ProjectManagerID':dropData[2].value.length===0?null: parseInt(dropData[2].value)
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
            type: CREATE_OWNER_SUCCESS,
            data: value
          };
        };


