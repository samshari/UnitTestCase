import { BASE_URL } from "../../../../ApiConstant";
export const GET_PPReplace_SUCCESS = "GET_PPReplace_SUCCESS";
export const UPDATE_PPReplace_SUCCESS = "UPDATE_PPReplace_SUCCESS";
export const CREATE_PPReplace_SUCCESS = "CREATE_PPReplace_SUCCESS";

export function getApi() {
  return (dispatch)=>{
    return new Promise((resolve, reject) => {  
      fetch(
        `${BASE_URL}/api/engineering/getppreplace`
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
    type: GET_PPReplace_SUCCESS,
    data: value
  };
};

export function updateApi(id,data,linkID) {
    
    return id === 0?createApi(data,linkID,1)  :new Promise((resolve, reject) => {  
        
    fetch(`${BASE_URL}/api/engineering/updateppreplace/${id}`,
      {
        method:'PUT',
        body: JSON.stringify({
          'totalNoOfPolesInRoute' :  !data[0].value?0 : data[0].value,
          'replacedNoOfOsmos' : !data[1].value? 0 : data[1].value,
          'replacedLoading' : !data[2].value? 0 : data[2].value,
          'replacedClearance' : !data[3].value? 0 : data[3].value,
          'replacedReliability' : !data[4].value? 0 : data[4].value,
          'newOrMidspanPoles' : !data[5].value? 0 : data[5].value,
          'totalRelocatedPoles' : !data[6].value? 0 : data[6].value,
          'totalPolesNeedingReplaced' : !data[7].value? 0 : data[7].value,
          'newAnchor': !data[8].value? 0 : data[8].value,
          'otherWorkOnPole': !data[9].value? 0 : data[9].value,
          'poleReplacementPercentage': !data[10].value? 0 : parseFloat(data[10].value)
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
        type: UPDATE_PPReplace_SUCCESS,
        data: value
      };
    };


    export function createApi(data,linkID,stepID) {
        return new Promise((resolve, reject) => {  
            fetch(`${BASE_URL}/api/engineering/createppreplace`,
    {
      method:'POST',
      body: JSON.stringify({
        'FK_linkingID': linkID,
        'stepID': stepID,
        'totalNoOfPolesInRoute' :  !data[0].value?0 : data[0].value,
        'replacedNoOfOsmos' : !data[1].value? 0 : data[1].value,
        'replacedLoading' : !data[2].value? 0 : data[2].value,
        'replacedClearance' : !data[3].value? 0 : data[3].value,
        'replacedReliability' : !data[4].value? 0 : data[4].value,
        'newOrMidspanPoles' : !data[5].value? 0 : data[5].value,
        'totalRelocatedPoles' : !data[6].value? 0 : data[6].value,
        'totalPolesNeedingReplaced' : !data[7].value? 0 : data[7].value,
        'newAnchor': !data[8].value? 0 : data[8].value,
        'otherWorkOnPole': !data[9].value? 0 : data[9].value,
        'poleReplacementPercentage': !data[10].value? 0 : parseFloat(data[10].value)
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
            type: CREATE_PPReplace_SUCCESS,
            data: value
          };
        };



