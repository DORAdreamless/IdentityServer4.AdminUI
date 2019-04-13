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
    Id=Id||'';
    return axios({
        url: `${base}/api/IdentityServer/ApiProperty/GetApiProperty?Id=${Id}`,
        method: 'GET'
    })
}

export const CreateApiProperty = function (param) {
    return axios({
        url: `${base}/api/IdentityServer/ApiProperty/AddApiProperty`,
        method: 'POST',
        data: param
    })
}

export const UpdateApiProperty = function (Id, param) {
    return axios({
        url: `${base}/api/IdentityServer/ApiProperty/UpdateApiProperty?Id=${Id}`,
        method: 'POST',
        data: param
    })
}

export const DeleteApiProperty = function (Id) {
    return axios({
        url: `${base}/api/IdentityServer/ApiProperty/DeleteApiProperty?Id=${Id}`,
        method: 'POST'
    })
}
