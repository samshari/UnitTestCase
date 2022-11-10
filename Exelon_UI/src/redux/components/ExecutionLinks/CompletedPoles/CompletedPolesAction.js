import { BASE_URL } from "../../../../ApiConstant";
export const GET_COMPLETEDPOLES_SUCCESS = "GET_COMPLETEDPOLES_SUCCESS";
export const UPDATE_COMPLETEDPOLES_SUCCESS = "UPDATE_COMPLETEDPOLES_SUCCESS";
export const CREATE_COMPLETEDPOLES_SUCCESS = "CREATE_COMPLETEDPOLES_SUCCESS";

export function getApi(id) {
return (dispatch)=>{
    return new Promise((resolve, reject) => {  
        fetch(
          `${BASE_URL}/api/executionlinks/GetCompletedPoleMileByLinkId/${id}`
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
    type: GET_COMPLETEDPOLES_SUCCESS,
    data: value
  };
};

export function updateApi(id,data,dropData,linkID) {
    return id ===0?createApi(data,dropData,linkID): new Promise((resolve, reject) => {  
        
        fetch(`${BASE_URL}/api/executionlinks/UpdateCompletedPoleMile/${id}`,
        {
        method:'PUT',
        body: JSON.stringify({
            'totalNoOfPolesNeeded': data[0].value?data[0].value:0,
            'poleInstalled': data[1].value?data[1].value:0,
            'ohMilesTotal':data[2].value?data[2].value:0,
            'makeReadyOHMilesCompleted':data[3].value?data[3].value:0,
            'ugMilesTotal':data[4].value?data[4].value:0,
            'ugMilesCompleted':data[5].value?parseInt(data[5].value):0
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
        type: UPDATE_COMPLETEDPOLES_SUCCESS,
        data: value
      };
    };


    export function createApi(data,dropData,linkID) {
        return new Promise((resolve, reject) => {  
            fetch(`${BASE_URL}/api/executionlinks/SaveCompletedPoleMile`,
            {
              method:'POST',
              body: JSON.stringify({
                'executionLinkingId':linkID,
                'totalNoOfPolesNeeded': data[0].value?data[0].value:0,
                'poleInstalled': data[1].value?data[1].value:0,
                'ohMilesTotal':data[2].value?data[2].value:0,
                'makeReadyOHMilesCompleted':data[3].value?data[3].value:0,
                'ugMilesTotal':data[4].value?data[4].value:0,
                'ugMilesCompleted':data[5].value?parseInt(data[5].value):0
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
            type: CREATE_COMPLETEDPOLES_SUCCESS,
            data: value
          };
        };


