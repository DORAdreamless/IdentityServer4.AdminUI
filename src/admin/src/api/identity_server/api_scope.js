import { base } from "../../common/config";
import axios from 'axios'

export const GetApiScopes = function (ApiResourceId) {
    return axios({
        url: `${base}/api/IdentityServer/ApiScope/GetApiScopes?ApiResourceId=${ApiResourceId}`,
        method: 'GET'
    })
}



export const GetOneForEdit = function (Id) {
    Id=Id||'';
    return axios({
        url: `${base}/api/IdentityServer/ApiScope/GetApiScope?Id=${Id}`,
        method: 'GET'
    })
}

export const CreateApiScope = function (param) {
    return axios({
        url: `${base}/api/IdentityServer/ApiScope/AddApiScope`,
        method: 'POST',
        data: param
    })
}

export const UpdateApiScope = function (Id, param) {
    return axios({
        url: `${base}/api/IdentityServer/ApiScope/UpdateApiScope?Id=${Id}`,
        method: 'POST',
        data: param
    })
}

export const DeleteApiScope = function (Id) {
    return axios({
        url: `${base}/api/IdentityServer/ApiScope/DeleteApiScope?Id=${Id}`,
        method: 'POST'
    })
}
