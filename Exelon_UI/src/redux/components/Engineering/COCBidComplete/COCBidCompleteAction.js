export const GET_COCBID_REQUEST = "GET_COCBID_REQUEST";
export const UPDATE_COCBID_REQUEST = "UPDATE_COCBID_REQUEST"
export const CREATE_COCBID_REQUEST = "CREATE_COCBID_REQUEST"

export function getApi() {
return(dispatch) =>{
  return new Promise((resolve, reject) => {  
    fetch(
      `http://localhost:63006/api/engineering/GetMCOCBID`
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
    type: GET_COCBID_REQUEST,
    data: value
  };
};

export function updateApi(id,data,dropData,apiData) {
    
    return (dispatch)=>{
      return new Promise((resolve, reject) => {  
        
        fetch(`http://localhost:63006/api/engineering/UpdateMCOCBID/${id}`,
        {
            method:'PUT',
            body: JSON.stringify({
              'fK_COCBidCompMkReadyID' : dropData[0].value === null?null: dropData[0].value,
              'fK_COCBidCompFiberID' : dropData[1].value === null ?null:dropData[1].value
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
        type: UPDATE_COCBID_REQUEST,
        data: value
      };
    };


    export function createApi(data,dropData,linkID,stepID) {
        return new Promise((resolve, reject) => {  
              fetch(`http://localhost:63006/api/engineering/CreateMCOCBID`,
            {
            method:'POST',
            body: JSON.stringify({
                'Fk_LinkingID': linkID,
                'FK_StepID':stepID,
                'fK_COCBidCompMkReadyID' : dropData[0].value === null?null: dropData[0].value,
                'fK_COCBidCompFiberID' : dropData[1].value === null ?null:dropData[1].value
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
            type: CREATE_COCBID_REQUEST,
            data: value
          };
        };


