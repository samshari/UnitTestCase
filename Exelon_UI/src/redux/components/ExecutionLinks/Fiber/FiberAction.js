import { BASE_URL } from "../../../../ApiConstant";
export const GET_FIBER_SUCCESS = "GET_FIBER_SUCCESS";
export const UPDATE_FIBER_SUCCESS = "UPDATE_FIBER_SUCCESS";
export const CREATE_FIBER_SUCCESS = "CREATE_FIBER_SUCCESS";

export function getApi() {
return (dispatch)=>{
    return new Promise((resolve, reject) => {  
        fetch(
          `${BASE_URL}/api/executionlinks/GetFIBER`
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
    type: GET_FIBER_SUCCESS,
    data: value
  };
};

export function updateApi(id,data,dropData,linkID) {
    return id===0?createApi(data,dropData,linkID): new Promise((resolve, reject) => {  
        
        fetch(`${BASE_URL}/api/executionlinks/UpdateFIBER/${id}`,
        {
        method:'PUT',
        body: JSON.stringify({
          'fK_FiberCOCID':dropData[0].value?dropData[0].value:null,
          'issuesOrComments':data[4].value,
          'startDate':data[1].value,
          'endDate':data[2].value,
          'weeklyFTECount':data[3].value,
          'otdrCompletionDate':data[5].value

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
        type: UPDATE_FIBER_SUCCESS,
        data: value
      };
    };


    export function createApi(data,dropData,linkID) {
        console.log('data',data);
        return new Promise((resolve, reject) => {  
            fetch(`${BASE_URL}/api/executionlinks/CreateFIBER`,
            {
              method:'POST',
              body: JSON.stringify({
                'fK_LinkingID':linkID,
                'fK_FiberCOCID':dropData[0].value==0?null:dropData[0].value,
                'issuesOrComments':data[4].value,
                'startDate':data[1].value,
                'endDate':data[2].value,
                'weeklyFTECount':data[3].value,
                'otdrCompletionDate':data[5].value
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
            type: CREATE_FIBER_SUCCESS,
            data: value
          };
        };


