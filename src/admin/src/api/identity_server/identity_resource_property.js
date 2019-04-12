import { base } from "../../common/config";
import axios from 'axios'

export const GetIdentityProperties = function (IdentityResourceId) {
    return axios({
        url: `${base}/api/IdentityServer/IdentityProperty/GetIdentityProperties?IdentityResourceId=${IdentityResourceId}`,
        method: 'GET'
    })
}



export const GetOneForEdit = function (Id) {
    return axios({
        url: `${base}/api/IdentityServer/IdentityProperty/GetIdentityProperty?Id=${Id}`,
        method: 'GET'
    })
}

export const CreateIdentityProperty = function (param) {
    return axios({
        url: `${base}/api/IdentityServer/IdentityProperty/AddIdentityProperty`,
        method: 'POST',
        data: param
    })
}

export const UpdateIdentityProperty = function (Id, param) {
    return axios({
        url: `${base}/api/IdentityServer/IdentityProperty/UpdateIdentityProperty?Id=${Id}`,
        method: 'POST',
        data: param
    })
}

export const DeleteIdentityProperty = function (Id) {
    return axios({
        url: `${base}/api/IdentityServer/IdentityProperty/DeleteIdentityProperty?Id=${Id}`,
        method: 'POST'
    })
}
