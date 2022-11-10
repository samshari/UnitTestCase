import { BASE_URL } from "../../../ApiConstant";
export const GET_HUT_SUCCESS = "GET_HUT_SUCCESS";
export const UPDATE_HUT_SUCCESS = "UPDATE_HUT_SUCCESS";
export const CREATE_HUT_SUCCESS = "CREATE_HUT_SUCCESS";
export const  HIDE_PERMITTING_FORM = "HIDE_PERMITTING_FORM"; // action types
export const SHOW_UPDATE_BUTTON= "SHOW_UPDATE_BUTTON";
export const GET_SUB_SUCCESS="GET_SUB_SUCCESS";
export const GET_HUT_LABEL="GET_HUT_LABEL";
export const GET_SUBSTATE_SUCCESS="GET_SUBSTATE_SUCCESS";

export function hidePermittingForm(value1, value2 ) {
  return {
    type: HIDE_PERMITTING_FORM,
    hideForm:value1, // action payload,
    function:clearSelectedRow(value2)
  }
}

export function gethutPermitLabelData(value) {
  return {
    type: GET_HUT_LABEL,
    data: value
  }
}


export function showUpdateButton(value ) {
  return {
    type: SHOW_UPDATE_BUTTON,
    showUpdateButton:value, // action payload,
  }
}
export function clearSelectedRow(value){
  return{
    data:value
  }
}

export function getallDataBysubstation(id){
  return (dispatch)=>{
    return new Promise((resolve, reject) => {  
      fetch(
        `${BASE_URL}/api/HutPermit/GetHUTBySub/${id}`
      )
        .then((res) => {
            const data = res.json().then((res)=> {
                dispatch(getSubSuccess(res))
                resolve(res)
            })
            return data;
          
        })
        .catch((error) => reject(error));
        })
  }
}



export function getApi() {
  return (dispatch)=>{
    return new Promise((resolve, reject) => {  
      fetch(
        `${BASE_URL}/api/HutPermit/GetHUT`
      )
        .then((res) => {
            const data = res.json().then((res)=> {
                dispatch(getApiSuccess(res))
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
    type: GET_HUT_SUCCESS,
    data: value
  };
};
const getSubSuccess = (value) => {
 
  return {
    type: GET_SUB_SUCCESS,
    data: value
  };
};
export const getsubStation = (value) => {
 
  return {
    type: GET_SUBSTATE_SUCCESS,
    data: value
  };
};

export function updateApi(id,data,dropData) {
    console.log('data',dropData);
    return new Promise((resolve, reject) => {  
        
    fetch(`${BASE_URL}/api/HutPermit/UpdateHUT/${id}`,
      {
        method:'PUT',
        body: JSON.stringify({
          'substation':data[0].value,
          'fK_EOCID':dropData[1].value?dropData[1].value:null,
          'installYear':data[2].value,
          'fK_SizeID':dropData[3].value?dropData[3].value:null,
          'location_Municipality':data[4].value,
          'location_County':data[5].value,
          'fK_RequiredCountyStormwater':dropData[6].value?dropData[6].value:null,
          'fK_ArmyCorpsPermitRequired':dropData[7].value?dropData[7].value:null,
          'fK_TROWPermitRequired':dropData[8].value?dropData[8].value:null,
          'fK_SiteDevelopmentPermitRequired':dropData[9].value?dropData[9].value:null,
          'fK_HwyOrIDOTPermit':dropData[10].value?dropData[10].value:null,
          'fK_BuildingOrOtherPermitRequired':dropData[11].value?dropData[11].value:null,
          'civilIFADate':data[12].value,
          'civilIFCDate':data[13].value,
          'permitSubmissionDate':data[14].value,
          'permitReadyDate':data[15].value,
          'permitExpiration':data[16].value,
          'status':data[17].value,
          'notes':data[18].value
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
        type: UPDATE_HUT_SUCCESS,
        data: value
      };
    };


    export function createApi(data,dropData) {
    return new Promise((resolve, reject) => {  
    fetch(`${BASE_URL}/api/HutPermit/CreateHUT`,
    {
      method:'POST',
      body: JSON.stringify({
          'substation':data[0].value,
          'fK_EOCID':dropData[1].value?dropData[1].value:null,
          'installYear':data[2].value,
          'fK_SizeID':dropData[3].value?dropData[3].value:null,
          'location_Municipality':data[4].value,
          'location_County':data[5].value,
          'fK_RequiredCountyStormwater':dropData[6].value?dropData[6].value:null,
          'fK_ArmyCorpsPermitRequired':dropData[7].value?dropData[7].value:null,
          'fK_TROWPermitRequired':dropData[8].value?dropData[8].value:null,
          'fK_SiteDevelopmentPermitRequired':dropData[9].value?dropData[9].value:null,
          'fK_HwyOrIDOTPermit':dropData[10].value?dropData[10].value:null,
          'fK_BuildingOrOtherPermitRequired':dropData[11].value?dropData[11].value:null,
          'civilIFADate':data[12].value,
          'civilIFCDate':data[13].value,
          'permitSubmissionDate':data[14].value,
          'permitReadyDate':data[15].value,
          'permitExpiration':data[16].value,
          'status':data[17].value,
          'notes':data[18].value
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
            type: CREATE_HUT_SUCCESS,
            data: value
          };
        };





