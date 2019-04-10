import { base } from "../../common/config";
import axios from 'axios'

export const GetApiResourceByPage = function (pageParam) {
    return axios({
        url: `${base}/api/IdentityServer/ApiResource/GetApiResourceByPage`,
        method: 'POST',
        data: pageParam
    })
}

export const GetOne = function (Id) {
    return axios({
        url: `${base}/api/IdentityServer/ApiResource/GetOne?Id=${Id}`,
        method: 'GET'
    })
}

export const GetOneForEdit = function (Id) {
    return axios({
        url: `${base}/api/IdentityServer/ApiResource/GetOneForEdit?Id=${Id}`,
        method: 'GET'
    })
}

export const CreateApiResource = function (param) {
    return axios({
        url: `${base}/api/IdentityServer/ApiResource/Put`,
        method: 'POST',
        data: param
    })
}

export const UpdateApiResource = function (Id, param) {
    return axios({
        url: `${base}/api/IdentityServer/ApiResource/Post?Id=${Id}`,
        method: 'POST',
        data: param
    })
}

export const DeleteApiResource = function (Id) {
    return axios({
        url: `${base}/api/IdentityServer/ApiResource/Delete?Id=${Id}`,
        method: 'POST'
    })
}
