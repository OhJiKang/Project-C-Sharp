let baseURL = "/api"
const url = `${baseURL}/mistake`

async function putMistake(MistakeData, id) {
    let result = await fetch(`${url}/PutMistake?id=${id}`, {
        headers: {
            "Content-Type": "application/json"
        },
        method: 'PUT',
        body: JSON.stringify(PostData),
    });
    result = await result.json();
}
async function postMistake(MistakeData) {
    let result = await fetch(`${url}/PostMistake`, {
        headers: {
            "Content-Type": "application/json"
        },
        method: 'POST',
        body: JSON.stringify(PostData),
    });
    result = await result.json();
}
async function hideMistake(id) {
    let result = await fetch(`${url}/PostMistake?id=${id}`, {
        headers: {
            "Content-Type": "application/json"
        },
        method: 'PUT',
    });
    result = await result.json();
}