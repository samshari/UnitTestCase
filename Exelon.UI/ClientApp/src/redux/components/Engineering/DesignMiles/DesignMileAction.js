export const GET_DESIGN_REQUEST = "GET_DESIGN_REQUEST";
export const UPDATE_DESIGN_REQUEST = "UPDATE_DESIGN_REQUEST"
export const CREATE_DESIGN_REQUEST = "CREATE_DESIGN_REQUEST"

export function getApi() {
  return (dispatch)=>{
    return new Promise((resolve, reject) => {  
      fetch(
        `http://localhost:63006/api/engineering/getdesign`
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
    type: GET_DESIGN_REQUEST,
    data: value
  };
};

export function updateApi(id,data,apiData) {
    
    return (dispatch)=>{
      return new Promise((resolve, reject) => {  
        
        fetch(`http://localhost:63006/api/engineering/updatedesign/${id}`,
        {
        method:'PUT',
        body: JSON.stringify({
            'ugMiles' : data[0].value.length ===0?apiData.ugMiles: parseFloat(data[0].value),
            'ohMiles' : data[1].value.length===0?apiData.ohMiles: parseFloat(data[1].value),
            'totalMiles': data[2].value.length===0?apiData.totalMiles:parseFloat(data[2].value)
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
        type: UPDATE_DESIGN_REQUEST,
        data: value
      };
    };


    export function createApi(data,linkID,stepID) {
        return new Promise((resolve, reject) => {  
            fetch(`http://localhost:63006/api/engineering/createdesign`,
            {
            method:'POST',
            body: JSON.stringify({
                'FK_LinkingID':linkID,
                'FK_StepId':stepID,
                'ugMiles' : data[0].value.length ===0?null: parseFloat(data[0].value),
                'ohMiles' : data[1].value.length===0?null: parseFloat(data[1].value),
                'totalMiles': data[2].value.length===0?null:parseFloat(data[2].value)
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
            type: CREATE_DESIGN_REQUEST,
            data: value
          };
        };


