﻿let baseURL = "/api"
const url = `${baseURL}/contract`

async function putContract(ContractData, id) {
    let result = await fetch(`${url}/PutContract?id=${id}`, {
        headers: {
            "Content-Type": "application/json"
        },
        method: 'PUT',
        body: JSON.stringify(ContractData),
    });
    result = await result.json();
}
async function postContract(ContractData) {
    let result = await fetch(`${url}/AddingContract`, {
        headers: {
            "Content-Type": "application/json"
        },
        method: 'POST',
        body: JSON.stringify(ContractData),
    });
    result = await result.json();
}
async function getContractByMSSV(RoomID) {
    let result = await fetch(`${url}/GetFeeByRoomID?RoomID=${RoomID}`, {
        headers: {
            "Content-Type": "application/json"
        },
        method: 'GET',
    });
    result = await result.json();
}