import { base } from "../../common/config";
import axios from 'axios'

export const GetIdentityResourceByPage = function (pageParam) {
    return axios({
        url: `${base}/api/IdentityServer/IdentityResource/GetIdentityResourceByPage`,
        method: 'POST',
        data: pageParam
    })
}

export const GetOne = function (Id) {
    return axios({
        url: `${base}/api/IdentityServer/IdentityResource/GetOne?Id=${Id}`,
        method: 'GET'
    })
}

export const GetOneForEdit = function (Id) {
    return axios({
        url: `${base}/api/IdentityServer/IdentityResource/GetOneForEdit?Id=${Id}`,
        method: 'GET'
    })
}

export const CreateIdentityResource = function (param) {
    return axios({
        url: `${base}/api/IdentityServer/IdentityResource/Put`,
        method: 'POST',
        data: param
    })
}

export const UpdateIdentityResource = function (Id, param) {
    return axios({
        url: `${base}/api/IdentityServer/IdentityResource/Post?Id=${Id}`,
        method: 'POST',
        data: param
    })
}

export const DeleteIdentityResource = function (Id) {
    return axios({
        url: `${base}/api/IdentityServer/IdentityResource/Delete?Id=${Id}`,
        method: 'POST'
    })
}
