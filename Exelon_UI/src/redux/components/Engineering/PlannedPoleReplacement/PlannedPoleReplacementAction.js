
export const GET_PPReplace_SUCCESS = "GET_PPReplace_SUCCESS";
export const UPDATE_PPReplace_SUCCESS = "UPDATE_PPReplace_SUCCESS";
export const CREATE_PPReplace_SUCCESS = "CREATE_PPReplace_SUCCESS";

export function getApi() {
  return (dispatch)=>{
    return new Promise((resolve, reject) => {  
      fetch(
        `http://localhost:63006/api/engineering/getppreplace`
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

export function updateApi(id,data,apiData) {
    
    return new Promise((resolve, reject) => {  
        
      fetch(`http://localhost:63006/api/engineering/updateppreplace/${id}`,
      {
        method:'PUT',
        body: JSON.stringify({
          'totalNoOfPolesInRoute' : data[0].value,
          'replacedNoOfOsmos' : data[1].value,
          'replacedLoading' : data[2].value,
          'replacedClearance' :  data[3].value,
          'replacedReliability' : data[4].value,
          'newOrMidspanPoles' : data[5].value,
          'totalRelocatedPoles' : data[6].value,
          'totalPolesNeedingReplaced' : data[7].value,
          'newAnchor': data[8].value,
          'otherWorkOnPole':data[9].value,
          'poleReplacementPercentage':  parseFloat(data[10].value)
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
            fetch(`http://localhost:63006/api/engineering/createppreplace`,
    {
      method:'POST',
      body: JSON.stringify({
        'FK_linkingID': linkID,
        'stepID': stepID,
        'totalNoOfPolesInRoute' :  data[0].value.length === 0?0 : data[0].value,
        'replacedNoOfOsmos' : data[1].value.length === 0? 0 : data[1].value,
        'replacedLoading' : data[2].value.length === 0? 0 : data[2].value,
        'replacedClearance' : data[3].value.length === 0? 0 : data[3].value,
        'replacedReliability' : data[4].value.length === 0? 0 : data[4].value,
        'newOrMidspanPoles' : data[5].value.length === 0? 0 : data[5].value,
        'totalRelocatedPoles' : data[6].value.length === 0? 0 : data[6].value,
        'totalPolesNeedingReplaced' : data[7].value.length === 0? 0 : data[7].value,
        'newAnchor': data[8].value.length === 0? 0 : data[8].value,
        'otherWorkOnPole': data[9].value.length === 0? 0 : data[9].value,
        'poleReplacementPercentage': data[10].value.length === 0? 0 : parseFloat(data[10].value)
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



