
const AccountURL = `/api/account`
async function postAccountStudent(accountData) {
    let result = await fetch(`${AccountURL}/AddingAccountStudent`, {
        headers: {
            "Content-Type": "application/json"
        },
        method: 'POST',
        body: JSON.stringify(accountData),
    });
    result = await result.json();
}
async function CheckingLogin(accountData) {
    let result = await fetch(`${AccountURL}/CheckingLogin`, {
        headers: {
            "Content-Type": "application/json"
        },
        method: 'POST',
        body: JSON.stringify(accountData),
    });
    return result
}
async function getAccountByID(AccountID) {
    let result = await fetch(`${AccountURL}/GetByID?id=${AccountID}`, {
        headers: {
            "Content-Type": "application/json"
        },
        method: 'GET',
    });
    return result.json();
}

