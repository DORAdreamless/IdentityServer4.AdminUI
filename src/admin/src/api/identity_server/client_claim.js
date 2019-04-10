import { base } from "../../common/config";
import axios from 'axios'

export const GetClientClaims = function (clientId) {
    return axios({
        url: `${base}/api/IdentityServer/ClientClaim/GetClientClaims?clientId=${clientId}`,
        method: 'GET'
    })
}

// export const GetOne = function (Id) {
//     return axios({
//         url: `${base}/api/IdentityServer/ClientClaim/GetOne?Id=${Id}`,
//         method: 'GET'
//     })
// }

// export const GetOneForEdit = function (Id) {
//     return axios({
//         url: `${base}/api/IdentityServer/ClientClaim/GetOneForEdit?Id=${Id}`,
//         method: 'GET'
//     })
// }

export const CreateClientClaim = function (param) {
    return axios({
        url: `${base}/api/IdentityServer/ClientClaim/Put`,
        method: 'POST',
        data: param
    })
}

// export const UpdateClientClaim = function (Id, param) {
//     return axios({
//         url: `${base}/api/IdentityServer/ClientClaim/Post?Id=${Id}`,
//         method: 'POST',
//         data: param
//     })
// }

export const DeleteClientClaim = function (Id) {
    return axios({
        url: `${base}/api/IdentityServer/ClientClaim/Delete?Id=${Id}`,
        method: 'POST'
    })
}
