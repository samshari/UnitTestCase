import { BASE_URL } from "../../../../ApiConstant";
export const GET_LINK_SUCCESS = "GET_LINK_SUCCESS";
export const UPDATE_LINK_SUCCESS = "UPDATE_LINK_SUCCESS";
export const CREATE_LINK_SUCCESS = "CREATE_LINK_SUCCESS";

export function getApi(id) {
  return (dispatch) => {
    return new Promise((resolve, reject) => {
      fetch(
        `${BASE_URL}/api/engineering/GetLinkInfo/${id}`
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
      
      fetch(`${BASE_URL}/api/engineering/updatelinkinfo/${id}`,
      {
      method:'PUT',
      body: JSON.stringify({
        'primaryKey':data[0].value,
        'nickname':data[1].value,
        'engineeringYear':data[2].value,
        'executionYear':data[3].value,
        'technologyId':dropData[4].value?dropData[4].value:null,
        'regionId':dropData[5].value?dropData[5].value:null,
        'barnId':dropData[6].value?dropData[6].value:null,
        'workOrder':data[7].value,
        'projectID':data[8].value,
        'comments':data[9].value,
        'itn':data[10].value,
        'projectStatusId':dropData[11].value?dropData[11].value:null,
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
          fetch(`${BASE_URL}/api/engineering/createlinkinfo`,
          {
            method:'POST',
            body: JSON.stringify({
              'primaryKey':data[0].value,
              'nickname':data[1].value?data[1].value:null,
              'engineeringYear':data[2].value?data[2].value:null,
              'executionYear':data[3].value?data[3].value:null,
              'technologyId':dropData[4].value?dropData[4].value:null,
              'regionId':dropData[5].value?dropData[5].value:null,
              'barnId':dropData[6].value?dropData[6].value:null,
              'workOrder':data[7].value?data[7].value:null,
              'projectID':data[8].value?data[8].value:null,
              'comments':data[9].value?data[9].value:null,
              'itn':data[10].value?data[10].value:null,
              'projectStatusId':dropData[11].value?dropData[11].value:null,
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
          type: CREATE_LINK_SUCCESS,
          data: value
        };
      };
