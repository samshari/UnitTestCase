
export const GET_REAL_SUCCESS = "GET_REAL_SUCCESS";
export const UPDATE_REAL_SUCCESS = "UPDATE_REAL_SUCCESS";
export const CREATE_REAL_SUCCESS = "CREATE_REAL_SUCCESS";


export function getApi() {
return (dispatch)=>{
    return new Promise((resolve, reject) => {  
        fetch(
          `http://localhost:63006/api/engineering/GetMEOCREALSTATE`
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

export function updateApi(id,data,dropData,apiData) {
    return new Promise((resolve, reject) => {  
        
      fetch(`http://localhost:63006/api/engineering/UpdateMEOCREALSTATE/${id}`,
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
        .catch((error) => reject(error));
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
            fetch(`http://localhost:63006/api/common/CreateMEOCREALSTATE`,
    {
      method:'POST',
      body: JSON.stringify({
        'FK_linkingID': linkID,
        'stepID': stepID,
        'fK_EOCID' : dropData[0].value,
        'eocReleaseDate' : dropData[1].value,
        'eocPoleForemanComplete' : dropData[2].value,
        'reefSubmittal' : dropData[3].value,
        'reef' :  dropData[4].value,
        'fK_RealEstateSupportCOCID' : dropData[5].value,
        'ugCnCInvestigation' : dropData[6].value,
        'mhDefects' : dropData[7].value,
        'investigationComments': dropData[8].value,
        'mRs':dropData[9].value
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



