import { BASE_URL } from "../../../../ApiConstant";
export const GET_EXLINK_SUCCESS = "GET_EXLINK_SUCCESS";
export const UPDATE_EXLINK_SUCCESS = "UPDATE_EXLINK_SUCCESS";
export const CREATE_EXLINK_SUCCESS = "CREATE_EXLINK_SUCCESS";


export function getExLinkApi(id) {
    return (dispatch) => {
        return new Promise((resolve, reject) => {
            fetch(
                `${BASE_URL}/api/executionlinks/GetExLinkInfo/${id}`
            )
                .then((res) => {
                    const data = res.json().then((res) => {
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

export function updateExLinkApi(id, data, dropData, fiberCount, apiData) {
    console.log('res',JSON.stringify({
        'primaryKey': "",
        'nickname': "",
        'engineeringYear': data[0].value,
        'executionYear': data[1].value,
        'technologyId': dropData[2]?.value ? dropData[2].value :null,
        'regionId': dropData[3]?.value ? dropData[3].value : null,
        'barnId': dropData[4]?.value ? dropData[4].value : null,
        'workOrder': data[5].value,
        'projectId': data[6].value,
        'comments': data[8].value,
        'itn': data[9].value,
        'projectStatusId': dropData[10]?.value ? dropData[10]?.value : null,
        'description': "",
        'scopeComments': data[11].value,
        'fiberCount': fiberCount

    }))
    return new Promise((resolve, reject) => {

        fetch(`${BASE_URL}/api/executionlinks/UpdateExLinkInfo/${id}`,
            {
                method: 'PUT',
                body: JSON.stringify({
                    'primaryKey': "",
                    'nickname': "",
                    'engineeringYear': data[0].value,
                    'executionYear': data[1].value,
                    'technologyId': dropData[2]?.value ? dropData[2].value :null,
                    'regionId': dropData[3]?.value ? dropData[3].value : null,
                    'barnId': dropData[4]?.value ? dropData[4].value : null,
                    'workOrder': data[5].value,
                    'projectId': data[6].value,
                    'comments': data[8].value,
                    'itn': data[9].value,
                    'projectStatusId': dropData[10]?.value ? dropData[10]?.value : null,
                    'description': "",
                    'scopeComments': data[11].value,
                    'fiberCount': fiberCount

                }),
                headers: {
                    'Content-Type': 'application/json; charset=utf-8'
                }
            }
        ).then((res) => {
            const data = res.json().then(res => {
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


export function createExLinkApi(data, dropData, fiberCount, pdID) {
    return new Promise((resolve, reject) => {
        fetch(`${BASE_URL}/api/executionlinks/CreateExLinkInfo`,
            {
                method: 'POST',
                body: JSON.stringify({
                    'primaryKey': "",
                    'nickname': "",
                    'engineeringYear': data[0].value,
                    'executionYear': data[1].value,
                    'technologyId': dropData[2].value ? dropData[2].value : null,
                    'regionId': dropData[3].value ? dropData[3].value : null,
                    'barnId': dropData[4].value ? dropData[4].value : null,
                    'workOrder': data[5].value,
                    'projectID': data[6].value,
                    'comments': data[8].value,
                    'itn': data[9].value,
                    'projectStatusId': dropData[10].value ? dropData[10].value : null,
                    'description': "",
                    'scopeComments': data[11].value,
                    'fiberCount': fiberCount,
                    'pdid': pdID
                }),
                headers: {
                    'Content-Type': 'application/json; charset=utf-8'
                }
            }
        ).then((response) => {
            response.json().then(res => {
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
