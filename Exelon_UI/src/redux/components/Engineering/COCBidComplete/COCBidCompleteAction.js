import { BASE_URL } from "../../../../ApiConstant";
export const GET_COCBID_REQUEST = "GET_COCBID_REQUEST";
export const UPDATE_COCBID_REQUEST = "UPDATE_COCBID_REQUEST"
export const CREATE_COCBID_REQUEST = "CREATE_COCBID_REQUEST"


export function getApi() {
return(dispatch) =>{
  return new Promise((resolve, reject) => {  
    fetch(
      `${BASE_URL}/api/engineering/GetMCOCBID`
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

export function updateApi(id,data,dropData,linkID) {
  return id ===0 ?createApi(data,dropData,linkID,1)  :new Promise((resolve, reject) => {  
      fetch(`${BASE_URL}/api/engineering/UpdateMCOCBID/${id}`,
        {
            method:'PUT',
            body: JSON.stringify({
              'fK_COCBidCompMkReadyID' : dropData[0].value?dropData[0].value:null,
              'fK_COCBidCompFiberID' : dropData[1].value?dropData[1].value:null
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
        type: UPDATE_COCBID_REQUEST,
        data: value
      };
    };


    export function createApi(data,dropData,linkID,stepID) {
        return new Promise((resolve, reject) => {  
              fetch(`${BASE_URL}/api/engineering/CreateMCOCBID`,
            {
            method:'POST',
            body: JSON.stringify({
                'Fk_LinkingID': linkID,
                'FK_StepID':stepID,
                'fK_COCBidCompMkReadyID' : dropData[0].value === null || dropData[0].value ===0?null: dropData[0].value,
                'fK_COCBidCompFiberID' : dropData[1].value === null || dropData[1].value ===0 ?null:dropData[1].value
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


