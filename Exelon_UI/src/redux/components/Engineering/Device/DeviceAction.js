export const GET_DEVICE_REQUEST = "GET_DEVICE_REQUEST";
export const UPDATE_DEVICE_REQUEST = "UPDATE_DEVICE_REQUEST"
export const CREATE_DEVICE_REQUEST = "CREATE_DEVICE_REQUEST"

export function getApi() {
return(dispatch) =>{
  return new Promise((resolve, reject) => {  
    fetch(
      `http://localhost:63006/api/engineering/Getdevice`
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
    type: GET_DEVICE_REQUEST,
    data: value
  };
};

export function updateApi(id,data,apiData) {
    
    return (dispatch)=>{
      return new Promise((resolve, reject) => {  
        
        fetch(`http://localhost:63006/api/engineering/updatedevice/${id}`,
        {
            method:'PUT',
            body: JSON.stringify({
              'totalDevices' : data[0].value.length===0?apiData.totalDevices: parseInt(data[0].value),
              'deviceType' : data[1].value.length===0?apiData.deviceType:data[1].value
            }),
            headers: {
              'Content-Type': 'application/json; charset=utf-8'
            }
        }
        ).then((res)=>{
            const data  = res.json().then(res=> {
              dispatch(updateApiSuccess(res));
                resolve(res);
              }); 
            return data;   
        })
        .catch((error) => reject(error));
        })
    }
    }
    
    
    const updateApiSuccess = (value) => {
     
      return {
        type: UPDATE_DEVICE_REQUEST,
        data: value
      };
    };


    export function createApi(data,linkID,stepID) {
        return new Promise((resolve, reject) => {  
              fetch(`http://localhost:63006/api/engineering/createdevice`,
            {
            method:'POST',
            body: JSON.stringify({
                'linkingId': linkID,
                'stepId':stepID,
                'totalDevices' :  parseInt(data[0].value),
                'deviceType' : data[1].length===0?null:data[1].value
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
            type: CREATE_DEVICE_REQUEST,
            data: value
          };
        };


