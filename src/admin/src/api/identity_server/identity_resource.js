import { base } from "../../common/config";
import axios from 'axios'

export const GetIdentityResourceByPage = function (pageParam) {
    return axios({
        url: `${base}/api/IdentityServer/IdentityResource/GetIdentityResourceByPage`,
        method: 'POST',
        data: pageParam
    })
}


export const GetIdentityResource = function (Id="") {
    return axios({
        url: `${base}/api/IdentityServer/IdentityResource/GetIdentityResource?Id=${Id}`,
        method: 'GET'
    })
}

export const AddIdentityResource = function (param) {
    return axios({
        url: `${base}/api/IdentityServer/IdentityResource/AddIdentityResource`,
        method: 'POST',
        data: param
    })
}

export const UpdateIdentityResource = function (Id, param) {
    return axios({
        url: `${base}/api/IdentityServer/IdentityResource/UpdateIdentityResource?Id=${Id}`,
        method: 'POST',
        data: param
    })
}

export const DeleteIdentityResource = function (Id) {
    return axios({
        url: `${base}/api/IdentityServer/IdentityResource/DeleteIdentityResource?Id=${Id}`,
        method: 'POST'
    })
}
