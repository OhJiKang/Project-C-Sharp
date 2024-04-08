let baseURL = "/api"
const url = `${baseURL}/account`
function postAccountStudent(accountData) {
    let result = await fetch(`${url}/AddingAccountStudent`, {
        headers: {
            "Content-Type": "application/json"
        },
        method: 'POST',
        body: JSON.stringify(accountData),
    });
    result = await result.json();
}