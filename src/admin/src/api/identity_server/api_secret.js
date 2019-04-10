import { base } from "../../common/config";
import axios from 'axios'

export const GetApiSecrets = function (ApiResourceId) {
    return axios({
        url: `${base}/api/IdentityServer/ApiSecret/GetApiSecrets?ApiResourceId=${ApiResourceId}`,
        method: 'GET'
    })
}

export const GetOne = function (Id) {
    return axios({
        url: `${base}/api/IdentityServer/ApiSecret/GetOne?Id=${Id}`,
        method: 'GET'
    })
}

export const GetOneForEdit = function (Id) {
    return axios({
        url: `${base}/api/IdentityServer/ApiSecret/GetOneForEdit?Id=${Id}`,
        method: 'GET'
    })
}

export const CreateApiSecret = function (param) {
    return axios({
        url: `${base}/api/IdentityServer/ApiSecret/Put`,
        method: 'POST',
        data: param
    })
}

export const UpdateApiSecret = function (Id, param) {
    return axios({
        url: `${base}/api/IdentityServer/ApiSecret/Post?Id=${Id}`,
        method: 'POST',
        data: param
    })
}

export const DeleteApiSecret = function (Id) {
    return axios({
        url: `${base}/api/IdentityServer/ApiSecret/Delete?Id=${Id}`,
        method: 'POST'
    })
}
