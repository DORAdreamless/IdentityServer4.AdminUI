import { base } from "../../common/config";
import axios from 'axios'

export const GetApiSecrets = function (ApiResourceId) {
    return axios({
        url: `${base}/api/IdentityServer/ApiSecret/GetApiSecrets?ApiResourceId=${ApiResourceId}`,
        method: 'GET'
    })
}


export const GetOneForEdit = function (Id) {
    Id = Id || '';
    return axios({
        url: `${base}/api/IdentityServer/ApiSecret/GetApiSecret?Id=${Id}`,
        method: 'GET'
    })
}

export const AddApiSecret = function (param) {
    return axios({
        url: `${base}/api/IdentityServer/ApiSecret/AddApiSecret`,
        method: 'POST',
        data: param
    })
}

export const UpdateApiSecret = function (Id, param) {
    return axios({
        url: `${base}/api/IdentityServer/ApiSecret/UpdateApiSecret?Id=${Id}`,
        method: 'POST',
        data: param
    })
}

export const DeleteApiSecret = function (Id) {
    return axios({
        url: `${base}/api/IdentityServer/ApiSecret/DeleteApiSecret?Id=${Id}`,
        method: 'POST'
    })
}
