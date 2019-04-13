import { base } from "../../common/config";
import axios from 'axios'

export const GetClientByPage = function (pageParam) {
    return axios({
        url: `${base}/api/IdentityServer/Client/GetClientByPage`,
        method: 'POST',
        data: pageParam
    })
}



export const GetOneForEdit = function (Id) {
    Id = Id || '';
    return axios({
        url: `${base}/api/IdentityServer/Client/GetClient?Id=${Id}`,
        method: 'GET'
    })
}

export const AddClient = function (param) {
    return axios({
        url: `${base}/api/IdentityServer/Client/AddClient`,
        method: 'POST',
        data: param
    })
}


export const UpdateClientName = function (Id, param) {
    return axios({
        url: `${base}/api/IdentityServer/Client/UpdateClientName?Id=${Id}`,
        method: 'POST',
        data: param
    })
}

export const UpdateClientBasic = function (Id, param) {
    return axios({
        url: `${base}/api/IdentityServer/Client/UpdateClientBasic?Id=${Id}`,
        method: 'POST',
        data: param
    })
}
export const UpdateClientAuthorization = function (Id, param) {
    return axios({
        url: `${base}/api/IdentityServer/Client/UpdateClientAuthorization?Id=${Id}`,
        method: 'POST',
        data: param
    })
}
export const UpdateClientToken = function (Id, param) {
    return axios({
        url: `${base}/api/IdentityServer/Client/UpdateClientToken?Id=${Id}`,
        method: 'POST',
        data: param
    })
}
export const UpdateClientConsent = function (Id, param) {
    return axios({
        url: `${base}/api/IdentityServer/Client/UpdateClientConsent?Id=${Id}`,
        method: 'POST',
        data: param
    })
}
export const UpdateClientDeviceFlow = function (Id, param) {
    return axios({
        url: `${base}/api/IdentityServer/Client/UpdateClientDeviceFlow?Id=${Id}`,
        method: 'POST',
        data: param
    })
}

export const DeleteClient = function (Id) {
    return axios({
        url: `${base}/api/IdentityServer/Client/DeleteClient?Id=${Id}`,
        method: 'POST'
    })
}


export const GetClients = function () {
    return axios({
        url: `${base}/api/IdentityServer/Client/GetClients`,
        method: 'GET'
    })
}