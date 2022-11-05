export const GET_INNERDUCT_SUCCESS = "GET_INNERDUCT_SUCCESS";
export const UPDATE_INNERDUCT_SUCCESS = "UPDATE_INNERDUCT_SUCCESS";
export const CREATE_INNERDUCT_SUCCESS = "CREATE_INNERDUCT_SUCCESS";

export function getApi() {
return (dispatch)=>{
    return new Promise((resolve, reject) => {  
        fetch(
          `http://localhost:63006/api/executionlinks/GetRODROPE`
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
    type: GET_INNERDUCT_SUCCESS,
    data: value
  };
};

export function updateApi(id,data,dropData,apiData) {
    return new Promise((resolve, reject) => {  
        
        fetch(`http://localhost:63006/api/executionlinks/UpdateRODROPE/${id}`,
        {
        method:'PUT',
        body: JSON.stringify({
            'innerductStartDate':data[0].value,
            'innerductEndDate':data[1].value,
            'comments':data[2].value
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
        type: UPDATE_INNERDUCT_SUCCESS,
        data: value
      };
    };


    export function createApi(data,dropData,linkID) {
        return new Promise((resolve, reject) => {  
            fetch(`http://localhost:63006/api/executionlinks/CreateRODROPE`,
            {
              method:'POST',
              body: JSON.stringify({
                'FK_LinkingID':linkID,
                'innerductStartDate':data[0].value,
                'innerductEndDate':data[1].value,
                'comments':data[2].value
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
            type: CREATE_INNERDUCT_SUCCESS,
            data: value
          };
        };


