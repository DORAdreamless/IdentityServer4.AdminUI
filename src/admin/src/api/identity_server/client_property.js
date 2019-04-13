import { base } from "../../common/config";
import axios from 'axios'


export const GetClientProperties = function (clientId) {
    return axios({
        url: `${base}/api/IdentityServer/Client/GetClientProperties?clientId=${clientId}`,
        method: 'GET'
    })
}

export const CreateClientProperty = function (param) {
    return axios({
        url: `${base}/api/IdentityServer/ClientProperty/Put`,
        method: 'POST',
        data: param
    })
}


export const DeleteClientProperty = function (Id) {
    return axios({
        url: `${base}/api/IdentityServer/ClientProperty/Delete?Id=${Id}`,
        method: 'POST'
    })
}
