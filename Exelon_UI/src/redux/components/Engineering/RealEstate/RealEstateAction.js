import { BASE_URL } from "../../../../ApiConstant";
export const GET_REAL_SUCCESS = "GET_REAL_SUCCESS";
export const UPDATE_REAL_SUCCESS = "UPDATE_REAL_SUCCESS";
export const CREATE_REAL_SUCCESS = "CREATE_REAL_SUCCESS";

export function getApi() {
return (dispatch)=>{
    return new Promise((resolve, reject) => {  
       fetch(
          `${BASE_URL}/api/engineering/GetMEOCREALSTATE`
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
    type: GET_REAL_SUCCESS,
    data: value
  };
};

export function updateApi(id,data,dropData,linkID) {
  return id === 0?createApi(data,dropData,linkID,1):new Promise((resolve, reject) => {  
        
    fetch(`${BASE_URL}/api/engineering/UpdateMEOCREALSTATE/${id}`,
    {
      method:'PUT',
      body: JSON.stringify({
        'fK_EOCID' : dropData[0].value,
        'eocReleaseDate' : data[1].value,
        'eocPoleForemanComplete' : data[2].value,
        'reefSubmittal' : data[3].value,
        'reef' :  data[4].value,
        'fK_RealEstateSupportCOCID' : dropData[5].value,
        'ugCnCInvestigation' : data[6].value,
        'mhDefects' : data[7].value,
        'investigationComments': data[8].value,
        'mRs':data[9].value
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
      .catch((error) =>{
          console.log(error)
         reject(error)
        });      
    })
}
    
    
    const updateApiSuccess = (value) => {
     
      return {
        type: UPDATE_REAL_SUCCESS,
        data: value
      };
    };


    export function createApi(data,dropData,linkID,stepID) {
      
        return new Promise((resolve, reject) => {  
            fetch(`${BASE_URL}/api/engineering/CreateMEOCREALSTATE`,
    {
      method:'POST',
      body: JSON.stringify({
        'FK_linkingID': linkID,
        'stepID': stepID,
        'fK_EOCID' : dropData[0].value?dropData[0].value:null,
        'eocReleaseDate' : data[1].value?data[1].value:null,
        'eocPoleForemanComplete' : data[2].value?data[2].value:null,
        'reefSubmittal' : data[3].value?data[3].value:null,
        'reef' :  data[4].value?data[4].value:null,
        'fK_RealEstateSupportCOCID' : dropData[5].value?dropData[5].value:null,
        'ugCnCInvestigation' : data[6].value?data[6].value:null,
        'mhDefects' : data[7].value?data[7].value:null,
        'investigationComments': data[8].value?data[8].value:null,
        'mRs':data[9].value?data[9].value:null
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
            type: CREATE_REAL_SUCCESS,
            data: value
          };
    };



