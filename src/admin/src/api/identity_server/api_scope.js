import { base } from "../../common/config";
import axios from 'axios'

export const GetApiScopes = function (ApiResourceId) {
    return axios({
        url: `${base}/api/IdentityServer/ApiScope/GetApiScopes?ApiResourceId=${ApiResourceId}`,
        method: 'GET'
    })
}

export const GetOne = function (Id) {
    return axios({
        url: `${base}/api/IdentityServer/ApiScope/GetOne?Id=${Id}`,
        method: 'GET'
    })
}

export const GetOneForEdit = function (Id) {
    return axios({
        url: `${base}/api/IdentityServer/ApiScope/GetOneForEdit?Id=${Id}`,
        method: 'GET'
    })
}

export const CreateApiScope = function (param) {
    return axios({
        url: `${base}/api/IdentityServer/ApiScope/Put`,
        method: 'POST',
        data: param
    })
}

export const UpdateApiScope = function (Id, param) {
    return axios({
        url: `${base}/api/IdentityServer/ApiScope/Post?Id=${Id}`,
        method: 'POST',
        data: param
    })
}

export const DeleteApiScope = function (Id) {
    return axios({
        url: `${base}/api/IdentityServer/ApiScope/Delete?Id=${Id}`,
        method: 'POST'
    })
}
