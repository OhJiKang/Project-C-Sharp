let baseURL = "/api"
const url = `${baseURL}/fee`

function putFee(FeeData, id) {
    let result = await fetch(`${url}/putCategory?id=${id}`, {
        headers: {
            "Content-Type": "application/json"
        },
        method: 'PUT',
        body: JSON.stringify(FeeData),
    });
    result = await result.json();
}
function addingFee(FeeData) {
    let result = await fetch(`${url}/AddingFee`, {
        headers: {
            "Content-Type": "application/json"
        },
        method: 'POST',
        body: JSON.stringify(FeeData),
    });
    result = await result.json();
}