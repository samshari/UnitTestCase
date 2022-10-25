export const GET_LINK_SUCCESS = "GET_LINK_SUCCESS";
export const UPDATE_LINK_SUCCESS = "UPDATE_LINK_SUCCESS";
export const CREATE_LINK_SUCCESS = "CREATE_LINK_SUCCESS";


export function getApi(id) {
  return (dispatch) => {
    return new Promise((resolve, reject) => {
      fetch(
        `http://localhost:63006/api/engineering/getlinkinfo/${id}`
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
    type: GET_LINK_SUCCESS,
    data: value,
  };
};

export function updateApi(id,data,dropData,fiberCount,apiData) {
  return new Promise((resolve, reject) => {  
      
      fetch(`http://localhost:63006/api/engineering/updatelinkinfo/${id}`,
      {
      method:'PUT',
      body: JSON.stringify({
        'primaryKey':data[0].value,
        'nickname':data[1].value,
        'engineeringYear':data[2].value,
        'executionYear':data[3].value,
        'fK_TechnologyID':dropData[4].value,
        'fK_RegionID':dropData[5].value,
        'fK_BarnID':dropData[6].value,
        'workOrder':data[7].value,
        'projectID':data[8].value,
        'comments':data[9].value,
        'itn':data[10].value,
        'fK_ProjectStatusID':dropData[11].value,
        'description':data[12].value,
        'scopeComments':data[13].value,
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
      type: UPDATE_LINK_SUCCESS,
      data: value
    };
  };


  export function createApi(data,dropData,fiberCount,stepID,pdID) {
      return new Promise((resolve, reject) => {  
          fetch(`http://localhost:63006/api/engineering/createlinkinfo`,
          {
            method:'POST',
            body: JSON.stringify({
              'primaryKey':data[0].value,
              'nickname':data[1].value,
              'engineeringYear':data[2].value,
              'executionYear':data[3].value,
              'fK_TechnologyID':dropData[4].value=== 0?null:dropData[4].value,
              'fK_RegionID':dropData[5].value === 0?null:dropData[5].value ,
              'fK_BarnID':dropData[6].value=== 0?null:dropData[6].value,
              'workOrder':data[7].value,
              'projectID':data[8].value,
              'comments':data[9].value,
              'itn':data[10].value,
              'fK_ProjectStatusID':dropData[11].value=== 0?null:dropData[11].value,
              'description':data[12].value,
              'scopeComments':data[13].value,
              'fiberCount':fiberCount,
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
          type: CREATE_LINK_SUCCESS,
          data: value
        };
      };
