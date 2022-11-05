export const GET_EXLINK_SUCCESS = "GET_EXLINK_SUCCESS";
export const UPDATE_EXLINK_SUCCESS = "UPDATE_EXLINK_SUCCESS";
export const CREATE_EXLINK_SUCCESS = "CREATE_EXLINK_SUCCESS";


export function getLinkApi(id) {
  return (dispatch) => {
    return new Promise((resolve, reject) => {
      fetch(
        `http://localhost:63006/api/engineering/GetLinkInfo/${id}`
      )
      .then((res) => {
        const data = res.json().then((res)=> {
            dispatch(getApiSuccess(res));
            resolve(res)
        })
        return data;
      
    })
        .catch((error) => reject(error));
    });
  };
}

const getApiSuccess = (value) => {
  return {
    type: GET_EXLINK_SUCCESS,
    data: value,
  };
};

export function updateLinkApi(id,data,dropData,fiberCount,apiData) {
  return new Promise((resolve, reject) => {  
      
      fetch(`http://localhost:63006/api/engineering/updatelinkinfo/${id}`,
      {
      method:'PUT',
      body: JSON.stringify({
        'primaryKey':apiData.primaryKey,
        'nickname':apiData.nickname,
        'engineeringYear':data[0].value,
        'executionYear':data[1].value,
        'technologyId':dropData[2].value?dropData[2].value:null,
        'regionId':dropData[3].value?dropData[3].value:null,
        'barnId':dropData[4].value?dropData[4].value:null,
        'workOrder':data[5].value,
        'projectID':data[6].value,
        'comments':data[9].value,
        'itn':data[10].value,
        'projectStatusId':dropData[11].value?dropData[11].value:null,
        'description':apiData.description,
        'scopeComments':data[12].value,
        'fiberCount':fiberCount

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
      type: UPDATE_EXLINK_SUCCESS,
      data: value
    };
  };


  export function createLinkApi(data,dropData,fiberCount,stepID,pdID) {
      return new Promise((resolve, reject) => {  
          fetch(`http://localhost:63006/api/engineering/createlinkinfo`,
          {
            method:'POST',
            body: JSON.stringify({
              'primaryKey':data[0].value,
              'nickname':data[1].value?data[1].value:null,
              'engineeringYear':data[2].value?data[2].value:null,
              'executionYear':data[3].value?data[3].value:null,
              'technologyId':dropData[4].value?data[4].value:null,
              'regionId':dropData[5].value?data[5].value:null,
              'barnId':dropData[6].value?data[6].value:null,
              'workOrder':data[7].value?data[7].value:null,
              'projectID':data[8].value?data[8].value:null,
              'comments':data[9].value?data[9].value:null,
              'itn':data[10].value?data[10].value:null,
              'projectStatusId':dropData[11].value?data[11].value:null,
              'description':data[12].value?data[12].value:null,
              'scopeComments':data[13].value?data[13].value:null,
              'fiberCount':fiberCount?fiberCount:null,
              'StepId':stepID,
              'pdid':pdID
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
          type: CREATE_EXLINK_SUCCESS,
          data: value
        };
      };
