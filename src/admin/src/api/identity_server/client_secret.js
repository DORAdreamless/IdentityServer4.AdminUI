import { base } from "../../common/config";
import axios from 'axios'

export const GetClientSecrets = function (clientId) {
    return axios({
        url: `${base}/api/IdentityServer/ClientSecret/GetClientSecrets?clientId=${clientId}`,
        method: 'GET'
    })
}



export const CreateClientSecret = function (param) {
    return axios({
        url: `${base}/api/IdentityServer/ClientSecret/Put`,
        method: 'POST',
        data: param
    })
}



export const DeleteClientSecret = function (Id) {
    return axios({
        url: `${base}/api/IdentityServer/ClientSecret/Delete?Id=${Id}`,
        method: 'POST'
    })
}