let baseURL = "/api"
const url = `${baseURL}/log`

async function putLog(FeeData, id) {
    let result = await fetch(`${url}/putLog?id=${id}`, {
        headers: {
            "Content-Type": "application/json"
        },
        method: 'PUT',
        body: JSON.stringify(FeeData),
    });
    result = await result.json();
}
async function addingFee(FeeData) {
    let result = await fetch(`${url}/AddingFee`, {
        headers: {
            "Content-Type": "application/json"
        },
        method: 'POST',
        body: JSON.stringify(FeeData),
    });
    result = await result.json();
}