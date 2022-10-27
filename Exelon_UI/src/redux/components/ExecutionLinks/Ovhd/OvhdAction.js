export const GET_OVHD_SUCCESS = "GET_OVHD_SUCCESS";
export const UPDATE_OVHD_SUCCESS = "UPDATE_OVHD_SUCCESS";
export const CREATE_OVHD_SUCCESS = "CREATE_OVHD_SUCCESS";

export function getApi() {
return (dispatch)=>{
    return new Promise((resolve, reject) => {  
        fetch(
          `http://localhost:63006/api/executionlinks/GetOVHD`
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
    type: GET_OVHD_SUCCESS,
    data: value
  };
};

export function updateApi(id,data,dropData,apiData) {
    console.log(JSON.stringify({
      'fK_OVHDCOCID':dropData[0].value==0? null :dropData[0].value,
      'startDate': data[1].value,
      'endDate': data[2].value,
      'issuesOrComments':data[3].value,
      'weeklyFTECount':data[4].value
  }))
    return new Promise((resolve, reject) => {  
        
        fetch(`http://localhost:63006/api/executionlinks/UpdateOvhd/${id}`,
        {
        method:'PUT',
        body: JSON.stringify({
            'fK_OVHDCOCID':dropData[0].value==0? null :dropData[0].value,
            'startDate': data[1].value,
            'endDate': data[2].value,
            'issuesOrComments':data[3].value,
            'weeklyFTECount':data[4].value
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
        type: UPDATE_OVHD_SUCCESS,
        data: value
      };
    };


    export function createApi(data,dropData,linkID,stepID) {
        return new Promise((resolve, reject) => {  
            fetch(`http://localhost:63006/api/executionlinks/CreateOVHD`,
            {
              method:'POST',
              body: JSON.stringify({
                'FK_LinkingID':linkID,
                'StepId':stepID,
                'fK_OVHDCOCID':dropData[0],
                'startDate': data[1].value,
                'endDate': data[2].value,
                'issuesOrComments':data[3].value,
                'weeklyFTECount':data[4].value
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
            type: CREATE_OVHD_SUCCESS,
            data: value
          };
        };


