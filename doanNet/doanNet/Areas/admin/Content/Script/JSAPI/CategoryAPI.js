﻿let baseURL = "/api"
const url = `${baseURL}/category`

async function putCategory(CategoryData, id) {
    let result = await fetch(`${url}/putCategory?id=${id}`, {
        headers: {
            "Content-Type": "application/json"
        },
        method: 'PUT',
        body: JSON.stringify(CategoryData),
    });
    result = await result.json();
}
async function postCategory(CategoryData) {
    let result = await fetch(`${url}/postCategory`, {
        headers: {
            "Content-Type": "application/json"
        },
        method: 'POST',
        body: JSON.stringify(CategoryData),
    });
    result = await result.json();
}