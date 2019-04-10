import { base } from "../../common/config";
import axios from 'axios'

export const GetIdentityProperties = function (IdentityResourceId) {
    return axios({
        url: `${base}/api/IdentityServer/IdentityProperty/GetIdentityProperties?IdentityResourceId=${IdentityResourceId}`,
        method: 'GET'
    })
}

export const GetOne = function (Id) {
    return axios({
        url: `${base}/api/IdentityServer/IdentityProperty/GetOne?Id=${Id}`,
        method: 'GET'
    })
}

export const GetOneForEdit = function (Id) {
    return axios({
        url: `${base}/api/IdentityServer/IdentityProperty/GetOneForEdit?Id=${Id}`,
        method: 'GET'
    })
}

export const CreateIdentityProperty = function (param) {
    return axios({
        url: `${base}/api/IdentityServer/IdentityProperty/Put`,
        method: 'POST',
        data: param
    })
}

export const UpdateIdentityProperty = function (Id, param) {
    return axios({
        url: `${base}/api/IdentityServer/IdentityProperty/Post?Id=${Id}`,
        method: 'POST',
        data: param
    })
}

export const DeleteIdentityProperty = function (Id) {
    return axios({
        url: `${base}/api/IdentityServer/IdentityProperty/Delete?Id=${Id}`,
        method: 'POST'
    })
}
