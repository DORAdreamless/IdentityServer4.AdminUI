import { base } from "../../common/config";
import axios from 'axios'

export const GetApiProperties= function (ApiResourceId) {
    return axios({
        url: `${base}/api/IdentityServer/ApiProperty/GetApiProperties?ApiResourceId=${ApiResourceId}`,
        method: 'GET'
    })
}

export const GetOne = function (Id) {
    return axios({
        url: `${base}/api/IdentityServer/ApiProperty/GetOne?Id=${Id}`,
        method: 'GET'
    })
}

export const GetOneForEdit = function (Id) {
    return axios({
        url: `${base}/api/IdentityServer/ApiProperty/GetOneForEdit?Id=${Id}`,
        method: 'GET'
    })
}

export const CreateApiProperty = function (param) {
    return axios({
        url: `${base}/api/IdentityServer/ApiProperty/Put`,
        method: 'POST',
        data: param
    })
}

export const UpdateApiProperty = function (Id, param) {
    return axios({
        url: `${base}/api/IdentityServer/ApiProperty/Post?Id=${Id}`,
        method: 'POST',
        data: param
    })
}

export const DeleteApiProperty = function (Id) {
    return axios({
        url: `${base}/api/IdentityServer/ApiProperty/Delete?Id=${Id}`,
        method: 'POST'
    })
}
