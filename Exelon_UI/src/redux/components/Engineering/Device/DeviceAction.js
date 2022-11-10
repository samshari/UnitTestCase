import { BASE_URL } from "../../../../ApiConstant";
export const GET_DEVICE_REQUEST = "GET_DEVICE_REQUEST";
export const UPDATE_DEVICE_REQUEST = "UPDATE_DEVICE_REQUEST"
export const CREATE_DEVICE_REQUEST = "CREATE_DEVICE_REQUEST"
export const GET_TOTAL_DEVICE="GET_TOTAL_DEVICE";

export function getApi() {
return(dispatch) =>{
  return new Promise((resolve, reject) => {  
    fetch(
      `${BASE_URL}/api/engineering/Getdevice`
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

export function updateApi(id,data,linkID) {
    
      return id===0?createApi(data,linkID,1) : new Promise((resolve, reject) => {  
        
      fetch(`${BASE_URL}/api/engineering/updatedevice/${id}`,
        {
            method:'PUT',
            body: JSON.stringify({
              'totalDevices' : parseInt(data[0].value),
              'deviceType' : data[1].value
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
        type: UPDATE_DEVICE_REQUEST,
        data: value
      };
    };


    export function createApi(data,linkID,stepID) {
      
        return new Promise((resolve, reject) => {  
              fetch(`${BASE_URL}/api/engineering/createdevice`,
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

export function gettotalDevice(value) {
    return {
        type: GET_TOTAL_DEVICE,
            data: value
        }
    }

