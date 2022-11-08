export const GET_ComEd_SUCCESS = "GET_ComEd_SUCCESS";
export const UPDATE_ComEd_SUCCESS = "UPDATE_ComEd_SUCCESS";
export const CREATE_ComEd_SUCCESS = "CREATE_ComEd_SUCCESS";
export const GET_LNLDROP_SUCCESS="GET_LNLDROP_SUCCESS";
export const GET_ComEdIDByLinkingID_SUCCESS="GET_ComEdIDByLinkingID_SUCCESS";

export function getApi(comEdId) {
return (dispatch)=>{
    return new Promise((resolve, reject) => {  
        fetch(
          `http://localhost:63006/api/ExecutionLinks/GetComEd/${comEdId}`
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
    type: GET_ComEd_SUCCESS,
    data: value
  };
};

export function updateApi(id,dropData,model) {
  debugger;
    return new Promise((resolve, reject) => {  
        
        fetch(`http://localhost:63006/api/ExecutionLinks/UpdateComEd/${id}`,
        {
        method:'PUT',
        body: JSON.stringify({
          'LinkingId': model.LinkingId,
          'LnLId': dropData[0].value==0?null:dropData[0].value,
          'ComEdId' : model.ComEdId
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
        type: UPDATE_ComEd_SUCCESS,
        data: value
      };
    };

    export function createApi(data,dropData,linkingId) {
        return new Promise((resolve, reject) => {  
            fetch(`http://localhost:63006/api/ExecutionLinks/CreateComEd`,
            {
              method:'POST',
              body: JSON.stringify({
                'LinkingId':linkingId,
                'LnLId':dropData[0].value==0?null:dropData[0].value
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
            type: CREATE_ComEd_SUCCESS,
            data: value
          };
        };

        export function getLnLApi() {
            return (dispatch)=>{
              return new Promise((resolve, reject) => {  
                fetch(
                  `http://localhost:63006/api/Common/GetLNL/${7}`
                )
                  .then((res) => {
                      const data = res.json().then((res)=> {
                          dispatch(getLnLApiSuccess(res));
                          resolve(res);
                      })
                      return data;
                    
                  })
                  .catch((error) => reject(error));
                  })
            }
          
          }
          const getLnLApiSuccess = (value) => {
            return {
              type: GET_ComEd_SUCCESS,
              data: value
            };
          };

          export function getComEdIdByLinkingIdApi(linkingId) {
            return (dispatch)=>{
              return new Promise((resolve, reject) => {  
                fetch(
                  `http://localhost:63006/api/ExecutionLinks/GetComEdIdByLinkingId/${linkingId}`
                )
                  .then((res) => {
                      const data = res.json().then((res)=> {
                          dispatch(getComEdIdByLinkingIdApiSuccess(res));
                          resolve(res);
                      })
                      return data;
                    
                  })
                  .catch((error) => reject(error));
                  })
            }
          
          }
          const getComEdIdByLinkingIdApiSuccess = (value) => {
            return {
              type: GET_ComEdIDByLinkingID_SUCCESS,
              data: value
            };
          };


