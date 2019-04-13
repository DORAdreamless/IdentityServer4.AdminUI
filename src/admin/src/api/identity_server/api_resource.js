import { base } from "../../common/config";
import axios from 'axios'

export const GetApiResourceByPage = function (pageParam) {
    return axios({
        url: `${base}/api/IdentityServer/ApiResource/GetApiResourceByPage`,
        method: 'POST',
        data: pageParam
    })
}



export const GetApiResource = function (Id) {
    Id=Id||"";
    return axios({
        url: `${base}/api/IdentityServer/ApiResource/GetApiResource?Id=${Id}`,
        method: 'GET'
    })
}

export const AddApiResource = function (param) {
    return axios({
        url: `${base}/api/IdentityServer/ApiResource/AddApiResource`,
        method: 'POST',
        data: param
    })
}

export const UpdateApiResource = function (Id, param) {
    return axios({
        url: `${base}/api/IdentityServer/ApiResource/UpdateApiResource?Id=${Id}`,
        method: 'POST',
        data: param
    })
}

export const DeleteApiResource = function (Id) {
    return axios({
        url: `${base}/api/IdentityServer/ApiResource/DeleteApiResource?Id=${Id}`,
        method: 'POST'
    })
}
