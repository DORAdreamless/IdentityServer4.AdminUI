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
    Id=Id||'';
    return axios({
        url: `${base}/api/IdentityServer/Client/GetClient?Id=${Id}`,
        method: 'GET'
    })
}

export const CreateClient = function (param) {
    return axios({
        url: `${base}/api/IdentityServer/Client/Put`,
        method: 'POST',
        data: param
    })
}


export const UpdateNameClient = function (Id, param) {
    return axios({
        url: `${base}/api/IdentityServer/Client/Name?Id=${Id}`,
        method: 'POST',
        data: param
    })
}

export const UpdateBasicClient = function (Id, param) {
    return axios({
        url: `${base}/api/IdentityServer/Client/Basic?Id=${Id}`,
        method: 'POST',
        data: param
    })
}
export const UpdateAuthoriztionClient = function (Id, param) {
    return axios({
        url: `${base}/api/IdentityServer/Client/Authoriztion?Id=${Id}`,
        method: 'POST',
        data: param
    })
}
export const UpdateTokenClient = function (Id, param) {
    return axios({
        url: `${base}/api/IdentityServer/Client/Token?Id=${Id}`,
        method: 'POST',
        data: param
    })
}
export const UpdateConsentClient = function (Id, param) {
    return axios({
        url: `${base}/api/IdentityServer/Client/Consent?Id=${Id}`,
        method: 'POST',
        data: param
    })
}
export const UpdateDeviceFlowClient = function (Id, param) {
    return axios({
        url: `${base}/api/IdentityServer/Client/DeviceFlow?Id=${Id}`,
        method: 'POST',
        data: param
    })
}

export const DeleteClient = function (Id) {
    return axios({
        url: `${base}/api/IdentityServer/Client/Delete?Id=${Id}`,
        method: 'POST'
    })
}


export const GetClients = function () {
    return axios({
        url: `${base}/api/IdentityServer/Client/GetClients`,
        method: 'GET'
    })
}