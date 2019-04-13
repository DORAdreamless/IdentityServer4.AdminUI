import { base } from "../../common/config";
import axios from 'axios'

export const GetClientSecrets = function (clientId) {
    return axios({
        url: `${base}/api/IdentityServer/Client/GetClientSecrets?clientId=${clientId}`,
        method: 'GET'
    })
}



export const AddClientSecret = function (param) {
    return axios({
        url: `${base}/api/IdentityServer/Client/AddClientSecret`,
        method: 'POST',
        data: param
    })
}



export const DeleteClientSecret = function (Id) {
    return axios({
        url: `${base}/api/IdentityServer/ClientSecret/DeleteClientSecret?Id=${Id}`,
        method: 'POST'
    })
}