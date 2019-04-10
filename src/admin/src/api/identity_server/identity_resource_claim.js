import { base } from "../../common/config";
import axios from 'axios'

export const GetIdentityClaims = function (IdentityResourceId) {
    return axios({
        url: `${base}/api/IdentityServer/IdentityClaim/GetIdentityClaims?IdentityResourceId=${IdentityResourceId}`,
        method: 'GET'
    })
}

export const GetOne = function (Id) {
    return axios({
        url: `${base}/api/IdentityServer/IdentityClaim/GetOne?Id=${Id}`,
        method: 'GET'
    })
}

export const GetOneForEdit = function (Id) {
    return axios({
        url: `${base}/api/IdentityServer/IdentityClaim/GetOneForEdit?Id=${Id}`,
        method: 'GET'
    })
}

export const CreateIdentityClaim = function (param) {
    return axios({
        url: `${base}/api/IdentityServer/IdentityClaim/Put`,
        method: 'POST',
        data: param
    })
}

export const UpdateIdentityClaim = function (Id, param) {
    return axios({
        url: `${base}/api/IdentityServer/IdentityClaim/Post?Id=${Id}`,
        method: 'POST',
        data: param
    })
}

export const DeleteIdentityClaim = function (Id) {
    return axios({
        url: `${base}/api/IdentityServer/IdentityClaim/Delete?Id=${Id}`,
        method: 'POST'
    })
}
